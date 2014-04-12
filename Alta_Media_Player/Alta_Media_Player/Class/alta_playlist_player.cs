using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alta_Media_Manager.Class
{
    public class alta_playlist_player
    {
        public int cur_pos_play { get; set; }
        public int Count { get; set; }
        public List<alta_media_in_player> media{get;set;}

        public alta_media_in_player getCurMedia()
        {
            return media[cur_pos_play];
        }

        public alta_media_in_player getMedia(int p)
        {
            return media[p];
        }
    }
}
