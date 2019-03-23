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

using System.Data.SQLite;

namespace BigBlueBox_2._0
{
    /// <summary>
    /// Interaction logic for HomeScreen_Panel.xaml
    /// </summary>
    public partial class HomeScreen_Panel : Page
    {
        public HomeScreen_Panel()
        {
            InitializeComponent();

            ItemsNeedingAttention_Button.Content = SQL_Interface.Instance.GetNumItemsNeedingAttention();
            GearNeedingAttention_Button.Content = SQL_Interface.Instance.GetNumGearNeedingAttention();
        }

        // i dont think I needs these
        //public int ItemsNeedingAttention { get; set; }
        //public int GearNeedingAttention { get; set; }
        //public int ReportsNeedingAttention { get; set; }


    }

    
}