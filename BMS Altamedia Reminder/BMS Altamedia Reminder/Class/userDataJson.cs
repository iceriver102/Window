using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_Altamedia_Reminder.Class
{
   public class userDataJson
    {
        public Boolean result { get; set; }
        public String user_id { get; set; }
        public String user_name { get; set; }
        public String user_access_token { get; set; }
        public String msg { get; set; }

        public userDataJson()
        {
            result = false;
        }
    }
}
