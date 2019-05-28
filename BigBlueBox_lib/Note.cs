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
    public class Note
    {

        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NoteText"></param>
        /// <param name="Author"></param>
        /// <param name="DateTimePublished"></param>
        Note(string NoteText, string Author, DateTime DateTimePublished)
        {
            this.NoteText = NoteText;
            this.Author = Author;
            this.DateTimePublished = DateTimePublished;
        }
        //*****************************************************************************************



        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        public string NoteText { set; get; }
        //*****************************************************************************************



        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        public string Author { set; get; }
        //*****************************************************************************************



        //*****************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateTimePublished { set; get; }
        //*****************************************************************************************

    }
}
