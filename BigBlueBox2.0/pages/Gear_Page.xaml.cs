using System;
using System.IO;
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

using System.Drawing;
using System.Drawing.Imaging;
using Svg;
using System.Xml;


using QRCoder;

using BigBlueBox_lib.Gear;
using BigBlueBox2._0.data;
//using Path = System.IO.Path;

namespace BigBlueBox2._0.pages
{
    /// <summary>
    /// Interaction logic for Gear_Page.xaml
    /// </summary>
    public partial class Gear_Page : UserControl
    {
        public Gear_Page()
        {
            InitializeComponent();
            // C: \Users\007ds\Documents\GitHub\BigBlueBox2.0\MainDemo.Wpf\Resources\ItemQr.svg



            // Fill gear notes table
            List<Gear_Note> notes = Sqlite3_Interface.Instance.GetGearNotes(3, 15);
            foreach (Gear_Note i in notes)
            {
                Notes_Table.Items.Add(i);
            }
            string path = @"C:\Users\007ds\Documents\GitHub\BigBlueBox2.0\BigBlueBox2.0\assests\images\";
            var svgDocument = Svg.SvgDocument.Open(path  + "ItemQr.svg");
            svgDocument.ShapeRendering = SvgShapeRendering.Auto;

            Bitmap bmp = svgDocument.Draw(200, 200);                          // Draw Bitmap in any Size you need - for example 12px x 12px
            bmp.Save(path + "itemQr.png", ImageFormat.Png); 				// save Bitmap as PNG-File

            ItemQRCode.Source = new BitmapImage(new Uri(path + "itemQr.png"));
            PersonQRCode.Source = ItemQRCode.Source;
        }


        void UpdateGearItemUI(string gearScanCode)
        {

        }

        void UpdatePersonUI(string personScanCode)
        {

        }

        Bitmap RenderQrCode(string code)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);


            return qrCodeImage;
        }

        private void ScanCodeTextField_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {

            var item = (sender as TextBox).Text;
            if (item != null)
            {

                // These are the same object (verified by toString method)
                Console.Out.WriteLine("***************************************************************************");
                Console.Out.WriteLine(item);
                //Item ii = item as Item;
                //Console.Out.WriteLine(ii.ToString());

                //ItemTextBox.Clear();
                //ItemTextBox.Text = ii.ItemName;

                //ItemBoxName.Text = ii.BoxName;

            }

        }

        private void ScanCodeTextField_TextChanged(object sender, TextChangedEventArgs e)
        {

            var item = (sender as TextBox).Text;
            if (item != null)
            {

                // These are the same object (verified by toString method)
                Console.Out.WriteLine("***************************************************************************");
                Console.Out.WriteLine(item);
            }
        }
    }
}
