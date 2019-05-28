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
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {

                // These are the same object (verified by toString method)
                Console.Out.WriteLine(item.ToString());
                Item ii = item as Item;
                Console.Out.WriteLine(ii.ToString());

                ItemTextBox.Clear();
                ItemTextBox.Text = ii.ItemName;

                ItemBoxName.Text = ii.BoxName;

            }
        }
    }

}
