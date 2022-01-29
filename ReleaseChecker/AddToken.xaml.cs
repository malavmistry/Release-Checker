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
            if(string.IsNullOrEmpty(this.TokenName.ToString()) || string.IsNullOrEmpty(this.TokenValue.ToString())) return;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings.Add(this.TokenName.ToString(), this.TokenValue.ToString());
            config.Save(ConfigurationSaveMode.Modified);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
