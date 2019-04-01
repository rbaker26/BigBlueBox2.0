using System.Windows;
using System.Windows.Controls;
using MaterialDesignColors.BigBlueBox2.Domain;

namespace MaterialDesignColors.BigBlueBox2
{
    /// <summary>
    /// Interaction logic for TextFields.xaml
    /// </summary>
    public partial class TextFields : UserControl
    {
        public TextFields()
        {
            InitializeComponent();	        
			DataContext = new TextFieldsViewModel();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {            
        }

    }
}
