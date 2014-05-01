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
    /// Interaction logic for alta_playlist_Item.xaml
    /// </summary>
    public partial class alta_playlist_Item : UserControl
    {
        public alta_playlist_Item()
        {
            InitializeComponent();
        }
        public void LoadData(alta_class_playlist playlist)
        {
            if (playlist != null)
            {
                this.Tag = playlist;
                this.lb_name.Content = playlist.alta_name;
                this.lb_user.Content = playlist.alta_user.alta_full_name;
                this.lb_date.Content = String.Format("{0:HH:mm - dd/MM/yyyy}", playlist.alta_playlist_time_create);
                if (playlist.alta_status)
                {
                    this.btn_status.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/white/ic_action_not_secure.png")));
                }
                else
                {
                    this.btn_status.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/white/ic_action_secure.png")));
                }
                if (playlist.list_terminal != null)
                {
                    int count = playlist.list_terminal.Count;
                    if (count > 0)
                    {
                        this.st_terminal.Visibility = Visibility.Visible;
                        for (int i = 0; i < count && i < 3; i++)
                        {
                            alta_item_terminal_list tmp = new alta_item_terminal_list();
                            tmp.Height = 24;
                            tmp.Width = 200;
                            tmp.LoadData(playlist.list_terminal[i]);
                            this.st_terminal.Children.Add(tmp);
                        }
                        if (count >= 3)
                            btn_more.Visibility = Visibility.Visible;
                        else
                            btn_more.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        this.st_terminal.Visibility = Visibility.Hidden;
                        btn_more.Visibility = Visibility.Hidden;
                    }
                }

            }
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá playlist này không?", "Thông báo", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                alta_class_playlist tmp = (alta_class_playlist)this.Tag;
                int num = Mysql_helpper.mysql_alta_helpper.delete_playlist(tmp.alta_id);
                if (num == 1)
                {
                    if (DeleteClick != null)
                        DeleteClick(this.Tag, new RoutedEventArgs());
                    this.Visibility = Visibility.Hidden;
                }
            }
        }
        public event RoutedEventHandler DeleteClick;
        public event RoutedEventHandler AddMediaClick;
        public event RoutedEventHandler ChangeStatusClick;
        private void btn_Add_media_Click(object sender, RoutedEventArgs e)
        {
            if (AddMediaClick != null)
                AddMediaClick(this, new RoutedEventArgs());
        }

        private void btn_Status_Click(object sender, RoutedEventArgs e)
        {
            alta_class_playlist playlist = (alta_class_playlist)this.Tag;
            if (ChangeStatusClick != null)
                ChangeStatusClick(playlist, new RoutedEventArgs());
            if (playlist.alta_status)
            {
                this.btn_status.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/white/ic_action_not_secure.png")));
            }
            else
            {
                this.btn_status.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/white/ic_action_secure.png")));
            }
        }

        private void btn_add_ScreenClick(object sender, RoutedEventArgs e)
        {
            if (AddTerminalClick != null)
                AddTerminalClick(this, new RoutedEventArgs());
        }
        public void reLoadData()
        {
            alta_class_playlist playlist = (alta_class_playlist)this.Tag;
            if (playlist != null)
            {
                playlist.LoadDetails();
                this.Tag = playlist;
            }
        }
        public event RoutedEventHandler AddTerminalClick;
        public event EventHandler<alta_class_playlist> ViewDetailsPlaylist;

        private void btn_view_details_click(object sender, RoutedEventArgs e)
        {
            if(ViewDetailsPlaylist!=null){
                ViewDetailsPlaylist(this, this.Tag as alta_class_playlist);
            }

        }
        private void btn_view_terminal_click(object sender, RoutedEventArgs e)
        {
            if (ViewTerminal != null)
            {
                ViewTerminal(this, this.Tag as Class.alta_class_playlist);
            }
        }
        public event EventHandler<Class.alta_class_playlist> ViewTerminal;
        private void Hide_Action_Bar(object sender, MouseEventArgs e)
        {
            this.grid_action.Visibility = Visibility.Hidden;
        }
        private void Show_Action_Bar(object sender, MouseEventArgs e)
        {
            this.grid_action.Visibility = Visibility.Visible;
        }
        
    }
}
