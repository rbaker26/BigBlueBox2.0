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
using BigBlueBox_lib.Person;
//using Path = System.IO.Path;

namespace BigBlueBox2._0.pages
{
    /// <summary>
    /// Interaction logic for Gear_Page.xaml
    /// </summary>
    public partial class Gear_Page : UserControl
    {

        //*****************************************************************************************
        public Gear_Page()
        {
            InitializeComponent();
            // C: \Users\007ds\Documents\GitHub\BigBlueBox2.0\MainDemo.Wpf\Resources\ItemQr.svg



            // Fill gear notes table
            //List<Gear_Note> notes = Sqlite3_Interface.Instance.GetGearNotes(3, 15);
            //foreach (Gear_Note i in notes)
            //{
            //    Notes_Table.Items.Add(i);
            //}

            //TODO make this work in AppData folder
            //string path = @"C:\Users\007ds\Documents\GitHub\BigBlueBox2.0\BigBlueBox2.0\assests\images\";
            //var svgDocument = Svg.SvgDocument.Open(path  + "ItemQr.svg");
            //svgDocument.ShapeRendering = SvgShapeRendering.Auto;

            //Bitmap bmp = svgDocument.Draw(200, 200);                          // Draw Bitmap in any Size you need - for example 12px x 12px
            //bmp.Save(path + "itemQr.png", ImageFormat.Png); 				// save Bitmap as PNG-File
            //bmp.Dispose();
          
            //ItemQRCode.Source = new BitmapImage(new Uri(path + "itemQr.png"));

            //PersonQRCode.Source = ItemQRCode.Source;
        }
        //*****************************************************************************************


        //*****************************************************************************************
        void UpdateGearItemUI(int catId, int idvId)
        {
            GearType gear = Sqlite3_Interface.Instance.GetGearById(catId, idvId);
            GearNameText.Text = gear.Name;
            GearIdvIdText.Text = gear.IdvId.ToString("X6");
            GearHealthStatusText.Text = GearType.HealthString[gear.Health_Status];
            GearObvDateText.Text = gear.ObsolDate.ToString();
            GearQrScancodeText.Text = "ITM:" + catId.ToString("X4") + ":" + idvId.ToString("X6");
        }
        //*****************************************************************************************


        //*****************************************************************************************
        void UpdatePersonUI(int catId, int idvId)
        {
            PIDScancode.Text = "PID:" + catId.ToString("X4") + ":" + idvId.ToString("X6");
            Person person = Sqlite3_Interface.Instance.GetPersonById(catId, idvId);

            TroopNameTextBox.Text = person.MajorGroupName;
            PatrolNameTextBox.Text = person.MinorGroupName;
            NameTextBox.Text = person.Name;
            PIDTextBox.Text = idvId.ToString("X6");
        }
        //*****************************************************************************************


        //*****************************************************************************************
        void UpdateQrCode(string scan_code)
        {
            Bitmap bm = RenderQrCode(scan_code);

            using (MemoryStream memory = new MemoryStream())
            {
                bm.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();


                if(scan_code.Substring(0, 3).ToLower() == "itm")
                {
                    ItemQRCode.Source = bitmapImage;
                }
                else if (scan_code.Substring(0, 3).ToLower() == "pid")
                {
                    PersonQRCode.Source = bitmapImage;
                }
                else
                {
                    throw new Exception("invalid scan code");
                }
            }
        }
        //*****************************************************************************************


        //*****************************************************************************************
        Bitmap RenderQrCode(string scan_code)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(scan_code, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);


            return qrCodeImage;
        }
        //*****************************************************************************************


        //// This function can check an item after each keystroke.
        //// I dont know why I wrote this.  maybe for some check as you go function.
        //private void ScanCodeTextField_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        //{

        //    string item_code = (sender as TextBox).Text;
        //    if (item_code != null && item_code.Length == 15)
        //    {

        //        // These are the same object (verified by toString method)
        //        Console.Out.WriteLine("***************************************************************************");
        //        Console.Out.WriteLine(item_code);
        //        //Item ii = item as Item;
        //        //Console.Out.WriteLine(ii.ToString());

        //        //ItemTextBox.Clear();
        //        //ItemTextBox.Text = ii.ItemName;

        //        //ItemBoxName.Text = ii.BoxName;

        //    }

        //}


        //// This function is called when the newline or enter key is press.
        private void ScanCodeTextField_TextChanged(object sender, TextChangedEventArgs e)
        {

            try
            {
            string item = (sender as TextBox).Text;
            Console.Out.WriteLine(item.Length);
            if (item != null && item.Length == 15)
               {
                if (item.Substring(0, 3).ToLower() == "itm")
               {
                   int catId = Int32.Parse(item.Substring(4, 4));
                   int idvId = Int32.Parse(item.Substring(9, 6));
                   List<Gear_Note> notes = Sqlite3_Interface.Instance.GetGearNotes(catId, catId);

                   Console.Out.WriteLine("##########################################################");
                   Console.Out.WriteLine(item + "\t" + catId + "\t" + idvId);
                   Console.Out.WriteLine("##########################################################");

                   ClearAndAddNotesToTable(notes);

                }
            }
        }
        catch(Exception exp)
        {
          Console.Error.WriteLine(exp.ToString());
            }

        }


        //*****************************************************************************************
        // This is the main logic of the gear checkout page.
        void EnterClicked(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                try
                {
                    string scan_code = (sender as TextBox).Text;
                    if (scan_code != null && scan_code.Length == 15)  // TODO move magic number to QrCodeData.cs
                    {
                        //***************************************************************
                        // For Gear Scan Codes
                        //***************************************************************
                        if (scan_code.Substring(0, 3).ToLower() == "itm")
                        {
                            int catId = Int32.Parse(scan_code.Substring(4, 4), System.Globalization.NumberStyles.HexNumber);
                            int idvId = Int32.Parse(scan_code.Substring(9, 6), System.Globalization.NumberStyles.HexNumber);

                            // TODO Check if item exists

                            UpdateGearNotes(catId, idvId);
                            UpdateGearItemUI(catId, idvId);
                            UpdateQrCode(scan_code);

                            // TODO Check to see if item is already checked-out
                            //if(isCheckedOut)
                            //{
                            //    offer to check in
                            //}
                            //else
                            //{
                            //    nothing
                            //}



                        }
                        //***************************************************************
                        // For Person Scan Codes
                        //***************************************************************
                        else if (scan_code.Substring(0, 3).ToLower() == "pid")
                        {
                            int catId = Int32.Parse(scan_code.Substring(4, 4), System.Globalization.NumberStyles.HexNumber);
                            int idvId = Int32.Parse(scan_code.Substring(9, 6), System.Globalization.NumberStyles.HexNumber);

                            // TODO Check if person exists

                            UpdatePersonUI(catId, idvId);
                            UpdateQrCode(scan_code);
                        }
                        //***************************************************************
                        // Invalid Scan Codes
                        //***************************************************************
                        else
                        {
                            // TODO - make popup of for bad code scan
                            // invalid code
                        }


                        // Start Checkout Prossess 
                        bool is_checked_out = false;
                        if(is_checked_out)
                        {

                        }
                        else
                        {

                        }
                    }
                }
                catch (Exception exp)
                {
                    // invalid code
                    //TODO - make popup of for bad code scan
                    Console.Error.WriteLine(exp.ToString());

                }


                // Clear out the text box after scan complete
                (sender as TextBox).Text = "";
                e.Handled = true;
            }
        }

        private void UpdateGearNotes(int catId, int idvId)
        {
            List<Gear_Note> notes = Sqlite3_Interface.Instance.GetGearNotes(catId, idvId);
            ClearAndAddNotesToTable(notes);
        }

        //*****************************************************************************************


        //*****************************************************************************************
        private void ClearAndAddNotesToTable(List<Gear_Note> notes)
        {
            Notes_Table.Items.Clear();
            if(notes != null && notes.Count > 0)
            {
                foreach (Gear_Note i in notes)
                {
                    Notes_Table.Items.Add(i);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        //*****************************************************************************************
        private void NoteAndAuthorKeyStroke(object sender, KeyEventArgs e)
        {
            // make sure a item is scanned
            if(GearQrScancodeText.Text.Length != 0)
            {
                // Enables the Add Note button when both fields contain text.
                if (NoteTextTextBox.Text.Length == 0 || NoteAuthorTextBox.Text.Length == 0)
                {
                    AddNoteButton.IsEnabled = false;
                }
                else
                {
                    AddNoteButton.IsEnabled = true;
                }
            }
            else
            {
                AddNoteButton.IsEnabled = false;
            }


        }

        private void Add_Note_Button_Click(object sender, RoutedEventArgs e)
        {
            // Assuming that a valid item is scanned.


            // TODO make sure the "AddNote" button is disabled when an Item is not scanned in

            Gear_Note note = new Gear_Note();

            note.NoteText = NoteTextTextBox.Text;
            note.Author = NoteAuthorTextBox.Text;
            note.TimeStamp = DateTime.Now;

            int catId = 1;
            int gearId = 1;


            Sqlite3_Interface.Instance.AddGearNote(catId, gearId, note);
            UpdateGearNotes(catId, gearId);
            ClearAddNoteFields();
            
        }

        private void Cancel_Add_Note_Button_Click(object sender, RoutedEventArgs e)
        {
            ClearAddNoteFields();
        }

        private void ClearAddNoteFields()
        {
            NoteTextTextBox.Text = "";
            NoteAuthorTextBox.Text = "";
            AddNoteButton.IsEnabled = false;
        }
    }
}
