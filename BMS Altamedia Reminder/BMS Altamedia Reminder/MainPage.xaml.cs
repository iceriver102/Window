using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BMS_Altamedia_Reminder.Resources;
using System.ComponentModel;
using System.Threading;
using System.Windows.Controls.Primitives;
using Windows.Storage;
using System.IO.IsolatedStorage;
using BMS_Altamedia_Reminder.Class;
using Microsoft.Phone.Notification;
using System.Text;
using System.IO;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Threading;
using BMS_Altamedia_Reminder.UCXaml;
using System.Collections.ObjectModel;

namespace BMS_Altamedia_Reminder
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        List<Reminder> _PathCollection =  new List<Reminder>();
        public List<Reminder> PathCollection
        { get { return _PathCollection; } }
        BackgroundWorker backroungWorker;
        private Popup popup;
        private Boolean flag_flashing;
        private Boolean flag_login;
        private Alta_Title ViewTitle;
        private IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;
        List_Remider ListData;
        userDataJson user;
        public MainPage()
        {
            InitializeComponent();
            try
            {
                LoadDemoData(50);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // ListData = new List_Remider();
            // Notifycation();
            // loadAppData();
            //LoadData();
            // flag_flashing = false;
            // ShowSplash();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.RemoveBackEntry();
            }
        }

        private void loadAppData()
        {
            try
            {
                Common.urlToast = (String)userSettings["urlPush"];
            }
            catch (Exception ex)
            {
                Common.urlToast = "";
            }

        }

        private void StartLoadingData()
        {
            this.flag_flashing = true;
            backroungWorker = new BackgroundWorker();
            backroungWorker.DoWork += new DoWorkEventHandler(backroungWorker_DoWork);
            backroungWorker.RunWorkerCompleted +=
          new RunWorkerCompletedEventHandler(backroungWorker_RunWorkerCompleted);
            backroungWorker.RunWorkerAsync();
        }

        public void LoadData()
        {
            try
            {
                user = new userDataJson();
                user.result = (Boolean)userSettings["login_result"];
                user.user_access_token = (String)userSettings["token"];
                user.user_id = (String)userSettings["user_id"];
                user.user_name = (String)userSettings["name"];
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                user = new userDataJson();
            }
        }
        void showTile(String title, int time = 3000)
        {
            layout_Msg.Visibility = Visibility.Visible;
            viewTitle.Visibility = Visibility.Visible;
            viewTitle.txt_Title.Text = title;
            ViewTitle_Show();

        }

        void ViewTitle_Show()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += HideTile;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        private void HideTile(object sender, EventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                viewTitle.Visibility = Visibility.Collapsed;
                layout_Msg.Visibility = Visibility.Collapsed;
            });
        }
        void backroungWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.flag_flashing = true;
            Thread.Sleep(3000);
        }
        void backroungWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                this.popup.IsOpen = false;
                this.flag_flashing = false;
                if (!user.result)
                {
                    ShowLogin();
                }
                else
                {
                    showTile("Xin chào " + user.user_name);
                    LoadDemoData();
                }
            });
        }

        private void LoadDemoData(int num = 10)
        {

            for (int i = 0; i < num; i++)
            {
                Reminder tmp = new Reminder();
                if (i % 3 == 0)
                {
                    tmp.title_type = true;
                    tmp.title = "Title " + i;
                }
                else
                {
                    tmp.title_type = false;
                    tmp.title = "Item " + i;
                    tmp.date = DateTime.Now;
                    tmp.content = "Content " + i;
                    
                }
                _PathCollection.Add(tmp);
            }
            ContactListBox.ItemsSource = this.PathCollection;

        }

        private void Notifycation()
        {
            HttpNotificationChannel pushChannel;

            // The name of our push channel.
            string channelName = "Toast_Alta_BMS_Remider";
            pushChannel = HttpNotificationChannel.Find(channelName);
            if (pushChannel == null)
            {
                pushChannel = new HttpNotificationChannel(channelName);

                // Register for all the events before attempting to open the channel.
                pushChannel.ChannelUriUpdated += new EventHandler<NotificationChannelUriEventArgs>(PushChannel_ChannelUriUpdated);
                pushChannel.ErrorOccurred += new EventHandler<NotificationChannelErrorEventArgs>(PushChannel_ErrorOccurred);

                // Register for this notification only if you need to receive the notifications while your application is running.
                pushChannel.ShellToastNotificationReceived += new EventHandler<NotificationEventArgs>(PushChannel_ShellToastNotificationReceived);
                pushChannel.Open();
                pushChannel.BindToShellToast();

            }
            else
            {
                // The channel was already open, so just register for all the events.
                pushChannel.ChannelUriUpdated += new EventHandler<NotificationChannelUriEventArgs>(PushChannel_ChannelUriUpdated);
                pushChannel.ErrorOccurred += new EventHandler<NotificationChannelErrorEventArgs>(PushChannel_ErrorOccurred);

                // Register for this notification only if you need to receive the notifications while your application is running.
                pushChannel.ShellToastNotificationReceived += new EventHandler<NotificationEventArgs>(PushChannel_ShellToastNotificationReceived);

                try
                {
                    Common.urlToast = pushChannel.ChannelUri.ToString();
                    userSettings.Add("urlPush", pushChannel.ChannelUri.ToString());

                }
                catch (Exception ex)
                {

                }
            }
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (this.flag_flashing)
                e.Cancel = true;
            else
            {
                if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thoát", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {

                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        private void ShowLogin()
        {
            // this.NavigationService.Navigate(new Uri("/Login.xaml?NavigatedFrom=Main Page", UriKind.Relative));
            this.popup = new Popup();
            Login formLogin = new Login();
            formLogin.Completed += formLogin_Completed;
            this.popup.Child = formLogin;
            this.popup.IsOpen = true;
        }

        private void formLogin_Completed(object sender, EventArgs e)
        {
            Login tmp = sender as Login;
            this.Dispatcher.BeginInvoke(() =>
            {
                this.user = tmp.user;
                this.popup.IsOpen = false;
                if (user.result)
                {
                    showTile("Xin chào " + user.user_name);
                    try
                    {
                        LoadDemoData(50);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            });
        }
        private void ShowSplash()
        {
            this.popup = new Popup();
            this.popup.Child = new SplashScreenControl();
            this.popup.IsOpen = true;
            StartLoadingData();
        }

        #region Notifycation

        /// <summary>
        /// Event handler for when the push channel Uri is updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PushChannel_ChannelUriUpdated(object sender, NotificationChannelUriEventArgs e)
        {

            Dispatcher.BeginInvoke(() =>
            {
                // Display the new URI for testing purposes.   Normally, the URI would be passed back to your web service at this point.
                // System.Diagnostics.Debug.WriteLine(e.ChannelUri.ToString());
                Common.urlToast = e.ChannelUri.ToString();
                try
                {
                    userSettings.Remove("urlPush");
                    userSettings.Add("urlPush", e.ChannelUri.ToString());
                }
                catch (Exception ex)
                {
                    userSettings.Add("urlPush", e.ChannelUri.ToString());
                }

            });
        }

        /// <summary>
        /// Event handler for when a push notification error occurs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PushChannel_ErrorOccurred(object sender, NotificationChannelErrorEventArgs e)
        {
            // Error handling logic for your particular application would be here.
            Dispatcher.BeginInvoke(() =>
                MessageBox.Show(String.Format("A push notification {0} error occurred.  {1} ({2}) {3}",
                    e.ErrorType, e.Message, e.ErrorCode, e.ErrorAdditionalData))
                    );
        }

        /// <summary>
        /// Event handler for when a toast notification arrives while your application is running.  
        /// The toast will not display if your application is running so you must add this
        /// event handler if you want to do something with the toast notification.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PushChannel_ShellToastNotificationReceived(object sender, NotificationEventArgs e)
        {
            StringBuilder message = new StringBuilder();
            string relativeUri = string.Empty;

            message.AppendFormat("Received Toast {0}:\n", DateTime.Now.ToShortTimeString());

            // Parse out the information that was part of the message.
            foreach (string key in e.Collection.Keys)
            {
                message.AppendFormat("{0}: {1}\n", key, e.Collection[key]);

                if (string.Compare(
                    key,
                    "wp:Param",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.CompareOptions.IgnoreCase) == 0)
                {
                    relativeUri = e.Collection[key];
                }
            }

            // Display a dialog of all the fields in the toast.
            Dispatcher.BeginInvoke(() => MessageBox.Show(message.ToString()));

        }


        #endregion


        private void post(String url, String postData)
        {

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] data = encoding.GetBytes(postData);
            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(url + "?mod=logout_reminder");
            httpWReq.Method = "POST";
            // httpWReq.ProtocolVersion = HttpVersion.Version10;
            httpWReq.Headers = new WebHeaderCollection();
            httpWReq.ContentType = "application/x-www-form-urlencoded";
            httpWReq.ContentLength = data.Length;
            httpWReq.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), httpWReq);
        }
        String postData;

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

        private void GetResponceStreamCallback(IAsyncResult callbackResult)
        {
            String result;
            HttpWebRequest request = (HttpWebRequest)callbackResult.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult);
            using (StreamReader httpWebStreamReader = new StreamReader(response.GetResponseStream()))
            {
                result = httpWebStreamReader.ReadToEnd();
            }
        }

        void rotate()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        int num_count = 0;
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            DispatcherTimer tmp = sender as DispatcherTimer;
            if (num_count >= Common.count)
            {
                tmp.Stop();
            }
            else
            {
                num_count++;
            }
            Storyboard MyStory = new Storyboard();
            MyStory.Duration = new TimeSpan(0, 0, 1);
            DoubleAnimation My_Double = new DoubleAnimation();
            My_Double.Duration = new TimeSpan(0, 0, 1);
            MyStory.Children.Add(My_Double);
            RotateTransform MyTransform = new RotateTransform();
            Storyboard.SetTarget(My_Double, MyTransform);
            Storyboard.SetTargetProperty(My_Double, new PropertyPath("Angle"));
            My_Double.To = 360;
            img_refresh.RenderTransform = MyTransform;
            img_refresh.RenderTransformOrigin = new Point(0.5, 0.5);
            MyStory.Begin();
        }

        private void Event_Logout(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Đăng xuất", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                String token = (String)userSettings["urlPush"];
                postData = "user_id=" + user.user_id + "&token=" + token + "&user_access_token=" + user.user_access_token;
                try
                {
                    userSettings.Remove("login_result");
                    userSettings.Remove("token");
                    userSettings.Remove("user_id");
                    userSettings.Remove("name");
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    user = new userDataJson();
                    this.post(Common.http, postData);
                    ShowLogin();
                }
            }
        }

        private void Event_LoadData(object sender, System.Windows.Input.GestureEventArgs e)
        {
            rotate();
            showTile("Phan thanh giang");
            LoadDemoData();
        }
    }
    public abstract class DataTemplateSelector : ContentControl
    {
        public virtual DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return null;
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);

            ContentTemplate = SelectTemplate(newContent, this);
        }
    }
    public class ContactTemplateSelector : DataTemplateSelector
    {
        public DataTemplate title
        {
            get;
            set;
        }
        public DataTemplate Item
        {
            get;
            set;
        }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var reminder = item as Reminder;
            if (reminder != null)
            {
                return reminder.title_type? title : Item;
            }
            return base.SelectTemplate(item, container);
        }
    }
}