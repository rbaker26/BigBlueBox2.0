using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using BigBlueBox_lib;
using BigBlueBox_lib.Item;
using BigBlueBox_lib.Gear;

namespace BigBlueBox2._0.data
{
    /// <summary>
    /// A Singlton Class that connects to the SQL Database
    /// </summary>
    public class Sqlite3_Interface : IDisposable
    {
        //*****************************************************************************************
        // Data Members
        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        private SQLiteConnection m_dbConnection;

        /// <summary>
        /// 
        /// </summary>
        private static readonly Lazy<Sqlite3_Interface>
            lazy = new Lazy<Sqlite3_Interface>(() => new Sqlite3_Interface());
        //*****************************************************************************************



        //*****************************************************************************************
        /// <summary>
        ///  Gets the instance of the SQL_Interface class
        /// </summary>
        public static Sqlite3_Interface Instance { get { return lazy.Value; } }
        //*****************************************************************************************



        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        private Sqlite3_Interface()
        {
            // SQLiteConnection.CreateFile("MyDatabase.sqlite");
            this.m_dbConnection = new SQLiteConnection("Data Source=C:/Users/007ds/Documents/GitHub/BigBlueBox2.0/BigBlueBox2.0/assests/data/BigBlueBox.db;Version=3;");

            m_dbConnection.Open();
        }
        //*****************************************************************************************

        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetNumGearNeedingAttention()
        {
            SQLiteDataReader sqlite_datareader;

            String query = "SELECT COUNT(primary_key) FROM gear_list WHERE health_status >= 4";
            SQLiteCommand command = m_dbConnection.CreateCommand();
            command.CommandText = query;
            sqlite_datareader = command.ExecuteReader();


            int myreader = 0;
            try
            {
                while (sqlite_datareader.Read())
                {
                    myreader = sqlite_datareader.GetInt32(0);
                    Console.WriteLine(myreader);
                }
            }
            catch (InvalidCastException e)
            {
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.InnerException);
                Console.Out.WriteLine(e.Source);
            }
            return myreader;
        }
        //*****************************************************************************************


        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetNumItemsNeedingAttention()
        {
            SQLiteDataReader sqlite_datareader;

            string query = "SELECT COUNT(ID) FROM inventory WHERE target_quantity > quantity;";
            SQLiteCommand command = m_dbConnection.CreateCommand();
            command.CommandText = query;
            sqlite_datareader = command.ExecuteReader();

            int myreader = 0;
            try
            {
                while (sqlite_datareader.Read())
                {
                    myreader = sqlite_datareader.GetInt32(0);
                    Console.WriteLine(myreader);
                }
            }
            catch (InvalidCastException e)
            {
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.InnerException);
                Console.Out.WriteLine(e.Source);
            }
            return myreader;
        }
        //*****************************************************************************************


        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> GetCategoryList()
        {
            SQLiteDataReader sqlite_datareader;

            string query = "SELECT  FROM inventory WHERE target_quantity > quantity;";
            SQLiteCommand command = m_dbConnection.CreateCommand();
            command.CommandText = query;
            sqlite_datareader = command.ExecuteReader();


            // TODO - Finish this section



            return new List<string>();
        }
        //*****************************************************************************************


        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Item> GetFullInventory()
        {
            List<Item> inventory = new List<Item>();
            SQLiteDataReader sqlite_datareader;

            String query = "Select * FROM inventory  ORDER BY cat ASC, item_name ASC;";
            SQLiteCommand command = m_dbConnection.CreateCommand();
            command.CommandText = query;
            sqlite_datareader = command.ExecuteReader();


            Item temp = new Item();
            try
            {
                sqlite_datareader.Read();
                while (sqlite_datareader.Read())
                {
                    temp.ItemName = sqlite_datareader.GetString(1);
                    temp.Quantity = sqlite_datareader.GetInt32(2);
                    temp.EffectiveOnHand = sqlite_datareader.GetInt32(3);
                    temp.CatTemp = sqlite_datareader.GetInt32(4);
                    temp.CanExpire = sqlite_datareader.GetBoolean(5);
                    temp.BoxName = sqlite_datareader.GetString(6);


                    inventory.Add(temp);
                    temp = new Item();
                    //****************************************
                    // Debug Code
                    //****************************************
                    //Console.Out.WriteLine(temp.ToString());
                    //****************************************
                };
            }
            catch (InvalidCastException e)
            {
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.InnerException);
                Console.Out.WriteLine(e.Source);
            }

            return inventory;
        }
        //*****************************************************************************************




        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void UpdateItem(Item item)
        {

        }
        //*****************************************************************************************




        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void CreateItem(Item item)
        {

        }
        //*****************************************************************************************


        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gear"></param>
        public void UpdateGear(GearType gear)
        {

        }
        //*****************************************************************************************


        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gear"></param>
        public void CreateGear(GearType gear)
        {

        }
        //*****************************************************************************************


        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gear"></param>
        public List<Gear_Note> GetGearNotes(GearType gear)
        {
            var notes = new List<Gear_Note>();

            SQLiteDataReader sqlite_datareader;

            string query = "Select note, author, time_stamp FROM gear_notes WHERE gear_cat_id = @catID AND gear_idv_id = @idvID ORDER BY time_stamp ASC;";
            SQLiteCommand command = m_dbConnection.CreateCommand();

            command.Parameters.Add(new System.Data.SQLite.SQLiteParameter("@catID", gear.CatId));
            command.Parameters.Add(new System.Data.SQLite.SQLiteParameter("@idvID", gear.IdvId));
            command.CommandText = query;
            sqlite_datareader = command.ExecuteReader();



            Gear_Note temp = new Gear_Note();
            try
            {
                sqlite_datareader.Read();
                while (sqlite_datareader.Read())
                {
                    temp.NoteText = sqlite_datareader.GetString(0);
                    temp.Author = sqlite_datareader.GetString(1);

                    temp.TimeStamp = DateTime.ParseExact(sqlite_datareader.GetString(2), "yyyy/MM/dd HH:mm::ss", null);
                    notes.Add(temp);


                    //****************************************
                    // Debug Code
                    //****************************************
                    //Console.Out.WriteLine(temp.ToString());
                    //****************************************

                    temp = new Gear_Note();
                };
            }
            catch (InvalidCastException e)
            {
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.InnerException);
                Console.Out.WriteLine(e.Source);
            }

            return notes;
        }
        public List<Gear_Note> GetGearNotes(int catId, int idvId)
        {
            return GetGearNotes(new GearType("", catId, idvId, 0, new DateTime(0), false));
        }
        //*****************************************************************************************



        //*****************************************************************************************
        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    m_dbConnection.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~Sqlite3_Interface()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
        //*****************************************************************************************
    }
}
