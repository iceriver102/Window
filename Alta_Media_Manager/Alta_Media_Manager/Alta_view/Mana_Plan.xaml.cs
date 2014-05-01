using Alta_Media_Manager.Alta_view.Class;
using Alta_Media_Manager.Alta_view.Item_mana;
using Alta_Media_Manager.Alta_view.Mysql_helpper;
using Alta_Media_Manager.Class;
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
using System.Windows.Threading;

namespace Alta_Media_Manager.Alta_view
{
    /// <summary>
    /// Interaction logic for Mana_Plan.xaml
    /// </summary>
    public partial class Mana_Plan : UserControl
    {
        BackgroundWorker bw;
        public List<alta_class_playlist> List_playlist { get; set; }
        private int cur_item_playlist;
        private alta_class_user user;
        public alta_class_user UserFilter
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                if (user.alta_id == 0)
                {
                    this.btn_back_navigation.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.Cb_Sort.SelectedIndex = 1;
                    this.btn_back_navigation.Visibility = Visibility.Visible;
                }
            }
        }
        public int cur_playlist_Item
        {
            get { return cur_item_playlist; }
            set
            {
                if (value >= this.totalPlaylist)
                    cur_item_playlist = this.totalPlaylist;
                else cur_item_playlist = value;
            }
        }
        public bool flag_load_playlist { get; set; }
        public string sql_sort { get; set; }
        public int pagePlaylist { get; set; }
        public Mana_Plan(bool flag = false)
        {
            InitializeComponent();
            List_playlist = new List<alta_class_playlist>();
            bw = new BackgroundWorker();
            cur_playlist_Item = 0;
            flag_load_playlist = false;
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = false;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            //start();
            if (!flag)
                this.Cb_Sort.SelectedIndex = 1;
        }

        public void start(bool reset = false)
        {
            if (bw.IsBusy != true)
            {
                if (reset)
                    this.pagePlaylist = 0;

                flag_load_playlist = false;
                bw.RunWorkerAsync();
            }
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            flag_load_playlist = true;
            // LoadPlaylist();
            if (flag_load_playlist)
            {
                this.List_playlist = Mysql_Optimize_Class.getDetails(this.List_playlist);
                getTerminalPlaylist();
                LoadView();
            }
        }



        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!flag_load_playlist)
            {
                if (UserFilter == null || UserFilter.alta_id == 0)
                {
                    if (CommonUtilities.alta_curUser.alta_type_user.alta_id == 1)
                        this.List_playlist = mysql_alta_helpper.getListPlaylist(ref this.totalPlaylist, -1, false, CommonUtilities.num_item_in_page * this.pagePlaylist, CommonUtilities.num_item_in_page, this.sql_sort);
                    else
                        this.List_playlist = mysql_alta_helpper.getListPlaylist(ref this.totalPlaylist, CommonUtilities.alta_curUser.alta_id, false, CommonUtilities.num_item_in_page * this.pagePlaylist, CommonUtilities.num_item_in_page, this.sql_sort);
                }
                else
                {
                    this.List_playlist = mysql_alta_helpper.getListPlaylist(ref this.totalPlaylist, this.UserFilter.alta_id, false, CommonUtilities.num_item_in_page * this.pagePlaylist, CommonUtilities.num_item_in_page, this.sql_sort);
                }
                this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                  delegate()
                  {
                      this.cur_playlist_Item = CommonUtilities.num_item_in_page * this.pagePlaylist;
                      this.lb_status.Content = "có " + this.totalPlaylist + " playlist đang xem playlist thứ " + (this.pagePlaylist + 1) + " đến " + (this.pagePlaylist + this.List_playlist.Count);
                      if (pagePlaylist < 1)
                      {
                          this.btn_backPage.IsEnabled = false;
                          this.btn_backPage.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/btn_back_disable.png")));
                      }
                      else
                      {
                          this.btn_backPage.IsEnabled = true;
                          this.btn_backPage.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/btn_back.png")));

                      }
                      if (pagePlaylist >= this.totalPage - 1)
                      {
                          this.btn_nextPage.IsEnabled = false;
                          this.btn_nextPage.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/btn_next_hover.png")));
                      }
                      else
                      {
                          this.btn_nextPage.IsEnabled = true;
                          this.btn_nextPage.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/btn_next.png")));
                      }
                  }));
                flag_load_playlist = true;
            }
        }
        private void getTerminalPlaylist()
        {
            int count = this.List_playlist.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    this.List_playlist[i].getListTerminal();
                }
            }
        }
        private void LoadView()
        {

            int count = this.List_playlist.Count;
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                    delegate()
                    {
                        this.list_Box_Item.Items.Clear();
                    }));
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    alta_playlist_Item item = new alta_playlist_Item();
                    item.Width = 298;
                    item.Height = 177;
                    this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                    delegate()
                    {
                        item.LoadData(this.List_playlist[i]);
                        item.DeleteClick += item_DeleteClick;
                        item.ChangeStatusClick += item_ChangeStatusClick;
                        item.AddMediaClick += item_AddMediaClick;
                        item.AddTerminalClick += item_AddTerminalClick;
                        item.ViewTerminal += item_ViewTerminal;
                        item.ViewDetailsPlaylist += item_ViewDetailsPlaylist;
                        list_Box_Item.Items.Add(item);
                    }));
                }
            }
            else
            {
                MessageBox.Show("Danh sách playlist trống");
            }
            if (this.totalPage > 1)
            {
                btn_nextPage.Visibility = Visibility.Visible;
                btn_backPage.Visibility = Visibility.Visible;
            }
            else
            {
                btn_nextPage.Visibility = Visibility.Hidden;
                btn_backPage.Visibility = Visibility.Hidden;
            }
        }

        void item_ViewDetailsPlaylist(object sender, alta_class_playlist e)
        {
            alta_add_playlist viewplaylist = new alta_add_playlist();
            viewplaylist.LoadData(e);
            viewplaylist.Width = 1346;
            viewplaylist.Height = 663;
            viewplaylist.txt_Title = "Sửa thông tin Playlist";
            viewplaylist.Close += viewplaylist_Close;
            viewplaylist.SaveData += viewplaylist_SaveData;
            main_layout.Children.Add(viewplaylist);
        }
        void item_ViewTerminal(object sender, alta_class_playlist e)
        {
            view_schedule_details view = new view_schedule_details();
            view.Playlist = e;
            view.CloseClick += view_CloseClick;
            this.main_layout.Children.Add(view);
        }

        void view_CloseClick(object sender, EventArgs e)
        {
            this.main_layout.Children.Remove(sender as view_schedule_details);
        }

        void item_AddTerminalClick(object sender, RoutedEventArgs e)
        {
            admin_add_playlist_terminal view = new admin_add_playlist_terminal();
            view.Playlist = (sender as alta_playlist_Item).Tag as Class.alta_class_playlist;
            view.SaveEvent += view_SaveEvent;
            view.CloseClick += view_Close_click;
            this.main_layout.Children.Add(view);
        }

        private void view_Close_click(object sender, RoutedEventArgs e)
        {
            this.main_layout.Children.Remove(sender as admin_add_playlist_terminal);
        }

        void view_SaveEvent(object sender, DateTimeEventAltamedia e)
        {
            admin_add_playlist_terminal tmp = (sender as admin_add_playlist_terminal);
            if (!Mysql_helpper.mysql_alta_helpper.checkTimeScheDuleDetails(tmp.Schedule.alta_id, e.StartTime, e.EndTime))
            {
                Mysql_helpper.mysql_alta_helpper.addPlaylistToTerminal(tmp.Playlist.alta_id, tmp.Terminal.alta_id, e.StartTime, e.EndTime, tmp.Schedule);
                this.main_layout.Children.Remove(sender as admin_add_playlist_terminal);
            }
            else
            {
                MessageBox.Show("Thời gian này đã được đặt lịch phát");
            }

        }

        void view_CloseClick(object sender, RoutedEventArgs e)
        {
            this.main_layout.Children.Remove(sender as View_List_Terminal);
        }
        void item_AddMediaClick(object sender, RoutedEventArgs e)
        {
            alta_playlist_Item playlist_view = sender as alta_playlist_Item;
            //View_list_media viewList = new View_list_media();
            //viewList.LoadData(playlist_view.Tag as alta_class_playlist);
            //viewList.UIControl = playlist_view;
            //viewList.CloseClick += viewList_CloseClick;
            //viewList.InsertEvent+= InsertEventFunction;
            //main_layout.Children.Add(viewList);
            alta_load_schedule view = new alta_load_schedule();
            view.Playlist = (playlist_view.Tag as alta_class_playlist);
            view.Tag = playlist_view.Tag as alta_class_playlist;
            main_layout.Children.Add(view);

        }
        private void InsertEventFunction(object sender, RoutedEventArgs e)
        {
            View_list_media media = sender as View_list_media;
            alta_playlist_Item playlist_View = media.UIControl as alta_playlist_Item;
            playlist_View.reLoadData();
            this.main_layout.Children.Remove(sender as View_list_media);
        }
        void viewList_CloseClick(object sender, RoutedEventArgs e)
        {
            main_layout.Children.Remove(sender as View_list_media);
        }
        void item_ChangeStatusClick(object sender, RoutedEventArgs e)
        {
            alta_class_playlist playlist = sender as alta_class_playlist;
            int count = this.List_playlist.Count;
            for (int i = 0; count > i; i++)
            {
                if (this.List_playlist[i].alta_id == playlist.alta_id)
                {
                    mysql_alta_helpper.changeStatusPlaylist(ref playlist);
                    this.List_playlist[i] = playlist;
                    return;
                }
            }
        }

        void item_DeleteClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa Playlist này không?", "Thông báo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                alta_class_playlist playlist = sender as alta_class_playlist;

                if (!this.del_Item_Playlist(playlist))
                {
                    mysql_alta_helpper.delete_playlist(playlist.alta_id);
                }
                else
                {
                    this.LoadView();
                }
            }
        }
        public bool del_Item_Playlist(alta_class_playlist playlist)
        {
            int count = this.List_playlist.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (List_playlist[i].alta_id == playlist.alta_id)
                    {
                        List_playlist.RemoveAt(i);
                        return true;
                    }
                }
            }
            return false;
        }
        public int totalPlaylist;
        public bool Search_Playlist(string key)
        {
            if (key.Length > 2)
            {
                if (this.UserFilter == null || this.UserFilter.alta_id == 0)
                {
                    if (CommonUtilities.alta_curUser.alta_type_user.alta_id == 1)
                        this.List_playlist = mysql_alta_helpper.SearchPlaylist(ref this.totalPlaylist, key, CommonUtilities.num_item_in_page * pagePlaylist, CommonUtilities.num_item_in_page, -1, this.sql_sort);
                    else
                        this.List_playlist = mysql_alta_helpper.SearchPlaylist(ref this.totalPlaylist, key, CommonUtilities.num_item_in_page * pagePlaylist, CommonUtilities.num_item_in_page, CommonUtilities.alta_curUser.alta_id, this.sql_sort);
                }
                else
                {
                    this.List_playlist = mysql_alta_helpper.SearchPlaylist(ref this.totalPlaylist, key, CommonUtilities.num_item_in_page * pagePlaylist, CommonUtilities.num_item_in_page, this.UserFilter.alta_id, this.sql_sort);
                }
                this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                  delegate()
                  {
                      this.cur_playlist_Item = pagePlaylist * CommonUtilities.num_item_in_page;
                      this.lb_status.Content = "có " + this.totalPlaylist + " video đang xem playlist thứ " + (this.cur_playlist_Item + 1) + " đến " + (this.cur_playlist_Item + this.List_playlist.Count);
                      if (pagePlaylist < 1)
                      {
                          this.btn_backPage.IsEnabled = false;
                          this.btn_backPage.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/btn_back_disable.png")));
                      }
                      else
                      {
                          this.btn_backPage.IsEnabled = true;
                          this.btn_backPage.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/btn_back.png")));

                      }
                      if (pagePlaylist >= this.totalPage - 1)
                      {
                          this.btn_nextPage.IsEnabled = false;
                          this.btn_nextPage.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/btn_next_hover.png")));
                      }
                      else
                      {
                          this.btn_nextPage.IsEnabled = true;
                          this.btn_nextPage.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/btn_next.png")));
                      }

                  }));
                if (this.List_playlist.Count > 0)
                    return true;
                else return false;
            }
            else
            {
                MessageBox.Show("Hãy nhập tối thiểu 3 ký tự");
                return false;
            }
        }
        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            String key = this.txt_Key_Search.Text.Trim();
            if (key.Length < 3)
            {
                MessageBox.Show("Hãy nhập tối thiểu 3 ký tự");
                return;
            }
            pagePlaylist = 0;
            this.cur_playlist_Item = 0;
            if (!this.Search_Playlist(key))
            {
                MessageBox.Show("Không tìm thấy playlist");
            }
            getTerminalPlaylist();
            LoadView();
        }
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            alta_add_playlist viewplaylist = new alta_add_playlist();
            viewplaylist.Width = 1346;
            viewplaylist.Height = 663;
            viewplaylist.txt_Title = "Thêm Playlist";
            viewplaylist.Close += viewplaylist_Close;
            viewplaylist.SaveData += viewplaylist_SaveData;
            main_layout.Children.Add(viewplaylist);
        }
        void viewplaylist_SaveData(object sender, RoutedEventArgs e)
        {
            start();
        }

        void viewplaylist_Close(object sender, RoutedEventArgs e)
        {
            alta_add_playlist viewPlaylist = sender as alta_add_playlist;
            main_layout.Children.Remove(viewPlaylist);
        }
        private void Cb_Sort_Selected_Change(object sender, SelectionChangedEventArgs e)
        {
            Label tmp = (Label)Cb_Sort.SelectedItem;
            string tmpMode = this.sql_sort;
            if (tmp == sort_name)
                this.sql_sort = " ORDER BY  `plan_name` ASC";
            else
                this.sql_sort = " ORDER BY  `plan_time_create` DESC";
            String key = this.txt_Key_Search.Text.Trim();
            if (key == String.Empty)
                start(true);
            else
            {
                pagePlaylist = 0;
                if (!this.Search_Playlist(key))
                {
                    MessageBox.Show("Không tìm thấy Playlist");
                }
                getTerminalPlaylist();
                LoadView();
            }
        }

        private void KeyUpEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                String key = this.txt_Key_Search.Text.Trim();
                if (key.Length < 3)
                {
                    MessageBox.Show("Hãy nhập tối thiểu 3 ký tự");
                    return;
                }
                pagePlaylist = 0;
                this.cur_playlist_Item = 0;
                if (!this.Search_Playlist(key))
                {
                    MessageBox.Show("Không tìm thấy playlist");
                }
                getTerminalPlaylist();
                LoadView();
            }
        }

        private void btn_backPage_Click(object sender, RoutedEventArgs e)
        {
            String key = this.txt_Key_Search.Text.Trim();

            if (key == String.Empty)
            {

                if (pagePlaylist > 0)
                {
                    pagePlaylist--;
                    start();
                    this.btn_backPage.IsEnabled = true;
                }
                else
                {
                    this.btn_nextPage.IsEnabled = false;
                }

            }
            else
            {
                if (pagePlaylist > 0)
                {
                    pagePlaylist--;
                    this.Search_Playlist(key);
                    getTerminalPlaylist();
                    LoadView();
                    this.btn_backPage.IsEnabled = true;
                }
                else
                {
                    this.btn_nextPage.IsEnabled = false;
                }
            }
        }

        private void btn_nextPage_Click(object sender, RoutedEventArgs e)
        {
            String key = this.txt_Key_Search.Text.Trim();

            if (key == String.Empty)
            {

                if (pagePlaylist < totalPage)
                {
                    pagePlaylist++;
                    start();
                    this.btn_backPage.IsEnabled = true;
                }
                else
                {
                    this.btn_nextPage.IsEnabled = false;
                }

            }
            else
            {
                if (pagePlaylist < totalPage)
                {
                    pagePlaylist++;
                    this.Search_Playlist(key);
                    getTerminalPlaylist();
                    LoadView();
                    this.btn_backPage.IsEnabled = true;
                }
                else
                {
                    this.btn_nextPage.IsEnabled = false;
                }
            }
        }
        public int totalPage
        {
            get
            {
                int tmp = this.totalPlaylist / CommonUtilities.num_item_in_page;
                if (CommonUtilities.num_item_in_page * tmp < this.totalPlaylist)
                    tmp++;
                return tmp;
            }
        }
        public event RoutedEventHandler backNavigation;

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            if (backNavigation != null)
                backNavigation(this, new RoutedEventArgs());
        }
    }
}
