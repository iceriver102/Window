using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace BMS_Altamedia_Reminder.Class
{
    public class MultiResImageChooserUri
    {

        public String Source;

        public Uri BestResolutionImage
        {
            get
            {
              //  MessageBox.Show(this.getName(Source) + "|" + this.getExt(Source));
                switch (ResolutionHelper.CurrentResolution)
                {
                    case Resolutions.HD:
                     //   MessageBox.Show("HD");
                        return new Uri(this.getName(Source) + ".screen-720p." + this.getExt(Source), UriKind.Relative);
                    case Resolutions.WXGA:
                      //  MessageBox.Show("WXGA");
                        return new Uri(this.getName(Source) + ".screen-wxga." + this.getExt(Source), UriKind.Relative);
                    case Resolutions.WVGA:
                      //  MessageBox.Show("WVGA");
                        return new Uri(this.getName(Source) + ".screen-wvga." + this.getExt(Source), UriKind.Relative);
                    default:
                        throw new InvalidOperationException("Unknown resolution type");
                }
            }
        }
        private String getName(String s)
        {
            int dot = s.LastIndexOf('.');
            return s.Substring(0, dot);
        }
        private String getExt(String s)
        {
            int dot = s.LastIndexOf('.');
            return s.Substring(dot + 1);
        }

    }

}
