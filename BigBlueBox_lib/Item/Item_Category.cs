using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBlueBox_lib.Item
{
    //*****************************************************************************************
    public class Item_Category
    {

        //*****************************************************************************************
        /// <summary>
        /// The Category Enum type
        /// </summary>
        //public enum CategoryType
        //{
        //    NO_OPP = 0,
        //    KITCHEN = 1,
        //    PROPANE = 2,
        //    CRAFTS = 3,
        //    TARPS = 4,
        //    OFFICE = 5
        //};
        //*****************************************************************************************

        static Dictionary<Int32, String> CategoryType = new Dictionary<int, string>();

        //*****************************************************************************************
        /// <summary>
        /// Converts a Int to a CategoryType String
        /// </summary>
        /// <param name="ict"></param>
        /// <returns></returns>
        public static String IntToCategoryTypeString(int ict)
        {
            if (ict >= 0 && ict < ENUM_COUNT)
            {
                return CategoryType.Values.ElementAt(ict);
            }
            else
            {
                throw new IndexOutOfRangeException("Value out of Range for CategoryType.");
            }
        }
        //*****************************************************************************************


        //*****************************************************************************************
        /// <summary>
        /// The number of Enums in CategoryType
        /// </summary>
        public static readonly int ENUM_COUNT = 6;
        //*****************************************************************************************


        //*****************************************************************************************
        /// <summary>
        /// A collection of enum string
        /// </summary>
        //public static readonly String[] enum_strings_m = 
        //    { "No Opp", "Kitchen", "Propane and Stoves",
        //    "Crafts", "Tarps", "Office" };
        //*****************************************************************************************


        //*****************************************************************************************
        /// <summary>
        /// Converts a Enum to a String
        /// </summary>
        /// <param name="ct"></param>
        /// <returns>category string</returns>
        //public static String CatToString(Item_Category.CategoryType ct) 
        //{
        //    try
        //    {
        //        return enum_strings_m[(int)ct];
        //    }
        //    catch(IndexOutOfRangeException)
        //    {
        //        //return "NO SUITABLE STRING CONVERVION EXISTS";
        //        throw (new IndexOutOfRangeException("NO SUITABLE STRING CONVERVION EXISTS"));
        //    }

        //}
        //*****************************************************************************************



        //*****************************************************************************************
        public static Int32 CategoryStringToInt(String s)
        {
            try
            {
                return CategoryType.AsEnumerable().Where(x => x.Value.Equals(s)).Select(x => x.Key).First();
            }
            catch(Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return 0;
            }
        }
        //*****************************************************************************************
    }

    //*****************************************************************************************
}
