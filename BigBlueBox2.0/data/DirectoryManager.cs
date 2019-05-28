using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBlueBox2._0.data
{
    public class DirectoryManager
    {
        public enum FileType
        {
            Database,
            BlankQr,

        }
        private void Init()
        {

        }

        private Dictionary<FileType, string> File = null;

        public string GetFilePath(FileType fileType)
        {
            return File[fileType];
        }

    }
}
