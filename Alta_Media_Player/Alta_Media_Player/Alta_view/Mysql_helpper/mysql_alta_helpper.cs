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
        #endregion
        #region colum user type table
        private static String ALTA_USER_TYPE_ID = "user_type_id";
        private static String ALTA_USER_TYPE_NAME = "name_type";
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
                    tmp.alta_playlist = playlist;
                    tmp.alta_time_play = reader.GetDateTime(ALTA_SCHEDULE_DETAILS_TIME_PLAY);
                    try
                    {
                        tmp.alta_time_end = reader.GetDateTime(ALTA_SCHEDULE_DETAILS_TIME_END);
                    }catch(Exception ){
                        tmp.alta_time_end = DateTime.Now;

                    }

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
                    alta_class_user_type user_type = new alta_class_user_type();
                    user_type.alta_id = reader.GetInt32(ALTA_USER_TYPE_ID);
                    tmp.alta_type_user = user_type;
                    // if (!reader.IsDBNull(5))
                    tmp.alta_user_status = reader.GetBoolean(ALTA_USER_STATUS);
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
                    alta_class_user_type user_type = new alta_class_user_type();
                    user_type.alta_id = reader.GetInt32(ALTA_USER_TYPE_ID);
                    tmp.alta_type_user = user_type;
                    // if (!reader.IsDBNull(5))
                    tmp.alta_user_status = reader.GetBoolean(ALTA_USER_STATUS);
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
                    string _query = "SELECT `user_id`, `username`, `user_pass`, `full_name`, `user_type_id`, `user_status` FROM `am_user` WHERE `user_id`=@user_id";
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
                        tmp.alta_type_user = getUserType(reader.GetInt32(ALTA_USER_TYPE_ID));
                    }
                    else
                    {
                        alta_class_user_type user_type = new alta_class_user_type();
                        user_type.alta_id = reader.GetInt32(ALTA_USER_TYPE_ID);
                        tmp.alta_type_user = user_type;
                    }
                    // if (!reader.IsDBNull(5))
                    tmp.alta_user_status = reader.GetBoolean(ALTA_USER_STATUS);
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
            String sql = "SELECT A.`termiral_id`, A.`termiral_name`, A.`termiral_ip`, A.`termiral_content`, A.`termiral_status` FROM `am_termiral` A, `am_schedules_details` B ";
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
                        total = getCount("`am_termiral` A, `am_schedules_details` B", where, cmd.Parameters);
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
                    string _query = "SELECT A.`user_id`, A.`username`, A.`user_pass`, A.`full_name`, A.`user_type_id`, A.`user_status` FROM `am_user` A, `am_schedules_details` B";
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
            String sql = "SELECT `termiral_id`, `termiral_name`, `termiral_ip`, `termiral_content`, `termiral_status` FROM `am_termiral` ";
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


    }
}
