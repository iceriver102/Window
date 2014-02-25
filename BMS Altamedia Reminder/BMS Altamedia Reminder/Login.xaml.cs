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

namespace BMS_Altamedia_Reminder
{
    public partial class Login : PhoneApplicationPage
    {
        public userDataJson user;
        public String postData;
        private IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;
        public Login()
        {
            InitializeComponent();
            txt_pass.GotFocus += txt_pass_placeholder;
            txt_pass.LostFocus += txt_pass_placeholder;
            txt_pass.KeyDown += txt_pass_placeholder;

            txt_user.KeyDown += txt_user_KeyDown;
            txt_user.GotFocus += txt_user_GotFocus;
            txt_user.LostFocus += txt_user_GotFocus;
            user = new userDataJson();
            postData = String.Empty;

        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Remove Page2 from the backstack
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.RemoveBackEntry();
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
        private void ShowMain()
        {
          //  this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

        }
        private void ClearBackEntries()
        {
            while (NavigationService.BackStack != null & NavigationService.BackStack.Count() > 0)
                NavigationService.RemoveBackEntry();
        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thoát Chương Trình", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                this.ClearBackEntries();
            else
                e.Cancel = true;
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

            postData = "username=" + txt_user.Text;
            postData += "&password=" + txt_pass.Password;
            postData += "&token=1234567890";
           // MessageBox.Show("Đăng nhập");
            post("http://bms.altamedia.vn/api.php");
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
         
            //MessageBox.Show(postData);

            byte[] data = System.Text.Encoding.UTF8.GetBytes(postData);
           // request.ContentLength = data.Length;

            // Create the post data
          //  string postData = "blah=" + textBlock1.Text + "&blah=" + textBlock2.Text + "&blah=moreblah";
            postStream.Write(data, 0, data.Length);
            postStream.Close();

            //Start the web request
            request.BeginGetResponse(new AsyncCallback(GetResponceStreamCallback), request);

        }
        String result;
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
            if (user.result)
            {
                Write(this.user);
                ShowMain();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
            }

        }


    }
}