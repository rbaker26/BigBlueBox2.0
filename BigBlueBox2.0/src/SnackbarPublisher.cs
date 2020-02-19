using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BigBlueBox2._0.src
{
    public static class SnackbarPublisher
    {
        public static void Publish(string msg)
        {
            MainWindow parent = (MainWindow)Application.Current.MainWindow;
            parent.PublishToSnackBar(msg);
        }
    }
}
