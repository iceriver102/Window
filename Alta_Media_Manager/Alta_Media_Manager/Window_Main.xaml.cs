using Alta_Media_Manager.Class;
using Alta_Media_Manager.Item_UC;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;
using Alta_Media_Manager.Alta_view.Class;
using Alta_Media_Manager.Alta_view;
using MySql.Data.MySqlClient;
using Alta_Media_Manager.Alta_view.Mysql_helpper;
using Vlc.DotNet.Core;

namespace Alta_Media_Manager
{
    /// <summary>
    /// Interaction logic for Window_Main.xaml
    /// </summary>
    public partial class Window_Main : Window
    {
        public Mana_Video View_Video_Mana;
        public Mana_Plan view_plan;
        public Mana_camera view_camera;
        public mana_Thiet_bi view_thietbi;
        public Mana_user view_user;
        public alta_setting_view view_setting;
        public alta_Schedule view_schedule;
        Thread load_data_user_type,load_data_media_Type,load_data_user;
        public bool flag_load_user_type, flag_load_media_type,flag_load_user;
       // public List<alta_class_user> List_user;        

        public Window_Main()
        {
            initVLC();
            InitializeComponent();
            load_data_user_type = new Thread(Load_data_User_Type_Thread);
            load_data_media_Type = new Thread(Load_data_Media_Type_Thread);
            load_data_user = new Thread(Load_data_User_Thread);
           // List_user = new List<alta_class_user>();
            initFunction();
            fixResoulution();
            flag_load_user_type = false;
            flag_load_media_type = false;
            flag_load_user=false;

            load_data_media_Type.IsBackground = true;
            load_data_media_Type.Start();

            load_data_user_type.IsBackground = true;
            load_data_user_type.Start();

            load_data_user.IsBackground = true;
            load_data_user.Start();

            View_Video_Mana = new Mana_Video();
            View_Video_Mana.Width = 1346;
            View_Video_Mana.Height = 663;
            layoutContent.Children.Add(View_Video_Mana);

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
         //   VlcContext.StartupOptions.LogOptions.Verbosity = VlcLogVerbosities.Debug;
            VlcContext.StartupOptions.AddOption("--ffmpeg-hw");
            // Disable showing the movie file name as an overlay
            VlcContext.StartupOptions.AddOption("--no-video-title-show");
            VlcContext.StartupOptions.AddOption("--rtsp-tcp");
            VlcContext.StartupOptions.AddOption("--rtsp-mcast");
           // VlcContext.StartupOptions.AddOption("--rtsp-host=192.168.10.35");
           // VlcContext.StartupOptions.AddOption("--sap-addr=192.168.10.35");
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

        #region Thread load data
        private void Load_data_User_Thread(object obj)
        {
            while (true)
            {
                Load_data_User();
                Thread.Sleep(80);
            }
        }

        private void Load_data_User()
        {
            if (!flag_load_user)
            {
                if (CommonUtilities.alta_curUser.alta_type_user.alta_id == 1)
                {
                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                        {
                            conn.Open();
                            string _query = "SELECT `user_id`, `username`, `user_pass`, `full_name`, `user_type_id`, `user_status` FROM `am_user`";
                            using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                            {
                                var tmp = cmd.ExecuteScalar();
                                if (Convert.ToInt32(tmp) > 0)
                                {
                                    using (MySqlDataReader reader = cmd.ExecuteReader())
                                    {
                                        CommonUtilities.List_user = mysql_alta_helpper.getListUser(reader);
                                    }
                                }
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception ex)
                    {
#if DEBUG
                        MessageBox.Show("ERR Login: "+ex.Message);
#endif
                    }
                }
                else
                {
                    CommonUtilities.List_user.Add(CommonUtilities.alta_curUser);
                }
                flag_load_user = true;
            }
            else
            {
                if (load_data_user.IsAlive)
                    load_data_user.Abort();
            }
        }

        private void Load_data_Media_Type_Thread(object obj)
        {
            while (true)
            {
                Load_data_media_Type();
                Thread.Sleep(80);
            }
        }

        private void Load_data_User_Type_Thread(object obj)
        {
            while (true)
            {
                Load_data_user_type();               
                Thread.Sleep(80);
            }
        }

        
        private void Load_data_media_Type()
        {
            if (!flag_load_media_type)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                    {
                        conn.Open();
                        string insert_query = "SELECT `media_type_id`, `media_type_name`, `media_type_content` FROM `am_media_type`";
                        using (MySqlCommand cmd = new MySqlCommand(insert_query, conn))
                        {
                            //cmd.Parameters.AddWithValue("@id_video", id);                           
                            var tmp = cmd.ExecuteScalar();
                            if (Convert.ToInt32(tmp) > 0)
                            {
                                using (MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    CommonUtilities.list_Type_Media = mysql_alta_helpper.getListTypeMedia(reader);
                                }
                            }
                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.Message);
#endif
                }
                finally
                {
                    flag_load_media_type = true;
                }
            }
            else
            {
                if (load_data_user.IsAlive)
                    load_data_user_type.Abort();
            }
        }

        private void Load_data_user_type()
        {
            if (!flag_load_user_type)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                    {
                        conn.Open();
                        string insert_query = "SELECT `user_type_id`, `name_type`, `content` FROM `am_user_type`";
                        using (MySqlCommand cmd = new MySqlCommand(insert_query, conn))
                        {
                            //cmd.Parameters.AddWithValue("@id_video", id);                           
                            var tmp = cmd.ExecuteScalar();
                            if (Convert.ToInt32(tmp) > 0)
                            {
                                using (MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    CommonUtilities.list_Type_User = mysql_alta_helpper.getListTypeUser(reader);
                                }
                            }
                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.Message);
#endif
                }
                finally
                {
                    flag_load_user_type = true;
                }
            }
            else
            {
                if (load_data_user.IsAlive)
                    load_data_user.Abort();
            }
        }
        #endregion 
        public void ItemClickView(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("click");
        }
        private void fixResoulution()
        {
            CommonUtilities.width = this.Width;
            CommonUtilities.height = this.Height;
            Size scale = CommonUtilities.getScaleSize();
            ScaleTransform s = new ScaleTransform(scale.Width, scale.Height);
            layoutMain.RenderTransform = s;
        }
        private void initFunction()
        {
            CommonUtilities.height = this.Height;
            CommonUtilities.width = this.Width;

        }
        private void showMenu(bool flag = true)
        {
            foreach (UIElement UITmp in header_canvas.Children)
            {
                if (UITmp.GetType().ToString().Equals("Alta_Media_Manager.Item_UC.Item_Menu"))
                {
                    Item_Menu tmp = (Item_Menu)UITmp;
                    tmp.Show = flag;
                }
            };
        }
        private void MenuBtnClick(object sender, RoutedEventArgs e)
        {
            if (CommonUtilities.flag_menu_animation)
            {
                if (Canvas.GetTop(header_canvas) != 0)
                {
                    showMenu(true);
                    StaticFunction.aniMoveTo(header_canvas, 0, 0, 0.5);
                    StaticFunction.aniMoveTo(layoutContent, 10, 209, 0.5);
                }
                else
                {
                    StaticFunction.aniMoveTo(header_canvas, 0, -80, 0.5);
                    StaticFunction.aniMoveTo(layoutContent, 10, 95, 0.5);
                    showMenu(false);
                }
            }
        }

        private void removeLayoutContent()
        {
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
              delegate()
              {
                  this.layoutContent.Children.Clear();
              }));
        }

        private void View_video_mana(object sender, RoutedEventArgs e)
        {
            if (View_Video_Mana == null || this.layoutContent.Children[0].GetType().ToString() != "Alta_Media_Manager.ManaView.Mana_Video")
            {
                layoutContent.Children.Clear();
                StaticFunction.aniMoveTo(header_canvas, 0, -80, 0.5);
                StaticFunction.aniMoveTo(layoutContent, 10, 95, 0.5);
                showMenu(false);
                View_Video_Mana = new Mana_Video();
                View_Video_Mana.Width=1346;
                View_Video_Mana.Height = 663;
                layoutContent.Children.Add(View_Video_Mana);
            }
            else
            {
                //View_Video_Mana.LoadVideo();
                View_Video_Mana.start();
                StaticFunction.aniMoveTo(header_canvas, 0, -80, 0.5);
                StaticFunction.aniMoveTo(layoutContent, 10, 95, 0.5);
                showMenu(false);
            }
        }

        private void Termiral_Mana(object sender, RoutedEventArgs e)
        {

        }

        private void View_Plan_Mana(object sender, RoutedEventArgs e)
        {
            if (view_plan == null || this.layoutContent.Children[0].GetType().ToString() != "Alta_Media_Manager.ManaView.Mana_Plan")
            {
                layoutContent.Children.Clear();
                StaticFunction.aniMoveTo(header_canvas, 0, -109, 0.5);
                StaticFunction.aniMoveTo(layoutContent, 10, 95, 0.5);
                showMenu(false);
                view_plan = new Mana_Plan();
                layoutContent.Children.Add(view_plan);
            }
            else
            {
                view_plan.start();
                StaticFunction.aniMoveTo(header_canvas, 0, -109, 0.5);
                StaticFunction.aniMoveTo(layoutContent, 10, 95, 0.5);
                showMenu(false);
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VlcContext.CloseAll();
        }

        private void View_Setting(object sender, RoutedEventArgs e)
        {
            if (view_setting == null || this.layoutContent.Children[0].GetType().ToString() != "Alta_Media_Manager.ManaView.alta_setting_view")
            {
                view_setting = new alta_setting_view();
                view_setting.loadConfig();
                layoutContent.Children.Clear();
                StaticFunction.aniMoveTo(header_canvas, 0, -109, 0.5);
                StaticFunction.aniMoveTo(layoutContent, 10, 95, 0.5);
                showMenu(false);
                layoutContent.Children.Add(view_setting);
                
            }
            else
            {
                view_setting.loadConfig();
                StaticFunction.aniMoveTo(header_canvas, 0, -109, 0.5);
                StaticFunction.aniMoveTo(layoutContent, 10, 95, 0.5);
                showMenu(false);
            }

        }

        private void View_camera_Mana(object sender, RoutedEventArgs e)
        {
            if (view_camera == null || this.layoutContent.Children[0].GetType().ToString() != "Alta_Media_Manager.ManaView.Mana_camera")
            {
                layoutContent.Children.Clear();
                StaticFunction.aniMoveTo(header_canvas, 0, -109, 0.5);
                StaticFunction.aniMoveTo(layoutContent, 10, 95, 0.5);
                showMenu(false);
                view_camera = new Mana_camera();
                layoutContent.Children.Add(view_camera);
            }
            else
            {
                view_camera.start();
                StaticFunction.aniMoveTo(header_canvas, 0, -109, 0.5);
                StaticFunction.aniMoveTo(layoutContent, 10, 95, 0.5);
                showMenu(false);
            }
        }

        private void View_thietbi_mana(object sender, RoutedEventArgs e)
        {
            if (view_thietbi == null || this.layoutContent.Children[0].GetType().ToString() != "Alta_Media_Manager.ManaView.mana_Thiet_bi")
            {
                layoutContent.Children.Clear();
                StaticFunction.aniMoveTo(header_canvas, 0, -109, 0.5);
                StaticFunction.aniMoveTo(layoutContent, 10, 95, 0.5);
                showMenu(false);
                view_thietbi = new mana_Thiet_bi();
                layoutContent.Children.Add(view_thietbi);
            }
            else
            {
                view_thietbi.start();
                StaticFunction.aniMoveTo(header_canvas, 0, -109, 0.5);
                StaticFunction.aniMoveTo(layoutContent, 10, 95, 0.5);
                showMenu(false);
            }
        }

        private void view_user_mana(object sender, RoutedEventArgs e)
        {
            if (view_user == null || this.layoutContent.Children[0].GetType().ToString() != "Alta_Media_Manager.ManaView.Mana_user")
            {
                layoutContent.Children.Clear();
                StaticFunction.aniMoveTo(header_canvas, 0, -109, 0.5);
                StaticFunction.aniMoveTo(layoutContent, 10, 95, 0.5);
                showMenu(false);
                view_user = new Mana_user();
                layoutContent.Children.Add(view_user);
            }
            else
            {
                view_user.StartUp();
                StaticFunction.aniMoveTo(header_canvas, 0, -109, 0.5);
                StaticFunction.aniMoveTo(layoutContent, 10, 95, 0.5);
                showMenu(false);
            }
        }

        private void view_schedule_mana(object sender, RoutedEventArgs e)
        {

            if (view_schedule == null || this.layoutContent.Children[0].GetType().ToString() != "Alta_Media_Manager.ManaView.alta_Schedule")
            {
                layoutContent.Children.Clear();
                StaticFunction.aniMoveTo(header_canvas, 0, -109, 0.5);
                StaticFunction.aniMoveTo(layoutContent, 10, 95, 0.5);
                showMenu(false);
                view_schedule = new alta_Schedule();
                layoutContent.Children.Add(view_schedule);
            }
            else
            {
                view_schedule.StartUp();
                StaticFunction.aniMoveTo(header_canvas, 0, -109, 0.5);
                StaticFunction.aniMoveTo(layoutContent, 10, 95, 0.5);
                showMenu(false);
            }
        }

       
    }
}
