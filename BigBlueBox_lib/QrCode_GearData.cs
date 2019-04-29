using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace BigBlueBox_lib
{
    /// <summary>
    /// 
    /// </summary>
    class QrCode_GearData : QrCode_Data
    {
        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        private static readonly Regex regex = new Regex(@"^itm|ITM{1}\d{10}$");
        //*****************************************************************************************



        //*****************************************************************************************
        /// <summary>
        /// QrCode_GearData Constructor
        /// </summary>
        /// <param name="s"></param>
        public QrCode_GearData(string s)
        {
            Data = s;
        }
        //*****************************************************************************************



        //*****************************************************************************************
        /// <summary>
        /// Static Validator 
        /// </summary>
        /// <param name="s">The Data String</param>
        /// <returns></returns>
        public new static bool IsValid(string s)
        {
            return regex.IsMatch(s);
        }
        //*****************************************************************************************


        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Data;
        }
        //*****************************************************************************************


        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Format(string s)
        {
            if(!IsValid(s))
            {
                throw new ArgumentException("String is wrong length");
            }
            var sb = new StringBuilder();
            sb.Append(s.Substring(0, 3));
            sb.Append(":");
            sb.Append(s.Substring(3, 4));
            sb.Append(":");
            sb.Append(s.Substring(7, 13));

            return sb.ToString(); ;
        }
        //*****************************************************************************************
    }
}
