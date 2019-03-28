using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;


using BigBlueBox_lib.Item;


namespace Lib_Test
{
    //*****************************************************************************************
    [TestClass]
    public class Item_Category_Test
    {

        //*****************************************************************************************
        /// <summary>
        /// An array of all category types
        /// </summary>
        private static readonly Array cats = Enum.GetValues(typeof(Item_Category.CategoryType));
        //private static readonly Category.CategoryType[] cats =
                //{Category.CategoryType.NO_OPP,
                //Category.CategoryType.KITCHEN,
                //Category.CategoryType.PROPANE,
                //Category.CategoryType.CRAFTS,
                //Category.CategoryType.TARPS,
                //Category.CategoryType.OFFICE};

        //*****************************************************************************************


        //*****************************************************************************************
        /// <summary>
        /// Tests Category.IntToCategoryType(int i)
        /// <seealso cref="Category.IntToCategoryType"/>
        /// </summary>
        [TestMethod]
        public void TestIntToCategory()
        {
            // Valid Convertions
            for(int i = 0; i < Item_Category.ENUM_COUNT; i++)
            {
                Assert.AreEqual(cats.GetValue(i), Item_Category.IntToCategoryType(i));
            }

            
            // Invalid COnvertion
            Assert.AreEqual(Item_Category.CategoryType.NO_OPP,
                            Item_Category.IntToCategoryType(10));
        }
        //*****************************************************************************************




    }
    //*****************************************************************************************
}
