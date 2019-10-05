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

using BigBlueBox_lib.Item;
using BigBlueBox2._0.data;

namespace BigBlueBox2._0.pages
{
    /// <summary>
    /// Interaction logic for Inventory_Page.xaml
    /// </summary>
    public partial class Inventory_Page : UserControl
    {

        public Inventory_Page()
        {
            InitializeComponent();

            List<Item> Invetory = Sqlite3_Interface.Instance.GetFullInventory();
            foreach (Item i in Invetory)
            {
                Inventory_Table.Items.Add(i);
            }

        }

        private void ClearItemArea()
        {
            ItemTextBox.Clear();

        }

        private void Inventory_Table_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("You are about to make changes to the inventory. Would you like to continue?","Are you sure?",MessageBoxButton.YesNo,MessageBoxImage.Warning);
            switch(result)
            {
                case MessageBoxResult.Yes:
                       Inventory_Editor invedit = new Inventory_Editor();
                       invedit.Show();
                    break;
                case MessageBoxResult.No:
                       
                    break;
            }
            
        }
    }

}
