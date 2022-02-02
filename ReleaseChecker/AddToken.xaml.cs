using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReleaseChecker
{
    /// <summary>
    /// Interaction logic for AddToken.xaml
    /// </summary>
    public partial class AddToken : UserControl
    {
        public AddToken()
        {
            InitializeComponent();
        }

        private void AddToken1_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TokenName.Text.ToString()) || string.IsNullOrEmpty(this.TokenValue.Text.ToString())) {
                this.Message.Content = "Please provide all the details.";
                return; 
            }
            SaveToken();
        }
        private void SaveToken()
        {
            XmlHelper.SaveXml(ConfigurationManager.AppSettings["TokenConfigPath"].ToString()
                                , "TokenConfig"
                                , new KeyValuePair<string, string>(this.TokenName.Text.ToString(), this.TokenValue.Text.ToString()));
            this.TokenName.Clear();
            this.TokenValue.Clear();
            this.Message.Content = "Successfully added the provided token.";
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton.Content.ToString() == "Delete")
                DisplayDeleteTokenContents();
            else DisplayAddTokenContents();
        }
        private void DisplayAddTokenContents()
        {
            this.AddToken1.Visibility = Visibility.Visible;
            this.DeleteToken.Visibility = Visibility.Hidden;
            this.TokenName.Visibility = Visibility.Visible;
            this.TokenNameList.Visibility = Visibility.Hidden;
            this.TokenValue.IsEnabled = true;
            this.Message.Content = "";
        }
        private void DisplayDeleteTokenContents()
        {
            this.AddToken1.Visibility = Visibility.Hidden;
            this.DeleteToken.Visibility = Visibility.Visible;
            this.TokenName.Visibility = Visibility.Hidden;
            this.TokenNameList.Visibility = Visibility.Visible;
            this.TokenValue.IsEnabled = false;
            this.Message.Content = "";

            var keys = XmlHelper.ReadXml(ConfigurationManager.AppSettings["TokenConfigPath"].ToString(), "TokenConfig");
            var sshList = new List<string>();
            sshList.Add("--Select One--");
            foreach (var key in keys)
            {
                sshList.Add(key["key"].ToString());
            }
            this.TokenNameList.ItemsSource = sshList;
            this.TokenNameList.SelectedIndex = 0;
        }

        private void DeleteToken_Click(object sender, RoutedEventArgs e)
        {
            if (this.TokenNameList.SelectedIndex <= 0)
            {
                this.Message.Content = "Please make a selection";
                return;
            }
            DeleteTokenRecord();
        }
        private void DeleteTokenRecord()
        {
            XmlHelper.DeleteXmlRecord(ConfigurationManager.AppSettings["TokenConfigPath"].ToString()
                                , "TokenConfig"
                                , this.TokenNameList.SelectedValue.ToString());
            DisplayDeleteTokenContents();
            this.Message.Content = "Successfully deleted the provided token.";
        }
    }
}
