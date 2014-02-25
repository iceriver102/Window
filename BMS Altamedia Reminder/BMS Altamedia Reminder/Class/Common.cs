using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BMS_Altamedia_Reminder.Class
{
    public static class Common
    {
        public static String http = "http://bms.altamedia.vn/api.php";
        public static String urlToast;
        public static int count=3;
        public static Size GetScreenResolution()
        {
            double ScreenWidth = Application.Current.Host.Content.ActualWidth;
            double ScreenHeight = Application.Current.Host.Content.ActualHeight;
            return new Size(ScreenWidth, ScreenHeight);
        } 
    }
}
