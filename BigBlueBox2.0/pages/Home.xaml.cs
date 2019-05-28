using System.Configuration;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

using BigBlueBox2._0.data;
namespace BigBlueBox2._0.pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();

            //************************************************************************
            // Set the Issues Quick Panel Buttons Content via DB 
            //************************************************************************
            ItemsNeedingAttention_Button.Content = Sqlite3_Interface.Instance.GetNumItemsNeedingAttention();
            GearNeedingAttention_Button.Content = Sqlite3_Interface.Instance.GetNumGearNeedingAttention();
            //ReportsNeedingAttention_Button.Content = Sqlite3_Interface.Instance.GetNumReportsNeedingAttention();
            ReportsNeedingAttention_Button.Content = 0;
            //************************************************************************

        }

        private void GitHubButton_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start(ConfigurationManager.AppSettings["GitHub"]);
        }

        private void TwitterButton_OnClick(object sender, RoutedEventArgs e)
        {
            // Process.Start("https://twitter.com/James_Willock");
        }

        private void ChatButton_OnClick(object sender, RoutedEventArgs e)
        {
            // Process.Start("https://gitter.im/ButchersBoy/MaterialDesignInXamlToolkit");
        }

        private void EmailButton_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("mailto://007dsi@gmail.com");
        }

        private void DonateButton_OnClick(object sender, RoutedEventArgs e)
        {
            // Process.Start("https://pledgie.com/campaigns/31029");
        }
    }
}


