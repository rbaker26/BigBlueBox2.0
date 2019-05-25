using System;
using System.Collections.Generic;
using System.Text;

namespace BigBlueBox_lib.Gear
{
    public class Gear
    {
        public static readonly string DT_FORMAT = "yyyy/MM/dd HH:mm::ss";

        //*****************************************************************************************
        // Data Fields
        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CatId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdvId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Health_Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ObsolDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsCheckedOut { get; set; }
        //*****************************************************************************************


        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="CatId"></param>
        /// <param name="IdvId"></param>
        /// <param name="Health_Status"></param>
        /// <param name="ObsolDate"></param>
        /// <param name="IsCheckedOut"></param>
        public Gear(string Name, int CatId, int IdvId, int Health_Status, DateTime ObsolDate, bool IsCheckedOut)
        {
            this.Name = Name;
            this.CatId = CatId;
            this.IdvId = IdvId;
            this.Health_Status = Health_Status;
            this.ObsolDate = ObsolDate;
            this.IsCheckedOut = IsCheckedOut;
        }
        //*****************************************************************************************

    }
}
