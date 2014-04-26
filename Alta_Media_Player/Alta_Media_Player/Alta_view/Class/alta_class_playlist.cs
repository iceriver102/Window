using Alta_Media_Manager.Alta_view.Mysql_helpper;
using Alta_Media_Manager.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alta_Media_Manager.Alta_view.Class
{
    public class alta_class_playlist
    {
        public String Id;
        public int alta_id { get { return Convert.ToInt32(Id); } set { Id = value.ToString(); } }
        public String alta_name { get; set; }
        public String alta_content { get; set; }
        public DateTime alta_playlist_date_begin { get; set; }
        public DateTime alta_playlist_date_end { get; set; }
        public DateTime alta_playlist_time_create { get; set; }
        public String alta_playlist_content { get; set; }
        public bool alta_status { get; set; }
        private int user_id;
        public alta_class_user alta_user { get { return mysql_alta_helpper.getUser(user_id); } set { user_id = value.alta_id; } }
        public List<alta_class_playlist_details> alta_details { get { return this.LoadDetails(); } }
        public List<alta_class_termiral> list_terminal { get; set; }

        private List<alta_class_playlist_details> LoadDetails()
        {

            List<alta_class_playlist_details> alta_details = new List<alta_class_playlist_details>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string insert_query = "SELECT `detail_plan_id`, `plan_id`, `media_id`, `time_play`, `time_create`,`time_end` FROM `am_plan_details` WHERE `plan_id`=@plan_id";
                    using (MySqlCommand cmd = new MySqlCommand(insert_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@plan_id", this.alta_id);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                alta_details = mysql_alta_helpper.getListPlayListDetails(reader, true);

                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return alta_details;
        }

        public void getListTerminal()
        {
            this.list_terminal = new List<alta_class_termiral>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string insert_query = "SELECT A.`termiral_id`, A.`termiral_name`, A.`termiral_ip`, A.`termiral_content`, A.`termiral_status` FROM `am_termiral` A,`am_schedules_details` B WHERE B.`plan_id`=@plan_id and A.`termiral_id`=B.`termiral_id`";
                    using (MySqlCommand cmd = new MySqlCommand(insert_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@plan_id", this.alta_id);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                this.list_terminal = mysql_alta_helpper.getListTerminal(reader);
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
        ~alta_class_playlist()
        {

        }
    }

    public class alta_class_playlist_details
    {
        public int alta_id { get; set; }
        public alta_class_playlist alta_playlist { get; set; }
        private DateTime _time_play;
        public DateTime alta_time_play { get { return _time_play; } set { _time_play = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, value.Hour, value.Minute, 0); } }
        private DateTime _timeend;
        public DateTime alta_time_end { get { return _timeend; } set { _timeend = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, value.Hour, value.Minute, 59); } }
        public DateTime? alta_time_create { get; set; }
        private int media_id;
        public alta_class_media alta_media { get { return this.getMedia(); } set { media_id = value.alta_id; } }
        private alta_class_media getMedia()
        {
            alta_class_media media = new alta_class_media();
            if (this.media_id <= 0)
                return null;
            media = mysql_alta_helpper.getMedia(this.media_id);
            return media;
        }
    }
}

