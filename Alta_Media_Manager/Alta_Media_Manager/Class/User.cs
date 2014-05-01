using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alta_Media_Manager.Class
{
    public class User
    {
        public int id { get; set; }
        public String user_name { get; set; }
        public String pass { get; set; }
        public String full_name { get; set; }
        public bool status { get; set; }
        public bool admin { get; set; }
        public userType type;
        public User()
        {
            id = 1;
            admin = true;
            type = new userType();
        }
    }
}
