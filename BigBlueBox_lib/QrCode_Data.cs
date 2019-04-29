using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBlueBox_lib
{
    /// <summary>
    /// 
    /// </summary>
    abstract class QrCode_Data
    {

        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        public string Data { get; set; }
        //*****************************************************************************************


        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsValid(string s) { return false; }
        //*****************************************************************************************



        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        override public abstract string ToString();
        //*****************************************************************************************
    }
}
