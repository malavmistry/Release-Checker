using System.Drawing;
namespace ReleaseChecker
{
    partial class ReleaseCheckerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.repoName = new System.Windows.Forms.Label();
            this.repoSSH = new System.Windows.Forms.Label();
            this.baseBranch = new System.Windows.Forms.Label();
            this.compareBranch = new System.Windows.Forms.Label();
            this.repoNameText = new System.Windows.Forms.TextBox();
            this.repoSSHText = new System.Windows.Forms.TextBox();
            this.baseBranchText = new System.Windows.Forms.TextBox();
            this.compareBranchText = new System.Windows.Forms.TextBox();
            this.compareBtn = new System.Windows.Forms.Button();
            this.MessageBox = new System.Windows.Forms.RichTextBox();
            this.exitBtn = new System.Windows.Forms.Button();
            this.repoList = new System.Windows.Forms.ComboBox();
            this.baseBranchList = new System.Windows.Forms.ComboBox();
            this.compareBranchList = new System.Windows.Forms.ComboBox();
            this.SshList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // repoName
            // 
            this.repoName.AutoSize = true;
            this.repoName.ForeColor = System.Drawing.Color.White;
            this.repoName.Location = new System.Drawing.Point(291, 36);
            this.repoName.Name = "repoName";
            this.repoName.Size = new System.Drawing.Size(111, 18);
            this.repoName.TabIndex = 0;
            this.repoName.Text = "Repository Name:";
            // 
            // repoSSH
            // 
            this.repoSSH.AutoSize = true;
            this.repoSSH.ForeColor = System.Drawing.Color.White;
            this.repoSSH.Location = new System.Drawing.Point(16, 37);
            this.repoSSH.Name = "repoSSH";
            this.repoSSH.Size = new System.Drawing.Size(69, 18);
            this.repoSSH.TabIndex = 1;
            this.repoSSH.Text = "Git Token:";
            // 
            // baseBranch
            // 
            this.baseBranch.AutoSize = true;
            this.baseBranch.ForeColor = System.Drawing.Color.White;
            this.baseBranch.Location = new System.Drawing.Point(14, 83);
            this.baseBranch.Name = "baseBranch";
            this.baseBranch.Size = new System.Drawing.Size(81, 18);
            this.baseBranch.TabIndex = 2;
            this.baseBranch.Text = "Base Branch:";
            // 
            // compareBranch
            // 
            this.compareBranch.AutoSize = true;
            this.compareBranch.ForeColor = System.Drawing.Color.White;
            this.compareBranch.Location = new System.Drawing.Point(291, 84);
            this.compareBranch.Name = "compareBranch";
            this.compareBranch.Size = new System.Drawing.Size(106, 18);
            this.compareBranch.TabIndex = 3;
            this.compareBranch.Text = "Compare Branch:";
            // 
            // repoNameText
            // 
            this.repoNameText.AllowDrop = true;
            this.repoNameText.Location = new System.Drawing.Point(217, 267);
            this.repoNameText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.repoNameText.Multiline = true;
            this.repoNameText.Name = "repoNameText";
            this.repoNameText.Size = new System.Drawing.Size(151, 25);
            this.repoNameText.TabIndex = 5;
            // 
            // repoSSHText
            // 
            this.repoSSHText.Location = new System.Drawing.Point(217, 165);
            this.repoSSHText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.repoSSHText.Name = "repoSSHText";
            this.repoSSHText.Size = new System.Drawing.Size(151, 25);
            this.repoSSHText.TabIndex = 4;
            // 
            // baseBranchText
            // 
            this.baseBranchText.Location = new System.Drawing.Point(217, 280);
            this.baseBranchText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.baseBranchText.Name = "baseBranchText";
            this.baseBranchText.Size = new System.Drawing.Size(151, 25);
            this.baseBranchText.TabIndex = 6;
            // 
            // compareBranchText
            // 
            this.compareBranchText.Location = new System.Drawing.Point(217, 360);
            this.compareBranchText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.compareBranchText.Name = "compareBranchText";
            this.compareBranchText.Size = new System.Drawing.Size(151, 25);
            this.compareBranchText.TabIndex = 7;
            // 
            // compareBtn
            // 
            this.compareBtn.BackColor = System.Drawing.Color.White;
            this.compareBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.compareBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.compareBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.compareBtn.ForeColor = System.Drawing.Color.Black;
            this.compareBtn.Location = new System.Drawing.Point(591, 31);
            this.compareBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.compareBtn.Name = "compareBtn";
            this.compareBtn.Size = new System.Drawing.Size(98, 34);
            this.compareBtn.TabIndex = 8;
            this.compareBtn.Text = "Compare";
            this.compareBtn.UseVisualStyleBackColor = false;
            this.compareBtn.Click += new System.EventHandler(this.compareBtn_Click);
            // 
            // MessageBox
            // 
            this.MessageBox.Location = new System.Drawing.Point(12, 137);
            this.MessageBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.ReadOnly = true;
            this.MessageBox.Size = new System.Drawing.Size(678, 368);
            this.MessageBox.TabIndex = 10;
            this.MessageBox.Text = "Welcome!!";
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.White;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitBtn.Location = new System.Drawing.Point(591, 77);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(98, 30);
            this.exitBtn.TabIndex = 11;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // repoList
            // 
            this.repoList.AllowDrop = true;
            this.repoList.Enabled = false;
            this.repoList.FormattingEnabled = true;
            this.repoList.Location = new System.Drawing.Point(413, 34);
            this.repoList.Name = "repoList";
            this.repoList.Size = new System.Drawing.Size(151, 26);
            this.repoList.TabIndex = 13;
            this.repoList.SelectedValueChanged += new System.EventHandler(this.RepoSelected);
            // 
            // baseBranchList
            // 
            this.baseBranchList.AllowDrop = true;
            this.baseBranchList.Enabled = false;
            this.baseBranchList.FormattingEnabled = true;
            this.baseBranchList.Location = new System.Drawing.Point(104, 77);
            this.baseBranchList.Name = "baseBranchList";
            this.baseBranchList.Size = new System.Drawing.Size(151, 26);
            this.baseBranchList.TabIndex = 14;
            // 
            // compareBranchList
            // 
            this.compareBranchList.AllowDrop = true;
            this.compareBranchList.Enabled = false;
            this.compareBranchList.FormattingEnabled = true;
            this.compareBranchList.Location = new System.Drawing.Point(413, 82);
            this.compareBranchList.Name = "compareBranchList";
            this.compareBranchList.Size = new System.Drawing.Size(151, 26);
            this.compareBranchList.TabIndex = 15;
            // 
            // SshList
            // 
            this.SshList.AllowDrop = true;
            this.SshList.FormattingEnabled = true;
            this.SshList.Location = new System.Drawing.Point(104, 35);
            this.SshList.Name = "SshList";
            this.SshList.Size = new System.Drawing.Size(151, 26);
            this.SshList.TabIndex = 16;
            //this.SshList.SelectedValueChanged += new System.EventHandler(this.SshTextChanged);
            this.SshList.SelectedIndexChanged += new System.EventHandler(this.SshTextChanged);
            //this.SshList.SelectionChangeCommitted += new System.EventHandler(this.SshTextChanged);
            // 
            // ReleaseCheckerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(702, 517);
            this.ControlBox = false;
            this.Controls.Add(this.SshList);
            this.Controls.Add(this.compareBranchList);
            this.Controls.Add(this.baseBranchList);
            this.Controls.Add(this.repoList);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.compareBtn);
            this.Controls.Add(this.compareBranchText);
            this.Controls.Add(this.baseBranchText);
            this.Controls.Add(this.repoSSHText);
            this.Controls.Add(this.repoNameText);
            this.Controls.Add(this.compareBranch);
            this.Controls.Add(this.baseBranch);
            this.Controls.Add(this.repoSSH);
            this.Controls.Add(this.repoName);
            this.Font = new System.Drawing.Font("Sylfaen", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ReleaseCheckerForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Release Checker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label repoName;
        private System.Windows.Forms.Label repoSSH;
        private System.Windows.Forms.Label baseBranch;
        private System.Windows.Forms.Label compareBranch;
        private System.Windows.Forms.TextBox repoNameText;
        private System.Windows.Forms.TextBox repoSSHText;
        private System.Windows.Forms.TextBox baseBranchText;
        private System.Windows.Forms.TextBox compareBranchText;
        private System.Windows.Forms.Button compareBtn;
        private System.Windows.Forms.RichTextBox MessageBox;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.ComboBox repoList;
        private System.Windows.Forms.ComboBox baseBranchList;
        private System.Windows.Forms.ComboBox compareBranchList;
        private System.Windows.Forms.ComboBox SshList;
    }
}

