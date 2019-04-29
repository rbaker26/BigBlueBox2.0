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


using System.Drawing;
using System.Drawing.Imaging;
using Svg;
using System.Xml;

using BigBlueBox_lib;

namespace MaterialDesignDemo
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
      
            var svgDocument = Svg.SvgDocument.Open("C:/Users/007ds/Documents/GitHub/BigBlueBox2.0/MainDemo.Wpf/Resources/ItemQr.svg");
            svgDocument.ShapeRendering = SvgShapeRendering.Auto;

            Bitmap bmp = svgDocument.Draw(200, 200);                          // Draw Bitmap in any Size you need - for example 12px x 12px
            bmp.Save("C:/Users/007ds/Documents/GitHub/BigBlueBox2.0/MainDemo.Wpf/Resources/ItemQr.png", ImageFormat.Png); 				// save Bitmap as PNG-File


            ItemQRCode.Source = new BitmapImage(new Uri("C:/Users/007ds/Documents/GitHub/BigBlueBox2.0/MainDemo.Wpf/Resources/ItemQr.png")) ;
            PersonQRCode.Source = ItemQRCode.Source;
        }

    }
}
