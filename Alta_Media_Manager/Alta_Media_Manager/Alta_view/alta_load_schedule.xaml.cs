using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
using WpfScheduler;

namespace Alta_Media_Manager.Alta_view
{
    /// <summary>
    /// Interaction logic for alta_load_schedule.xaml
    /// </summary>
    public partial class alta_load_schedule : UserControl
    {
        BackgroundWorker bw;
        List<Class.alta_class_playlist_details> listPlaylist;
        private Class.alta_class_playlist playlist;
        public Class.alta_class_playlist Playlist
        {
            get { return playlist; }
            set
            {
                playlist = value;
                if (value != null)
                    this.lb_Name.Content = value.alta_name;
                Startup();
            }
        }
        private bool backevent;
        public bool BackEvent { get { return backevent; } set { backevent = value; if (value) this.backNavigation.Visibility = Visibility.Visible; else this.backNavigation.Visibility = Visibility.Hidden; } }
        public event EventHandler BackNavigationEvent;
        private void Startup()
        {
            if (!bw.IsBusy)
            {
                bw.RunWorkerAsync();
            }
        }
        public alta_load_schedule()
        {
            InitializeComponent();
            this.BackEvent = false;
            Canvas.SetLeft(this, 0);
            Canvas.SetTop(this, 0);
            bw = new BackgroundWorker();
            listPlaylist = new List<Class.alta_class_playlist_details>();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (listPlaylist.Count > 0)
            {
                LoadEvents();
            }
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            listPlaylist = Mysql_helpper.mysql_alta_helpper.getListPlayListDetails(Playlist.alta_id);
        }

        private void OneventEdit(object sender, WpfScheduler.Event e)
        {
            playlist_view_add_shcedule view = new playlist_view_add_shcedule();
            view.loadView(e.Tag as Class.alta_class_playlist_details);
            view.CloseClick += view_CloseClick;
            view.UpdateEvent += view_UpdateEvent;
            view.DeleteEvent += view_DeleteEvent;
            this.mainLayout.Children.Add(view);
        }

        void view_DeleteEvent(object sender, Class.alta_class_playlist_details e)
        {
            if (MessageBox.Show("Bạn có muốn xóa chi tiết playlist này không?", "Thông báo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Mysql_helpper.mysql_alta_helpper.delete_playlist_Details(e.alta_id);
                this.mainLayout.Children.Remove(sender as playlist_view_add_shcedule);
                Startup();
            }
        }

        void view_UpdateEvent(object sender, DateTimeEventAltamedia e)
        {
            Class.alta_class_playlist_details playlist_details=(sender as playlist_view_add_shcedule).playlistDetails;
            int idPlaylistDetails = playlist_details.alta_id;
            if (!Mysql_helpper.mysql_alta_helpper.checkFreeTimeOfPlaylist(playlist_details.alta_playlist.alta_id,e.StartTime, e.EndTime, idPlaylistDetails))
            {
                Class.alta_class_media media = (sender as playlist_view_add_shcedule).Tag as Class.alta_class_media;
                Mysql_helpper.mysql_alta_helpper.UpdatePlaylistDetails(media.alta_id, idPlaylistDetails, e.StartTime, e.EndTime);
                this.mainLayout.Children.Remove(sender as playlist_view_add_shcedule);
                Startup();
            }
            else
            {
                MessageBox.Show("Thời gian này đã được đặt lịch phát");
            }
        }

        private void OnAddEventClick(object sender, DateTime e)
        {
            //MessageBox.Show(e.ToString());
        }
        private void LoadEvents()
        {
            int count = this.listPlaylist.Count;
            this.Alta_Schedule.Events.Clear();
            for (int i = 0; i < count; i++)
            {
                listPlaylist[i].alta_playlist.LoadUser();
                Event tmpEvent = new Event();
                tmpEvent.Tag = this.listPlaylist[i];
                tmpEvent.Start = this.listPlaylist[i].alta_time_play;
                tmpEvent.End = this.listPlaylist[i].alta_time_end;
                tmpEvent.Subject = this.listPlaylist[i].alta_media.alta_name;
                tmpEvent.Description = this.listPlaylist[i].alta_media.alta_name;
                tmpEvent.Color = Brushes.Brown;
                tmpEvent.User = listPlaylist[i].alta_playlist.alta_user.alta_full_name;
                Alta_Schedule.AddEvent(tmpEvent);
                // list_event.Add(tmpEvent);
            }
            //    Alta_Schedule.Events = list_event;    
        }

        private void LoadSchedule(object sender, RoutedEventArgs e)
        {
            Alta_Schedule.SelectedDate = DateTime.Now;
        }

        private void btn_add_schedule_click(object sender, RoutedEventArgs e)
        {
            list_media = new View_list_media();
            list_media.ShowAction = false;
            list_media.LoadData(this.Tag as Class.alta_class_playlist);
            list_media.ItemDoubleClick += list_media_ItemDoubleClick;
            list_media.CloseClick += list_media_CloseClick;
            this.mainLayout.Children.Add(list_media);
        }

        void list_media_CloseClick(object sender, RoutedEventArgs e)
        {
            this.mainLayout.Children.Remove(list_media);
        }
        View_list_media list_media;
        void list_media_ItemDoubleClick(object sender, Class.alta_class_media e)
        {
            playlist_view_add_shcedule view = new playlist_view_add_shcedule();
            view.loadView(e, list_media.Tag as Class.alta_class_playlist);
            view.CloseClick += view_CloseClick;
            view.SaveClick += view_SaveClick;
            this.mainLayout.Children.Add(view);
            this.mainLayout.Children.Remove(list_media);
        }

        void view_SaveClick(object sender, DateTimeEventAltamedia e)
        {
            Class.alta_class_playlist playlist = (sender as playlist_view_add_shcedule).playlist;
            if (!Mysql_helpper.mysql_alta_helpper.checkFreeTimeOfPlaylist(playlist.alta_id,e.StartTime, e.EndTime))
            {
                Class.alta_class_media media = (sender as playlist_view_add_shcedule).Tag as Class.alta_class_media;
                
                Mysql_helpper.mysql_alta_helpper.addMediaToPlaylist(media.alta_id, playlist.alta_id, e.StartTime, e.EndTime);
                this.mainLayout.Children.Remove(sender as playlist_view_add_shcedule);
                Startup();
            }
            else
            {
                MessageBox.Show("Thời gian này đã được đặt lịch phát");
            }
        }

        void view_CloseClick(object sender, RoutedEventArgs e)
        {
            this.mainLayout.Children.Remove(sender as playlist_view_add_shcedule);
        }

        private void btn_back_click(object sender, RoutedEventArgs e)
        {
            if (BackNavigationEvent != null)
                BackNavigationEvent(this, new EventArgs());
        }
    }
}
