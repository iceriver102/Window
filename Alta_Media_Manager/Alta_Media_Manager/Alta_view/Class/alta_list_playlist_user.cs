using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alta_Media_Manager.Alta_view.Class
{
    public class alta_list_playlist_user
    {
        public alta_class_user user{get;set;}
        public List<alta_class_playlist> List_playlist{get;set;}
        
    }
    public class alta_list_media_user
    {
        public alta_class_user user { get; set; }
        public List<alta_class_media> List_media { get; set; }
    }
    public class alta_list_schedules_user
    {
        public alta_class_user user { get; set; }
        public List<alta_class_schedules> List_schedules { get; set; }
    }
    public class alta_list_termiral_user
    {
        public alta_class_user user { get; set; }
        public List<alta_class_termiral> List_temiral { get; set; }
    }
}
