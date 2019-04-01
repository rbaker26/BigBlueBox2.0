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

using MaterialDesignColors.BigBlueBox2.src;

using BigBlueBox_lib.Item;

namespace MaterialDesignDemo
{
    /// <summary>
    /// Interaction logic for Inventory_Page.xaml
    /// </summary>
    public partial class Inventory_Page : UserControl
    {
        public Inventory_Page()
        {
            InitializeComponent();

            List<Item> Invetory = SQL_Interface.Instance.GetFullInventory();
            foreach(Item i in Invetory)
            {
                Inventory_Table.Items.Add(i);
            }
            
        }
    }
}
