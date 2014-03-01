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
        public String type { get; set; }
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
        public String Str_date { get { return String.Format("{0:dd/MM/yyyy}",date); } }
        public int title_type = 0;
        public Color color;
        public bool title_mode = false;
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
        public Reminder(Newtonsoft.Json.Linq.JObject json)
        {
            this.id = Convert.ToInt32(json.GetValue("id").ToString());
            this.content = json.GetValue("content").ToString();
            this.type = json.GetValue("type").ToString();
            this.canComplete = Convert.ToInt32(json.GetValue("status").ToString());
            this._isComplete = false;
            this.title = json.GetValue("title").ToString();
            this.date = DateTime.ParseExact(json.GetValue("time").ToString(), "dd/MM/yyyy", null);
            this.title_mode = false;
        }
        public Reminder()
        {
            _isComplete = false;
            canComplete = 1;
            title_mode = false;
        }
    }
}
