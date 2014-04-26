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

        public alta_playlist_player()
        {
            cur_pos_play = -1;
        }

        public alta_media_in_player getCurMedia()
        {
            return media[cur_pos_play];
        }

        public alta_media_in_player getMedia(int p)
        {
            return media[p];
        }
        public bool Compare(alta_playlist_player list)
        {
            if (this.media != null && list.media!=null)
            {
                if (this.media.Count == list.media.Count)
                {
                    int count=list.media.Count;
                    for (int i = 0; i < count; i++)
                    {
                        bool flag = false;
                        for (int j = 0; j < count; j++)
                        {
                            if (this.media[i].Equals(list.media[j]))
                            {
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
