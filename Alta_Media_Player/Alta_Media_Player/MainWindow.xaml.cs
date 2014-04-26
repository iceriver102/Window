using Alta_Media_Manager.Alta_view.Mysql_helpper;
using Alta_Media_Manager.Class;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops.Signatures.LibVlc.MediaListPlayer;
using Vlc.DotNet.Core.Medias;
using Alta_Media_Manager.Alta_view.Class;
using System.Security.Cryptography;
using Alta_Media_Manager.Alta_net;
using System.Threading;
using System.Windows.Threading;

namespace Alta_Media_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool myPositionChanging;
        public bool flag_play_local { get; set; }
        public AnimationClock clock { get; set; }
        public AnimationClock mainClock { get; set; }
        public bool flag_Load_Data;
        private BackgroundWorker bw = new BackgroundWorker();
        private Thread sendImgThread;
        private Thread localThread;
        private alta_class_schedules Schedule;
        private alta_playlist_player mainPlaylist;
        private alta_class_net Tcp_Server;
        private int countDemo;
        string output = @":sout=#transcode{vcodec=h264,acodec=mpga,ab=128,channels=2,samplerate=44100}:rtp{sdp=rtsp://:8554/demo}";
        public MainWindow()
        {
            initVLC();
            InitializeComponent();
            countDemo = 0;
           // LoadConfig();
            Schedule = new alta_class_schedules();
            mainPlaylist = new alta_playlist_player();
            myVlcControl.PositionChanged += VlcControlOnPositionChanged;
            myVlcControl.TimeChanged += VlcControlOnTimeChanged;
            myVlcControl.Paused += myVlcControl_Paused;
            myVlcControl.Playing += myVlcControl_Playing;
            myVlcControl.Stopped += myVlcControl_Stopped;
            myVlcControl.PlaybackMode = PlaybackModes.Loop;
            this.Closing += MainWindowOnClosing;
            flag_Load_Data = false;
            flagPlaying = false;
            flagTiming = false;
            using (MD5 md5Hash = MD5.Create())
            {
                CommonUtilities.keySerect = CommonUtilities.GetMd5Hash(md5Hash, DateTime.Now.Ticks.ToString());
            }
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = false;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);        
            Start();          
            Tcp_Server = new alta_class_net();
            Tcp_Server.SendPlaying += Tcp_Server_SendPlaying;
        }

        void Tcp_Server_SendPlaying(object sender, System.Net.EndPoint e)
        {
            if (flagPlaying)
            {
                alta_media_in_player media = this.mainPlaylist.media[this.mainPlaylist.cur_pos_play];
                this.Tcp_Server.SendMsg("PLAY|" + media.ID + "_" + media.name,e);
            }
            else
            {
                this.Tcp_Server.SendMsg("PLAY|" + -1 + "_" + "NULL");
            }
        }

        void myVlcControl_Stopped(Vlc.DotNet.Wpf.VlcControl sender, VlcEventArgs<EventArgs> e)
        {
           
        }  
        #region Back ground worker
        private void Start()
        {
            if (!bw.IsBusy)
                bw.RunWorkerAsync();

        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            flag_Load_Data = true;
            ClockPlay();
        }

        private void LoadMyselfInfo()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string _query = "SELECT `termiral_id`, `termiral_name`, `termiral_ip`, `termiral_content`, `termiral_status` FROM `am_termiral` WHERE  `termiral_id`=@id_termiral";
                    using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_termiral", CommonUtilities.config.id_termiral);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) > 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                CommonUtilities.This = mysql_alta_helpper.getTermiral(reader);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
        }
        public void LoadMySchedule()
        {
            if (CommonUtilities.This.alta_status)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                    {
                        conn.Open();
                        string _query = "SELECT `schedules_id`, `user_id`, `termiral_id`, `schedules_date_begin`, `schedules_date_end`, `schedules_content` FROM `am_schedules` ";
                        _query += "WHERE termiral_id=@id_termiral AND DATE_FORMAT( schedules_date_begin,  '%Y-%m-%d' ) <= DATE_FORMAT( NOW( ) ,  '%Y-%m-%d' ) AND DATE_FORMAT( schedules_date_end,  '%Y-%m-%d' ) >= DATE_FORMAT( NOW( ) ,  '%Y-%m-%d' ) ";
                        using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id_termiral", CommonUtilities.This.alta_id);
                            var tmp = cmd.ExecuteScalar();
                            if (Convert.ToInt32(tmp) > 0)
                            {
                                using (MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    this.Schedule = mysql_alta_helpper.getSchedule(reader);
                                    this.Schedule.alta_user = mysql_alta_helpper.getUser(this.Schedule.alta_user.alta_id);
                                    CommonUtilities.userColtrol = this.Schedule.alta_user;
                                }
                            }
                        }
                        conn.Close();
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
#if DEBUG
                MessageBox.Show("Màn hình đang ở chế độ khoá");
#endif
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!flag_Load_Data)
            {
              //  LoadMyselfInfo();
                this.LoadMySchedule();
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        #endregion

        #region VLC menthod
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VlcControlOnPositionChanged(Vlc.DotNet.Wpf.VlcControl sender, VlcEventArgs<float> e)
        {
            if (myPositionChanging)
            {
                // User is currently changing the position using the slider, so do not update. 
                return;
            }
            // demoTxt.Text = e.Data.ToString("#.00");
            barTimeSeek.Value = (int)(e.Data * 100);
        }
        void myVlcControl_Playing(Vlc.DotNet.Wpf.VlcControl sender, VlcEventArgs<EventArgs> e)
        {
            if (mediaClock != null && mediaClock.IsPaused)
                mediaClock.Controller.Resume();
            HideControl();
        }
        void myVlcControl_Paused(Vlc.DotNet.Wpf.VlcControl sender, VlcEventArgs<EventArgs> e)
        {

            if (mediaClock != null)
                mediaClock.Controller.Pause();
            try
            {
                if (localThread != null && localThread.IsAlive)
                    localThread.Abort();
                VisibleControl();
            }
            catch (Exception ex)
            {

            }
            
        }
        private void VlcControlOnTimeChanged(Vlc.DotNet.Wpf.VlcControl sender, VlcEventArgs<TimeSpan> e)
        {

            if (myVlcControl.Media == null)
            {
                return;
            }
            TimeSpan duration = myVlcControl.Media.Duration;
            if (mainPlaylist != null && mainPlaylist.media != null)
            {
                if (duration == TimeSpan.Zero && mainPlaylist.media[mainPlaylist.cur_pos_play].isVideo)
                    return;
                alta_txt_curTime.Text = string.Format(
                    "{0:00}:{1:00}:{2:00}",
                    e.Data.Hours,
                    e.Data.Minutes,
                    e.Data.Seconds);
                if (duration.TotalSeconds - e.Data.TotalSeconds < 1 && flagTiming && !flag_camera_media)
                {
                    myVlcControl.Pause();
                    myVlcControl.Position = 0;
                    myVlcControl.Play();
                }
                else if (duration.TotalSeconds - e.Data.TotalSeconds < 1 && !flagTiming && !flag_camera_media)
                {
                    myVlcControl.Pause();
                    flagPlaying = false;
                   // if (this.mainPlaylist != null)
                       // mainPlaylist.cur_pos_play = Next(mainPlaylist);
                }
            }
            //totalTime.Text = string.Format("{0:00}:{1:00}:{2:00}",
            //    duration.Hours,
            //    duration.Minutes,
            //    duration.Seconds);
        }
        public void initVLC()
        {
            // Set libvlc.dll and libvlccore.dll directory path
            VlcContext.LibVlcDllsPath = @"VLC";

            // Set the vlc plugins directory path
            VlcContext.LibVlcPluginsPath = @"VLC\plugins";


            // Ignore the VLC configuration file
            VlcContext.StartupOptions.IgnoreConfig = true;

            // Enable file based logging
            VlcContext.StartupOptions.LogOptions.LogInFile = true;

            // Shows the VLC log console (in addition to the applications window)
            // VlcContext.StartupOptions.LogOptions.ShowLoggerConsole = true;

            // Set the log level for the VLC instance
            //  VlcContext.StartupOptions.LogOptions.Verbosity = VlcLogVerbosities.Debug;
            VlcContext.StartupOptions.AddOption("--ffmpeg-hw");
            // Disable showing the movie file name as an overlay
            VlcContext.StartupOptions.AddOption("--no-video-title-show");
            VlcContext.StartupOptions.AddOption("--rtsp-tcp");
            VlcContext.StartupOptions.AddOption("--rtsp-mcast");
            VlcContext.StartupOptions.AddOption("--rtsp-port=8554");
            VlcContext.StartupOptions.AddOption("--rtp-client-port=8554");
            VlcContext.StartupOptions.AddOption("--sout-rtp-rtcp-mux");
            VlcContext.StartupOptions.AddOption("--rtsp-wmserver");


            VlcContext.StartupOptions.AddOption("--file-caching=18000");
            VlcContext.StartupOptions.AddOption("--sout-rtp-caching=18000");
            VlcContext.StartupOptions.AddOption("--sout-rtp-port=8554");
            VlcContext.StartupOptions.AddOption("--sout-rtp-proto=tcp");
            VlcContext.StartupOptions.AddOption("--network-caching=1000");

            // Pauses the playback of a movie on the last frame
            VlcContext.StartupOptions.AddOption("--play-and-pause");

            // Initialize the VlcContext
            VlcContext.Initialize();
        }
        #endregion

        #region VLC event
        private void MainWindowOnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VlcContext.CloseAll();
        }


        /// <summary>
        /// ẩn thanh điều khiển
        /// </summary>
        private void HideControl(int time = 5)
        {
            Title_Layout.Visibility = Visibility.Visible;
            ControlPlayer_Layout.Visibility = Visibility.Visible;
            if (WindowState == WindowState.Maximized)
            {
                if (time > 5)
                {
                    localThread = new Thread(localThreadRun);
                    localThread.IsBackground = true;
                    localThread.Start();
                }
                else
                {
                    DoubleAnimation daHideControl = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(2));
                    clock = daHideControl.CreateClock();
                    daHideControl.EasingFunction = new PowerEase() { EasingMode = EasingMode.EaseOut };
                    clock.Completed += (o, s) =>
                    {
                        Title_Layout.Visibility = Visibility.Hidden;
                        ControlPlayer_Layout.Visibility = Visibility.Hidden;
                        try
                        {
                            if (localThread != null && localThread.IsAlive)
                                localThread.Abort();
                        }
                        catch (Exception)
                        {

                        }
                    };

                    Title_Layout.ApplyAnimationClock(OpacityProperty, clock);
                    ControlPlayer_Layout.ApplyAnimationClock(OpacityProperty, clock);
                }
            }
            else
            {
                this.VisibleControl();
            }
        }

        private void localThreadRun(object obj)
        {
            while (true)
            {
                Thread.Sleep(10000);
                if (clock != null)
                    clock.Controller.Begin();
                localThread.Abort();
            }
        }
        /// <summary>
        /// hàm hiện thanh điều khiển
        /// </summary>
        private void VisibleControl()
        {
            Title_Layout.Visibility = Visibility.Visible;
            ControlPlayer_Layout.Visibility = Visibility.Visible;
            try
            {
                if (clock != null)
                    clock.Controller.Stop();
                Title_Layout.Opacity = 1;
                ControlPlayer_Layout.Opacity = 1;
            }
            catch (Exception)
            {
            }
        }
        private void Close_Click_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_move(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Changed_State_Event(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (localThread != null && localThread.IsAlive)
                    localThread.Abort();
            }
            catch (Exception ex)
            {

            }
            VisibleControl();
            HideControl(15);
            //if (myVlcControl.IsPaused)
            //{
            //    myVlcControl.Play();
            //    btn_play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Player;component/Asset/Themes/ic_action_pause.png")));
            //}
            //else if (myVlcControl.IsPlaying)
            //{
            //    myVlcControl.Pause();
            //    btn_play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Player;component/Asset/Themes/ic_action_play.png")));
            //}

        }

        private void WindowCHange_State_btn_Click(object sender, RoutedEventArgs e)
        {

            if (WindowState.Maximized == this.WindowState)
            {
                this.WindowState = WindowState.Normal;
                btn_full_screen.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Player;component/Asset/Themes/ic_action_full_screen.png")));
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                btn_full_screen.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Player;component/Asset/Themes/ic_action_return_from_full_screen.png")));
            }
            HideControl();
        }
        private void OpenMedia()
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Open media file for playback",
                Filter = "All files |*.*"
            };
            if (openFileDialog.ShowDialog() != true)
                return;
            flag_play_local = true;
            myVlcControl.Media = new PathMedia(openFileDialog.FileName);
            myVlcControl.Media.ParsedChanged += MediaOnParsedChanged;
            myVlcControl.Play();
            btn_play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Player;component/Asset/Themes/ic_action_pause.png")));
            FileInfo File_open = new FileInfo(openFileDialog.FileName);
            txt_alta_media_name.Text = File_open.Name;
        }

        private void Open_btn_Click(object sender, RoutedEventArgs e)
        {
            myVlcControl.Stop();
            if (myVlcControl.Media != null)
            {
                myVlcControl.Media.ParsedChanged -= MediaOnParsedChanged;
            }
            OpenMedia();
        }

        private void MediaOnParsedChanged(Vlc.DotNet.Core.Medias.MediaBase sender, VlcEventArgs<int> e)
        {
            alta_txt_curTime.Text = string.Format(
                "{0:00}:{1:00}:{2:00}",
                myVlcControl.Media.Duration.Hours,
                myVlcControl.Media.Duration.Minutes,
                myVlcControl.Media.Duration.Seconds);
        }



        private void btn_Click_Mute(object sender, RoutedEventArgs e)
        {
            if (myVlcControl.AudioProperties.IsMute)
            {
                myVlcControl.AudioProperties.IsMute = false;
                btn_mute.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Player;component/Asset/Themes/ic_action_volume_on.png")));
            }
            else
            {
                myVlcControl.AudioProperties.IsMute = true;
                btn_mute.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Player;component/Asset/Themes/ic_action_volume_muted.png")));
            }

        }

        private void btn_Play_Event(object sender, RoutedEventArgs e)
        {

            if (myVlcControl.Medias.Count > 0)
            {
                if (myVlcControl.IsPlaying)
                {
                    myVlcControl.Pause();
                    btn_play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Player;component/Asset/Themes/ic_action_play.png")));
                }
                else
                {
                    myVlcControl.Play();
                    btn_play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Player;component/Asset/Themes/ic_action_pause.png")));
                }
            }

        }

        private void btn_Click_Stop(object sender, RoutedEventArgs e)
        {
            myVlcControl.Stop();
            flagPlaying = true;           
            btn_play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Player;component/Asset/Themes/ic_action_play.png")));
            barTimeSeek.Value = 0;
            if (mediaClock != null && mediaClock.CurrentState != ClockState.Stopped)
                mediaClock.Controller.Stop();
          
        }

        /// <summary>
        /// sự kiện seekbar change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressBarChange(object sender, MouseButtonEventArgs e)
        {
            //Update the current position text when it is in pause
            var duration = myVlcControl.Media == null ? TimeSpan.Zero : myVlcControl.Media.Duration;
            var time = TimeSpan.FromMilliseconds(duration.TotalMilliseconds * myVlcControl.Position);
            double pos;
            pos = (e.GetPosition(barTimeSeek).X / barTimeSeek.ActualWidth) * 100;
            if (pos >= barTimeSeek.Minimum && pos <= barTimeSeek.Maximum)
            {
                barTimeSeek.Value = (int)pos;
                if (myPositionChanging)
                {
                    myVlcControl.Position = (float)pos / 100;
                }
                // var duration = myVlcControl.Media.Duration;
                alta_txt_curTime.Text = string.Format(
                    "{0:00}:{1:00}:{2:00}",
                    time.Hours,
                    time.Minutes,
                    time.Seconds);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SliderMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            myPositionChanging = true;
            myVlcControl.PositionChanged -= VlcControlOnPositionChanged;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SliderMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            myVlcControl.Position = (float)barTimeSeek.Value / 100;
            myVlcControl.PositionChanged += VlcControlOnPositionChanged;
            myPositionChanging = false;
        }

        private void Volume_Change_Event(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            myVlcControl.AudioProperties.Volume = Convert.ToInt32(alta_volume.Value);
            if (Convert.ToInt32(alta_volume.Value) <= 0)
            {
                myVlcControl.AudioProperties.IsMute = true;
                btn_mute.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Player;component/Asset/Themes/ic_action_volume_muted.png")));
            }
            else
            {
                myVlcControl.AudioProperties.IsMute = false;
                btn_mute.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Player;component/Asset/Themes/ic_action_volume_on.png")));
            }
        }

        private void Vlc_btn_next_Click(object sender, RoutedEventArgs e)
        {
            if (mainPlaylist != null)
            {
                if (mediaClock != null && mediaClock.CurrentState != ClockState.Stopped)
                    mediaClock.Controller.Stop();
                mainPlaylist.cur_pos_play = Next(mainPlaylist);
            }
        }

        private void vlc_btn_back_click(object sender, RoutedEventArgs e)
        {
            if (mainPlaylist != null)
            {
                if (mediaClock != null && mediaClock.CurrentState != ClockState.Stopped)
                    mediaClock.Controller.Stop();
                mainPlaylist.cur_pos_play = Back(mainPlaylist);
            }
        }

        #endregion

        private void WinDow_Loaded(object sender, RoutedEventArgs e)
        {
            myVlcControl.AudioProperties.Volume = Convert.ToInt32(alta_volume.Value);

            if (this.flag_Load_Data)
            {
                //ClockPlay();
            }
        }

        #region Thread
        /// <summary>
        /// hàm khởi tạo thread chạy ngầm
        /// </summary>
        public void ClockPlay()
        {
            DoubleAnimation tmp = new DoubleAnimation(1, 1, TimeSpan.FromMinutes(3));
            tmp.RepeatBehavior = RepeatBehavior.Forever;
            mainClock = tmp.CreateClock();
            mainClock.CurrentTimeInvalidated += mainClock_CurrentTimeInvalidated;
            demoTxt.ApplyAnimationClock(OpacityProperty, clock);
        }     
        public alta_playlist_player LoadMediaToPlaylist(List<alta_class_playlist_details> list_media)
        {
            alta_playlist_player playlist = new alta_playlist_player();
            playlist.Count = list_media.Count;
            if (playlist.Count > 0)
            {
                playlist.media = new List<alta_media_in_player>();
                for (int i = 0; i < playlist.Count; i++)
                {
                    alta_media_in_player tmp = new alta_media_in_player();
                    tmp.ftpUrl = list_media[i].alta_media.alta_url;
                    if (list_media[i].alta_media.alta_media_type.alta_id == 1)
                    {
                        tmp.type = 1;
                        String location = alta_class_ftp.downLoadFile(list_media[i].alta_media.alta_url);
                        tmp.Url = location;
                        tmp.name = list_media[i].alta_media.alta_name;
                    }
                    else if (list_media[i].alta_media.alta_media_type.alta_id == 2)
                    {
                        tmp.type = 2;
                        tmp.Url = list_media[i].alta_media.alta_url;
                        tmp.name = list_media[i].alta_media.alta_name;
                    }
                    else
                    {
                        tmp.type = 3;
                        tmp.Url = list_media[i].alta_media.alta_url;
                        tmp.name = list_media[i].alta_media.alta_name;
                    }
                    DateTime time = list_media[i].alta_time_play;
                    tmp.TimePlay = time.Hour * 360 + time.Minute * 60 + time.Second;
                    tmp.ID = list_media[i].alta_media.alta_id;
                    tmp.TimeBeginPlay = list_media[i].alta_time_play;
                    tmp.TimeEndPlay = list_media[i].alta_time_end;
                    playlist.media.Add(tmp);
                }
            }
            if (playlist.Compare(this.mainPlaylist))
                return this.mainPlaylist;
            return playlist;
        }
     
      
        /// <summary>
        /// phát media 
        /// </summary>
        /// <param name="media">vitri media</param>
        public void playMedia(int pos)
        {
            flagPlaying = true;
            if (this.mainPlaylist.Count < pos || pos < 0 || this.mainPlaylist.Count <= 0)
            {
                flagPlaying = false;
                return;
            }
           // this.Tcp_Server.se           
            alta_media_in_player media = new alta_media_in_player();
            media = this.mainPlaylist.media[pos];
            this.mainPlaylist.cur_pos_play = pos;
            this.Tcp_Server.SendMsg("PLAY|"+media.ID+"_"+media.name);
            //if (media.TimePlay > 0)
            //{
            //    if (mediaClock != null)
            //    {
            //        mediaClock.Controller.Remove();
            //        mediaClock = null;
            //    }
            //    flagTiming = true;
            //    DoubleAnimation daPlay = new DoubleAnimation(1, 1, new TimeSpan(0, 0, media.TimePlay));
            //    mediaClock = daPlay.CreateClock();
            //    mediaClock.Completed += (s, a) =>
            //    {
            //        flagTiming = false;
            //        myVlcControl.Stop();
            //        if (this.mainPlaylist != null)
            //            this.mainPlaylist.cur_pos_play = Next(this.mainPlaylist);
            //    };
            //}
            //else
            //{
            //    flagTiming = false;
            //}
            myVlcControl.Stop();
            if (media.isCamera)
            {
                MediaBase tmpMedia = new LocationMedia(media.Url);               
                myVlcControl.Media = tmpMedia;
                flag_camera_media = true;
            }
            else if (media.isVideo)
            {
                MediaBase tmpMedia = new PathMedia(media.Url);
                myVlcControl.Media = tmpMedia;
                myVlcControl.Media.ParsedChanged += MediaOnParsedChanged;
                flag_camera_media = false;
            }
           
            Tcp_Server.sendImage(media.name + "|" + media.ftpUrl);
            txt_alta_media_name.Text = media.name;
            btn_play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Player;component/Asset/Themes/ic_action_pause.png")));
            myVlcControl.Play();
        }

        private int Next(alta_playlist_player alta_playlist)
        {
            if(this.mediaClock!=null)
                this.mediaClock.Controller.Stop();
            if (alta_playlist.cur_pos_play + 1 < alta_playlist.Count)
            {
                playMedia(alta_playlist.cur_pos_play + 1);
                return alta_playlist.cur_pos_play + 1;
            }
            else
            {
                playMedia(0);
                return 0;
            }
        }
        /// <summary>
        /// phát media trước đó
        /// </summary>
        /// <param name="plan">list media</param>
        /// <returns>pos media</returns>
        public int Back(alta_playlist_player plan)
        {
            if (this.mediaClock != null)
                this.mediaClock.Controller.Stop();
            if (plan.cur_pos_play - 1 > 0)
            {
                playMedia(plan.cur_pos_play - 1);
                return plan.cur_pos_play - 1;
            }
            else
            {
                playMedia(plan.Count - 1);
                return plan.Count - 1;
            }
        }
        /// <summary>
        /// hàm bắt các sự kiện của cờ control flag admin panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mainClock_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            if (this.mainPlaylist != null && this.mainPlaylist.Count > 0)
            {
                int count=this.mainPlaylist.Count;
                for (int i = 0; i < count; i++)
                {
                    alta_media_in_player media = this.mainPlaylist.media[i];
                    if (media.TimeBeginPlay.TimeOfDay <= DateTime.Now.TimeOfDay && media.TimeEndPlay.TimeOfDay >= DateTime.Now.TimeOfDay )
                    {
                        //this.mainPlaylist.cur_pos_play = i;
                        if(!this.flagPlaying || this.mainPlaylist.cur_pos_play!=i)
                            playMedia(i);
                    }
                    else if (this.mainPlaylist.cur_pos_play==i)
                    {
                        myVlcControl.Stop();
                        this.mainPlaylist.cur_pos_play = -1;
                    }
                }
            }
            if (this.Schedule != null && this.Schedule.alta_details_schedule != null && this.Schedule.alta_details_schedule.Count > 0)
            {
                lb_count.Content = "count: " + countDemo;                
                flag_play_local = false;
                int curPosPlay = this.mainPlaylist.cur_pos_play;
                if (!myVlcControl.IsPlaying)
                {
                    countDemo++;
                    if(countDemo==1)
                        this.mainPlaylist = LoadMediaToPlaylist(this.Schedule.alta_details_schedule[0].alta_playlist.alta_details);
                    if (countDemo > 1000)
                        countDemo = 0;
                }
                else
                {
                    countDemo = 0;
                }
                if (!flagPlaying)
                {
                    //this.mainPlaylist.cur_pos_play = 0;
                   // playMedia(0);
                }
                else
                {
                    this.mainPlaylist.cur_pos_play = curPosPlay;
                }
            }
            else
            {

            }
            if (Tcp_Server.adminControl == _controlVLC._CONTROL_OFF)
            {
                Tcp_Server.adminControl = _controlVLC._CONTROL_FREE;                
                this.Close();                
            }
            else if (Tcp_Server.adminControl == _controlVLC._CONTROL_PLAY)
            {
                myVlcControl.Media.ParsedChanged += MediaOnParsedChanged;
                myVlcControl.Play();
                Tcp_Server.adminControl = _controlVLC._CONTROL_FREE;
            }
            else if (Tcp_Server.adminControl == _controlVLC._CONTROL_PAUSE)
            {
                myVlcControl.Pause();
                Tcp_Server.adminControl = _controlVLC._CONTROL_FREE;
            }
            else if (Tcp_Server.adminControl == _controlVLC._CONTROL_STOP)
            {
                myVlcControl.Stop();
                Tcp_Server.adminControl = _controlVLC._CONTROL_FREE;
            }
            //else if (Tcp_Server.adminControl == _controlVLC._CONTROL_NEXT)
            //{
            //    this.mainPlaylist.cur_pos_play = Next(mainPlaylist);
            //    Tcp_Server.adminControl = _controlVLC._CONTROL_FREE;
            //}
            //else if (Tcp_Server.adminControl == _controlVLC._CONTROL_BACK)
            //{
            //    this.mainPlaylist.cur_pos_play = Back(mainPlaylist);
            //    Tcp_Server.adminControl = _controlVLC._CONTROL_FREE;
            //}
            else if (Tcp_Server.adminControl == _controlVLC._CONTROL_ABORT_USER)
            {
                Tcp_Server.flag_login_user = false;
                Tcp_Server.abort_user();
                Tcp_Server.adminControl = _controlVLC._CONTROL_FREE;
            }
            else if (Tcp_Server.adminControl == _controlVLC._CONTROL_ACCEPT_USER)
            {
                Tcp_Server.flag_login_user = true;
                Tcp_Server.adminControl = _controlVLC._CONTROL_FREE;

            }
            else if (Tcp_Server.adminControl == _controlVLC._CONTROL_SCREEN)
            {
                if (myVlcControl.IsPaused || myVlcControl.IsPlaying)
                {
                    // myVlcControl.Pause();
                    // myVlcControl.Media.AddOption(":sout=#transcode{vcodec=h264,acodec=mpga,ab=128,channels=2,samplerate=44100}:rtp{sdp=rtsp://:8554/demo} :sout-all :sout-keep");
                    // myVlcControl.Play();
                    
                   
                }
                Tcp_Server.adminControl = _controlVLC._CONTROL_FREE;
            }
            else if (Tcp_Server.dataControl == _controlVLC._CONTROL_PLAY)
            {
                myVlcControl.Media.ParsedChanged += MediaOnParsedChanged;
                myVlcControl.Play();
                Tcp_Server.dataControl = _controlVLC._CONTROL_FREE;
            }
            else if (Tcp_Server.dataControl == _controlVLC._CONTROL_PAUSE)
            {
                myVlcControl.Pause();
                Tcp_Server.dataControl = _controlVLC._CONTROL_FREE;
            }
            else if (Tcp_Server.dataControl == _controlVLC._CONTROL_STOP)
            {
                myVlcControl.Stop();
                Tcp_Server.dataControl = _controlVLC._CONTROL_FREE;
            }
            //else if (Tcp_Server.dataControl == _controlVLC._CONTROL_NEXT)
            //{
            //    this.mainPlaylist.cur_pos_play = Next(mainPlaylist);
            //    Tcp_Server.dataControl = _controlVLC._CONTROL_FREE;
            //}
            //else if (Tcp_Server.dataControl == _controlVLC._CONTROL_BACK)
            //{
            //    this.mainPlaylist.cur_pos_play = Back(mainPlaylist);
            //    Tcp_Server.dataControl = _controlVLC._CONTROL_FREE;
            //}
            else if (Tcp_Server.dataControl == _controlVLC._CONTROL_SCREEN)
            {
                if (myVlcControl.IsPaused || myVlcControl.IsPlaying)
                {
                    flag_send_image = true;
                    alta_media_in_player media = this.mainPlaylist.media[this.mainPlaylist.cur_pos_play];
                    Tcp_Server.sendImage(media.name + "|" + media.ftpUrl);
                }
                Tcp_Server.dataControl = _controlVLC._CONTROL_FREE;
            }
            else if (Tcp_Server.dataControl == _controlVLC._CONTROL_STREAM)
            {
                if (mediaClock != null)
                {
                    mediaClock.Controller.Remove();
                    mediaClock = null;
                }
                myVlcControl.Stop();
                if (mediaClock != null)
                    mediaClock.Controller.Stop();
                Thread.Sleep(10000);
                MediaBase tmpMedia = new LocationMedia("rtsp://" + Tcp_Server.ipHostStream + ":8554/demo");
                myVlcControl.Media = tmpMedia;
                myVlcControl.Play();
                Tcp_Server.dataControl = _controlVLC._CONTROL_FREE;

            }
            else if (Tcp_Server.dataControl == _controlVLC._CONTROL_STREAM_STOP)
            {
                myVlcControl.Stop();
                this.mainPlaylist.cur_pos_play = 0;
                Start();
               // playMedia(0);
                Tcp_Server.dataControl = _controlVLC._CONTROL_FREE;
            }

#if DEBUG

            demoTxt.Text = Tcp_Server.ipHostStream + " | " + CommonUtilities.userColtrol.getNoOnce(CommonUtilities.keySerect) + " | " + CommonUtilities.keySerect;
#endif
        }



        #endregion

        public bool flagPlaying { get; set; }
        public bool flagTiming { get; set; }
        public AnimationClock mediaClock { get; set; }
        public bool flag_camera_media { get; set; }
        public bool flag_send_image { get; set; }
        private void WindowResize(object sender, SizeChangedEventArgs e)
        {
            fixResoulution();
        }
        private void fixResoulution()
        {
            CommonUtilities.width = this.Width;
            CommonUtilities.height = this.Height;
            Size scale = CommonUtilities.getScaleSize();
            ScaleTransform s = new ScaleTransform(scale.Width, scale.Height);
            this.MainLayout.RenderTransform = s;
        }
        
        private void KeyPressControl(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    if (this.WindowState == WindowState.Maximized)
                    {
                        this.WindowState = WindowState.Normal;
                        try
                        {
                            if (localThread != null && localThread.IsAlive)
                                localThread.Abort();
                        }
                        catch (Exception ex)
                        {

                        }
                        VisibleControl();
                    }
                    break;
                case Key.Space:
                    if (myVlcControl.IsPlaying)
                        myVlcControl.Pause();
                    else if (myVlcControl.IsPaused)
                        myVlcControl.Play();
                    break;
                default:
                    break;

            }
        }
    }
}
