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
using System.Text.RegularExpressions;
using System.Threading;
using BigBlueBox2._0.src;

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

            LoadInventoryTable();

        }

        private void LoadInventoryTable()
        {
            Inventory_Table.Items.Clear();

            List<Item> Invetory = Sqlite3_Interface.Instance.GetFullInventory();
            foreach (Item i in Invetory)
            {
                Inventory_Table.Items.Add(i);
            }
        }

        private void ClearItemArea()
        {
            ItemId.Clear();
            ItemTextBox.Clear();
            ItemBoxName.Clear();
            ItemQuantity.Clear();
            ItemTargetQuantity.Clear();
            ItemCanExpire.IsChecked = false;

        }

        private void Inventory_Table_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {

                Item ii = item as Item;
                Console.Out.WriteLine(ii.ToString());

                ClearItemArea();

                ItemId.Text = ii.Id.ToString();
                ItemTextBox.Text = ii.ItemName;
                ItemBoxName.Text = ii.BoxName;
                ItemQuantity.Text = ii.Quantity.ToString();
                ItemTargetQuantity.Text = ii.EffectiveOnHand.ToString();

                ItemCanExpire.IsChecked = ii.CanExpire;
            }
        }


        private void ItemApplyButton_Click(object sender, RoutedEventArgs e)
        {
            //todo create popup item diaglog
            Item temp = new Item
            {
                ItemName = ItemTextBox.Text,
                BoxName = ItemBoxName.Text,
                Quantity = Int32.Parse(ItemQuantity.Text),
                EffectiveOnHand = Int32.Parse(ItemTargetQuantity.Text),
                CanExpire = ItemCanExpire.IsChecked ?? false
            };

            Sqlite3_Interface.Instance.UpdateItem(Int32.Parse(ItemId.Text), temp);

            ClearItemArea();
            LoadInventoryTable();
            SnackbarPublisher.Publish(string.Format("Item Update Successful:\t{0}", temp.ItemName));
        }

        //*******************************************************************************
        // Data Field Validation Functions
        #region Data Field Validation Functions
        // Protects the database from sql injections and the like.
        // will also be implamented in the Lib, but they will throw exexptions if it gets that far

        // Regex Objs
        private static readonly Regex _regexNumOnly = new Regex(@"[^0-9.-]+"); 
        private static readonly Regex _regexItemName = new Regex(@"^[-A-Za-z0-9()._]{1}[-A-Za-z0-9() ._]{0,35}$");

        //*******************************************************************************
        // Number Validation
        //*******************************************************************************
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text, _regexNumOnly);

        }
        private static bool IsTextAllowed(string text, Regex regex)
        {
            return regex.IsMatch(text);
        }
        private void NumberValidationPastingTextBox(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (IsTextAllowed(text, _regexNumOnly))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
        //*******************************************************************************


        //*******************************************************************************
        // Text Validation
        //*******************************************************************************
        private void TextValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text, _regexItemName);
        }
        private void TextValidationPastingTextBox(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text, _regexItemName))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
        //*******************************************************************************


        #endregion
        //*******************************************************************************
    }

}
