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
using System.Windows.Shapes;

namespace BigBlueBox_2._0
{
    /// <summary>
    /// Interaction logic for InventoryScreen_Panel.xaml
    /// </summary>
    public partial class InventoryScreen_Panel : Page
    {
        public InventoryScreen_Panel()
        {
            InitializeComponent();
            
        }

        //*************************************************************************
        // Inventory Button Click Actions
        //*************************************************************************
        private void Update_Inventory_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine("Update Inventory Clicked");
            //Inventory_Form_Frame.Source = new Uri("UpdateInventory-Form.xaml", UriKind.Relative);
            //uncomment above when forms exist
        }

        private void New_Inventory_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine("New Inventory Clicked");
            MessageBoxResult result = MessageBox.Show("Are your sure this Item does not already exist?" + Environment.NewLine + "Please check again before making any changes." + Environment.NewLine + "All changes are IRREVERSIBLE and should not be made unless nescessary.", "Are you sure?", MessageBoxButton.YesNo);
            switch(result)
            {
                case MessageBoxResult.Yes:
                    Inventory_Form_Frame.Source = new Uri("NewInventory-Form.xaml", UriKind.Relative);
                    break;

                case MessageBoxResult.No:
                    break;

            }
        }
        private void Print_Report_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine("Print Report Clicked");
            //write the print report function before using this button
        }
    }
}
