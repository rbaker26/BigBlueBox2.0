using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace BigBlueBox_2._0
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
    }

}

