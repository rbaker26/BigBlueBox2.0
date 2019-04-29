using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using BigBlueBox_lib.Item;
using BigBlueBox_lib.Gear;

namespace MaterialDesignColors.BigBlueBox2.src

{
    /// <summary>
    /// A Singlton Class that connects tot he SQL Database
    /// </summary>
    public sealed class SQL_Interface
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
        private static readonly Lazy<SQL_Interface>
            lazy = new Lazy<SQL_Interface> (() => new SQL_Interface());
        //*****************************************************************************************



        //*****************************************************************************************
        /// <summary>
        ///  Gets the instance of the SQL_Interface class
        /// </summary>
        public static SQL_Interface Instance { get { return lazy.Value; } }
        //*****************************************************************************************



        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        private SQL_Interface()
        {
            // SQLiteConnection.CreateFile("MyDatabase.sqlite");
            this.m_dbConnection = new SQLiteConnection("Data Source=../../rec/BigBlueBox.db;Version=3;");

            m_dbConnection.Open();
        }
        //*****************************************************************************************


        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        ~SQL_Interface()
        {
            try
            {
                m_dbConnection.Close();
            }
            catch(Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
            
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
            catch(InvalidCastException e)
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
        public void UpdateGear(Gear gear)
        {

        }
        //*****************************************************************************************


        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gear"></param>
        public void CreateGear(Gear gear)
        {

        }
        //*****************************************************************************************


        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gear"></param>
        public List<Gear_Note> GetGearNotes(Gear gear)
        {
            var notes = new List<Gear_Note>();

            SQLiteDataReader sqlite_datareader;

            String query = "Select * FROM gear_notes WHERE cat_id = ? AND idv_id = ?;";
            SQLiteCommand command = m_dbConnection.CreateCommand();
            command.Parameters.Add(gear.CatId);
            command.Parameters.Add(gear.IdvId);

            command.CommandText = query;
            sqlite_datareader = command.ExecuteReader();



            Gear_Note temp = new Gear_Note();
            try
            {
                sqlite_datareader.Read();
                while (sqlite_datareader.Read())
                {
                    temp.NoteText = sqlite_datareader.GetString(1);
                    temp.Author  = sqlite_datareader.GetString(2);
                    temp.TimeStamp = sqlite_datareader.GetDateTime(3);



                    notes.Add(temp);
                    temp = new Gear_Note();
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

            return notes;
        }
        //*****************************************************************************************



    }

}

