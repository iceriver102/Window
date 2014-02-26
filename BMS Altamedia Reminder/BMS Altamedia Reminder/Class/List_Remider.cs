using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_Altamedia_Reminder.Class
{
    public class List_Remider
    {
        public List<Reminder> data { get; set; }
        public int count { get { return Count(); } }
        public List_Remider()
        {
            data = new List<Reminder>();
        }
        private int Count()
        {
            return data.Count;
        }
        public void Sort()
        {
            data.Sort();
        }
    }
}
