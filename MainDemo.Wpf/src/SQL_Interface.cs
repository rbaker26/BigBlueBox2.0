using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using BigBlueBox_lib.Item;

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
        private SQLiteConnection m_dbConnection;
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
        private SQL_Interface()
        {
            // SQLiteConnection.CreateFile("MyDatabase.sqlite");
            this.m_dbConnection = new SQLiteConnection("Data Source=../../rec/BigBlueBox.db;Version=3;");

            m_dbConnection.Open();
        }
        //*****************************************************************************************


        //*****************************************************************************************
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
        public int GetNumItemsNeedingAttention()
        {
            SQLiteDataReader sqlite_datareader;

            String query = "SELECT COUNT(ID) FROM inventory WHERE target_quantity > quantity;";
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
        public List<string> GetCategoryList()
        {
            SQLiteDataReader sqlite_datareader;

            String query = "SELECT  FROM inventory WHERE target_quantity > quantity;";
            SQLiteCommand command = m_dbConnection.CreateCommand();
            command.CommandText = query;
            sqlite_datareader = command.ExecuteReader();



            return new List<string>();
        }
        //*****************************************************************************************


        public List<Item> GetFullInventory()
        {
            Console.Out.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
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
                    //Console.Out.WriteLine(sqlite_datareader.GetString(1));
                    temp.ItemName = sqlite_datareader.GetString(1);
                    temp.Quantity = sqlite_datareader.GetInt32(2);
                    temp.EffectiveOnHand = sqlite_datareader.GetInt32(3);
                    temp.CatTemp = sqlite_datareader.GetInt32(4);
                    temp.CanExpire = sqlite_datareader.GetBoolean(5);
                    temp.BoxName = sqlite_datareader.GetString(6);


                    inventory.Add(temp);
                    temp = new Item();
                    //Console.Out.WriteLine(temp.ToString());
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
    }

}

