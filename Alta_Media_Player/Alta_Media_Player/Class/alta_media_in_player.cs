using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alta_Media_Manager.Class
{
    public class alta_media_in_player
    {
        public String ftpUrl { get; set; }
        public String Url { get; set; }
        private int typeProperty = 1;
        public String name { get; set; }
        public int type
        {
            get
            {
                return typeProperty;
            }
            set
            {
                if (value == 1)
                {
                    isCamera = false;
                    isVideo = true;
                }
                else if (value == 2)
                {
                    isCamera = true;
                    isVideo = false;
                }
                else
                {
                    isCamera = false;
                    isVideo = false;
                }
                typeProperty = value;
            }
        }
        private bool flag_camera = false;
        private bool flag_video = false;
        public bool isCamera
        {
            get { return flag_camera; }
            private set { flag_camera = value; }
        }
        public bool isVideo
        {
            get { return flag_video; }
            private set { flag_video = value; }
        }

        private int TimeProperty = -1;
        public int TimePlay
        {
            get { return TimeProperty; }
            set
            {
                if (value <= 0) TimeProperty = -1;
                else TimeProperty = value;
            }
        }
    }
}
