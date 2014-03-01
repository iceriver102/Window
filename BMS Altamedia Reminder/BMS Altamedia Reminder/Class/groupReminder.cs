using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_Altamedia_Reminder.Class
{
    public class groupReminder
    {
        public List<Reminder> data;
        public String title;
        public int count
        {
            get { return data.Count; }
        }
        public DateTime date;

        public groupReminder()
        {
            data = new List<Reminder>();
        }
    }
}
