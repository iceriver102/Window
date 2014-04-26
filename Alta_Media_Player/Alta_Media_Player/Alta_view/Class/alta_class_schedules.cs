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
        public int alta_id { get; set; }
        public alta_class_user alta_user { get; set; }
        public alta_class_termiral alta_termiral { get; set; }
        public DateTime alta_schedules_date_begin { get; set; }
        public DateTime alta_schedules_date_end { get; set; }
        public String alta_content { get; set; }
        public List<alta_class_schedules_details> alta_details_schedule { get { return loadDetails(DateTime.Now); } }
        public List<alta_class_schedules_details> loadDetails(DateTime time)
        {
            List<alta_class_schedules_details> alta_details_schedule = new List<alta_class_schedules_details>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string _query = "SELECT `schedules_details_id`, `schedules_id`, `plan_id`, `user_id`, `termiral_id`, `time_play`,`time_end` FROM `am_schedules_details` WHERE  `schedules_id`=@schedule_id and  DATE_FORMAT( time_play, '%Y-%m-%d' )<=DATE_FORMAT( @time_play,'%Y-%m-%d') and DATE_FORMAT( time_end, '%Y-%m-%d' )>=DATE_FORMAT( @time_play,'%Y-%m-%d')";
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@schedule_id", this.alta_id);
                        cmd.Parameters.AddWithValue("@time_play", time.Date);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                alta_details_schedule = mysql_alta_helpper.getListScheduleDetals(reader, true);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return alta_details_schedule;
        }
    }
    public class alta_class_schedules_details
    {
        public int alta_id { get; set; }
        public alta_class_schedules alta_schedules { get; set; }
        public alta_class_playlist alta_playlist { get; set; }
        public DateTime alta_time_play { get; set; }
        public DateTime alta_time_end { get; set; }

        public bool checkTime(DateTime time)
        {
            if (this.alta_time_play.Date <= time.Date && this.alta_time_end >= time.Date)
                return true;
            return false;
        }

    }
}
