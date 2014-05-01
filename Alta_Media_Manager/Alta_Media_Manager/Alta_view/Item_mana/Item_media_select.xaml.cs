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
    /// Interaction logic for Item_media_select.xaml
    /// </summary>
    public partial class Item_media_select : UserControl
    {
        bool flag;
        bool status;
        public Item_media_select()
        {
            InitializeComponent();
            this.Width = 298;
            this.Height = 177;
            flag = false;
            this.status = false;
        }
        public void LoadData(alta_class_media media, bool flag=false)
        {
            if (media != null)
            {
                this.Tag = media;
                this.txt_alta_name.Content = media.alta_name;
                this.txt_alta_date.Content = String.Format("{0:HH:mm - dd/MM/yyyy.}", media.alta_media_time);
                this.txt_alta_userCreate.Tag = media.alta_user;
                this.txt_alta_userCreate.Content = media.alta_user.alta_full_name + ".";
                //this.txt_num_playlist.Tag = media.alta_playlist;
             //   if (media.alta_playlist.Count > 0)
                   // this.txt_num_playlist.Cursor = Cursors.Hand;
             //   else
                    //this.txt_num_playlist.Cursor = Cursors.Arrow;
              //  this.txt_num_playlist.Content = "Playlist: " + media.alta_playlist.Count + ".";
                this.flag = flag;
                this.status = media.isSelect;
                if(this.status)
                {
                    btn_check.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_accept.png")));
                }
                else
                {
                    btn_check.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_remove.png")));
                }
                if (this.flag)
                {
                    btn_check.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_accept.png")));
                    btn_check.Cursor = Cursors.Arrow;
                    
                }
                else if(!this.status)
                {
                    btn_check.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_remove.png")));
                   // btn_check.Cursor = Cursors.Hand;
                }
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
        private void btn_select_Click(object sender, RoutedEventArgs e)
        {
            if (!this.flag)
            {
                alta_class_media media = this.Tag as alta_class_media;
                if (!this.status)
                {
                    this.status = true;
                    media.isSelect = true;
                    btn_check.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_accept.png")));
                }
                else
                {
                    this.status = false;
                    media.isSelect = false;
                    btn_check.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_remove.png")));
                }
                if (AddMediaToPlaylist != null)
                    AddMediaToPlaylist(media, new RoutedEventArgs());
                
            }
        }
        public event RoutedEventHandler AddMediaToPlaylist;
        public event EventHandler<alta_class_media> ItemDoubleClick;

        private void click_mouse_click(object sender, MouseButtonEventArgs e)
        {
            if (ItemDoubleClick != null)
                ItemDoubleClick(this, this.Tag as alta_class_media);
        }
      
    }
}
