using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alta_Media_Manager.Alta_view.Class
{
    public class alta_class_termiral
    {
        public int alta_id { get; set; }
        public String alta_name { get; set; }
        public String alta_ip { get; set; }
        public String alta_content { get; set; }
        public bool alta_status { get; set; }
        public string alta_pass { get; set; }
        public alta_class_user user { get { return getUser(); } }
        private alta_class_user getUser()
        {
            return Mysql_helpper.mysql_alta_helpper.getUser(this, DateTime.Now);
        }

    }

}
