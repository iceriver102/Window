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
    public class alta_class_media
    {
        public int alta_id { get; set; }
        public String alta_name { get; set; }
        public String alta_url { get; set; }
        public bool alta_media_status { get; set; }
        public alta_class_media_type alta_media_type { get; set; }
        public DateTime alta_media_time { get; set; }
        public String alta_content { get; set; }
        public alta_class_user alta_user { get; set; }
        public List<alta_class_playlist> alta_playlist { get; set; }
        public static alta_class_media LoadMedia(int id, bool flag = false)
        {
            return mysql_alta_helpper.getMedia(id, flag);
        }
        public void LoadMediaType(int id_media_type)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string insert_query = "SELECT `media_type_id`, `media_type_name`, `media_type_content` FROM `am_media_type` WHERE `media_type_id`=@media_type_id";
                    using (MySqlCommand cmd = new MySqlCommand(insert_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@media_type_id", id_media_type);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                this.alta_media_type = mysql_alta_helpper.getMediaType(reader);
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
        public void LoadPlaylist()
        {
            alta_playlist = new List<alta_class_playlist>();
            alta_playlist = mysql_alta_helpper.getListPlaylistofMedia(this.alta_id);
        }

    }
    public class alta_class_media_type
    {
        public int alta_id { get; set; }
        public String alta_name { get; set; }
        public String alta_content { get; set; }

    }

}