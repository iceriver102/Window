using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alta_Media_Manager.Alta_view.Class;

namespace Alta_Media_Manager.Alta_view.Mysql_helpper
{
    public class Mysql_Optimize_Class
    {
        public static List<alta_class_user> mysql_optimize_user(List<alta_class_user> list_user, List<alta_class_user_type> list_type_user)
        {
            int count = list_user.Count;
            int count_type = list_type_user.Count;

            for (int i = 0; i < count; i++)
            {
                //alta_class_user tmp = list_user[i];
                for (int j = 0; j < count_type; j++)
                {
                    if (list_user[i].alta_type_user.alta_id == list_type_user[j].alta_id)
                    {
                        list_user[i].alta_type_user = list_type_user[j];
                    }
                }
            }
            return list_user;
        }
        public static List<alta_class_media> mysql_optimize_media(List<alta_class_media> list_media, List<alta_class_media_type> list_type_media)
        {
            int count = list_media.Count;
            int count_type = list_type_media.Count;

            for (int i = 0; i < count; i++)
            {
                //alta_class_user tmp = list_user[i];
                for (int j = 0; j < count_type; j++)
                {
                    if (list_media[i].alta_media_type.alta_id == list_type_media[j].alta_id)
                    {
                        list_media[i].alta_media_type = list_type_media[j];
                    }
                }
            }
            return list_media;
        }
        public static List<alta_class_media> mysql_optimize_media(List<alta_class_media> list_media, List<alta_class_user> list_user)
        {
            int count = list_media.Count;
            int count_type = list_user.Count;

            for (int i = 0; i < count; i++)
            {
                //alta_class_user tmp = list_user[i];
                for (int j = 0; j < count_type; j++)
                {
                    if (list_media[i].alta_user.alta_id == list_user[j].alta_id)
                    {
                        list_media[i].alta_user = list_user[j];
                    }
                }
            }
            return list_media;
        }
        public static alta_class_media mysql_optimize_media(alta_class_media list_media, List<alta_class_playlist> playlist)
        {
            int count = playlist.Count;
            list_media.alta_playlist = new List<alta_class_playlist>();
            for (int i = 0; i < count; i++)
            {
                int count_detais = playlist[i].alta_details.Count;
                for (int j = 0; j < count_detais; j++)
                {
                    if (list_media.alta_id == playlist[i].alta_details[j].alta_media.alta_id)
                    {
                        list_media.alta_playlist.Add(playlist[i]);
                        break;
                    }
                }
            }

            return list_media;
        }
        public static alta_class_media mysql_optimize_media(alta_class_media list_media, List<alta_class_playlist_details> playlist_details)
        {
            int count = playlist_details.Count;
            list_media.alta_playlist = new List<alta_class_playlist>();
            for (int i = 0; i < count; i++)
            {
                if (list_media.alta_id == playlist_details[i].alta_media.alta_id)
                {
                    list_media.alta_playlist.Add(playlist_details[i].alta_playlist);
                }
            }
            return list_media;
        }
        public static List<alta_class_playlist_details> mysql_optimize_playlist_detais(List<alta_class_playlist_details> list_details, List<alta_class_playlist> list_playlist, List<alta_class_media> list_media)
        {
            int count = list_details.Count;
            int count_playlist = list_playlist.Count;
            int count_media = list_media.Count;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count_playlist; j++)
                {
                    if (list_playlist[j].alta_id == list_details[i].alta_id)
                    {
                        list_details[i].alta_playlist = list_playlist[j];
                        break;
                    }

                }
                for (int k = 0; k < count_media; k++)
                {
                    if (list_details[i].alta_media.alta_id == list_media[k].alta_id)
                    {
                        list_details[i].alta_media = list_media[k];
                        break;
                    }
                }
            }
            return list_details;
        }
        public static List<alta_class_playlist> mysql_optimize_playlist(List<alta_class_playlist> list_playlist, List<alta_class_playlist_details> list_details)
        {
            int count = list_playlist.Count;
            int count_details = list_details.Count;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count_details; j++)
                {
                    if (list_playlist[i].alta_id == list_details[j].alta_playlist.alta_id)
                    {
                        list_playlist[i].alta_details.Add(list_details[j]);
                    }
                }
            }
            return list_playlist;
        }
       
    }
}
