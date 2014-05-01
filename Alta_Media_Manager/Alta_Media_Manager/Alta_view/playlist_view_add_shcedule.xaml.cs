using Alta_Media_Manager.Alta_view.Class;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Alta_Media_Manager.Alta_view
{
    /// <summary>
    /// Interaction logic for playlist_view_add_shcedule.xaml
    /// </summary>
    public partial class playlist_view_add_shcedule : UserControl
    {
        public playlist_view_add_shcedule()
        {
            InitializeComponent();
        }
        public void loadView(alta_class_media media, alta_class_playlist playlist)
        {
            if (media != null)
            {
                this.Tag = media;
                this.txt_name.Text = media.alta_name;
                this.playlist = playlist;
                this.bar_action.Visibility = Visibility.Hidden;
                this.bar_action_new.Visibility = Visibility.Visible;
                this.title.Content = "Thêm chi tiết playlist";
            }
        }
        public void loadView(alta_class_playlist_details playlist_details)
        {
            if (playlist_details != null)
            {
                //playlist_details.getMedia();
                this.Tag = playlist_details.alta_media;
                this.playlist = playlist_details.alta_playlist;
                this.playlistDetails = playlist_details;
                this.bar_action_new.Visibility = Visibility.Hidden;
                this.bar_action.Visibility = Visibility.Visible;
                this.txt_name.Text=playlist_details.alta_media.alta_name;
                this.hour_start.Text = playlist_details.alta_time_play.Hour.ToString("00");
                this.minute_start.Text = playlist_details.alta_time_play.Minute.ToString("00");
                this.minute_end.Text = playlist_details.alta_time_end.Minute.ToString("00");
                this.hour_end.Text = playlist_details.alta_time_end.Hour.ToString("00");
                this.title.Content = "Sửa chi tiết playlist";
            }
        }
        public void loadView(alta_class_media media)
        {
            if (media != null)
            {
                this.Tag = media;
            }
        }
        public alta_class_playlist playlist;

        private void btn_click(object sender, RoutedEventArgs e)
        {
            if (CloseClick != null)
            {
                CloseClick(this, new RoutedEventArgs());
            }
        }

        public event RoutedEventHandler CloseClick;
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            DateTime std = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(this.hour_start.Text), Convert.ToInt32(this.minute_start.Text), 0);
            DateTime etd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(this.hour_end.Text), Convert.ToInt32(this.minute_end.Text), 0);
            if (etd < std)
            {
                MessageBox.Show("thời gian bắt đầu phải nhỏ hơn thời gian kết thúc!");
                return;
            }
            DateTimeEventAltamedia tmp = new DateTimeEventAltamedia(std,etd);
            if (SaveClick != null)
            {
                SaveClick(this, tmp);
            }

        }
        public event EventHandler<DateTimeEventAltamedia> SaveClick;

        private void btn_Chon_Click(object sender, RoutedEventArgs e)
        {
            list_media = new View_list_media();
            list_media.ShowAction = false;
            list_media.LoadData(this.playlist);
            list_media.ItemDoubleClick += list_media_ItemDoubleClick;
            list_media.CloseClick += list_media_CloseClick;
            this.mainlayout.Children.Add(list_media);
        }

        void list_media_CloseClick(object sender, RoutedEventArgs e)
        {
            this.mainlayout.Children.Remove(list_media);
        }

        private void list_media_ItemDoubleClick(object sender, alta_class_media e)
        {
            this.loadView(e);
            this.mainlayout.Children.Remove(list_media);
        }

        public View_list_media list_media { get; set; }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (DeleteEvent != null && this.playlistDetails!=null)
            {
                DeleteEvent(this, this.playlistDetails);
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            DateTime std = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(this.hour_start.Text), Convert.ToInt32(this.minute_start.Text), 0);
            DateTime etd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(this.hour_end.Text), Convert.ToInt32(this.minute_end.Text), 0);
            if (etd < std)
            {
                MessageBox.Show("thời gian bắt đầu phải nhỏ hơn thời gian kết thúc!");
                return;
            }
            DateTimeEventAltamedia tmp = new DateTimeEventAltamedia(std, etd);
            if (UpdateEvent != null)
            {
                UpdateEvent(this, tmp);
            }
        }

        public event EventHandler<DateTimeEventAltamedia> UpdateEvent;
        public event EventHandler<Class.alta_class_playlist_details> DeleteEvent;

        public alta_class_playlist_details playlistDetails { get; set; }
    }
    public class DateTimeEventAltamedia
    {

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTimeEventAltamedia()
        {

        }
        public DateTimeEventAltamedia(DateTime std, DateTime etd)
        {
            this.StartTime = std;
            this.EndTime = etd;
        }
    }
}
