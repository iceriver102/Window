using Alta_Media_Manager.Alta_view.Mysql_helpper;
using Alta_Media_Manager.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alta_Media_Manager.Alta_view.Class
{
    public class alta_class_schedules
    {
        private int _user_id;
        public int alta_id { get; set; }
        public alta_class_user alta_user
        {
            get
            {
                return getUser();
            }
            set
            {
                if (value != null)
                {
                    this._user_id = value.alta_id;
                }
            }
        }
        private int _alta_terminal_id;
        public alta_class_termiral alta_termiral
        {
            get
            {
               return getTerminal();
            }
            set
            {
                if (value != null)
                    this._alta_terminal_id = value.alta_id;
            }
        }
        public DateTime alta_schedules_date_begin { get; set; }
        public DateTime alta_schedules_date_end { get; set; }
        public String alta_content { get; set; }
        public List<alta_class_schedules_details> alta_details_schedule { get; set; }
        private alta_class_user getUser()
        {
            alta_class_user user = new alta_class_user();
            if (_user_id == 0)
            {
                user = mysql_alta_helpper.getUser(this);
            }
            else
            {
                user = mysql_alta_helpper.getUser(_user_id);
            }
            return user;
        }
        private alta_class_termiral getTerminal()
        {
            alta_class_termiral terminal = new alta_class_termiral();
            if (_alta_terminal_id == 0)
            {
                terminal = mysql_alta_helpper.getTermiral(this);
            }
            else
            {
                terminal = mysql_alta_helpper.getTermiral(_alta_terminal_id);
            }
            return terminal;
        }
        public void loadDetails()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string _query = "SELECT `schedules_details_id`, `schedules_id`, `plan_id`, `user_id`, `termiral_id`, `time_play`,`time_end` FROM `am_schedules_details` WHERE  `schedules_id`=@schedule_id";
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@schedule_id", this.alta_id);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                this.alta_details_schedule = mysql_alta_helpper.getListScheduleDetals(reader, true);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public alta_class_schedules getData()
        {
            if (this.alta_id != 0)
            {
                return mysql_alta_helpper.getSchedule(this.alta_id);              
            }
            return null;
        }


    }
    public class alta_class_schedules_details
    {
        public int alta_id { get; set; }
        public alta_class_schedules alta_schedules { get; set; }
        public alta_class_playlist alta_playlist { get; set; }
        public DateTime alta_time_play { get; set; }
        public DateTime alta_time_end { get; set; }
        private alta_class_user _user;
        public alta_class_user alta_user
        {
            get
            {
                if (_user == null && this.alta_id!=0)
                {
                    return getUser();
                }
                else if (this.alta_id != 0)
                {
                    return _user;
                }
                else
                {
                    return null;
                }
            }
            private set
            {
                _user = value;
            }
        }

        public alta_class_user getUser()
        {
            return mysql_alta_helpper.getUser(this);
        }

        public bool checkTime(DateTime time)
        {
            if (this.alta_time_play.Date <= time.Date && this.alta_time_end >= time.Date)
                return true;
            return false;
        }

    }
}
