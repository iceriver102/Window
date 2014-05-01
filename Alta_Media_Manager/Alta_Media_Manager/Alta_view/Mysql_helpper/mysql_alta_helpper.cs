using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alta_Media_Manager.Alta_view.Class;
using MySql.Data.MySqlClient;
using Alta_Media_Manager.Class;
using System.Collections;

namespace Alta_Media_Manager.Alta_view.Mysql_helpper
{
    public class mysql_alta_helpper
    {
        #region colum Schedule details table
        private static String ALTA_SCHEDULE_DETAILS_ID = "schedules_details_id";
        private static String ALTA_SCHEDULE_DETAILS_TIME_PLAY = "time_play";
        private static String ALTA_SCHEDULE_DETAILS_TIME_END = "time_end";
        #endregion
        #region colum Schedule table
        private static String ALTA_SCHEDULE_ID = "schedules_id";
        private static String ALTA_SCHEDULE_DATE_BEGIN = "schedules_date_begin";
        private static String ALTA_SCHEDULE_DATE_END = "schedules_date_end";
        private static String ALTA_SCHEDULE_CONTENT = "schedules_content";
        #endregion
        #region colum Termiral table
        private static String ALTA_TERMIRAL_ID = "termiral_id";
        private static String ALTA_TERMIRAL_NAME = "termiral_name";
        private static String ALTA_TERMIRAL_IP = "termiral_ip";
        private static String ALTA_TERMIRAL_CONTENT = "termiral_content";
        private static String ALTA_TERMIRAL_STATUS = "termiral_status";
        private static String ALTA_TERMIRAL_PASS = "termiral_pass";
        #endregion
        #region colum User table
        private static String ALTA_USER_ID = "user_id";
        private static String ALTA_USER_NAME = "username";
        private static String ALTA_USER_PASS = "user_pass";
        private static String ALTA_USER_FULL_NAME = "full_name";
        private static String ALTA_USER_STATUS = "user_status";
        private static String ALTA_USER_EMAIL = "user_email";
        private static String ALTA_USER_PHONE = "user_phone";
        private static String ALTA_USER_DATE = "user_time_create";
        #endregion
        #region colum User parent table
        private static String ALTA_USER_PARENT_DETAIL_ID = "id_details_user";
        private static String ALTA_USER_PARENT_ID = "parent_id";
        private static String ALTA_USER_SON_ID = "user_id";
        private static String ALTA_USER_PARENT_DETAIL_TIME = "time";
        #endregion
        #region colum user type table
        private static String ALTA_USER_TYPE_ID = "user_type_id";
        private static String ALTA_USER_TYPE_NAME = "name_type";
        private static String ALTA_USER_TYPE_PERMISION = "permision";
        private static String ALTA_USER_TYPE_CONTENT = "content";
        #endregion
        #region colum media type
        private static String ALTA_MEDIA_TYPE_ID = "media_type_id";
        private static String ALTA_MEDIA_TYPE_NAME = "media_type_name";
        private static String ALTA_MEDIA_TYPE_CONTENT = "media_type_content";
        #endregion
        #region colum media table
        private static String ALTA_MEDIA_ID = "media_id";
        private static String ALTA_MEDIA_NAME = "media_name";
        private static String ALTA_MEDIA_URL = "media_url";
        private static String ALTA_MEDIA_CONTENT = "media_content";

        private static String ALTA_MEDIA_DATE = "media_date";
        private static String ALTA_MEDIA_STATUS = "media_status";

        #endregion
        #region colum plan table
        private static String ALTA_PLAN_ID = "plan_id";
        private static String ALTA_PLAN_NAME = "plan_name";
        private static String ALTA_PLAN_DATE_BEGIN = "plan_date_begin";
        private static String ALTA_PLAN_DATE_END = "plan_date_end";
        private static String ALTA_PLAN_STATUS = "plan_status";
        private static String ALTA_PLAN_CREATE = "plan_time_create";
        private static String ALTA_PLAN_CONTENT = "plan_content";
        #endregion
        #region colum plan detais table
        private static String ALTA_PLAN_DETAILS_ID = "detail_plan_id";
        private static String ALTA_PLAN_DETAILS_TIME_PLAY = "time_play";
        private static String ALTA_PLAN_DETAILS_TIME_CREATE = "time_create";
        private static String ALTA_PLAN_DETAILS_TIME_END = "time_end";

        #endregion
        #region conlum terminal type table
        private static String ALTA_TERMIRAL_TYPE_ID = "terminal_type_id";
        private static String ALTA_TERMIRAL_TYPE_NAME = "terminal_type_name";
        private static String ALTA_TERMIRAL_TYPE_CONTENT = "terminal_type_content";
        #endregion
        public static void addMediaToPlaylist(int media_id, int playlist_id)
        {
            //check xem no da ton tai trong playlist hay chua

            String _query = "INSERT INTO `am_plan_details`( `plan_id`, `media_id`, `time_play`) VALUES (@id_plan,@id_media,@timeplay)";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_plan", playlist_id);
                        cmd.Parameters.AddWithValue("@id_media", media_id);
                        cmd.Parameters.AddWithValue("@timeplay", DateTime.Now.Date);
                        int tmp = cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }

        }
        public static void addMediaToPlaylist(int media_id, int playlist_id, DateTime time, DateTime timeEnd)
        {
            //check xem no da ton tai trong playlist hay chua

            String _query = "INSERT INTO `am_plan_details`( `plan_id`, `media_id`, `time_play`,`time_end`) VALUES (@id_plan,@id_media,@timeplay,@time_end)";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_plan", playlist_id);
                        cmd.Parameters.AddWithValue("@id_media", media_id);
                        cmd.Parameters.AddWithValue("@timeplay", time);
                        cmd.Parameters.AddWithValue("@time_end", timeEnd);
                        int tmp = cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }

        }
        private static int getCount(String table, String where, MySqlParameterCollection par)
        {
            int num = -1;
            String _query = "select count(*) as count from " + table + where;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        int count = par.Count;
                        for (int i = 0; count > i; i++)
                        {
                            cmd.Parameters.Add(par[i]);
                        }
                        var tmp = cmd.ExecuteScalar();

                        num = Convert.ToInt32(tmp);

                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return num;
        }
        public static List<alta_class_playlist> getListPlaylist(int id_user = -1, bool status = false, int from = -1, int num = -1, String sort = "")
        {
            List<alta_class_playlist> list_playlist = new List<alta_class_playlist>();
            string _query = "SELECT `plan_id`, `plan_name`, `plan_date_begin`, `plan_date_end`, `plan_status`, `user_id`, `plan_time_create`, `plan_content` FROM `am_plan`";
            String where = " Where 1";
            if (id_user != -1)
                where += " and user_id =@id_user";
            if (status)
            {
                where += " and plan_status=@plan_status";
            }
            _query += where;
            _query += sort;
            if (from != -1 && num != -1)
            {
                _query += " limit @cur_item, @page_num";
            }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        if (id_user != -1)
                            cmd.Parameters.AddWithValue("@id_user", id_user);
                        if (from != -1 && num != -1)
                        {
                            cmd.Parameters.AddWithValue("@cur_item", from);
                            cmd.Parameters.AddWithValue("@page_num", num);
                        }
                        if (status)
                            cmd.Parameters.AddWithValue("@plan_status", status);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                list_playlist = mysql_alta_helpper.getListPlaylist(reader, true);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return list_playlist;
        }
        public static List<alta_class_playlist> getListPlaylist(ref int total, int id_user = -1, bool status = false, int from = -1, int num = -1, String sort = "")
        {
            List<alta_class_playlist> list_playlist = new List<alta_class_playlist>();
            string _query = "SELECT `plan_id`, `plan_name`, `plan_date_begin`, `plan_date_end`, `plan_status`, `user_id`, `plan_time_create`, `plan_content` FROM `am_plan`";
            String where = " Where 1";
            if (id_user != -1)
                where += " and user_id =@id_user";
            if (status)
            {
                where += " and plan_status=@plan_status";
            }
            _query += where;
            _query += sort;
            if (from != -1 && num != -1)
            {
                _query += " limit @cur_item, @page_num";
            }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        if (id_user != -1)
                            cmd.Parameters.AddWithValue("@id_user", id_user);
                        if (from != -1 && num != -1)
                        {
                            cmd.Parameters.AddWithValue("@cur_item", from);
                            cmd.Parameters.AddWithValue("@page_num", num);
                        }
                        if (status)
                            cmd.Parameters.AddWithValue("@plan_status", status);
                        total = getCount("am_plan", where, cmd.Parameters);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                list_playlist = mysql_alta_helpper.getListPlaylist(reader, true);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return list_playlist;
        }

        public static List<alta_class_media> getListMedia(ref int sum, String sortData, int id_user = -1, int type = -1, bool status = false, int from = -1, int num = -1)
        {

            List<alta_class_media> List_media = new List<alta_class_media>();
            String where = " WHERE 1 ";
            string _query = "SELECT `media_id`, `media_name`, `media_url`, `media_content`, `media_type_id`, `media_date`, `media_status`, `user_id` FROM `am_media`";
            if (status)
            {
                // _query += " and media_status=@media_status";
                where += " and media_status=@media_status";
            }
            if (type != -1)
            {
                // _query += " And media_type_id =@media_type_id ";
                where += " And media_type_id =@media_type_id ";
            }
            if (id_user != -1)
            {
                // _query+=" And user_id =@id_user ";
                where += " And user_id =@id_user ";
            }
            _query += where;
            _query += sortData;
            if (from != -1 && num != -1)
            {
                _query += " limit @cur_media, @page_num";
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        //cmd.Parameters.AddWithValue("@id_video", id);
                        if (id_user != -1)
                            cmd.Parameters.AddWithValue("@id_user", id_user);
                        if (from != -1 && num != -1)
                        {
                            cmd.Parameters.AddWithValue("@cur_media", from);
                            cmd.Parameters.AddWithValue("@page_num", num);
                        }
                        if (type != -1)
                            cmd.Parameters.AddWithValue("@media_type_id", type);
                        if (status)
                            cmd.Parameters.AddWithValue("@media_status", status);
                        //  _query += " And media_type_id =@media_type_id ";
                        var tmp = cmd.ExecuteScalar();
                        sum = getCount("am_media", where, cmd.Parameters);
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                List_media = mysql_alta_helpper.getListMedia(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return List_media;
        }
        public static List<alta_class_media> getListMedia(ref int sum, String sortData, alta_class_user user, int type = -1, bool status = false, int from = -1, int num = -1)
        {

            List<alta_class_media> List_media = new List<alta_class_media>();
            String where = " WHERE 1 ";
            string _query = "SELECT `media_id`, `media_name`, `media_url`, `media_content`, `media_type_id`, `media_date`, `media_status`, `user_id` FROM `am_media`";
            if (status)
            {
                // _query += " and media_status=@media_status";
                where += " and media_status=@media_status";
            }
            if (type != -1)
            {
                // _query += " And media_type_id =@media_type_id ";
                where += " And media_type_id =@media_type_id ";
            }
            if (user != null)
            {
                String Array_user_id = "";
                int count = user.Children.Count;
                for (int i = 0; i < count; i++)
                {
                    Array_user_id += user.Children[i].alta_user.alta_id + ",";
                }
                Array_user_id += user.alta_id;
                    // _query+=" And user_id =@id_user ";
                where += " And user_id in (" + Array_user_id + ") ";
            }
            _query += where;
            _query += sortData;
            if (from != -1 && num != -1)
            {
                _query += " limit @cur_media, @page_num";
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        //cmd.Parameters.AddWithValue("@id_video", id);
                       
                        if (from != -1 && num != -1)
                        {
                            cmd.Parameters.AddWithValue("@cur_media", from);
                            cmd.Parameters.AddWithValue("@page_num", num);
                        }
                        if (type != -1)
                            cmd.Parameters.AddWithValue("@media_type_id", type);
                        if (status)
                            cmd.Parameters.AddWithValue("@media_status", status);
                        //  _query += " And media_type_id =@media_type_id ";
                        var tmp = cmd.ExecuteScalar();
                        sum = getCount("am_media", where, cmd.Parameters);
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                List_media = mysql_alta_helpper.getListMedia(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return List_media;
        }
        public static List<alta_class_media> getListMedia(int id_user = -1, int type = -1, bool status = false, int from = -1, int num = -1)
        {

            List<alta_class_media> List_media = new List<alta_class_media>();
            string _query = "SELECT `media_id`, `media_name`, `media_url`, `media_content`, `media_type_id`, `media_date`, `media_status`, `user_id` FROM `am_media` WHERE 1";
            if (status)
                _query += " and media_status=@media_status";
            if (type != -1)
                _query += " And media_type_id =@media_type_id ";
            if (id_user != -1)
                _query += " And user_id =@id_user ";
            if (from != -1 && num != -1)
            {
                _query += " limit @cur_media, @page_num";
            }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        //cmd.Parameters.AddWithValue("@id_video", id);
                        if (id_user != -1)
                            cmd.Parameters.AddWithValue("@id_user", id_user);
                        if (from != -1 && num != -1)
                        {
                            cmd.Parameters.AddWithValue("@cur_media", from);
                            cmd.Parameters.AddWithValue("@page_num", num);
                        }
                        if (type != -1)
                            cmd.Parameters.AddWithValue("@media_type_id", type);
                        if (status)
                            cmd.Parameters.AddWithValue("@media_status", status);
                        //  _query += " And media_type_id =@media_type_id ";
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                List_media = mysql_alta_helpper.getListMedia(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return List_media;
        }

        public static List<alta_class_media> SearchMedia(ref int total, String key_search, int from, int num, int user_id = -1, int type = -1, String sort = "", bool status = false)
        {
            List<alta_class_media> list_media = new List<alta_class_media>();
            String sql = "SELECT `media_id`, `media_name`, `media_url`, `media_content`, `media_type_id`, `media_date`, `media_status`, `user_id` FROM `am_media`";
            String where = " WHERE `media_name` like '%" + key_search + "%'";
            if (user_id != -1)
                where += " and user_id=@user_id";
            if (type != -1)
            {
                where += " and `media_type_id`=@type_id";
            }
            if (status)
            {
                where += " and media_status=@status";
            }
            sql += where;
            sql += sort;
            if (from != -1 && num != -1)
            {
                sql += " Limit @from, @num";
            }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // cmd.Parameters.AddWithValue("@key", key_search);
                        if (user_id != -1)
                        {
                            cmd.Parameters.AddWithValue("@user_id", user_id);
                        }
                        if (type != -1)
                        {
                            cmd.Parameters.AddWithValue("@type_id", type);
                        }
                        if (status)
                        {
                            cmd.Parameters.AddWithValue("@status", status);
                        }
                        if (from != -1 && num != -1)
                        {
                            cmd.Parameters.AddWithValue("@from", from);
                            cmd.Parameters.AddWithValue("@num", num);
                        }
                        total = getCount("am_media", where, cmd.Parameters);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                list_media = getListMedia(reader, true);
                            }
                        }

                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return list_media;
        }
        public static List<alta_class_media> SearchMedia(ref int total, String key_search, int from, int num, alta_class_user user, int type = -1, String sort = "", bool status = false)
        {
            List<alta_class_media> list_media = new List<alta_class_media>();
            String sql = "SELECT `media_id`, `media_name`, `media_url`, `media_content`, `media_type_id`, `media_date`, `media_status`, `user_id` FROM `am_media`";
            String where = " WHERE `media_name` like '%" + key_search + "%'";
            if (user != null)
            {
                String Array_user_id = "";
                int count = user.Children.Count;
                for (int i = 0; i < count; i++)
                {
                    Array_user_id += user.Children[i].alta_user.alta_id + ",";
                }
                Array_user_id += user.alta_id;
                // _query+=" And user_id =@id_user ";
                where += " And user_id in (" + Array_user_id + ") ";
            }
            if (type != -1)
            {
                where += " and `media_type_id`=@type_id";
            }
            if (status)
            {
                where += " and media_status=@status";
            }
            sql += where;
            sql += sort;
            if (from != -1 && num != -1)
            {
                sql += " Limit @from, @num";
            }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // cmd.Parameters.AddWithValue("@key", key_search);
                       
                        if (type != -1)
                        {
                            cmd.Parameters.AddWithValue("@type_id", type);
                        }
                        if (status)
                        {
                            cmd.Parameters.AddWithValue("@status", status);
                        }
                        if (from != -1 && num != -1)
                        {
                            cmd.Parameters.AddWithValue("@from", from);
                            cmd.Parameters.AddWithValue("@num", num);
                        }
                        total = getCount("am_media", where, cmd.Parameters);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                list_media = getListMedia(reader, true);
                            }
                        }

                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return list_media;
        }
        public static List<alta_class_termiral> SearchTerminal(ref int total, String key_search, int user_id = -1, String sort = "", bool status = false)
        {
            List<alta_class_termiral> list_terminal = new List<alta_class_termiral>();
            String sql = "SELECT A.`termiral_id`, A.`termiral_name`, A.`termiral_ip`, A.`termiral_content`, A.`termiral_status`,A.`termiral_pass` FROM `am_termiral` A, `am_schedules` B";
            String where = " WHERE A.`termiral_name` like '%" + key_search + "%'";
            if (user_id != -1)
                where += " and B.user_id=@user_id";

            if (status)
            {
                where += " and A.`termiral_status`=@status";
            }
            sql += where;
            sql += sort;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // cmd.Parameters.AddWithValue("@key", key_search);
                        if (user_id != -1)
                        {
                            cmd.Parameters.AddWithValue("@user_id", user_id);
                        }

                        if (status)
                        {
                            cmd.Parameters.AddWithValue("@status", status);
                        }

                        total = getCount("`am_termiral` A, `am_schedules` B", where, cmd.Parameters);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                list_terminal = getListTerminal(reader);
                            }
                        }

                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return list_terminal;
        }
        public static List<alta_class_schedules_details> getListScheduleDetals(MySqlDataReader reader, bool flag = false)
        {
            List<alta_class_schedules_details> list_schedule = new List<alta_class_schedules_details>();
            while (reader.Read())
            {
                alta_class_schedules_details tmp = new alta_class_schedules_details();
                if (!reader.IsDBNull(0))
                {
                    tmp.alta_id = reader.GetInt32(ALTA_SCHEDULE_DETAILS_ID);

                    alta_class_schedules schedule = new alta_class_schedules();
                    schedule.alta_id = reader.GetInt32(ALTA_SCHEDULE_ID);
                    tmp.alta_schedules = schedule;

                    alta_class_playlist playlist = new alta_class_playlist();
                    playlist.alta_id = reader.GetInt32(ALTA_PLAN_ID);
                   

                    //tmp.alta_user = user;

                    if (flag)
                        playlist.LoadDetails();
                    tmp.alta_playlist = playlist;
                    tmp.alta_time_play = reader.GetDateTime(ALTA_SCHEDULE_DETAILS_TIME_PLAY);
                    tmp.alta_time_end = reader.GetDateTime(ALTA_SCHEDULE_DETAILS_TIME_END);

                    list_schedule.Add(tmp);

                }
            }
            return list_schedule;
        }
        public static List<alta_class_playlist_details> getListPlayListDetails(MySqlDataReader reader, bool flag = false)
        {
            List<alta_class_playlist_details> list_details = new List<alta_class_playlist_details>();
            while (reader.Read())
            {
                alta_class_playlist_details tmp = new alta_class_playlist_details();
                //alta_class_playlist tmp = new alta_class_playlist();
                if (!reader.IsDBNull(0))
                {
                    tmp.alta_id = reader.GetInt32(ALTA_PLAN_DETAILS_ID);
                    alta_class_media media = new alta_class_media();
                    if (flag)
                    {
                        media = alta_class_media.LoadMedia(reader.GetInt32(ALTA_MEDIA_ID), true);
                        tmp.alta_media = media;
                    }
                    else
                    {

                        media.alta_id = reader.GetInt32(ALTA_MEDIA_ID);
                        tmp.alta_media = media;
                    }

                    alta_class_playlist playlist = new alta_class_playlist();
                    playlist.alta_id = reader.GetInt32(ALTA_PLAN_ID);
                    tmp.alta_playlist = playlist;

                    tmp.alta_time_play = reader.GetDateTime(ALTA_PLAN_DETAILS_TIME_PLAY);
                    tmp.alta_time_end = reader.GetDateTime(ALTA_PLAN_DETAILS_TIME_END);
                    try
                    {
                        tmp.alta_time_create = reader.GetDateTime(ALTA_PLAN_DETAILS_TIME_CREATE);
                    }
                    catch (Exception)
                    {
                        tmp.alta_time_create = null;
                    }
                    
                    list_details.Add(tmp);

                }
            }
            return list_details;
        }
        public static alta_class_playlist_details getPlayListDetails(MySqlDataReader reader, bool flag = false)
        {
            alta_class_playlist_details tmp = new alta_class_playlist_details();
            while (reader.Read())
            {
                //  alta_class_playlist_details tmp = new alta_class_playlist_details();
                //alta_class_playlist tmp = new alta_class_playlist();
                if (!reader.IsDBNull(0))
                {
                    tmp.alta_id = reader.GetInt32(ALTA_PLAN_DETAILS_ID);
                    alta_class_media media = new alta_class_media();
                    if (flag)
                    {
                        media = alta_class_media.LoadMedia(reader.GetInt32(ALTA_MEDIA_ID), true);
                        tmp.alta_media = media;
                    }
                    else
                    {
                        media.alta_id = reader.GetInt32(ALTA_MEDIA_ID);
                        tmp.alta_media = media;
                    }

                    alta_class_playlist playlist = new alta_class_playlist();
                    playlist.alta_id = reader.GetInt32(ALTA_PLAN_ID);
                    tmp.alta_playlist = playlist;

                    tmp.alta_time_play = reader.GetDateTime(ALTA_PLAN_DETAILS_TIME_PLAY);
                    tmp.alta_time_end = reader.GetDateTime(ALTA_PLAN_DETAILS_TIME_END);
                    try
                    {
                        tmp.alta_time_create = reader.GetDateTime(ALTA_PLAN_DETAILS_TIME_CREATE);
                    }
                    catch (Exception)
                    {
                        tmp.alta_time_create = null;
                    }                   
                    //  list_details.Add(tmp);

                }
            }
            return tmp;
        }

        public static List<alta_class_user_type> getListTypeUser(MySqlDataReader reader)
        {
            List<alta_class_user_type> list_user = new List<alta_class_user_type>();
            while (reader.Read())
            {
                alta_class_user_type tmp = new alta_class_user_type();
                //alta_class_playlist tmp = new alta_class_playlist();
                if (!reader.IsDBNull(0))
                {

                    tmp.alta_id = reader.GetInt32(ALTA_USER_TYPE_ID);
                    tmp.alta_name = reader.GetString(ALTA_USER_TYPE_NAME);
                    try
                    {
                        tmp.alta_permision = reader.GetInt32(ALTA_USER_TYPE_PERMISION);
                    }
                    catch (Exception)
                    {
                        tmp.alta_permision = 0;
                    }
                    try
                    {
                        tmp.alta_content = reader.GetString(ALTA_USER_TYPE_CONTENT);
                    }
                    catch (Exception)
                    {
                        tmp.alta_content = "";
                    }
                    list_user.Add(tmp);
                }
            }
            return list_user;
        }

        public static List<alta_class_user> getListUser(MySqlDataReader reader)
        {
            List<alta_class_user> list_user = new List<alta_class_user>();
            while (reader.Read())
            {
                alta_class_user tmp = new alta_class_user();
                //alta_class_playlist tmp = new alta_class_playlist();
                if (!reader.IsDBNull(0))
                {
                    tmp.alta_id = reader.GetInt32(ALTA_USER_ID);
                    // if (!reader.IsDBNull(1))
                    tmp.alta_username = reader.GetString(ALTA_USER_NAME);
                    // if (!reader.IsDBNull(2))
                    tmp.alta_user_pass = reader.GetString(ALTA_USER_PASS);
                    // if (!reader.IsDBNull(3))
                    tmp.alta_full_name = reader.GetString(ALTA_USER_FULL_NAME);
                    // if (!reader.IsDBNull(4))
                    //  alta_class_user_type user_type = new alta_class_user_type();
                    // user_type.alta_id = reader.GetInt32(ALTA_USER_TYPE_ID);
                    // tmp.alta_type_user = user_type;
                    // if (!reader.IsDBNull(5))
                    tmp.alta_user_status = reader.GetBoolean(ALTA_USER_STATUS);
                    try
                    {
                        tmp.alta_email = reader.GetString(ALTA_USER_EMAIL);
                    }
                    catch (Exception)
                    {
                        tmp.alta_email = "";
                    }
                    try
                    {
                        tmp.alta_phone = reader.GetString(ALTA_USER_PHONE);
                    }
                    catch (Exception)
                    {
                        tmp.alta_phone = "";
                    }

                    // list_playlist.Add(tmp);
                    list_user.Add(tmp);
                }
            }
            return list_user;
        }
        public static alta_class_user getUser(MySqlDataReader reader)
        {
            alta_class_user tmp = new alta_class_user();
            while (reader.Read())
            {
                //alta_class_playlist tmp = new alta_class_playlist();
                if (!reader.IsDBNull(0))
                {
                    tmp.alta_id = reader.GetInt32(ALTA_USER_ID);
                    // if (!reader.IsDBNull(1))
                    tmp.alta_username = reader.GetString(ALTA_USER_NAME);
                    // if (!reader.IsDBNull(2))
                    tmp.alta_user_pass = reader.GetString(ALTA_USER_PASS);
                    // if (!reader.IsDBNull(3))
                    tmp.alta_full_name = reader.GetString(ALTA_USER_FULL_NAME);
                    // if (!reader.IsDBNull(4)) 
                    // alta_class_user_type user_type = new alta_class_user_type();
                    // user_type.alta_id = reader.GetInt32(ALTA_USER_TYPE_ID);
                    // tmp.alta_type_user = user_type;
                    // if (!reader.IsDBNull(5))
                    tmp.alta_user_status = reader.GetBoolean(ALTA_USER_STATUS);

                    try
                    {
                        tmp.alta_email = reader.GetString(ALTA_USER_EMAIL);
                    }
                    catch (Exception)
                    {
                        tmp.alta_email = "";
                    }
                    try
                    {
                        tmp.alta_phone = reader.GetString(ALTA_USER_PHONE);
                    }
                    catch (Exception)
                    {
                        tmp.alta_phone = "";
                    }
                    // list_playlist.Add(tmp);

                }
            }

            return tmp;
        }

        public static List<alta_class_playlist> getListPlaylist(MySqlDataReader reader, bool flagUser = false, bool flagDetails = false)
        {
            List<alta_class_playlist> list_playlist = new List<alta_class_playlist>();
            while (reader.Read())
            {
                alta_class_playlist tmp = new alta_class_playlist();
                if (!reader.IsDBNull(0))
                {
                    tmp.alta_id = reader.GetInt32(ALTA_PLAN_ID);
                    // if (!reader.IsDBNull(1))
                    tmp.alta_name = reader.GetString(ALTA_PLAN_NAME);
                    // if (!reader.IsDBNull(2))
                    tmp.alta_playlist_date_begin = reader.GetDateTime(ALTA_PLAN_DATE_BEGIN);
                    // if (!reader.IsDBNull(3))
                    tmp.alta_playlist_date_end = reader.GetDateTime(ALTA_PLAN_DATE_END);
                    // if (!reader.IsDBNull(4))
                    tmp.alta_status = reader.GetBoolean(ALTA_PLAN_STATUS);
                    // if (!reader.IsDBNull(5))
                    alta_class_user alta_user = new alta_class_user();
                    alta_user.alta_id = reader.GetInt32(ALTA_USER_ID);
                    tmp.alta_user = alta_user;

                    if (flagDetails)
                        tmp.LoadDetails();
                    // if (!reader.IsDBNull(6))
                    tmp.alta_playlist_time_create = reader.GetDateTime(ALTA_PLAN_CREATE);
                    // if (!reader.IsDBNull(7))
                    try
                    {
                        tmp.alta_content = reader.GetString(ALTA_PLAN_CONTENT);
                    }
                    catch (Exception ex)
                    {
                        tmp.alta_content = "";
                    }

                    list_playlist.Add(tmp);

                }
            }

            return list_playlist;
        }

        public static List<alta_class_media> getListMedia(MySqlDataReader reader, bool flag = false)
        {
            List<alta_class_media> list_media = new List<alta_class_media>();
            while (reader.Read())
            {
                alta_class_media tmp = new alta_class_media();
                if (!reader.IsDBNull(0))
                {
                    tmp.alta_id = reader.GetInt32(ALTA_MEDIA_ID);
                    // if (!reader.IsDBNull(1))
                    tmp.alta_name = reader.GetString(ALTA_MEDIA_NAME);
                    // if (!reader.IsDBNull(2))
                    tmp.alta_url = reader.GetString(ALTA_MEDIA_URL);
                    //   if (!reader.IsDBNull(3))
                    try
                    {
                        tmp.alta_content = reader.GetString(ALTA_MEDIA_CONTENT);
                    }
                    catch (Exception)
                    {
                        tmp.alta_content = "";
                    }

                    alta_class_media_type media_type = new alta_class_media_type();
                    media_type.alta_id = reader.GetInt32(ALTA_MEDIA_TYPE_ID);
                    tmp.alta_media_type = media_type;

                    // if (!reader.IsDBNull(5))
                    tmp.alta_media_time = reader.GetDateTime(ALTA_MEDIA_DATE);
                    //  if (reader.IsDBNull(6))
                    tmp.alta_media_status = reader.GetBoolean(ALTA_MEDIA_STATUS);

                    alta_class_user alta_user = new alta_class_user();
                    alta_user.alta_id = reader.GetInt32(ALTA_USER_ID);
                    tmp.alta_user = alta_user;

                    if (flag)
                    {
                        tmp.LoadPlaylist();
                    }
                    list_media.Add(tmp);

                }
            }
            return list_media;

        }
        public static List<alta_class_media_type> getListTypeMedia(MySqlDataReader reader)
        {
            List<alta_class_media_type> list_type_media = new List<alta_class_media_type>();
            while (reader.Read())
            {
                alta_class_media_type tmp = new alta_class_media_type();
                //alta_class_playlist tmp = new alta_class_playlist();
                if (!reader.IsDBNull(0))
                {
                    tmp.alta_id = reader.GetInt32(ALTA_MEDIA_TYPE_ID);
                    // if (!reader.IsDBNull(1))
                    tmp.alta_name = reader.GetString(ALTA_MEDIA_TYPE_NAME);
                    // if (!reader.IsDBNull(2))
                    try
                    {
                        tmp.alta_content = reader.GetString(ALTA_MEDIA_TYPE_CONTENT);
                    }
                    catch (Exception)
                    {
                        tmp.alta_content = "";
                    }

                    // list_playlist.Add(tmp);
                    list_type_media.Add(tmp);
                }
            }
            return list_type_media;
        }
        public static int del_Media_Item(alta_class_media item)
        {
            int r = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string insert_query = "DELETE FROM `am_media` WHERE `media_id`=@media_id";
                    using (MySqlCommand cmd = new MySqlCommand(insert_query, conn))
                    {
                        //cmd.Parameters.AddWithValue("@id_video", id);
                        cmd.Parameters.AddWithValue("@media_id", item.alta_id);
                        r = cmd.ExecuteNonQuery();

                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return r;

        }
        public static int delete_playlist(int id_playlist)
        {
            int r = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string insert_query = "DELETE FROM `am_plan` WHERE `plan_id`=@plan_id";
                    using (MySqlCommand cmd = new MySqlCommand(insert_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@plan_id", id_playlist);
                        r = cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return r;
        }

        public static alta_class_termiral getTermiral(MySqlDataReader reader)
        {
            alta_class_termiral tmp = new alta_class_termiral();
            while (reader.Read())
            {

                //alta_class_playlist tmp = new alta_class_playlist();
                if (!reader.IsDBNull(0))
                {
                    tmp.alta_id = reader.GetInt32(ALTA_TERMIRAL_ID);
                    // if (!reader.IsDBNull(1))
                    tmp.alta_name = reader.GetString(ALTA_TERMIRAL_NAME);
                    // if (!reader.IsDBNull(2))
                    tmp.alta_ip = reader.GetString(ALTA_TERMIRAL_IP);
                    // if (!reader.IsDBNull(3))
                    tmp.alta_status = reader.GetBoolean(ALTA_TERMIRAL_STATUS);
                    try
                    {
                        tmp.alta_content = reader.GetString(ALTA_TERMIRAL_CONTENT);
                    }
                    catch (Exception)
                    {
                        tmp.alta_content = "";
                    }
                    tmp.alta_pass = reader.GetString(ALTA_TERMIRAL_PASS);
                    // list_playlist.Add(tmp);

                }
            }
            return tmp;
        }

        public static alta_class_schedules getSchedule(MySqlDataReader reader)
        {
            alta_class_schedules tmp = new alta_class_schedules();
            while (reader.Read())
            {

                if (!reader.IsDBNull(0))
                {
                    tmp.alta_id = reader.GetInt32(ALTA_SCHEDULE_ID);
                    // if (!reader.IsDBNull(1))
                    alta_class_user user = new alta_class_user();
                    user.alta_id = reader.GetInt32(ALTA_USER_ID);
                    tmp.alta_user = user;
                    // if (!reader.IsDBNull(2))
                    alta_class_termiral termiral = new alta_class_termiral();
                    termiral.alta_id = reader.GetInt32(ALTA_TERMIRAL_ID);
                    tmp.alta_termiral = termiral;
                    // if (!reader.IsDBNull(3))
                    tmp.alta_schedules_date_begin = reader.GetDateTime(ALTA_SCHEDULE_DATE_BEGIN);
                    // if (!reader.IsDBNull(4))
                    tmp.alta_schedules_date_end = reader.GetDateTime(ALTA_SCHEDULE_DATE_END);
                    // if (!reader.IsDBNull(5))                   

                    try
                    {
                        tmp.alta_content = reader.GetString(ALTA_TERMIRAL_CONTENT);
                    }
                    catch (Exception)
                    {
                        tmp.alta_content = "";
                    }

                }
            }
            return tmp;
        }
        public alta_class_schedules_details getScheduleDetails(int id)
        {
            alta_class_schedules_details scheduleDetails = new alta_class_schedules_details();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string _query = "SELECT `schedules_details_id`, `schedules_id`, `plan_id`, `user_id`, `termiral_id`, `time_play` FROM `am_schedules_details` WHERE schedules_details_id=@id";
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                scheduleDetails = getScheduleDetails(reader);
                            }
                        }
                        else
                        {
                            scheduleDetails = null;
                        }
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {

            }

            return scheduleDetails;
        }

        private alta_class_schedules_details getScheduleDetails(MySqlDataReader reader)
        {
            alta_class_schedules_details scheduleDetails = new alta_class_schedules_details();
            while (reader.Read())
            {
                if (reader.IsDBNull(0))
                {
                    scheduleDetails.alta_id = reader.GetInt32(ALTA_SCHEDULE_DETAILS_ID);
                    alta_class_schedules schedule = new alta_class_schedules();
                    schedule.alta_id = reader.GetInt32(ALTA_SCHEDULE_ID);
                    scheduleDetails.alta_schedules = schedule;
                    alta_class_playlist playlist = new alta_class_playlist();
                    playlist.alta_id = reader.GetInt32(ALTA_PLAN_ID);
                   // alta_class_user user = new alta_class_user();
                 //   user.alta_id = reader.GetInt32(ALTA_USER_ID);
                    //scheduleDetails.alta_user = user;
                    scheduleDetails.alta_playlist = playlist;
                    scheduleDetails.alta_time_play = reader.GetDateTime(ALTA_SCHEDULE_DETAILS_TIME_PLAY);
                    scheduleDetails.alta_time_end = reader.GetDateTime(ALTA_SCHEDULE_DETAILS_TIME_END);

                }
            }
            return scheduleDetails;
        }
        public static alta_class_user getUser(int user_id)
        {
            alta_class_user user = new alta_class_user();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string _query = "SELECT `user_id`, `username`, `user_pass`, `full_name`,`user_email`, `user_phone`,`user_type_id`, `user_status` FROM `am_user` WHERE `user_id`=@user_id";
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", user_id);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                user = getUser(reader);
                            }
                        }
                        else
                        {
                            user = null;
                        }
                    }
                    conn.Close();
                }
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static alta_class_media getMedia(MySqlDataReader reader, bool flag = false)
        {
            alta_class_media media = new alta_class_media();
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    media.alta_id = reader.GetInt32(ALTA_MEDIA_ID);
                    // if (!reader.IsDBNull(1))
                    media.alta_name = reader.GetString(ALTA_MEDIA_NAME);
                    // if (!reader.IsDBNull(2))
                    media.alta_url = reader.GetString(ALTA_MEDIA_URL);
                    //   if (!reader.IsDBNull(3))
                    try
                    {
                        media.alta_content = reader.GetString(ALTA_MEDIA_CONTENT);
                    }
                    catch (Exception)
                    {
                        media.alta_content = "";
                    }
                    if (flag)
                    {
                        media.LoadMediaType(reader.GetInt32(ALTA_MEDIA_TYPE_ID));
                    }
                    else
                    {
                        alta_class_media_type media_type = new alta_class_media_type();
                        media_type.alta_id = reader.GetInt32(ALTA_MEDIA_TYPE_ID);
                        media.alta_media_type = media_type;
                    }

                    // if (!reader.IsDBNull(5))
                    media.alta_media_time = reader.GetDateTime(ALTA_MEDIA_DATE);
                    //  if (reader.IsDBNull(6))
                    media.alta_media_status = reader.GetBoolean(ALTA_MEDIA_STATUS);

                    alta_class_user alta_user = new alta_class_user();
                    alta_user.alta_id = reader.GetInt32(ALTA_USER_ID);
                    media.alta_user = alta_user;

                    //list_media.Add(tmp);

                }
            }
            return media;
        }

        public static alta_class_media_type getMediaType(MySqlDataReader reader)
        {
            alta_class_media_type tmp = new alta_class_media_type();
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    tmp.alta_id = reader.GetInt32(ALTA_MEDIA_TYPE_ID);
                    // if (!reader.IsDBNull(1))
                    tmp.alta_name = reader.GetString(ALTA_MEDIA_TYPE_NAME);
                    // if (!reader.IsDBNull(2))
                    try
                    {
                        tmp.alta_content = reader.GetString(ALTA_MEDIA_TYPE_CONTENT);
                    }
                    catch (Exception)
                    {
                        tmp.alta_content = "";
                    }
                }
            }
            return tmp;
        }

        public static alta_class_media getMedia(int id, bool flag = false)
        {
            alta_class_media media = new alta_class_media();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string insert_query = "SELECT `media_id`, `media_name`, `media_url`, `media_content`, `media_type_id`, `media_date`, `media_status`, `user_id` FROM `am_media` WHERE `media_id`=@media_id";
                    using (MySqlCommand cmd = new MySqlCommand(insert_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@media_id", id);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                media = mysql_alta_helpper.getMedia(reader, flag);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return media;
        }

        public static alta_class_user getUser(MySqlDataReader reader, bool p = false)
        {
            alta_class_user tmp = new alta_class_user();
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    tmp.alta_id = reader.GetInt32(ALTA_USER_ID);
                    // if (!reader.IsDBNull(1))
                    tmp.alta_username = reader.GetString(ALTA_USER_NAME);
                    // if (!reader.IsDBNull(2))
                    tmp.alta_user_pass = reader.GetString(ALTA_USER_PASS);
                    // if (!reader.IsDBNull(3))
                    tmp.alta_full_name = reader.GetString(ALTA_USER_FULL_NAME);
                    // if (!reader.IsDBNull(4))
                    if (p)
                    {
                        // tmp.alta_type_user = getUserType(reader.GetInt32(ALTA_USER_TYPE_ID));
                    }
                    else
                    {
                        //  alta_class_user_type user_type = new alta_class_user_type();
                        // user_type.alta_id = reader.GetInt32(ALTA_USER_TYPE_ID);
                        // tmp.alta_type_user = user_type;
                    }
                    // if (!reader.IsDBNull(5))
                    tmp.alta_user_status = reader.GetBoolean(ALTA_USER_STATUS);
                    try
                    {
                        tmp.alta_email = reader.GetString(ALTA_USER_EMAIL);
                    }
                    catch (Exception)
                    {
                        tmp.alta_email = "";
                    }
                    try
                    {
                        tmp.alta_phone = reader.GetString(ALTA_USER_PHONE);

                    }
                    catch (Exception)
                    {
                        tmp.alta_phone = "";
                    }
                    // list_playlist.Add(tmp);

                }
            }
            return tmp;
        }

        public static alta_class_user_type getUserType(int p)
        {
            alta_class_user_type user_type = new alta_class_user_type();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string insert_query = "SELECT `user_type_id`, `name_type`, `content` FROM `am_user_type` WHERE `user_type_id`=@type_user";
                    using (MySqlCommand cmd = new MySqlCommand(insert_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@type_user", p);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                user_type = mysql_alta_helpper.getUserType(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return user_type;
        }
        public static alta_class_user_type getTypeOfUser(int p)
        {
            alta_class_user_type user_type = new alta_class_user_type();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string insert_query = "SELECT A.* FROM `am_user_type` A, `am_user` B WHERE A.`user_type_id`=B.user_type_id and B.user_id=@user_id";
                    using (MySqlCommand cmd = new MySqlCommand(insert_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", p);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                user_type = mysql_alta_helpper.getUserType(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return user_type;
        }

        private static alta_class_user_type getUserType(MySqlDataReader reader)
        {
            alta_class_user_type tmp = new alta_class_user_type();
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {

                    tmp.alta_id = reader.GetInt32(ALTA_USER_TYPE_ID);
                    tmp.alta_name = reader.GetString(ALTA_USER_TYPE_NAME);
                    try
                    {
                        tmp.alta_permision = reader.GetInt32(ALTA_USER_TYPE_PERMISION);
                    }
                    catch (Exception ex)
                    {
                        tmp.alta_permision = 0;
                    }
                    try
                    {
                        tmp.alta_content = reader.GetString(ALTA_USER_TYPE_CONTENT);
                    }
                    catch (Exception)
                    {
                        tmp.alta_content = "";
                    }
                }
            }
            return tmp;
        }

        public static List<alta_class_playlist> getListPlaylistofMedia(int p)
        {
            List<alta_class_playlist> playlist = new List<alta_class_playlist>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string insert_query = "SELECT A.* FROM `am_plan` A,am_plan_details B WHERE A.plan_id=B.plan_id and B.media_id=@media_id";
                    using (MySqlCommand cmd = new MySqlCommand(insert_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@media_id", p);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                playlist = mysql_alta_helpper.getListPlaylist(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }

            return playlist;
        }

        public static alta_class_media checkMedia(bool p, alta_class_media mediaItem)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string insert_query = "UPDATE `am_media` SET`media_status`=@media_status WHERE `media_id`=@media_id";
                    using (MySqlCommand cmd = new MySqlCommand(insert_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@media_id", mediaItem.alta_id);
                        cmd.Parameters.AddWithValue("@media_status", p);
                        var tmp = cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                mediaItem.alta_media_status = p;
            }
            catch (Exception ex)
            {

            }
            return mediaItem;
        }

        public static List<alta_class_termiral> getListTerminal(MySqlDataReader reader)
        {
            List<alta_class_termiral> list_Terminal = new List<alta_class_termiral>();
            while (reader.Read())
            {
                alta_class_termiral tmp = new alta_class_termiral();
                if (!reader.IsDBNull(0))
                {
                    tmp.alta_id = reader.GetInt32(ALTA_TERMIRAL_ID);
                    // if (!reader.IsDBNull(1))
                    tmp.alta_name = reader.GetString(ALTA_TERMIRAL_NAME);
                    // if (!reader.IsDBNull(2))
                    tmp.alta_ip = reader.GetString(ALTA_TERMIRAL_IP);
                    // if (!reader.IsDBNull(3))
                    tmp.alta_status = reader.GetBoolean(ALTA_TERMIRAL_STATUS);
                    try
                    {
                        tmp.alta_content = reader.GetString(ALTA_TERMIRAL_CONTENT);
                    }
                    catch (Exception)
                    {
                        tmp.alta_content = "";
                    }
                    tmp.alta_pass = reader.GetString(ALTA_TERMIRAL_PASS);
                    list_Terminal.Add(tmp);

                }
            }
            return list_Terminal;
        }

        public static void changeStatusPlaylist(ref alta_class_playlist playlist)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string insert_query = "UPDATE `am_plan` SET`plan_status`=@plan_status WHERE `plan_id`=@plan_id";
                    using (MySqlCommand cmd = new MySqlCommand(insert_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@plan_id", playlist.alta_id);
                        cmd.Parameters.AddWithValue("@plan_status", !playlist.alta_status);
                        var tmp = cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                playlist.alta_status = !playlist.alta_status;
            }
            catch (Exception ex)
            {

            }
        }

        public static List<alta_class_playlist> SearchPlaylist(ref int total, string key_search, int from = -1, int num = -1, int user_id = -1, string sort = "", bool status = false)
        {
            List<alta_class_playlist> playlist = new List<alta_class_playlist>();

            String sql = "SELECT `plan_id`, `plan_name`, `plan_date_begin`, `plan_date_end`, `plan_status`, `user_id`, `plan_time_create`, `plan_content` FROM `am_plan`";
            String where = " WHERE `plan_name` like '%" + key_search + "%'";
            if (user_id != -1)
                where += " and user_id=@user_id";

            if (status)
            {
                where += " and plan_status=@status";
            }
            sql += where;
            sql += sort;
            if (from != -1 && num != -1)
            {
                sql += " Limit @from, @num";
            }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // cmd.Parameters.AddWithValue("@key", key_search);
                        if (user_id != -1)
                        {
                            cmd.Parameters.AddWithValue("@user_id", user_id);
                        }

                        if (status)
                        {
                            cmd.Parameters.AddWithValue("@status", status);
                        }
                        if (from != -1 && num != -1)
                        {
                            cmd.Parameters.AddWithValue("@from", from);
                            cmd.Parameters.AddWithValue("@num", num);
                        }
                        total = getCount("am_plan", where, cmd.Parameters);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                playlist = getListPlaylist(reader, true);
                            }
                        }

                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return playlist;
        }
        public static List<alta_class_termiral> getListTerminal(ref int total, int user_id, string sort = "", bool status = false, int from = -1, int num = -1)
        {
            List<alta_class_termiral> terminal = new List<alta_class_termiral>();
            String sql = "SELECT A.`termiral_id`, A.`termiral_name`, A.`termiral_ip`, A.`termiral_content`, A.`termiral_status`, A.`termiral_pass` FROM `am_termiral` A, `am_schedules` B ";
            String where = " WHERE A.termiral_id=B.termiral_id";
            if (status)
                where += " AND A.termiral_status= 1 ";
            if (user_id > 0)
            {
                where += " AND B.user_id=@user_id";
            }
            sql += where + sort;
            if (from != -1 && num != -1)
            {
                sql += " LIMIT @from , @num";
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        if (from != -1 && num != -1)
                        {
                            cmd.Parameters.AddWithValue("@from", from);
                            cmd.Parameters.AddWithValue("@num", num);
                        }
                        if (user_id > 0)
                            cmd.Parameters.AddWithValue("@user_id", user_id);
                        total = getCount("`am_termiral` A, `am_schedules` B", where, cmd.Parameters);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                terminal = getListTerminal(reader);
                            }
                        }
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {

            }
            return terminal;

        }

        public static alta_class_user getUser(alta_class_termiral t)
        {
            if (t != null)
            {
                alta_class_user user = new alta_class_user();
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string _query = "SELECT A.`user_id`, A.`username`, A.`user_pass`, A.`full_name`, A.`user_type_id`, A.`user_status` FROM `am_user` A, `am_schedules_details`B WHERE B.termiral_id=@id and B.user_id=A.user_id";
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", t.alta_id);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                user = getUser(reader);
                            }
                        }
                        else
                        {
                            user = null;
                        }
                    }
                    conn.Close();
                }

                return user;
            }
            else
            {
                return null;
            }
        }
        public static alta_class_user getUser(alta_class_termiral t, DateTime time)
        {
            if (t != null)
            {
                alta_class_user user = new alta_class_user();
                String timeStr = String.Format("{0:yyyy-MM-dd}", time);
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string _query = "SELECT A.`user_id`, A.`username`, A.`user_pass`, A.`full_name`, A.`user_type_id`, A.`user_status`,A.`user_phone`,A.`user_email` FROM `am_user` A, `am_schedules_details` B";
                    _query += " WHERE B.termiral_id=@id and B.user_id=A.user_id and (DATE_FORMAT(B.time_play,'%Y-%m-%d')<=DATE_FORMAT(@time,'%Y-%m-%d') and DATE_FORMAT(B.time_end,'%Y-%m-%d')>=DATE_FORMAT(@time,'%Y-%m-%d'))";
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", t.alta_id);
                        cmd.Parameters.AddWithValue("@time", time);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                user = getUser(reader);
                            }
                        }
                        else
                        {
                            user = null;
                        }
                    }
                    conn.Close();
                }

                return user;
            }
            else
            {
                return null;
            }
        }
        public static List<alta_class_termiral> getListTerminal(ref int total, string sort = "", bool status = false, int from = -1, int num = -1)
        {
            List<alta_class_termiral> terminal = new List<alta_class_termiral>();
            String sql = "SELECT `termiral_id`, `termiral_name`, `termiral_ip`, `termiral_content`, `termiral_status`, `termiral_pass` FROM `am_termiral` ";
            String where = " WHERE 1";
            if (status)
                where += " AND termiral_status= 1";
            sql += where + sort;
            if (from != -1 && num != -1)
            {
                sql += " LIMIT @from , @num";
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        if (from != -1 && num != -1)
                        {
                            cmd.Parameters.AddWithValue("@from", from);
                            cmd.Parameters.AddWithValue("@num", num);
                        }
                        total = getCount("am_termiral", where, cmd.Parameters);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                terminal = getListTerminal(reader);
                            }
                        }
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {

            }
            return terminal;

        }
        /// <summary>
        /// fix lai
        /// </summary>
        /// <param name="id_terminal"></param>
        /// <param name="id_user"></param>
        /// <returns></returns>
        public static alta_class_schedules getSchedule(int id_terminal, int id_user)
        {
            alta_class_schedules schedule = new alta_class_schedules();
            String _query = "SELECT `schedules_id`, `user_id`, `termiral_id`, `schedules_date_begin`, `schedules_date_end`, `schedules_content` FROM `am_schedules` WHERE `user_id`=@user_id and termiral_id=@termiral_id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", id_user);
                        cmd.Parameters.AddWithValue("@termiral_id", id_terminal);
                        // cmd.Parameters.AddWithValue("@timeplay", DateTime.Now.Date);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                schedule = getSchedule(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return schedule;
        }
        public static void addPlaylistToTerminal(int playlist_id, int terminal_id, DateTime timePlay, DateTime timeEnd, alta_class_schedules schedule=null)
        {
            if (schedule==null)
                schedule = getSchedule(terminal_id, CommonUtilities.alta_curUser.alta_id);

            String _query = "INSERT INTO `am_schedules_details`( `schedules_id`, `plan_id`, `user_id`, `termiral_id`,`time_play`,`time_end`) VALUES (@schedule_id,@plan_id,@user_id,@terminal_id,@time_play,@time_end)";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@schedule_id", schedule.alta_id);
                        cmd.Parameters.AddWithValue("@plan_id", playlist_id);
                        cmd.Parameters.AddWithValue("@user_id", schedule.alta_user.alta_id);
                        cmd.Parameters.AddWithValue("@terminal_id", terminal_id);
                        cmd.Parameters.AddWithValue("@time_play", timePlay.Date);
                        cmd.Parameters.AddWithValue("@time_end", timeEnd.Date);
                        int tmp = cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static List<alta_class_user> getListUser(ref int total, string sort = "", bool status = false, int from = -1, int num = -1)
        {
            List<alta_class_user> list_user = new List<alta_class_user>();
            String _query = "SELECT `user_id`, `username`, `user_pass`, `full_name`, `user_type_id`, `user_status`,`user_email`,`user_phone` FROM `am_user`";
            String where = " WHERE 1";
            if (status)
            {
                where += " and user_status=@status";
            }
            _query += where;
            if (sort != string.Empty)
            {
                _query += sort;
            }
            if (from != -1 && num != -1)
            {
                _query += " LIMIT @from , @num";
            }
           
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        if (status)
                        {
                            cmd.Parameters.AddWithValue("@status",status);
                        }
                        if (from != -1 && num != -1)
                        {
                            cmd.Parameters.AddWithValue("@from", from);
                            cmd.Parameters.AddWithValue("@num", num);
                        }
                        total = getCount("`am_user`", where, cmd.Parameters);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                list_user = getListUser(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }

            return list_user;
        }

        public static bool setStatus_User(int p, bool f)
        {
            String _query = "UPDATE  `am_user` SET  `user_status` =  @status WHERE  `user_id` =@id_user;";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", f);
                        cmd.Parameters.AddWithValue("@id_user", p);
                        var tmp = cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public static bool delete_user(int p)
        {
            String _query = "DELETE FROM `am_user` WHERE  `user_id` =@id_user;";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        //  cmd.Parameters.AddWithValue("@status", f);
                        cmd.Parameters.AddWithValue("@id_user", p);
                        var tmp = cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public static List<alta_class_user_type> getListTypeUser()
        {
            List<alta_class_user_type> list_type = new List<alta_class_user_type>();
            String _query = "SELECT `user_type_id`, `name_type`, `content` FROM `am_user_type`;";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                list_type = getListTypeUser(reader);
                            }
                        }
                    }
                    conn.Close();
                }
                //return true;
            }
            catch (Exception ex)
            {

            }
            // return false;

            return list_type;
        }

        public static List<alta_class_user> SearchUser(ref int total, String key, string sort = "", bool status = false, int from = -1, int num = -1)
        {
            List<alta_class_user> list_user = new List<alta_class_user>();
            String _query = "SELECT `user_id`, `username`, `user_pass`, `full_name`, `user_email`, `user_phone`, `user_type_id`, `user_status` FROM `am_user`";
            String where = " WHERE (username like '%" + key + "%' or full_name like '%" + key + "%')";
            if (status)
            {
                where += " and user_status=1";
            }
            _query += where;
            if (num > -1 && from > -1)
            {
                _query += " LIMIT @from , @num";
            }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        if (num > -1 && from > -1)
                        {
                            cmd.Parameters.AddWithValue("@from", from);
                            cmd.Parameters.AddWithValue("@num", num);
                        }
                        var tmp = cmd.ExecuteScalar();

                        total = getCount("am_user", where, cmd.Parameters);
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                list_user = getListUser(reader);
                            }
                        }
                    }
                    conn.Close();
                }
                //return true;
            }
            catch (Exception ex)
            {

            }
            return list_user;
        }

        public static void connectUserTermiral(int user_id, int termiral_id, DateTime stdTime, DateTime endTime)
        {
            String _query = "INSERT INTO `am_schedules`(`user_id`, `termiral_id`, `schedules_date_begin`, `schedules_date_end`, `schedules_content`) VALUES (@user_id,@termiral_id,@beginDate,@endDate,@content)";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.Parameters.AddWithValue("@termiral_id", termiral_id);
                        cmd.Parameters.AddWithValue("@beginDate", stdTime);
                        cmd.Parameters.AddWithValue("@endDate", endTime);
                        cmd.Parameters.AddWithValue("@content", DateTime.Now.ToString());
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                //return true;
            }
            catch (Exception ex)
            {

            }
        }

        public static bool checkTimeScheDule(DateTime timeBegin, DateTime timeEnd, int termiral_id)
        {
            bool flag = false; ;
            string _query = "Select `schedules_id` From `am_schedules` WHERE `termiral_id`=@termiral_id";
            _query += " and((DATE_FORMAT(`schedules_date_begin`,'%Y-%m-%d')<= DATE_FORMAT(@dateBegin,'%Y-%m-%d') and DATE_FORMAT(`schedules_date_end`,'%Y-%m-%d')>= DATE_FORMAT(@dateBegin,'%Y-%m-%d'))";
            _query += " OR (DATE_FORMAT(`schedules_date_begin`,'%Y-%m-%d')<= DATE_FORMAT(@dateEnd,'%Y-%m-%d') and DATE_FORMAT(`schedules_date_end`,'%Y-%m-%d')>= DATE_FORMAT(@dateEnd,'%Y-%m-%d'))";
            _query += " OR (DATE_FORMAT(`schedules_date_begin`,'%Y-%m-%d')<= DATE_FORMAT(@dateBegin,'%Y-%m-%d') and DATE_FORMAT(`schedules_date_end`,'%Y-%m-%d')>= DATE_FORMAT(@dateEnd,'%Y-%m-%d'))";
            _query += " OR (DATE_FORMAT(`schedules_date_begin`,'%Y-%m-%d')>= DATE_FORMAT(@dateBegin,'%Y-%m-%d') and DATE_FORMAT(`schedules_date_end`,'%Y-%m-%d')<= DATE_FORMAT(@dateEnd,'%Y-%m-%d')))";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        // cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.Parameters.AddWithValue("@termiral_id", termiral_id);
                        cmd.Parameters.AddWithValue("@dateBegin", timeBegin);
                        cmd.Parameters.AddWithValue("@dateEnd", timeEnd);
                        //cmd.Parameters.AddWithValue("@content", DateTime.Now.ToString());
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                            flag = false;
                        else
                            flag = true;
                    }
                    conn.Close();
                }
                //return true;
            }
            catch (Exception ex)
            {

            }
            return flag;
        }
      


        public static List<alta_class_schedules> getListScheduleofMonth(DateTime dateTime)
        {
            List<alta_class_schedules> list_schedule = new List<alta_class_schedules>();
            String _query = "SELECT `schedules_id`, `user_id`, `termiral_id`, `schedules_date_begin`, `schedules_date_end`, `schedules_content` FROM `am_schedules` WHERE DATE_FORMAT(`schedules_date_begin`,'%Y-%m')=DATE_FORMAT(@month,'%Y-%m') or DATE_FORMAT(`schedules_date_end`,'%Y-%m')=DATE_FORMAT(@month,'%Y-%m')";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        // cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.Parameters.AddWithValue("@month", dateTime);
                        //cmd.Parameters.AddWithValue("@content", DateTime.Now.ToString());
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                list_schedule = getListSchedule(reader);
                            }
                        }
                    }
                    conn.Close();
                }
                //return true;
            }
            catch (Exception ex)
            {

            }
            return list_schedule;
        }
        public static List<alta_class_schedules> getListScheduleofMonth(DateTime dateTimeBegin, DateTime dateTimeEnd)
        {
            List<alta_class_schedules> list_schedule = new List<alta_class_schedules>();
            String _query = "SELECT `schedules_id`, `user_id`, `termiral_id`, `schedules_date_begin`, `schedules_date_end`, `schedules_content` FROM `am_schedules` WHERE ";
            _query += "(DATE_FORMAT(`schedules_date_begin`,'%Y-%m-%d')>=DATE_FORMAT(@Timebegin,'%Y-%m-%d') and DATE_FORMAT(`schedules_date_end`,'%Y-%m-%d')>=DATE_FORMAT(@TimeEnd,'%Y-%m-%d'))";
            _query += " or (DATE_FORMAT(`schedules_date_begin`,'%Y-%m-%d')<=DATE_FORMAT(@Timebegin,'%Y-%m-%d') and DATE_FORMAT(`schedules_date_end`,'%Y-%m-%d')>=DATE_FORMAT(@Timebegin,'%Y-%m-%d'))";
            _query += " or (DATE_FORMAT(`schedules_date_begin`,'%Y-%m-%d')<=DATE_FORMAT(@TimeEnd,'%Y-%m-%d') and DATE_FORMAT(`schedules_date_end`,'%Y-%m-%d')>=DATE_FORMAT(@TimeEnd,'%Y-%m-%d'))";
            _query += " or (DATE_FORMAT(`schedules_date_begin`,'%Y-%m-%d')>=DATE_FORMAT(@Timebegin,'%Y-%m-%d') and DATE_FORMAT(`schedules_date_end`,'%Y-%m-%d')<=DATE_FORMAT(@TimeEnd,'%Y-%m-%d'))";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        // cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.Parameters.AddWithValue("@Timebegin", dateTimeBegin);
                        cmd.Parameters.AddWithValue("@TimeEnd", dateTimeEnd);
                        //cmd.Parameters.AddWithValue("@content", DateTime.Now.ToString());
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                list_schedule = getListSchedule(reader);
                            }
                        }
                    }
                    conn.Close();
                }
                //return true;
            }
            catch (Exception ex)
            {

            }
            return list_schedule;
        }

        private static List<alta_class_schedules> getListSchedule(MySqlDataReader reader)
        {
            List<alta_class_schedules> list_schedule = new List<alta_class_schedules>();
            while (reader.Read())
            {
                alta_class_schedules tmp = new alta_class_schedules();
                if (!reader.IsDBNull(0))
                {
                    tmp.alta_id = reader.GetInt32(ALTA_SCHEDULE_ID);
                    // if (!reader.IsDBNull(1))
                    alta_class_user user = new alta_class_user();
                    user.alta_id = reader.GetInt32(ALTA_USER_ID);
                    tmp.alta_user = user;
                    // if (!reader.IsDBNull(2))
                    alta_class_termiral termiral = new alta_class_termiral();
                    termiral.alta_id = reader.GetInt32(ALTA_TERMIRAL_ID);
                    tmp.alta_termiral = termiral;
                    // if (!reader.IsDBNull(3))
                    tmp.alta_schedules_date_begin = reader.GetDateTime(ALTA_SCHEDULE_DATE_BEGIN);
                    // if (!reader.IsDBNull(4))
                    tmp.alta_schedules_date_end = reader.GetDateTime(ALTA_SCHEDULE_DATE_END);
                    // if (!reader.IsDBNull(5))                   

                    try
                    {
                        tmp.alta_content = reader.GetString(ALTA_TERMIRAL_CONTENT);
                    }
                    catch (Exception)
                    {
                        tmp.alta_content = "";
                    }
                    list_schedule.Add(tmp);

                }
            }
            return list_schedule;
        }

        public static alta_class_termiral getTermiral(int _alta_terminal_id)
        {
            alta_class_termiral terminal = new alta_class_termiral();
            String _query = "SELECT `termiral_id`, `termiral_name`, `termiral_ip`, `termiral_content`, `termiral_status`, `termiral_pass` FROM `am_termiral` WHERE `termiral_id`=@terminal_id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        // cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.Parameters.AddWithValue("@terminal_id", _alta_terminal_id);
                        //cmd.Parameters.AddWithValue("@content", DateTime.Now.ToString());
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                terminal = getTermiral(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
            return terminal;
        }

        public static List<alta_class_playlist_details> getListPlayListDetails(int IDPlaylist)
        {
            List<alta_class_playlist_details> list_playlist = new List<alta_class_playlist_details>();
            String _query = "SELECT `detail_plan_id`, `plan_id`, `media_id`, `time_play`, `time_end`, `time_create` FROM `am_plan_details` WHERE `plan_id`=@plan_id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        // cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.Parameters.AddWithValue("@plan_id", IDPlaylist);
                        //cmd.Parameters.AddWithValue("@content", DateTime.Now.ToString());
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                list_playlist = getListPlayListDetails(reader, true);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
            return list_playlist;
        }
        public static void UpdatePlaylistDetails(int idMedia, int idDetails, DateTime stdTime, DateTime etdTime)
        {
            String _query = "UPDATE `am_plan_details` SET `media_id`=@media_id,`time_play`=@stdTime,`time_end`=@etdTime WHERE `detail_plan_id`=@details";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        // cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.Parameters.AddWithValue("@details", idDetails);
                        cmd.Parameters.AddWithValue("@media_id", idMedia);
                        cmd.Parameters.AddWithValue("@stdTime", stdTime);
                        cmd.Parameters.AddWithValue("@etdTime", etdTime);
                        //cmd.Parameters.AddWithValue("@content", DateTime.Now.ToString());
                        cmd.ExecuteNonQuery();

                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
        }
        public static void delete_playlist_Details(int idDetails)
        {
            String _query = "DELETE FROM `am_plan_details` WHERE `detail_plan_id`=@details";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        // cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.Parameters.AddWithValue("@details", idDetails);

                        //cmd.Parameters.AddWithValue("@content", DateTime.Now.ToString());
                        cmd.ExecuteNonQuery();

                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
        }
        public static bool checkFreeTimeOfPlaylist(int id_playlist,DateTime? stdTime = null, DateTime? etdTime = null, int idPlaylist = 0)
        {
            String _query = "SELECT `detail_plan_id` FROM `am_plan_details` Where `plan_id`=@plan_id ";
            _query += " and ((DATE_FORMAT(time_play,'%H%i')<= DATE_FORMAT(@dateBegin,'%H%i') and DATE_FORMAT(time_end,'%H%i')>= DATE_FORMAT(@dateBegin,'%H%i'))";
            _query += " or (DATE_FORMAT(time_play,'%H%i')<= DATE_FORMAT(@dateEnd,'%H%i') and DATE_FORMAT(time_end,'%H%i')>= DATE_FORMAT(@dateEnd,'%H%i'))";
            _query += " or (DATE_FORMAT(time_play,'%H%i')<= DATE_FORMAT(@dateBegin,'%H%i') and DATE_FORMAT(time_end,'%H%i')>= DATE_FORMAT(@dateEnd,'%H%i'))";
            _query += " or (DATE_FORMAT(time_play,'%H%i')>= DATE_FORMAT(@dateBegin,'%H%i') and DATE_FORMAT(time_end,'%H%i')<= DATE_FORMAT(@dateEnd,'%H%i')))";
            _query += " and detail_plan_id<>@detail_plan_id";
            bool flag = false;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@plan_id", id_playlist);
                        cmd.Parameters.AddWithValue("@dateBegin", stdTime);
                        cmd.Parameters.AddWithValue("@dateEnd", etdTime);
                        cmd.Parameters.AddWithValue("@detail_plan_id", idPlaylist);
                        //cmd.Parameters.AddWithValue("@content", DateTime.Now.ToString());
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }
        public static alta_class_user getUserOfPlaylist(int playlist)
        {
            alta_class_user user = new alta_class_user();
            String _query = "SELECT A.`user_id`, A.`username`, A.`user_pass`, A.`full_name`, A.`user_email`, A.`user_phone`, A.`user_type_id`, A.`user_status`, A.`user_time_create` FROM `am_user` A, `am_plan` B WHERE A.`user_id`=B.`user_id` and B.`plan_id`=@plan_id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        // cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.Parameters.AddWithValue("@plan_id", playlist);
                        //cmd.Parameters.AddWithValue("@content", DateTime.Now.ToString());
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                user = getUser(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
            return user;
        }

        public static void delete_termiral(int id_terminal)
        {
            if (id_terminal != 0)
            {
                String _query = "DELETE FROM `am_termiral` WHERE `termiral_id` =@termiral_id";
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                        {
                            // cmd.Parameters.AddWithValue("@user_id", user_id);
                            cmd.Parameters.AddWithValue("@termiral_id", id_terminal);
                            //cmd.Parameters.AddWithValue("@content", DateTime.Now.ToString());
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }
                catch (Exception)
                {

                }
            }
        }
        internal static alta_class_playlist getScheduleDetails(int idTerminal, DateTime dateTime)
        {
            alta_class_playlist playlist = new alta_class_playlist();
            // DATE_FORMAT(B.time_play,'%Y-%m-%d')
            String _query = "SELECT A.* FROM `am_plan` A, `am_schedules_details` B WHERE B.`termiral_id` =@termiral_id and DATE_FORMAT(B.`time_play`,'%Y-%m-%d')<=DATE_FORMAT(@dateTime,'%Y-%m-%d') and DATE_FORMAT(B.`time_end`,'%Y-%m-%d') >= DATE_FORMAT(@dateTime,'%Y-%m-%d') and A.plan_id=B.plan_id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        // cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.Parameters.AddWithValue("@termiral_id", idTerminal);
                        cmd.Parameters.AddWithValue("@dateTime", dateTime);
                        //cmd.Parameters.AddWithValue("@content", DateTime.Now.ToString());
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                playlist = getPlaylist(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
            return playlist;
        }

        private static alta_class_playlist getPlaylist(MySqlDataReader reader, bool flagDetails = false)
        {
            alta_class_playlist tmp = new alta_class_playlist();
            while (reader.Read())
            {

                if (!reader.IsDBNull(0))
                {
                    tmp.alta_id = reader.GetInt32(ALTA_PLAN_ID);
                    // if (!reader.IsDBNull(1))
                    tmp.alta_name = reader.GetString(ALTA_PLAN_NAME);
                    // if (!reader.IsDBNull(2))
                    tmp.alta_playlist_date_begin = reader.GetDateTime(ALTA_PLAN_DATE_BEGIN);
                    // if (!reader.IsDBNull(3))
                    tmp.alta_playlist_date_end = reader.GetDateTime(ALTA_PLAN_DATE_END);
                    // if (!reader.IsDBNull(4))
                    tmp.alta_status = reader.GetBoolean(ALTA_PLAN_STATUS);
                    // if (!reader.IsDBNull(5))
                    alta_class_user alta_user = new alta_class_user();
                    alta_user.alta_id = reader.GetInt32(ALTA_USER_ID);
                    tmp.alta_user = alta_user;

                    if (flagDetails)
                        tmp.LoadDetails();
                    // if (!reader.IsDBNull(6))
                    tmp.alta_playlist_time_create = reader.GetDateTime(ALTA_PLAN_CREATE);
                    // if (!reader.IsDBNull(7))
                    try
                    {
                        tmp.alta_content = reader.GetString(ALTA_PLAN_CONTENT);
                    }
                    catch (Exception ex)
                    {
                        tmp.alta_content = "";
                    }



                }
            }
            return tmp;
        }
        public static alta_class_terminal_type getTypeTerminal(alta_class_termiral terminal)
        {
            if (terminal != null)
            {
                alta_class_terminal_type type = new alta_class_terminal_type();
                String _query = "SELECT A.* FROM `am_terminal_type` A, `am_termiral` B WHERE B.termiral_id=@id_terminal and B.terminal_type_id=A.terminal_type_id";
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                        {
                            // cmd.Parameters.AddWithValue("@user_id", user_id);
                            cmd.Parameters.AddWithValue("@id_terminal", terminal.alta_id);
                            //  cmd.Parameters.AddWithValue("@dateTime", dateTime);
                            //cmd.Parameters.AddWithValue("@content", DateTime.Now.ToString());
                            var tmp = cmd.ExecuteScalar();
                            if (Convert.ToInt32(tmp) > 0)
                            {
                                using (MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    type = getTypeTerminal(reader);
                                }
                            }
                        }
                        conn.Close();
                    }
                }
                catch (Exception)
                {

                }
                return type;
            }
            return null;
        }
        public static alta_class_terminal_type getTypeTerminal(int idTypeTerminal)
        {
            if (idTypeTerminal > 0)
            {
                alta_class_terminal_type type = new alta_class_terminal_type();
                String _query = "SELECT * FROM `am_terminal_type`  WHERE terminal_type_id=@id_type";
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                        {
                            // cmd.Parameters.AddWithValue("@user_id", user_id);
                            cmd.Parameters.AddWithValue("@id_type", idTypeTerminal);
                            //  cmd.Parameters.AddWithValue("@dateTime", dateTime);
                            //cmd.Parameters.AddWithValue("@content", DateTime.Now.ToString());
                            var tmp = cmd.ExecuteScalar();
                            if (Convert.ToInt32(tmp) > 0)
                            {
                                using (MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    type = getTypeTerminal(reader);
                                }
                            }
                        }
                        conn.Close();
                    }
                }
                catch (Exception)
                {

                }
                return type;
            }
            return null;
        }
        public static List<alta_class_terminal_type> getListTypeTerminal()
        {
            List<alta_class_terminal_type> type = new List<alta_class_terminal_type>();
            String _query = "SELECT * FROM `am_terminal_type`";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                type = getListTypeTerminal(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
            return type;

        }

        private static alta_class_terminal_type getTypeTerminal(MySqlDataReader reader)
        {
            alta_class_terminal_type type = new alta_class_terminal_type();
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    type.alta_id = reader.GetInt32(ALTA_TERMIRAL_TYPE_ID);
                    // if (!reader.IsDBNull(1))
                    type.alta_name = reader.GetString(ALTA_TERMIRAL_TYPE_NAME);
                    // if (!reader.IsDBNull(2))                  
                    try
                    {
                        type.alta_content = reader.GetString(ALTA_TERMIRAL_TYPE_CONTENT);
                    }
                    catch (Exception ex)
                    {
                        type.alta_content = "";
                    }
                }
            }
            return type;
        }
        private static List<alta_class_terminal_type> getListTypeTerminal(MySqlDataReader reader)
        {
            List<alta_class_terminal_type> list_type = new List<alta_class_terminal_type>();
            while (reader.Read())
            {
                alta_class_terminal_type type = new alta_class_terminal_type();
                if (!reader.IsDBNull(0))
                {
                    type.alta_id = reader.GetInt32(ALTA_TERMIRAL_TYPE_ID);
                    // if (!reader.IsDBNull(1))
                    type.alta_name = reader.GetString(ALTA_TERMIRAL_TYPE_NAME);
                    // if (!reader.IsDBNull(2))                  
                    try
                    {
                        type.alta_content = reader.GetString(ALTA_TERMIRAL_TYPE_CONTENT);
                    }
                    catch (Exception ex)
                    {
                        type.alta_content = "";
                    }
                    list_type.Add(type);
                }
            }
            return list_type;

        }

        public static List<alta_class_user_parent> getListUserSon(int userId)
        {
            List<alta_class_user_parent> list = new List<alta_class_user_parent>();
            String _query = "SELECT * FROM `user_parent_details` WHERE parent_id=@id_parent";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_parent", userId);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                list = getListUserSon(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
            return list;
        }

        private static List<alta_class_user_parent> getListUserSon(MySqlDataReader reader)
        {
            List<alta_class_user_parent> list = new List<alta_class_user_parent>();
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    alta_class_user_parent tmp = new alta_class_user_parent();
                    tmp.alta_id = reader.GetInt32(ALTA_USER_PARENT_DETAIL_ID);
                    tmp.parent_id = reader.GetInt32(ALTA_USER_PARENT_ID);
                    tmp.alta_user = getUser(reader.GetInt32(ALTA_USER_SON_ID));
                    try
                    {
                        tmp.time = reader.GetDateTime(ALTA_USER_PARENT_DETAIL_TIME);
                    }
                    catch (Exception ex)
                    {
                        tmp.time = null;
                    }
                    list.Add(tmp);
                }
            }
            return list;
        }

        public static List<alta_class_user> getListUser(ref int total, int type, string sort="", bool status=false, int from=-1, int num=-1)
        {
            List<alta_class_user> list_user = new List<alta_class_user>();
            String _query = "SELECT `user_id`, `username`, `user_pass`, `full_name`, `user_type_id`, `user_status`,`user_email`,`user_phone` FROM `am_user`";
            String where = " WHERE 1";
            if (status)
            {
                where += " and user_status=@status";
            }
            if (type != -1)
            {
                where += " and user_type_id=@type";
            }
            _query += where;
            if (sort != string.Empty)
            {
                _query += sort;
            }
            if (from != -1 && num != -1)
            {
                _query += " LIMIT @from , @num";
            }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        if (status)
                        {
                            cmd.Parameters.AddWithValue("@status",status);
                        }
                        if (type != -1)
                        {
                            cmd.Parameters.AddWithValue("@type", type);
                        }
                        if (from != -1 && num != -1)
                        {
                            cmd.Parameters.AddWithValue("@from", from);
                            cmd.Parameters.AddWithValue("@num", num);
                        }
                        total = getCount("`am_user`", where, cmd.Parameters);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                list_user = getListUser(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }

            return list_user;
        }
        public static void removeChildren(int idDetailsChildren)
        {
            String _query = "DELETE FROM `user_parent_details` WHERE `id_details_user`=@idChildren";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idChildren", idDetailsChildren);
                        cmd.ExecuteNonQuery();
                        
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        internal static void addChildren(int idParent, int idChild)
        {
            String _query = "INSERT INTO `user_parent_details`(`parent_id`, `user_id`) VALUES (@parent,@child)";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@parent", idParent);
                        cmd.Parameters.AddWithValue("@child", idChild);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
        }
        internal static void upDateScheDule(int id_schedule, int id_terminal, int user_id, DateTime beginTime, DateTime endTime)
        {
            String _query = "UPDATE `am_schedules` SET `user_id`=@user_id,`termiral_id`=@termiral_id,`schedules_date_begin`=@schedules_date_begin,`schedules_date_end`=@schedules_date_end WHERE `schedules_id`=@schedules_id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@schedules_id", id_schedule);
                        cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.Parameters.AddWithValue("@termiral_id", id_terminal);
                        cmd.Parameters.AddWithValue("@schedules_date_begin", beginTime);
                        cmd.Parameters.AddWithValue("@schedules_date_end", endTime);
                        cmd.ExecuteNonQuery();
                        deleteScheduleDetails(new alta_class_schedules() { alta_id = id_schedule });
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        private static void deleteScheduleDetails(alta_class_schedules data)
        {
            String _query = "DELETE FROM `am_schedules_details` WHERE `schedules_id`=@schedules_id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@schedules_id", data.alta_id);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
        }
        public static void deleteScheDule(int id_schedule)
        {
            String _query = "DELETE FROM `am_schedules` WHERE `schedules_id`=@schedules_id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@schedules_id", id_schedule);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
        }
        public void updateScheduleDetails(int schedules_details_id, int id_Schedule, int id_user, int plan_id, int termiral_id, DateTime time_play, DateTime time_end)
        {
            String _query = "UPDATE `am_schedules_details` SET `schedules_id`=@schedules_id,`plan_id`=@plan_id,`user_id`=@user_id,`termiral_id`=@termiral_id,`time_play`=@time_play,`time_end`=@time_end WHERE `schedules_details_id`=@schedules_details_id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@schedules_details_id", schedules_details_id);
                        cmd.Parameters.AddWithValue("@plan_id", plan_id);
                        cmd.Parameters.AddWithValue("@schedules_id", id_Schedule);
                        cmd.Parameters.AddWithValue("@user_id", id_user);
                        cmd.Parameters.AddWithValue("@termiral_id", termiral_id);
                        cmd.Parameters.AddWithValue("@time_play", time_play);
                        cmd.Parameters.AddWithValue("@time_end", time_end);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
        }
        internal static alta_class_user getUser(alta_class_schedules_details data)
        {
            if (data == null)
                return null;
            alta_class_user user = new alta_class_user();
            String _query = "SELECT A.* FROM `am_user` A, am_schedules_details B WHERE A.`user_id`=B.`user_id` and B.schedules_details_id=@schedules_details_id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@schedules_details_id", data.alta_id);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                user = getUser(reader);
                            }
                        }
                        
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
            return user;
        }

        internal static alta_class_termiral getTermiral(alta_class_schedules data)
        {
            if (data == null)
                return null;
            alta_class_termiral terminal = new alta_class_termiral();
            String _query = "SELECT A.* FROM `am_termiral` A, `am_schedules` B WHERE A.`termiral_id`=B.`termiral_id` and B.schedules_id=@schedules_id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        // cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.Parameters.AddWithValue("@schedules_id", data.alta_id);
                        //cmd.Parameters.AddWithValue("@content", DateTime.Now.ToString());
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                terminal = getTermiral(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
            return terminal;
        }

        internal static List<alta_class_schedules_details> getListScheduleDetails()
        {
            List<alta_class_schedules_details> list = new List<alta_class_schedules_details>();
            String _query = "SELECT * FROM `am_schedules_details`";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                    
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                list = getListScheduleDetals(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
            return list;
        }

        internal static List<alta_class_schedules_details> getListScheduleDetails(alta_class_playlist Playlist)
        {
            List<alta_class_schedules_details> list = new List<alta_class_schedules_details>();
            String _query = "SELECT A.* FROM `am_schedules_details` A WHERE A.`plan_id`=@plan_id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@plan_id", Playlist.alta_id);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                list = getListScheduleDetals(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                
            }
            return list;
        }

        internal static void deleteScheduleDetails(int schedules_details_id)
        {
            String _query = "DELETE FROM `am_schedules_details` WHERE `schedules_details_id`= @schedules_details_id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@schedules_details_id", schedules_details_id);                       
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
        }
        internal static void updateScheduleDetails(int id_schedule_details, int plan_id ,Class.alta_class_schedules schedule, DateTime beginTime, DateTime endTime)
        {
            String _query = "UPDATE `am_schedules_details` SET `schedules_id`=@schedules_id,`plan_id`=@plan_id,`user_id`=@user_id,`termiral_id`=@termiral_id,`time_play`=@time_play,`time_end`=@time_end WHERE `schedules_details_id`=@schedules_details_id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@schedules_details_id", id_schedule_details);
                        cmd.Parameters.AddWithValue("@schedules_id", schedule.alta_id);
                        cmd.Parameters.AddWithValue("@user_id", schedule.alta_user.alta_id);
                        cmd.Parameters.AddWithValue("@termiral_id", schedule.alta_termiral.alta_id);
                        cmd.Parameters.AddWithValue("@time_play", beginTime);
                        cmd.Parameters.AddWithValue("@time_end", endTime);
                        cmd.Parameters.AddWithValue("@plan_id", plan_id);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        internal static List<alta_class_schedules> getListSchedule(int user_id, DateTime? dateTime=null)
        {
            List<alta_class_schedules> list = new List<alta_class_schedules>();
            String _query;
            if(dateTime!=null)
                _query = "SELECT `schedules_id`,`user_id`, `termiral_id`, `schedules_date_begin`, `schedules_date_end`, `schedules_content` FROM `am_schedules` WHERE `user_id`=@user_id and ( DATE_FORMAT(`schedules_date_begin`,'%Y-%m-%d')<=DATE_FORMAT(@time,'%Y-%m-%d') and DATE_FORMAT(`schedules_date_end`,'%Y-%m-%d')>=DATE_FORMAT(@time,'%Y-%m-%d'))";
            else
            {
                _query = "SELECT `schedules_id`,`user_id`, `termiral_id`, `schedules_date_begin`, `schedules_date_end`, `schedules_content` FROM `am_schedules` WHERE `user_id`=@user_id";
            }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", user_id);
                        if(dateTime!=null)
                            cmd.Parameters.AddWithValue("@time", ((DateTime)dateTime).Date);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                list = getListSchedule(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
            return list;
        }

        internal static alta_class_user getUser(alta_class_schedules data)
        {
            if (data == null)
                return null;
            alta_class_user user = new alta_class_user();
            String _query = "SELECT A.* FROM `am_user` A, am_schedules B WHERE A.`user_id`=B.`user_id` and B.schedules_id=@schedules_id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@schedules_id", data.alta_id);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                user = getUser(reader);
                            }
                        }

                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
            return user;
        }

        internal static alta_class_schedules getSchedule(int schedule_id)
        {
            alta_class_schedules schedule = new alta_class_schedules();
            String _query = "SELECT * FROM `am_schedules` WHERE schedules_id=@schedules_id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@schedules_id", schedule_id);
                       // cmd.Parameters.AddWithValue("@termiral_id", id_terminal);
                        // cmd.Parameters.AddWithValue("@timeplay", DateTime.Now.Date);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                schedule = getSchedule(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return schedule;
        }

        internal static bool checkTimeScheDuleDetails(int id_schedule,DateTime beginTime, DateTime endTime, int id_Schedule_details=0)
        {
            bool flag = false;
            String _query;
            if (id_Schedule_details == 0)
            {
                _query = "SELECT `schedules_details_id` FROM `am_schedules_details` WHERE schedules_id=@schedules_id ";
            }
            else
            {
                _query = "SELECT `schedules_details_id` FROM `am_schedules_details` WHERE schedules_details_id<>@schedules_details_id and schedules_id=@schedules_id ";
            }
            _query += " and ((DATE_FORMAT(`time_play`,'%Y-%m-%d') >= DATE_FORMAT(@timeBegin,'%Y-%m-%d')AND DATE_FORMAT(`time_end`,'%Y-%m-%d') >= DATE_FORMAT(@timeEnd, '%Y-%m-%d'))";
            _query+=  " OR (DATE_FORMAT(`time_play`,'%Y-%m-%d') <= DATE_FORMAT(@timeBegin,'%Y-%m-%d') AND DATE_FORMAT(`time_end`, '%Y-%m-%d') >= DATE_FORMAT(@timeBegin, '%Y-%m-%d'))";
            _query += " OR (DATE_FORMAT(`time_play`,'%Y-%m-%d') <= DATE_FORMAT(@timeEnd,'%Y-%m-%d') AND DATE_FORMAT(`time_end`, '%Y-%m-%d') >= DATE_FORMAT(@timeEnd, '%Y-%m-%d'))";
            _query += " OR (DATE_FORMAT(`time_play`,'%Y-%m-%d') <= DATE_FORMAT(@timeBegin,'%Y-%m-%d') AND DATE_FORMAT(`time_end`, '%Y-%m-%d') >= DATE_FORMAT(@timeEnd, '%Y-%m-%d')))";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        if(id_Schedule_details!=0)
                            cmd.Parameters.AddWithValue("@schedules_details_id", id_Schedule_details);
                        cmd.Parameters.AddWithValue("@schedules_id", id_schedule);
                        cmd.Parameters.AddWithValue("@timeBegin", beginTime);
                        cmd.Parameters.AddWithValue("@timeEnd", endTime);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                
            }
            return flag;
        }
    }
}
