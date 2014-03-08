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
using Microsoft.Phone.Net.NetworkInformation;

namespace BMS_Altamedia_Reminder
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        ObservableCollection<Reminder> _PathCollection = new ObservableCollection<Reminder>();
        public ObservableCollection<Reminder> PathCollection
        { get { return _PathCollection; } }
        BackgroundWorker backroungWorker;
        private Popup popup;
        private Boolean flag_flashing;
        private Boolean flag_login;
        HttpNotificationChannel pushChannel;
      
        private IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;
      
        userDataJson user;
        public MainPage()
        {
            InitializeComponent();
            Notifycation();
            loadAppData();
            LoadData();
            flag_flashing = false;
            ShowSplash();
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

        #region backgroundWorker
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
                    if (NetworkInterface.GetIsNetworkAvailable())
                    {
                        showTile("Xin chào " + user.user_name);
                        getData();
                    }
                    else
                    {
                        MessageBox.Show("Không có kết nối internet kiểm tra Wifi hoặc 3G");
                        Application.Current.Terminate();
                    }
                }
            });
        }
        #endregion

        #region HTTP
        Reminder remind;
        private void Completed(int id)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                if (user.result)
                {
                    rotate();
                    remind = Search(id);
                    if (remind != null)
                    {
                        postData = "user_id=" + user.user_id + "&user_access_token=" + user.user_access_token + "&id=" + remind.id + "&type=" + remind.type;
                        System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                        byte[] data = encoding.GetBytes(postData);
                        HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(Common.http + "?mod=reminder_action&action=complete");
                        httpWReq.Method = "POST";
                        // httpWReq.ProtocolVersion = HttpVersion.Version10;
                        httpWReq.Headers = new WebHeaderCollection();
                        httpWReq.ContentType = "application/x-www-form-urlencoded";
                        httpWReq.ContentLength = data.Length;
                        httpWReq.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback_Complete), httpWReq);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có kết nối internet kiểm tra lại kết nối wifi hoặc 3G");
            }
        }

        private void GetRequestStreamCallback_Complete(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
            // End the stream request operation
            Stream postStream = request.EndGetRequestStream(asynchronousResult);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(postData);
            postStream.Write(data, 0, data.Length);
            postStream.Close();
            request.BeginGetResponse(new AsyncCallback(GetResponceStreamCallback_Complete), request);
        }

        private void GetResponceStreamCallback_Complete(IAsyncResult callbackResult)
        {
            String result = String.Empty;
            List<groupReminder> list_group = new List<groupReminder>();
            HttpWebRequest request = (HttpWebRequest)callbackResult.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult);
            using (StreamReader httpWebStreamReader = new StreamReader(response.GetResponseStream()))
            {
                result = httpWebStreamReader.ReadToEnd();
            }
            dynamic tmpJson = Newtonsoft.Json.Linq.JObject.Parse(result);
            bool jsonResult = tmpJson.result;
            if (jsonResult && remind != null)
            {
                this.Dispatcher.BeginInvoke(() =>
                {
                    _PathCollection.Remove(remind);
                    ContactListBox.ItemsSource = this.PathCollection;
                    optimize();
                });
            }
            else
            {
                MessageBox.Show("Không thể hoàn thành công việc!", "Thông báo", MessageBoxButton.OK);
            }
            this.Dispatcher.BeginInvoke(() =>
               {
                   try
                   {
                       if (dispatcherTimer.IsEnabled)
                           dispatcherTimer.Stop();
                   }
                   catch (Exception ex)
                   {
#if DEBUG
                       MessageBox.Show(ex.Message);
#endif
                   }
               });
           
        }

        private void getData()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                if (user.result)
                {
                    rotate();
                    postData = "user_id=" + user.user_id + "&user_access_token=" + user.user_access_token;
                    System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                    byte[] data = encoding.GetBytes(postData);
                    HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(Common.http + "?mod=get_reminder");
                    httpWReq.Method = "POST";
                    // httpWReq.ProtocolVersion = HttpVersion.Version10;
                    httpWReq.Headers = new WebHeaderCollection();
                    httpWReq.ContentType = "application/x-www-form-urlencoded";
                    httpWReq.ContentLength = data.Length;
                    httpWReq.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), httpWReq);
                }
            }
            else
            {
                MessageBox.Show("Không có kết nối internet kiểm tra lại kết nối wifi hoặc 3G");
            }
        }

        private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
            // End the stream request operation
            Stream postStream = request.EndGetRequestStream(asynchronousResult);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(postData);
            postStream.Write(data, 0, data.Length);
            postStream.Close();
            request.BeginGetResponse(new AsyncCallback(GetResponceStreamCallback), request);
        }

        private void GetResponceStreamCallback(IAsyncResult callbackResult)
        {
            String result = String.Empty;
            List<groupReminder> list_group = new List<groupReminder>();
            HttpWebRequest request = (HttpWebRequest)callbackResult.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult);
            using (StreamReader httpWebStreamReader = new StreamReader(response.GetResponseStream()))
            {
                result = httpWebStreamReader.ReadToEnd();
            }
            dynamic root = Newtonsoft.Json.Linq.JObject.Parse(result);
            Newtonsoft.Json.Linq.JArray Reminders = (Newtonsoft.Json.Linq.JArray)root["reminders"];
            Newtonsoft.Json.Linq.JObject reminder;
            int lenght = Reminders.Count;
            List_Remider list = new List_Remider();

            //MessageBox.Show(""+lenght);
            for (int i = 0; i < lenght; i++) //loop through rows
            {
                reminder = (Newtonsoft.Json.Linq.JObject)Reminders[i];
                Reminder tmp = new Reminder(reminder);
                System.Diagnostics.Debug.WriteLine(reminder.ToString());
                list.data.Add(tmp);
            }
            //lenght = list.count;
            int size = list.count;
            while (size > 0)
            {
                int j = 0;
                Reminder remind = list.data[j];
                groupReminder tmpGroup = new groupReminder();
                tmpGroup.data.Add(remind);
                tmpGroup.title = remind.Str_date;
                tmpGroup.date = remind.date;
                list.data.RemoveAt(j);
                size = list.count;
                while (size > j)
                {
                    if (remind.date.Date == list.data[j].date.Date)
                    {
                        tmpGroup.data.Add(list.data[j]);
                        list.data.RemoveAt(j);
                        size = list.count;
                    }
                    else
                    {
                        j++;
                    }
                }
                list_group.Add(tmpGroup);

            }
            int gSize = list_group.Count;
            this.Dispatcher.BeginInvoke(() =>
                 {
                     _PathCollection.Clear();
                     if (gSize > 0)
                     {
                         for (int jj = 0; jj < gSize; jj++)
                         {
                             groupReminder tmpGroup = list_group[jj];
                             if (tmpGroup.date.Date == DateTime.Now.Date)
                             {
                                 Reminder title = new Reminder();
                                 title.title = "Công việc ngày hôm nay " + tmpGroup.title;
                                 title.title_type = 0;
                                 title.title_mode = true;
                                
                                 _PathCollection.Add(title);
                             }
                             else if (tmpGroup.date.Date < DateTime.Now.Date)
                             {
                                 Reminder title = new Reminder();
                                 title.title = "Công việc ngày " + tmpGroup.title;
                                 title.title_mode = true;
                                
                                 title.title_type = -1;
                                 _PathCollection.Add(title);
                             }
                             else
                             {
                                 Reminder title = new Reminder();
                                 title.title = "Công việc ngày " + tmpGroup.title;
                                 title.title_mode = true;
                                 
                                 title.title_type = 1;
                                 _PathCollection.Add(title);
                             }
                             int gDataSize = list_group[jj].count;
                             for (int jjj = 0; jjj < gDataSize; jjj++)
                             {
                                 _PathCollection.Add(list_group[jj].data[jjj]);
                             }
                         }

                         ContactListBox.ItemsSource = this.PathCollection;

                     }

                     try
                     {
                         if (dispatcherTimer.IsEnabled)
                             dispatcherTimer.Stop();
                     }
                     catch (Exception ex)
                     {
#if DEBUG
                         MessageBox.Show(ex.Message);
#endif
                     }

                 });
        }
        #endregion

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
                        getData();
                    }
                    catch (Exception ex)
                    {
#if DEBUG
                        MessageBox.Show(ex.Message);
#endif
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

        private void Notifycation()
        {
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
                pushChannel.BindToShellTile();
             
                try
                {
                    Common.urlToast = pushChannel.ChannelUri.ToString();
                    userSettings.Add("urlPush", pushChannel.ChannelUri.ToString());
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.Message);
#endif
                }

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
#if DEBUG
                    MessageBox.Show(ex.Message);
#endif
                }
            }
        }


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
                if (Common.urlToast != String.Empty)
                {
                    try
                    {
                        userSettings.Remove("urlPush");
                        userSettings.Add("urlPush", e.ChannelUri.ToString());
                    }
                    catch (Exception ex)
                    {
                        userSettings.Add("urlPush", e.ChannelUri.ToString());
                    }
                }
                else
                {
#if DEBUG
                    MessageBox.Show("ID Empty");
#endif
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

            //message.AppendFormat("Received Toast {0}:\n", DateTime.Now.ToShortTimeString());

            //// Parse out the information that was part of the message.
            //foreach (string key in e.Collection.Keys)
            //{
            //    message.AppendFormat("{0}: {1}\n", key, e.Collection[key]);

            //    if (string.Compare(
            //        key,
            //        "wp:Param",
            //        System.Globalization.CultureInfo.InvariantCulture,
            //        System.Globalization.CompareOptions.IgnoreCase) == 0)
            //    {
            //        relativeUri = e.Collection[key];
            //    }
            //}

            // Display a dialog of all the fields in the toast.
            if(user.result){
                Dispatcher.BeginInvoke(() => { 
#if  DEBUG
                    MessageBox.Show("dang nhap thanh cong reload data","DEBUG",MessageBoxButton.OK);
#endif
                    getData(); 
                });
            }else{
#if DEBUG 
                Dispatcher.BeginInvoke(() => { MessageBox.Show("chua dang nhap", "debug", MessageBoxButton.OK); });
#endif
            }

        }


        #endregion
        String postData;
        DispatcherTimer dispatcherTimer;
        void rotate()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //DispatcherTimer tmp = sender as DispatcherTimer;
            //if (num_count >= Common.count)
            //{
            //    tmp.Stop();
            //}
            //else
            //{
            //    num_count++;
            //}
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
                    userSettings.Clear();
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    user = new userDataJson();
                    Common http = new Common();
                    http.post("?mod=logout_reminder", postData);
                    ShowLogin();
                    if (pushChannel.IsShellToastBound)
                    {
                        pushChannel.UnbindToShellToast();
                    }
                    if (pushChannel.IsShellTileBound)
                    {
                        pushChannel.UnbindToShellTile();
                    }
                }
            }
        }

        private void optimize()
        {
            int lenght = _PathCollection.Count;
            if (_PathCollection[lenght - 1].title_mode == true) 
            {
                _PathCollection.RemoveAt(lenght-1);
                ContactListBox.ItemsSource = PathCollection;
                lenght = _PathCollection.Count;
            };
            
            int i=0;
            while(i<lenght-1)
            {
                if (_PathCollection[i].title_mode && _PathCollection[i + 1].title_mode)
                {
                    _PathCollection.RemoveAt(i);
                    ContactListBox.ItemsSource = PathCollection;
                    lenght = _PathCollection.Count;
                }
                else
                {
                    i++;
                }
            }
        }

        private void Event_LoadData(object sender, System.Windows.Input.GestureEventArgs e)
        {
            getData();
        }
        private void Click_Complete(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hoàn thành công việc này không?", "Thông Báo", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var tmp = sender as Image;
                int id = (int)tmp.Tag;
                Completed(id);
            }

        }
        private Reminder Search(int id)
        {
            int length = PathCollection.Count();
            for (int i = 0; i < length; i++)
            {
                if (PathCollection[i].id == id)
                    return PathCollection[i];
            }
            return null;
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
        public DataTemplate titlelast { get; set; }
        public DataTemplate title_fur { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var reminder = item as Reminder;
            if (reminder != null)
            {
                if (reminder.title_mode)
                {
                    if (reminder.title_type == -1)
                    {
                        return titlelast;
                    }
                    else if (reminder.title_type == 0)
                    {
                        return title;
                    }
                    else
                    {
                        return title_fur;
                    }
                }
                return Item;
            }
            return base.SelectTemplate(item, container);
        }
    }
}