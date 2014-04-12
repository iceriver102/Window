using Alta_Media_Manager.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Alta_Media_Manager.Alta_view.Class
{
    public class alta_class_user
    {
        public int alta_id { get; set; }
        public String alta_username { get; set; }
        public String alta_full_name { get; set; }
        public bool alta_user_status { get; set; }
        public String alta_user_pass { get; set; }
        public alta_class_user_type alta_type_user { get; set; }
        public String getNoOnce(String key)
        {
            String keyNoOnce = "";
            using (MD5 md5Hash = MD5.Create())
            {
                keyNoOnce = CommonUtilities.GetMd5Hash(md5Hash, "ALTA_" + this.alta_username + this.alta_user_pass + key);
            }
            return keyNoOnce;
        }
        public bool checkLoginNetWork(String key,String noOnce)
        {
            return noOnce == this.getNoOnce(key);
        }
    }
    public class alta_class_user_type
    {
        public int alta_id { get; set; }
        public String alta_name { get; set; }
        public String alta_content { get; set; }
    }
}
