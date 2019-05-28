using System;
using System.Collections.Generic;
using System.Text;

namespace BigBlueBox_lib.Gear
{
    public class GearType
    {
        public const string DT_FORMAT = "yyyy/MM/dd HH:mm::ss";

        //*****************************************************************************************
        // Data Fields
        //*****************************************************************************************
        public string Name { get; set; }

        public int CatId { get; set; }

        public int IdvId { get; set; }

        public int Health_Status { get; set; }

        public DateTime ObsolDate { get; set; }

        public bool IsCheckedOut { get; set; }

        

        //*****************************************************************************************


        //*****************************************************************************************
        public GearType(string Name, int CatId, int IdvId, int Health_Status, DateTime ObsolDate, bool IsCheckedOut)
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
