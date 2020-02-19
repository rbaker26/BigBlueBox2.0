using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBlueBox_lib.Person
{
    public class Person
    {
        public string Name { get; set; }
        public string MajorGroupName { get; set; }
        public string MinorGroupName { get; set; }
        public int GroupId { get; set; }

        public int IdvId { get; set; }



        //*****************************************************************************************
        #region Constructors
        public Person()
        {
            Name = "";
            GroupId = 0;
            IdvId = 0;
        }


        public Person(int groupId, int idvId)
        {
            Name = "";
            GroupId = groupId;
            IdvId = idvId;
        }

        public Person(int groupId, int idvId, string name)
        {
            Name = name;
            GroupId = groupId;
            IdvId = idvId;
        }
        #endregion
        //*****************************************************************************************
    }
}
