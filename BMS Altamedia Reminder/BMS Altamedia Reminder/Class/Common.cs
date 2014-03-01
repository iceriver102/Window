using Microsoft.Phone.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace BMS_Altamedia_Reminder.Class
{
    public class Common
    {
        public static String http = "http://bms.altamedia.vn/api.php";
        public static String urlToast = String.Empty;
        public static int count = 3;
        public static String access = "efe892d63b9af44cfdf89d1d5aa87040";
        private String _postData = String.Empty;       
        public userDataJson user;
        public static Size GetScreenResolution()
        {
            double ScreenWidth = Application.Current.Host.Content.ActualWidth;
            double ScreenHeight = Application.Current.Host.Content.ActualHeight;
            return new Size(ScreenWidth, ScreenHeight);
        }
        public void post(String action, String postData)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                _postData = postData;
                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                byte[] data = encoding.GetBytes(postData);
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(http + action);
                httpWReq.Method = "POST";
                // httpWReq.ProtocolVersion = HttpVersion.Version10;
                httpWReq.Headers = new WebHeaderCollection();
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;
                httpWReq.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), httpWReq);
            }
            else
            {
                MessageBox.Show("Không có kết nối internet kiểm tra lại Wifi hoặc 3G");
            }
        }
        private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
            // End the stream request operation
            Stream postStream = request.EndGetRequestStream(asynchronousResult);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(_postData);
            postStream.Write(data, 0, data.Length);
            postStream.Close();
            request.BeginGetResponse(new AsyncCallback(GetResponceStreamCallback), request);
        }

        private void GetResponceStreamCallback(IAsyncResult callbackResult)
        {
            String result = String.Empty;
            HttpWebRequest request = (HttpWebRequest)callbackResult.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult);
            using (StreamReader httpWebStreamReader = new StreamReader(response.GetResponseStream()))
            {
                result = httpWebStreamReader.ReadToEnd();
            }
        }
        public static Color GetColorFromHexString(string hexValue)
        {
            var a = Convert.ToByte(hexValue.Substring(0, 2), 16);
            var r = Convert.ToByte(hexValue.Substring(2, 2), 16);
            var g = Convert.ToByte(hexValue.Substring(4, 2), 16);
            var b = Convert.ToByte(hexValue.Substring(6, 2), 16);
            return Color.FromArgb(a, r, g, b);
        }
        public static Reminder getReminder()
        {
            Reminder tmp = new Reminder();


            return tmp;
        }

    }
    public static class MODE_HTTP_REQUEST
    {
        public const int POST_MODE_LOGIN = 1;
        public const int POST_MODE_LOGOUT = 2;
        public const int POST_MODE_GET_REMIDER = 3;
        public const int POT_MODE_COMPETED_REMIDER = 4;
    }
}
