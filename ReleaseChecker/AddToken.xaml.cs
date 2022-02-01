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
    }
}
