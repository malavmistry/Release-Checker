using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Newtonsoft.Json;
using ReleaseChecker.Models;

namespace ReleaseChecker
{
    public partial class ReleaseCheckerForm : Form
    {
        private static string authString;
        private static string apiUrl = "https://api.github.com";
        public ReleaseCheckerForm()
        {
            InitializeComponent();
            LoadSSHKeys();
            AppendMessageText("Start by providing GIT Token..");
        }

        private void compareBtn_Click(object sender, EventArgs e)
        {
            if (!Validate())
            {
                EnableError("Error: Please provide all the fields!");
                return;
            }
            this.compareBtn.Enabled = false;
            if (this.MessageBox.Rtf.Length > 0) this.MessageBox.Rtf = "";
            AppendMessageText("Starting...");
            Compare();

            this.compareBtn.Enabled = true;
        }
        private void Compare()
        {
            authString = GetAuthTokenFromName();
            if (!Authenticate()) return;

            GetGitDiff();
        }
        public new bool Validate() {
            if (this.repoList.SelectedIndex <= 0) return false;
            if (this.baseBranchList.SelectedIndex <= 0) return false;
            if (this.compareBranchList.SelectedIndex <= 0) return false;
            if (this.SshList.SelectedIndex <= 0) return false;

            return true;
        }
        public bool Authenticate()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "ReleaseChecker");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authString);

                var request = new HttpRequestMessage(HttpMethod.Get, $"{apiUrl}/users/mmistrymoso");
                var response = Task.Factory.StartNew(async () => await client.SendAsync(request)).Result.Result;
                if (!response.IsSuccessStatusCode)
                {
                    EnableError("Error: Unable to access/authenticate Git account. Please verify the token and try again");
                    return false;
                }
            }

            AppendMessageText("Git Account Authenticated...");
            return true;
        }

        public void GetGitDiff() {
            var repo = GetRepoByName(this.repoList.Text);
            if (repo == null) return;
            var branches = GetBranches(repo.Url);
            if (branches == null || branches.Count == 0) return;
            var baseBranch = branches.FirstOrDefault(x => x.Name.ToLower() == this.baseBranchList.Text.ToLower());
            if (baseBranch == null)
            {
                EnableError($"Error: Unable to access base branch - {this.baseBranchText.Text}.");
                return;
            }
            var compareBranch = branches.FirstOrDefault(x => x.Name.ToLower() == this.compareBranchList.Text.ToLower());
            if (compareBranch == null)
            {
                EnableError($"Error: Unable to access Compare branch - {this.compareBranchText.Text}.");
                return;
            }
            AppendMessageText("Successfully fetched the given branches..");
            CompareCommits(repo.Url,baseBranch.Name, compareBranch.Name);
        }

        public void CompareCommits(string repoUrl, string baseBranch, string compareBranch)
        {
            AppendMessageText("Starting compare process..");
            var compareInfo = GetCompareInfo(repoUrl, baseBranch, compareBranch);
            if (compareInfo == null) return;
            AppendMessageText("Compare info successfully retrived..");
            if (!compareInfo.Commits.Any()) {
                AppendMessageText("The two branches are identical!!");
                return;
            }
            AppendMessageText("Loading information..");
            var tabularData = GetTabularData(compareInfo, baseBranch, compareBranch);
            this.MessageBox.Text = "";
            this.MessageBox.Rtf =tabularData;
    }
        public string GetTabularData(CompareInfo data, string baseBranch, string compareBranch) {
            string resultMessage = string.Empty;
            if(data.Status.ToLower() == "diverged")
                resultMessage = $"{baseBranch} branch is ahead of {compareBranch} branch by {data.Ahead_by} commits and behind of {compareBranch} branch by {data.Behind_by} commits.";
            else resultMessage = $"{baseBranch} is {data.Status} of {compareBranch} by {data.Commits.Count()} commits.";
            StringBuilder str = new StringBuilder();
            str.Append(@"{\rtf1 ");
            str.Append(resultMessage);
            str.Append(@"\trowd");
            str.Append(@"\cellx2200 ");
            str.Append(@"\cellx3700 ");
            str.Append(@"\cellx8400 ");
            str.Append(@"\cellx9400 ");
            str.Append(@" Commit ID\intbl\cell ");
            str.Append(@" JIRA\intbl\cell ");
            str.Append(@" Message\intbl\cell ");
            str.Append(@" Release\intbl\cell ");
            str.Append(@"\row");
            for (int i = 0; i < data.Commits.Count(); i++) {
                str.Append(@"\trowd");
                str.Append(@"\cellx2200 ");
                str.Append(@"\cellx3700 ");
                str.Append(@"\cellx8400 ");
                str.Append(@"\cellx9400 ");
                str.Append(data.Commits[i].Sha + @"\intbl\cell ");
                str.Append(data.Commits[i].Message.Message.Substring(0,11) + @"\intbl\cell ");
                str.Append(data.Commits[i].Message.Message + @"\intbl\cell ");
                str.Append( @"3.17.71 \intbl\cell ");
                str.Append(@"\row");
            }
            str.Append(@"\pard");
            str.Append(@"}");
            return str.ToString();
        }
        public CompareInfo GetCompareInfo(string repoUrl, string baseBranch, string compareBranch)
        {
            CompareInfo branches = null;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "ReleaseChecker");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authString);

                var request = new HttpRequestMessage(HttpMethod.Get, $"{repoUrl}/compare/{baseBranch}...{compareBranch}");
                var response = Task.Factory.StartNew(async () => await client.SendAsync(request)).Result.Result;
                if (!response.IsSuccessStatusCode)
                {
                    EnableError($"Error: Unable to access Git branches. Please check if the provided token has necessary access.");
                    return branches;
                }
            var responseString = Task.Factory.StartNew(async () => await response.Content.ReadAsStringAsync()).Result;
            branches = JsonConvert.DeserializeObject<CompareInfo>(responseString.Result);
                        }
            return branches;
        }

        public List<BranchInfo> GetBranches(string repoUrl)
        {
            List<BranchInfo> branches = new List<BranchInfo>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "ReleaseChecker");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authString);

                var request = new HttpRequestMessage(HttpMethod.Get, $"{repoUrl}/branches?per_page=500");
                var response = Task.Factory.StartNew(async () => await client.SendAsync(request)).Result.Result;
                if (!response.IsSuccessStatusCode)
                {
                    EnableError($"Error: Unable to access Git branch.");
                    return branches;
                }
                var responseString = Task.Factory.StartNew(async () => await response.Content.ReadAsStringAsync()).Result;
                branches = JsonConvert.DeserializeObject<List<BranchInfo>>(responseString.Result);
            }
            return branches;
        }

        public RepoInfo GetRepoByName(string repoName) {
            var repo = GetAllRepos().FirstOrDefault(x => x.Name.ToLower() == repoName.ToLower());

            if (repo == null)
            {
                EnableError($"Error: Repository {repoName} not found. Please check the name");
                return null;
            }

            AppendMessageText($"Repo - {repo.Name} found!");
            return repo;
        }

        public List<RepoInfo> GetAllRepos()
        {
            List<RepoInfo> repos = new List<RepoInfo>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "ReleaseChecker");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authString);

                var request = new HttpRequestMessage(HttpMethod.Get, $"{apiUrl}/user/repos");
                var response = Task.Factory.StartNew(async () => await client.SendAsync(request)).Result.Result;
                if (!response.IsSuccessStatusCode)
                {
                    EnableError("Error: Unable to access Git branchesitory");
                    return repos;
                }
                var responseString = Task.Factory.StartNew(async () => await response.Content.ReadAsStringAsync()).Result;
                repos = JsonConvert.DeserializeObject<List<RepoInfo>>(responseString.Result);
            }
            return repos;
        }
        public void AppendMessageText(string text) {
            this.MessageBox.Text += Environment.NewLine + text;
            this.MessageBox.Show();

        }
        public void EnableError(string text)
        {
            AppendMessageText(text);

        }
        private void SshTextChanged(object sender, EventArgs e)
        {
            DisableSelection();
            if (this.SshList.Text.ToString() == "--Add New Token--")
            {
                var _addTokenWindow = new AddToken();
                _addTokenWindow.BringIntoView();
                Window popWindow = new Window();
                popWindow.Content = _addTokenWindow;
                popWindow.SizeToContent = SizeToContent.WidthAndHeight;
                popWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                popWindow.ShowDialog();
                DisableSelection();
                LoadSSHKeys();
            }
            else
            {
                authString = GetAuthTokenFromName();
                if (string.IsNullOrEmpty(authString) || !Authenticate()) return;
                fetchRepos();
            }
        }
        private string GetAuthTokenFromName()
        {
            var token = this.SshList.Text.ToString();
            if (this.SshList.SelectedIndex <= 0) return "";
            var keys = (NameValueCollection)ConfigurationManager.GetSection("TokenConfig");
            return keys[token];
        }
        private void LoadSSHKeys()
        {
            var keys = (NameValueCollection)ConfigurationManager.GetSection("TokenConfig");
            var sshList = new List<string>();
            sshList.Add("--Select One--");
            foreach (var key in keys) {
                sshList.Add(key.ToString());
            }

            sshList.Add("--Add New Token--");
            this.SshList.DataSource = sshList;
        }
        private void fetchRepos()
        {
            this.repoList.Enabled = true;
            var repos = GetAllRepos().Select(x => x.Name).ToList();
            repos.Insert(0, "--Select One--");
            this.repoList.DataSource = repos;
            if (repos.Count <= 1) EnableError("No repositories found for given token..");
            else AppendMessageText("Please select a repository..");
        }
        private void RepoSelected(object sender, EventArgs e)
        {
            DisableBranchSelection();
            if (this.repoList.SelectedIndex <= 0)  return;

            var repo = GetRepoByName(this.repoList.Text);

            this.baseBranchList.Enabled = true;
            this.compareBranchList.Enabled = true;
            var branches = GetBranches(repo.Url);
            if (branches == null || branches.Count == 0) return;
            var compareBranch = branches.Select(x => x.Name).ToList();
            var baseBranch = branches.Select(x => x.Name).ToList();
            baseBranch.Insert(0, "--Select One--");
            compareBranch.Insert(0, "--Select One--");
            this.baseBranchList.DataSource = baseBranch;
            this.compareBranchList.DataSource = compareBranch;
            AppendMessageText("Please select branches to compare..");
        }

        private void DisableSelection()
        {
            this.repoList.Enabled = false;
            this.repoList.DataSource = null;
            DisableBranchSelection();
        }
        private void DisableBranchSelection()
        {
            this.baseBranchList.Enabled = false;
            this.compareBranchList.Enabled = false;
            this.baseBranchList.DataSource = null;
            this.compareBranchList.DataSource = null;
        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
