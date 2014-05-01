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
        public String alta_email { get; set; }
        public String alta_phone { get; set; }
        public alta_class_user_type alta_type_user
        {
            get
            {
                return getType();
            }
        }

        public List<alta_class_user_parent> Children
        {
            get { return getListUser(); }
        }
        public override bool Equals(object obj)
        {
            alta_class_user user = obj as alta_class_user;
            if (user != null && user.alta_id == this.alta_id)
                return true;
            return false;
        }

        private List<alta_class_user_parent> getListUser()
        {
            List<alta_class_user_parent> list = new List<alta_class_user_parent>();
            list = Mysql_helpper.mysql_alta_helpper.getListUserSon(this.alta_id);
            return list;
        }

        public bool setStatus(bool f)
        {
            if (Mysql_helpper.mysql_alta_helpper.setStatus_User(this.alta_id, f))
            {
                this.alta_user_status = f;
                return true;
            }
            return false;
        }
        private alta_class_user_type getType()
        {
            alta_class_user_type type = new alta_class_user_type();
            type = Mysql_helpper.mysql_alta_helpper.getTypeOfUser(this.alta_id);
            return type;
        }
        public String getNoOnce(String key)
        {
            String keyNoOnce = "";
            using (MD5 md5Hash = MD5.Create())
            {
                keyNoOnce = CommonUtilities.GetMd5Hash(md5Hash, "ALTA_" + this.alta_username + this.alta_user_pass + key);
            }
            return keyNoOnce;
        }
        public bool checkLoginNetWork(String key, String noOnce)
        {
            return noOnce == this.getNoOnce(key);
        }
        internal void removeChildren(alta_class_user e)
        {
            int count = this.Children.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (this.Children[i].alta_user.Equals(e))
                    {
                        Mysql_helpper.mysql_alta_helpper.removeChildren(this.Children[i].alta_id);
                    }
                }
            }
        }
        internal void AddChildren(alta_class_user e)
        {
            int count = this.Children.Count;
            if (count > 0)
            {
                int i = 0;
                while (i < count && !this.Children[i].alta_user.Equals(e)) ++i;
                if (i >= count)
                    Mysql_helpper.mysql_alta_helpper.addChildren(this.alta_id, e.alta_id);
            }
            else
            {
                Mysql_helpper.mysql_alta_helpper.addChildren(this.alta_id, e.alta_id);
            }
        }
    }
    public class alta_class_user_type
    {
        public int alta_id { get; set; }
        public String alta_name { get; set; }
        public int alta_permision { get; set; }
        public String alta_content { get; set; }
    }
    public class alta_class_user_parent
    {
        public int alta_id { get; set; }
        public int parent_id { get; set; }
        public alta_class_user alta_user { get; set; }
        public DateTime? time { get; set; }
    }
}
