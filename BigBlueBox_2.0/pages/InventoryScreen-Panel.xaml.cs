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
            //Inventory_Form_Frame.Source = new Uri("HomeScreen-Panel.xaml", UriKind.Relative);
            //uncomment above when forms exist
        }

        private void New_Inventory_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine("New Inventory Clicked");
            //possibly write "are you sure this is new" y/n prompt to prevent overlap
            //Inventory_Form_Frame.Source = new Uri("HomeScreen-Panel.xaml", UriKind.Relative);
            //uncomment above when forms exist
        }
    }
}
