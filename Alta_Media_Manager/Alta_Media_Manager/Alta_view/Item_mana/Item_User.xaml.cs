using Alta_Media_Manager.Class;
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
    /// Interaction logic for Item_User.xaml
    /// </summary>
    public partial class Item_User : UserControl
    {
        public object UIControl;
        public Item_User()
        {
            InitializeComponent();
        }
        public void LoadData(Class.alta_class_user user)
        {
            if (user != null)
            {
                this.Tag = user;
                this.lb_full_name.Content = user.alta_full_name;
                this.lb_user.Content = "Username: "+user.alta_username;
                this.lb_email.Content="Email: "+user.alta_email;
                this.lb_type.Content ="Type: "+ user.alta_type_user.alta_name;
                this.lb_phone.Content = "Phone: " + user.alta_phone;
                if (user.alta_user_status)
                {
                    btn_lock.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/white/ic_action_not_secure.png")));
                    
                }
                else
                {
                    btn_lock.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/white/ic_action_secure.png")));
                }
                if (CommonUtilities.alta_curUser.alta_id != user.alta_id && CommonUtilities.alta_curUser.alta_type_user.alta_permision!=2)
                {
                    this.btnedit.IsEnabled = false;
                }
                if (CommonUtilities.alta_curUser.alta_type_user.alta_permision!=2)
                {
                    this.btnconnect.IsEnabled = false;
                    this.btndelete.IsEnabled = false;
                    this.btn_lock.IsEnabled = false;
                    this.btnListUser.IsEnabled = false;
                }
                else
                {
                    this.btnedit.IsEnabled = true;
                    this.btnconnect.IsEnabled = true;
                    this.btndelete.IsEnabled = true;
                    this.btn_lock.IsEnabled = true;
                    if (user.alta_type_user.alta_permision == 1)
                    {
                        this.btnListUser.IsEnabled = true;
                    }
                    else
                    {
                        this.btnListUser.IsEnabled = false;
                    }         
                }
            }
        }

        private void Hide_Action_Bar(object sender, MouseEventArgs e)
        {
            this.grid_action.Visibility = Visibility.Hidden;
        }

        private void Show_Action_Bar(object sender, MouseEventArgs e)
        {
            this.grid_action.Visibility = Visibility.Visible;
        }

        private void btn_lock_click(object sender, RoutedEventArgs e)
        {
            Class.alta_class_user user= (Class.alta_class_user) this.Tag;

            if (user != null)
            {
                if(user.alta_user_status)
                {
                    if(user.setStatus(false))
                    btn_lock.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/white/ic_action_secure.png")));
                }
                else
                {
                    if (user.setStatus(true))
                        btn_lock.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/white/ic_action_not_secure.png")));
                }
            }
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (deleteItem != null)
            {
                deleteItem(this, new RoutedEventArgs());
            }
        }
        public event RoutedEventHandler deleteItem;
        public event EventHandler<Class.alta_class_user> viewTerminal;
        public event RoutedEventHandler EditItem;
        public event EventHandler<Class.alta_class_user> viewCamera;
        public event EventHandler<Class.alta_class_user> viewVideo;
        public event EventHandler<Class.alta_class_user> viewPlaylist;
        public event EventHandler<Class.alta_class_user> connectTermiral;
        private void btn_view_thietbi(object sender, RoutedEventArgs e)
        {
            if (viewTerminal != null)
                viewTerminal(this, this.Tag as Class.alta_class_user);
        }
        public void reloadData()
        {
            Class.alta_class_user user = this.Tag as Class.alta_class_user;
            if (user != null)
            {
                user = Mysql_helpper.mysql_alta_helpper.getUser(user.alta_id);
                this.LoadData(user);
            }
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (EditItem != null)
                EditItem(this, new RoutedEventArgs());
        }
        private void View_Camra_btn_Click(object sender, RoutedEventArgs e)
        {
            if (viewCamera != null)
                viewCamera(this, this.Tag as Class.alta_class_user);
        }

        private void btn_view_video_click(object sender, RoutedEventArgs e)
        {
            if (viewVideo != null)
                viewVideo(this, this.Tag as Class.alta_class_user);
        }

        private void view_playlist_btn_click(object sender, RoutedEventArgs e)
        {
            if (viewPlaylist != null)
                viewPlaylist(this, this.Tag as Class.alta_class_user);
        }

        private void btn_connect_click(object sender, RoutedEventArgs e)
        {
            if (connectTermiral != null)
                connectTermiral(this, this.Tag as Class.alta_class_user);
        }

        private void btn_view_list_user(object sender, RoutedEventArgs e)
        {
            if (viewParent != null)
                viewParent(this, this.Tag as Class.alta_class_user);
        }
        public event EventHandler<Class.alta_class_user> viewParent;
    }
}
