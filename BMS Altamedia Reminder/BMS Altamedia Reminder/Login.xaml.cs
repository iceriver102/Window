using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using BMS_Altamedia_Reminder.Class;
using Newtonsoft.Json.Linq;
using System.IO.IsolatedStorage;
using ImageTools.IO.Gif;

namespace BMS_Altamedia_Reminder
{
    public partial class Login : UserControl
    {
        public userDataJson user;
        public String postData;
        private String result;
        private IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;
        public Uri ImageSource { get; set; }

        public Login()
        {
            InitializeComponent();
            ImageTools.IO.Decoders.AddDecoder<GifDecoder>();
            ImageSource = new Uri("/Assets/animated_loader.gif", UriKind.RelativeOrAbsolute);
            //this.DataContext = this;
            img_loading.Visibility = Visibility.Collapsed;
            Size ScreenSize = Common.GetScreenResolution();
            this.Width = ScreenSize.Width;
            this.Height = ScreenSize.Height;
            txt_pass.GotFocus += txt_pass_placeholder;
            txt_pass.LostFocus += txt_pass_placeholder;
            txt_pass.KeyDown += txt_pass_placeholder;

            txt_user.KeyDown += txt_user_KeyDown;
            txt_user.GotFocus += txt_user_GotFocus;
            txt_user.LostFocus += txt_user_GotFocus;
            user = new userDataJson();
            postData = String.Empty;
            if (Common.urlToast == String.Empty)
            {
                try
                {
                    Common.urlToast = (String)userSettings["urlPush"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể lấy được ID của thiết bị hãy restart lại ứng dụng!");
                }
            }
        }

        public void Write(userDataJson user)
        {
            try
            {
                userSettings.Add("name", user.user_name);
                userSettings.Add("login_result", user.result);
                userSettings.Add("user_id", user.user_id);
                userSettings.Add("token", user.user_access_token);
            }
            catch (ArgumentException ex)
            {
                userSettings.Clear();
                userSettings.Add("name", user.user_name);
                userSettings.Add("login_result", user.result);
                userSettings.Add("user_id", user.user_id);
                userSettings.Add("token", user.user_access_token);
                userSettings.Add("urlPush", Common.urlToast);
            }
        }
        void txt_user_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_user.Text == "")
                txt_user_hoder.Text = "Username";
            else txt_user_hoder.Text = "";
        }

        void txt_user_KeyDown(object sender, EventArgs e)
        {
            if (txt_user.Text == "")
                txt_user_hoder.Text = "Username";
            else txt_user_hoder.Text = "";
        }
        public void txt_pass_placeholder(object sender, EventArgs e)
        {
            if (txt_pass.Password == "")
                txt_pass_hoder.Text = "Password";
            else txt_pass_hoder.Text = "";
        }
        public event EventHandler Completed;
        private void ShowMain(EventArgs e)
        {
            if (user.result)
            {
                Write(this.user);
                if (Completed != null)
                    Completed(this, e);

            }
            else
            {
                this.Dispatcher.BeginInvoke(() =>
            {
                img_loading.Visibility = Visibility.Collapsed;
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
            });
            }


        }


        private void Login_Event(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (txt_user.Text == "")
            {
                MessageBox.Show("Tên đăng nhập không được để trống");
                return;
            }
            if (txt_pass.Password == "")
            {
                MessageBox.Show("Mật khẩu không được để trống");
                return;
            }
            img_loading.Visibility = Visibility.Visible;
            postData = "username=" + txt_user.Text;
            postData += "&password=" + txt_pass.Password;
            postData += "&token=" + Common.urlToast;
            // MessageBox.Show("Đăng nhập");
            post(Common.http);
        }
        private void post(String url)
        {

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] data = encoding.GetBytes(postData);
            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(url + "?mod=login_reminder&device=windowphone");
            httpWReq.Method = "POST";
            // httpWReq.ProtocolVersion = HttpVersion.Version10;
            httpWReq.Headers = new WebHeaderCollection();
            httpWReq.ContentType = "application/x-www-form-urlencoded";
            httpWReq.ContentLength = data.Length;
            httpWReq.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), httpWReq);
        }

        private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
            // End the stream request operation
            Stream postStream = request.EndGetRequestStream(asynchronousResult);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(postData);
            postStream.Write(data, 0, data.Length);
            postStream.Close();

            //Start the web request
            request.BeginGetResponse(new AsyncCallback(GetResponceStreamCallback), request);

        }

        void GetResponceStreamCallback(IAsyncResult callbackResult)
        {
            HttpWebRequest request = (HttpWebRequest)callbackResult.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult);
            using (StreamReader httpWebStreamReader = new StreamReader(response.GetResponseStream()))
            {
                this.result = httpWebStreamReader.ReadToEnd();
            }
            dynamic tmpJson = JObject.Parse(this.result);
            user.result = tmpJson.result;
            user.user_access_token = tmpJson.user_access_token;
            user.user_id = tmpJson.user_id;
            user.user_name = tmpJson.user_name;
            user.msg = tmpJson.msg;
            EventArgs e = new EventArgs();
            ShowMain(e);


        }


    }
}