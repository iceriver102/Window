using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool isComplete
        {
            get { return this.isComplete; }
            set
            {
                if (canComplete == 1)
                {
                    if (value == true)
                    {
                        isComplete = true;
                        canComplete = 0;
                    }
                }
            }
        }

        public DateTime date { get; set; }
        public bool title_type = false;
        public Color color;
        public Reminder()
        {
            isComplete = false;
            canComplete = 1;
            title_type = false;
        }
    }
}
