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

namespace Alta_Media_Manager.Alta_view.Item_mana
{
    /// <summary>
    /// Interaction logic for Item_view_camera.xaml
    /// </summary>
    public partial class Item_view_camera : UserControl
    {
        public event RoutedEventHandler deleteItem;
        public event RoutedEventHandler ViewPlaylistClick;
        public event RoutedEventHandler EditItemClick;
        public event RoutedEventHandler CheckItemClick;
        public event RoutedEventHandler PlayMediaClick;
        public Item_view_camera()
        {
            InitializeComponent();
            this.Width = 320;
            this.Height = 160;
        }
        public void LoadData(alta_class_media media)
        {
            if (media != null)
            {
                this.Tag = media;
                this.txt_alta_name.Content = media.alta_name;
                this.txt_alta_date.Content = String.Format("{0:HH:mm - dd/MM/yyyy.}", media.alta_media_time);
                this.txt_alta_userCreate.Tag = media.alta_user;
                this.txt_alta_userCreate.Content = media.alta_user.alta_full_name + ".";
                this.txt_num_playlist.Tag = media.alta_playlist;
                if (media.alta_playlist.Count > 0)
                    this.txt_num_playlist.Cursor = Cursors.Hand;
                else
                    this.txt_num_playlist.Cursor = Cursors.Arrow;
                this.txt_num_playlist.Content = "Playlist: " + media.alta_playlist.Count + ".";
                if (media.alta_media_status)
                {
                    btn_icon_status.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_icon/icon-duyet.png")));

                }
                else
                {
                    btn_icon_status.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_icon/icon-not-duyet.png")));
                }
            }
            else
            {
#if DEBUG
                MessageBox.Show("Nulll");
#endif
            }
        }
        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá camera này không?", "Thông báo", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                alta_class_media tmp = (alta_class_media)this.Tag;
                int num = Mysql_helpper.mysql_alta_helpper.del_Media_Item(tmp);

                if (num == 1)
                {
                    if (deleteItem != null)
                        deleteItem(this, new RoutedEventArgs());
                    this.Visibility = Visibility.Hidden;

                }
            }
        }

        private void View_Playlist_Click_Btn(object sender, MouseButtonEventArgs e)
        {
            if (ViewPlaylistClick != null)
                ViewPlaylistClick(this.Tag, new RoutedEventArgs());
        }

        private void btn_edit_click(object sender, RoutedEventArgs e)
        {
            if (this.EditItemClick != null)
                EditItemClick(this.Tag, new RoutedEventArgs());
        }

        private void btn_duyet_Click(object sender, RoutedEventArgs e)
        {
            if (CheckItemClick != null)
                CheckItemClick(this.Tag, new RoutedEventArgs());
        }

        private void btn_Play_Click(object sender, RoutedEventArgs e)
        {
            if (PlayMediaClick != null)
                PlayMediaClick(this.Tag, new RoutedEventArgs());
        }
    }
}
