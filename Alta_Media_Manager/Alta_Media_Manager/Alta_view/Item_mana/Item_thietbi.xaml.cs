using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Alta_Media_Manager.Class;

namespace Alta_Media_Manager.Alta_view.Item_mana
{
    /// <summary>
    /// Interaction logic for Item_thietbi.xaml
    /// </summary>
    public partial class Item_thietbi : UserControl
    {
        private String ip;
        public alta_client client;
        private bool flag_connect;
        private BackgroundWorker bw = new BackgroundWorker();
        private String key;
        private String noonce;
        private bool status;
        Thread checkOnline;
        private Class.alta_class_media file_playing;
        public event RoutedEventHandler viewStreaming;
        public event EventHandler<Class.alta_class_termiral> EditTermiral;
        public Class.alta_class_playlist playlist { get { return LoadPlaylist(); } }

        public Item_thietbi()
        {
            InitializeComponent();
            checkOnline = new Thread(functionCheckOnline);
            checkOnline.IsBackground = true;
            flag_connect = false;
            status = false;
            noonce = key = "";
            client = new alta_client();
            client.Disconnect += client_Disconnect;
            client.NoOnceEvent += client_NoOnceEvent;
            client.MsgEvent += client_MsgEvent;
            client.OkEvent += client_OkEvent;
            client.MediaPlaying += client_MediaPlaying;
            if (CommonUtilities.alta_curUser.alta_type_user.alta_id == 1)
            {
                btn_turn_off.Visibility = Visibility.Visible;
            }
            else
            {
                btn_turn_off.Visibility = Visibility.Hidden;
            }
        }

        void client_MediaPlaying(object sender, mediaTCP e)
        {
            if (e.id > 0)
            {
                this.file_playing = Mysql_helpper.mysql_alta_helpper.getMedia(e.id);
            }
            else
            {
                this.lb_name_file.Content = "";
                this.file_playing = null;
            }
        }

        void client_OkEvent(object sender, string e)
        {
            if (noonce != String.Empty && !flag_send_Screen)
            {
                client.sendData("SCREEN");
                flag_send_Screen = true;
                flag_connect = true;
            }
        }

        void client_MsgEvent(object sender, string e)
        {
            MessageBox.Show(e);
        }

        void client_NoOnceEvent(object sender, string e)
        {
            noonce = CommonUtilities.alta_curUser.getNoOnce(e);
            if (CommonUtilities.alta_curUser.alta_type_user.alta_id == 1)
            {
                noonce = "ADMIN_" + noonce;
            }
            client.sendData(noonce);
        }

        void client_Disconnect(object sender, EventArgs e)
        {
            this.flag_connect = false;

        }
        ~Item_thietbi()
        {
            try
            {
                if (checkOnline.IsAlive)
                    checkOnline.Abort();
            }
            catch (Exception)
            {

            }
            finally
            {
                checkOnline = null;
            }
        }

        private void functionCheckOnline(object obj)
        {
            while (true)
            {
                Alta_Ping();
                Thread.Sleep(5000);
            }
        }

        private Class.alta_class_playlist LoadPlaylist()
        {
            Class.alta_class_playlist playlist = new Class.alta_class_playlist();
            if (this.Tag != null)
            {
                Class.alta_class_termiral termiral = this.Tag as Class.alta_class_termiral;
                playlist = Mysql_helpper.mysql_alta_helpper.getScheduleDetails(termiral.alta_id, DateTime.Now);
            }
            return playlist;
        }


        public void LoadData(Class.alta_class_termiral terminal)
        {
            if (terminal != null)
            {
                this.Tag = terminal;
                this.ip = terminal.alta_ip;
                this.lb_ip.Content = "IP: " + terminal.alta_ip;
                this.lb_name.Content = terminal.alta_name;
                this.lb_name_type.Content = "Type: " + terminal.alta_type.alta_name;
                // this.lb_name_file.Content = "File:";
                LoadPlaylist();
                if (terminal.user != null)
                    this.lb_user_name.Content = "User: " + terminal.user.alta_full_name;
                checkOnline.Start();
            }
        }
        public void Alta_Ping()
        {
            try
            {
                AutoResetEvent waiter = new AutoResetEvent(false);
                Ping pingSender = new Ping();
                pingSender.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);
                IPAddress address = IPAddress.Parse(this.ip); ;
                int timeout = 3000;
                pingSender.SendAsync(address, timeout, waiter);
                waiter.Close();
            }
            catch (Exception)
            {

            }

        }
        private void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            PingReply tmp = e.Reply;
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                  delegate()
                  {
                      if (tmp.Status == IPStatus.Success && this.client.isConnected)
                      {
                          flag_connect = true;
                          status = true;
                          this.status_btn.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/white/ic_action_location_found.png")));
                      }
                      else if (tmp.Status == IPStatus.Success && !this.client.isConnected)
                      {
                          noonce = "";
                          flag_connect = false;
                          status = true;
                          this.status_btn.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/white/ic_action_warning.png")));
                      }
                      else
                      {
                          status = false;
                          noonce = "";
                          flag_connect = false;
                          this.status_btn.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/white/ic_action_location_off.png")));
                      }
                  }));
            if (tmp.Status == IPStatus.Success && !flag_connect)
            {
                if (!client.isConnected && client.autoConnect)
                {
                    client.connect(this.ip);
                    flag_connect = true;
                    if (client.key != "")
                        this.key = client.key;

                }
                else
                {

                }
            }
        }


        public void SendControl(String cmd)
        {
            client.sendData(cmd);
        }
        private void ViewStreaming(object sender, RoutedEventArgs e)
        {
            if (status)
            {
                if (viewStreaming != null)
                    viewStreaming(this, new RoutedEventArgs());
            }
            else
            {
                MessageBox.Show("Màn hình hiện không online");
            }
        }
        public object view_Stream { get; set; }

        private void btn_full_screen(object sender, RoutedEventArgs e)
        {
            if(client.isConnected)
                client.sendData("SCREEN");
            if (viewFilePlaying != null)
            {
                PlayEvent eventPlay= new PlayEvent(){media=this.file_playing};
                viewFilePlaying(this,eventPlay);
            }
        }
        private void btn_view_playlist_click(object sender, RoutedEventArgs e)
        {

            if (ViewPlaylistEvent != null)
            {
                ViewPlaylistEvent(this, this.playlist);
            }

        }
        public event EventHandler<PlayEvent> viewFilePlaying;
        public event EventHandler<Class.alta_class_playlist> ViewPlaylistEvent;
        private void btn_Stop_Play_Click(object sender, RoutedEventArgs e)
        {
            if (this.client.isConnected)
            {
                this.client.sendData("STOP");
            }
            else
            {
                MessageBox.Show("Hiện tại không thể kết nối với màn hình!");
            }
        }
        private void btn_setting_click(object sender, RoutedEventArgs e)
        {
            if (EditTermiral != null)
            {
                EditTermiral(this, this.Tag as Class.alta_class_termiral);
            }
        }
        private void btn_turn_off_click(object sender, RoutedEventArgs e)
        {
            if (this.client.isConnected)
            {
                if (MessageBox.Show("Bạn muốn tắt màn hình này không?", "Thông báo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    this.SendControl("TURN_OFF");
                this.client.autoConnect = false;
            }
            else
            {
                MessageBox.Show("Hiện tại không thể kết nối với màn hình!");
            }
        }
        private void btn_delete_click(object sender, RoutedEventArgs e)
        {
            if (DeleteEvent != null)
            {
                DeleteEvent(this, this.Tag as Class.alta_class_termiral);
            }
        }
        public event EventHandler<Class.alta_class_termiral> DeleteEvent;

        private void Hide_Action_Bar(object sender, MouseEventArgs e)
        {
            this.grid_action.Visibility = Visibility.Hidden;
        }

        private void Show_Action_Bar(object sender, MouseEventArgs e)
        {
            this.grid_action.Visibility = Visibility.Visible;
        }
        public bool flag_send_Screen { get; set; }
    }
    public class PlayEvent
    {
        public Class.alta_class_media media
        {
            get { return _media; }
            set
            {
                _media = value;
                isMedia = true;
                isStreaming = false;
            }
        }
        private Class.alta_class_media _media;
        public EndPoint StreamIP
        {
            get { return _ip; }
            set
            {
                _ip = value;
                isMedia = false;
                isStreaming = true;
            }
        }
        private EndPoint _ip;
        public bool isMedia;
        public bool isStreaming;
    }
}
