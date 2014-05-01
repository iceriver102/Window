using Alta_Media_Manager.Class;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace Alta_Media_Manager.Alta_view
{
    /// <summary>
    /// Interaction logic for alta_Media_Player.xaml
    /// </summary>
    public partial class alta_Media_Player : UserControl
    {
        public event RoutedEventHandler CheckItemClick;
        public event RoutedEventHandler CloseClick;
        public alta_Media_Player()
        {
            InitializeComponent();           
            myVlcControl.PositionChanged += VlcControlOnPositionChanged;
            myVlcControl.TimeChanged += VlcControlOnTimeChanged;
            myVlcControl.Paused += myVlcControl_Paused;
            myVlcControl.Playing += myVlcControl_Playing;
            myVlcControl.PlaybackMode = PlaybackModes.Loop;
        }
        #region VLC
        private void myVlcControl_Playing(Vlc.DotNet.Wpf.VlcControl sender, VlcEventArgs<EventArgs> e)
        {
            btn_play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Images/media-pause.png")));
            HideControl();
        }

        /// <summary>
        /// ẩn thanh điều khiển
        /// </summary>
        private void HideControl()
        {
            //if (WindowState == WindowState.Maximized)
            //{
            //    if (myVlcControl.IsPlaying)
            //    {
            //        DoubleAnimation daHideControl = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(10));
            //        daHideControl.EasingFunction = new PowerEase() { EasingMode = EasingMode.EaseOut };
            //        clock = daHideControl.CreateClock();
            //        Title_Layout.ApplyAnimationClock(OpacityProperty, clock);
            //        ControlPlayer_Layout.ApplyAnimationClock(OpacityProperty, clock);
            //    }
            //    else
            //    {
            //        this.VisibleControl();
            //    }
            //}
            //else
            //{
            //    this.VisibleControl();
            //}
        }

        private void myVlcControl_Paused(Vlc.DotNet.Wpf.VlcControl sender, VlcEventArgs<EventArgs> e)
        {
           
        }

        private void VlcControlOnTimeChanged(Vlc.DotNet.Wpf.VlcControl sender, VlcEventArgs<TimeSpan> e)
        {
            if (myVlcControl.Media == null)
            {
                return;
            }
            //TimeSpan duration = myVlcControl.Media.Duration;
            //if (duration == TimeSpan.Zero && mainPlaylist.media[mainPlaylist.cur_pos_play].isVideo)
            //    return;
            alta_txt_curTime.Text = string.Format(
                "{0:00}:{1:00}:{2:00}",
                e.Data.Hours,
                e.Data.Minutes,
                e.Data.Seconds);
            //if (duration.TotalSeconds - e.Data.TotalSeconds < 1 && flagTiming && !flag_camera_media)
            //{
            //    myVlcControl.Pause();
            //    myVlcControl.Position = 0;
            //    myVlcControl.Play();
            //}
            //else if (duration.TotalSeconds - e.Data.TotalSeconds < 1 && !flagTiming && !flag_camera_media)
            //{
            //    myVlcControl.Pause();
            //    if (this.mainPlaylist != null)
            //        mainPlaylist.cur_pos_play = Next(mainPlaylist);
            //}
        }

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
        #endregion

        public bool myPositionChanging { get; set; }

        public AnimationClock clock { get; set; }

        private void Changed_State_Event(object sender, MouseButtonEventArgs e)
        {
            if (myVlcControl.IsPlaying)
            {
                myVlcControl.Pause();
                btn_play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Images/btn_play.png")));

            }
            else
            {
                myVlcControl.Play();
                btn_play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Images/media-pause.png")));
            }
        }
        private void btn_Click_Mute(object sender, RoutedEventArgs e)
        {
            if (myVlcControl.AudioProperties.IsMute)
            {
                myVlcControl.AudioProperties.IsMute = false;
                btn_mute.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Images/sound.png")));
            }
            else
            {
                myVlcControl.AudioProperties.IsMute = true;
                btn_mute.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Images/sound_mute.png")));
            }
        }

        private void Volume_Change_Event(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            myVlcControl.AudioProperties.Volume = Convert.ToInt32(alta_volume.Value);
            if (Convert.ToInt32(alta_volume.Value) <= 0)
            {
                myVlcControl.AudioProperties.IsMute = true;
                btn_mute.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Images/sound_mute.png")));
            }
            else
            {
                myVlcControl.AudioProperties.IsMute = false;
                btn_mute.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Images/sound.png")));
            }
        }

        private void WindowCHange_State_btn_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void SliderMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            myPositionChanging = true;
            myVlcControl.PositionChanged -= VlcControlOnPositionChanged;
        }

        private void ProgressBarChange(object sender, MouseButtonEventArgs e)
        {
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

        private void SliderMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            myVlcControl.Position = (float)barTimeSeek.Value / 100;
            myVlcControl.PositionChanged += VlcControlOnPositionChanged;
            myPositionChanging = false;
        }

        private void btn_Play_Event(object sender, RoutedEventArgs e)
        {
            if (myVlcControl.Medias.Count > 0)
            {
                if (myVlcControl.IsPlaying)
                {
                    myVlcControl.Pause();
                    btn_play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Images/btn_play.png")));

                }
                else
                {
                    myVlcControl.Play();
                    btn_play.Background = new ImageBrush(new BitmapImage(new Uri("Asset/Images/media-pause.png")));
                }
            }
        }

        private void Vlc_btn_next_Click(object sender, RoutedEventArgs e)
        {
            if (this.myVlcControl.Media != null)
            {
                this.myVlcControl.Stop();
                this.myVlcControl.Next();
            }
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
            btn_play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Images/media-pause.png")));
            FileInfo File_open = new FileInfo(openFileDialog.FileName);
            txt_alta_media_name.Text = File_open.Name;
        }

        private void MediaOnParsedChanged(MediaBase sender, VlcEventArgs<int> e)
        {
            alta_txt_curTime.Text = string.Format(
                "{0:00}:{1:00}:{2:00}",
                myVlcControl.Media.Duration.Hours,
                myVlcControl.Media.Duration.Minutes,
                myVlcControl.Media.Duration.Seconds);
        }

        private void btn_Click_Stop(object sender, RoutedEventArgs e)
        {
            this.myVlcControl.Stop();
            barTimeSeek.Value = 0;
        }

        private void vlc_btn_back_click(object sender, RoutedEventArgs e)
        {
            
        }
        ~alta_Media_Player()
        {
            try
            {
                myVlcControl.Stop();
            }catch(Exception ex){

            }
        }
        public bool flag_play_local { get; set; }

        public void LoadData(Class.alta_class_media media)
        {
            if (media != null)
            {
                this.Tag = media;
                if (media.alta_media_status)
                {
                    btn_status.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_icon/icon-duyet.png")));
                }
                else
                {
                    btn_status.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_icon/icon-not-duyet.png")));
                }
                txt_alta_media_name.Text = media.alta_name;
                if (media.alta_media_type.alta_id == 1)
                {                    
                    String location = alta_class_ftp.downLoadFile(media.alta_url);
                    myVlcControl.Media = new PathMedia(location);
                    myVlcControl.Media.ParsedChanged += MediaOnParsedChanged;
                    //ftp_download.FtpPath = media.alta_url;
                    
                }
                else if (media.alta_media_type.alta_id == 2)
                {
                    myVlcControl.Media = new LocationMedia(media.alta_url);
                }
                else
                {
                    MessageBox.Show("tinh nang chua ho tro");
                }
            }
            else
            {
                MessageBox.Show("sai dinh dang");
            }
        }

        private void Hide_View_Click(object sender, MouseButtonEventArgs e)
        {

        }
        
        private void btn_status_Click(object sender, RoutedEventArgs e)
        {
            Class.alta_class_media media = (Class.alta_class_media)this.Tag;
            if (CheckItemClick!=null)
            {
                CheckItemClick(this.Tag,new RoutedEventArgs());                
            }
            if (!media.alta_media_status)
            {
                btn_status.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_icon/icon-not-duyet.png")));               
            }
            else
            {
                btn_status.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_icon/icon-duyet.png")));                
            }
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myVlcControl.Stop();
            }
            catch (Exception ex)
            {

            }
            if (CloseClick != null)
                CloseClick(this, new RoutedEventArgs());

        }

        private void Download_Completed(object sender, EventArgs e)
        {
            myVlcControl.Media = new PathMedia(ftp_download.Source);
            myVlcControl.Media.ParsedChanged += MediaOnParsedChanged;
            (sender as Alta_Media_Manager.Plugin.ftp_download).Visibility = Visibility.Hidden;
        }
        private void Start_DownLoad(object sender, EventArgs e)
        {
            (sender as Alta_Media_Manager.Plugin.ftp_download).Visibility = Visibility.Visible;
        }
    }
}
