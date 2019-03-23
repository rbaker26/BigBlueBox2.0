using System;
using System.Collections.Generic;
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



namespace BigBlueBox_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Widget_Frame.Source = new Uri("HomeScreen-Panel.xaml", UriKind.Relative);


        }



        //*************************************************************************
        // Menu Button Click Actions
        //*************************************************************************
        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine("Home Clicked");
            Widget_Frame.Source = new Uri("HomeScreen-Panel.xaml", UriKind.Relative);

        }

        private void Inventory_Button_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine("Inventory Clicked");
            Widget_Frame.Source = new Uri("InventoryScreen-Panel.xaml", UriKind.Relative);
        }

        private void Gear_Button_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine("Gear Clicked");
        }


        private void Analytics_Button_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine("Analytics Clicked");
        }

        private void Accounts_Button_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine("Accounts Clicked");
        }

        private void Settings_Button_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine("Settings Clicked");
        }
        //*************************************************************************


    }


}
