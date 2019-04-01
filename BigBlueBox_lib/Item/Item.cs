using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBlueBox_lib.Item
{
    public class Item
    {
        public Item()
        {
            ItemName = "";
            Quantity = 0;
            EffectiveOnHand = 0;
            BoxName = "";
            CanExpire = false;

            ModifiedBy = "";
        }
        public String ItemName { get; set; }
        public int Quantity { get; set; }
        public int EffectiveOnHand { get; set; }
        public int CatTemp { get; set; }
        public String BoxName { get; set; }
        public bool CanExpire { get; set; }


        public DateTime DateModified { get; set; }
        public String ModifiedBy { get; set; }


        public override string ToString()
        {
            return ItemName;
        }


    }
}
