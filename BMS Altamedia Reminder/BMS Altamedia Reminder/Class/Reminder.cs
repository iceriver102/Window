using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BMS_Altamedia_Reminder.Class
{
    public class Reminder : IComparable<Reminder>
    {
        public int id { get; set; }
        public String title { get; set; }
        public String content { get; set; }
        public int canComplete { get; set; }
        public int CompareTo(Reminder other)
        {
            return date.Date.CompareTo(other.date.Date);
        }
        private bool _isComplete;

        public bool isComplete
        {
            get { return this._isComplete; }
            set
            {
                if (canComplete == 1)
                {
                    if (value == true)
                    {
                        _isComplete = true;
                        canComplete = 0;
                    }
                }
            }
        }
        public DateTime date { get; set; }
        public String Str_date { get { return date.ToLongDateString(); } }
        public bool title_type = false;
        public Color color;
        public ImageSource img_stt
        {
            get
            {
                if (isComplete)
                    return new BitmapImage(new Uri("/Assets/Checkbox/checkbox_checked_bg.png", UriKind.Relative));
                else
                    return new BitmapImage(new Uri("/Assets/Checkbox/checkbox_uncheck_bg.png", UriKind.Relative));
            }
        }
        public Reminder()
        {
            _isComplete = false;
            canComplete = 1;
            title_type = false;
        }
    }
}
