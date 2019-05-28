using System;
using System.Collections.Generic;
using System.Text;

namespace BigBlueBox_lib.Gear
{
    public class Gear_Note
    {
        public string NoteText { get; set; }
        public string Author { get; set; }
        public DateTime TimeStamp { get; set; }



        public override string ToString()
        {
            return "Author: " + Author + "\tNoteText: " + NoteText + "\tDateTime: " + TimeStamp.ToString();
        }
    }
}
