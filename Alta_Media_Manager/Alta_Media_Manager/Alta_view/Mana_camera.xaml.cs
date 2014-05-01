using Alta_Media_Manager.Alta_view.Class;
using Alta_Media_Manager.Alta_view.Item_mana;
using Alta_Media_Manager.Alta_view.Mysql_helpper;
using Alta_Media_Manager.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Mana_camera.xaml
    /// </summary>
    public partial class Mana_camera : UserControl
    {
        Thread loadData_playlist;
        alta_load_playlist_of_media view_Playlist_of_media;
        alta_Media_Player Player;
        private BackgroundWorker bw = new BackgroundWorker();
        List<alta_class_playlist> List_playlist;
        List<alta_class_media> List_media;
        //List<alta_class_playlist_details> List_details;
        private int cur_item_media;
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
        public int CurMediaItem
        {
            get { return cur_item_media; }
            set
            {
                if (value >= this.totalmedia)
                    cur_item_media = this.totalmedia;
                else cur_item_media = value;
            }
        }
        public int cur_playlist_Item;
        private bool flag_load_media, flag_load_playlist;
        public alta_add_Video detailMedia;
        public int totalmedia, pageMedia;
        public Mana_camera(bool flag=false)
        {
            InitializeComponent();
            UserFilter = new alta_class_user();
            type_camera = CommonUtilities.Type_camera;
            totalmedia = 0;
            pageMedia = 0;
            this.sql_sort = " ORDER BY  `am_media`.`media_name` ASC";
            List_media = new List<alta_class_media>();
            List_playlist = new List<alta_class_playlist>();
            CurMediaItem = 0;
            cur_playlist_Item = 0;
            flag_load_media = flag_load_playlist = false;
            loadData_playlist = new Thread(LoadPlaylistThread);
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = false;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            if(!flag)
                this.Cb_Sort.SelectedIndex = 1;
            // start();
            loadData_playlist.IsBackground = true;
            loadData_playlist.Start();
        }
        #region BackgroundWorker
        public void start(bool reset = false)
        {
            if (bw.IsBusy != true)
            {
                if (reset)
                    this.pageMedia = 0;
                flag_load_media = false;
                bw.RunWorkerAsync();
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            flag_load_media = true;
            // LoadPlaylist();
            if (flag_load_media && flag_load_playlist)
            {
                this.List_playlist = Mysql_Optimize_Class.getDetails(this.List_playlist);
                LoadView();
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.UserFilter == null || this.UserFilter.alta_id == 0)
            {
                if (CommonUtilities.alta_curUser.alta_type_user.alta_permision == 0)
                    this.List_media = mysql_alta_helpper.getListMedia(ref this.totalmedia, this.sql_sort, CommonUtilities.alta_curUser.alta_id, type_camera, false, CommonUtilities.num_item_in_page * pageMedia, CommonUtilities.num_item_in_page);
                else if (CommonUtilities.alta_curUser.alta_type_user.alta_permision == 1)
                {
                    this.List_media = mysql_alta_helpper.getListMedia(ref this.totalmedia, this.sql_sort, CommonUtilities.alta_curUser, type_camera, false, CommonUtilities.num_item_in_page * pageMedia, CommonUtilities.num_item_in_page);
                }
                else
                    this.List_media = mysql_alta_helpper.getListMedia(ref this.totalmedia, this.sql_sort, -1, type_camera, false, CommonUtilities.num_item_in_page * pageMedia, CommonUtilities.num_item_in_page);
            }
            else
            {
                this.List_media = mysql_alta_helpper.getListMedia(ref this.totalmedia, this.sql_sort, this.UserFilter.alta_id, type_camera, false, CommonUtilities.num_item_in_page * pageMedia, CommonUtilities.num_item_in_page);
            }
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                  delegate()
                  {
                      this.CurMediaItem = pageMedia * CommonUtilities.num_item_in_page;
                      this.lb_status.Content = "có " + this.totalmedia + " camera đang xem camera thứ " + (this.CurMediaItem + 1) + " đến " + (this.CurMediaItem + this.List_media.Count);
                      if (pageMedia < 1)
                      {
                          this.btn_backPage.IsEnabled = false;
                          this.btn_backPage.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/btn_back_disable.png")));
                      }
                      else
                      {
                          this.btn_backPage.IsEnabled = true;
                          this.btn_backPage.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/btn_back.png")));

                      }
                      if (pageMedia >= this.totalPage - 1)
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

            flag_load_media = true;
            while (!flag_load_playlist)
            {
                if (!loadData_playlist.IsAlive)
                    loadData_playlist.Start();
            }

        }

        #endregion
        #region Thread Load Data
        public void LoadPlaylistThread()
        {
            while (true)
            {
                LoadPlaylist();
                Thread.Sleep(100);
            }
        }

        private void LoadPlaylist()
        {
            if (!flag_load_playlist)
            {
                if (CommonUtilities.alta_curUser.alta_type_user.alta_id == 1)
                    this.List_playlist = mysql_alta_helpper.getListPlaylist();
                else
                    this.List_playlist = mysql_alta_helpper.getListPlaylist(CommonUtilities.alta_curUser.alta_id);
                this.cur_playlist_Item = this.List_playlist.Count;

                flag_load_playlist = true;

            }
        }

        #endregion
        private void optimize()
        {
            // CommonUtilities.List_user = Mysql_Optimize_Class.mysql_optimize_user(CommonUtilities.List_user, CommonUtilities.list_Type_User);
            this.List_media = Mysql_Optimize_Class.mysql_optimize_media(this.List_media, CommonUtilities.list_Type_Media);
            this.List_media = Mysql_Optimize_Class.mysql_optimize_media(this.List_media, CommonUtilities.List_user);
        }

        public bool Search_Media(string key)
        {
            if (key.Length > 2)
            {
                if (UserFilter == null || UserFilter.alta_id == 0)
                {
                    if (CommonUtilities.alta_curUser.alta_type_user.alta_permision == 2)
                        this.List_media = mysql_alta_helpper.SearchMedia(ref this.totalmedia, key, CommonUtilities.num_item_in_page * pageMedia, CommonUtilities.num_item_in_page, -1, type_camera, this.sql_sort);
                    else if (CommonUtilities.alta_curUser.alta_type_user.alta_permision == 1)
                    {
                        this.List_media = mysql_alta_helpper.SearchMedia(ref this.totalmedia, key, CommonUtilities.num_item_in_page * pageMedia, CommonUtilities.num_item_in_page, CommonUtilities.alta_curUser, type_camera, this.sql_sort);
                    }
                    else
                        this.List_media = mysql_alta_helpper.SearchMedia(ref this.totalmedia, key, CommonUtilities.num_item_in_page * pageMedia, CommonUtilities.num_item_in_page, CommonUtilities.alta_curUser.alta_id, type_camera, this.sql_sort);
                }
                else
                {
                    this.List_media = mysql_alta_helpper.SearchMedia(ref this.totalmedia, key, CommonUtilities.num_item_in_page * pageMedia, CommonUtilities.num_item_in_page, this.UserFilter.alta_id, type_camera, this.sql_sort);
                }
                this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                  delegate()
                  {
                      this.CurMediaItem = pageMedia * CommonUtilities.num_item_in_page;
                      this.lb_status.Content = "có " + this.totalmedia + " camera đang xem camera thứ " + (this.CurMediaItem + 1) + " đến " + (this.CurMediaItem + this.List_media.Count);
                      if (pageMedia < 1)
                      {
                          this.btn_backPage.IsEnabled = false;
                          this.btn_backPage.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/btn_back_disable.png")));
                      }
                      else
                      {
                          this.btn_backPage.IsEnabled = true;
                          this.btn_backPage.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/btn_back.png")));

                      }
                      if (pageMedia >= this.totalPage - 1)
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
                if (this.List_media.Count > 0)
                    return true;
                else return false;
            }
            else
            {
                MessageBox.Show("Hãy nhập tối thiểu 3 ký tự");
                return false;
            }
        }

        public void LoadView()
        {
            optimize();
            int count = this.List_media.Count;
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                    delegate()
                    {
                        this.list_Box_Item.Items.Clear();
                    }));
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    Item_view_camera item = new Item_view_camera();
                    item.Width = 298;
                    item.Height = 177;
                    this.List_media[i] = Mysql_Optimize_Class.mysql_optimize_media(this.List_media[i], this.List_playlist);
                    this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                    delegate()
                    {
                        item.LoadData(this.List_media[i]);
                        item.deleteItem += item_deleteItem;
                        item.ViewPlaylistClick += item_ViewPlaylistClick;
                        item.EditItemClick += item_EditItemClick;
                        item.CheckItemClick += item_CheckItemClick;
                        item.PlayMediaClick += item_PlayMediaClick;
                        list_Box_Item.Items.Add(item);
                    }));
                }
            }
            else
            {
                MessageBox.Show("Không tồn tại camera");
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

        public void UpdateView(List<alta_class_media> list_media)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                    delegate()
                    {
                        list_Box_Item.Items.Clear();
                        int count = list_media.Count;
                        if (count > 0)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                alta_Item_Media item = new alta_Item_Media();
                                item.Width = 298;
                                item.Height = 177;
                                item.LoadData(this.List_media[i]);
                                item.deleteItem += item_deleteItem;
                                item.ViewPlaylistClick += item_ViewPlaylistClick;
                                item.EditItemClick += item_EditItemClick;
                                item.CheckItemClick += item_CheckItemClick;
                                item.PlayMediaClick += item_PlayMediaClick;
                                list_Box_Item.Items.Add(item);
                            }
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
                    }));

        }
        public bool del_Item_Media(alta_class_media media)
        {
            int count = this.List_media.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (List_media[i].alta_id == media.alta_id)
                    {
                        List_media.RemoveAt(i);
                        return true;
                    }
                }
            }
            return false;
        }
        #region Click_Item
        void item_PlayMediaClick(object sender, RoutedEventArgs e)
        {
            alta_class_media media = sender as alta_class_media;
            Player = new alta_Media_Player();
            Player.LoadData(media);
            Player.Width = 1346;
            Player.Height = 690;
            Player.CheckItemClick += item_CheckItemClick;
            Player.CloseClick += Player_CloseClick;
            main_layout.Children.Add(Player);
        }

        void Player_CloseClick(object sender, RoutedEventArgs e)
        {
            main_layout.Children.Remove(Player);
        }

        void item_EditItemClick(object sender, RoutedEventArgs e)
        {
            alta_class_media media = sender as alta_class_media;
            alta_add_camera cameraAddView = new alta_add_camera();
            cameraAddView.LoadData(media);
            cameraAddView.Width = 1346;
            cameraAddView.Height = 690;
            cameraAddView.txt_Title = "Sửa thông tin camera";
            cameraAddView.Close += cameraAddView_Close;
            cameraAddView.SaveData += cameraAddView_SaveData;
            main_layout.Children.Add(cameraAddView);

        }

        void item_CheckItemClick(object sender, RoutedEventArgs e)
        {
            alta_class_media media = sender as alta_class_media;
            int count = this.List_media.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.List_media[i] == media)
                {
                    this.List_media[i] = mysql_alta_helpper.checkMedia(!media.alta_media_status, media);
                    break;
                }
            }
            UpdateView(this.List_media);

        }

        void item_deleteItem(object sender, RoutedEventArgs e)
        {
            Item_view_camera tmp = sender as Item_view_camera;
            alta_class_media media = (alta_class_media)tmp.Tag;
            if (!del_Item_Media(media))
            {
#if DEBUG
                MessageBox.Show("ERR");
#endif
            }
            else
            {
                UpdateView(this.List_media);
            }
        }

        void item_ViewPlaylistClick(object sender, RoutedEventArgs e)
        {
            alta_class_media media = sender as alta_class_media;
            if (media.alta_playlist.Count > 0)
            {
                view_Playlist_of_media = new alta_load_playlist_of_media();
                view_Playlist_of_media.HideViewClick += HideViewClick;
                view_Playlist_of_media.LoadItem(media.alta_playlist);
                view_Playlist_of_media.ViewItemClick += view_Playlist_of_media_ViewItemClick;
                main_layout.Children.Add(view_Playlist_of_media);
            }
        }
        void view_Playlist_of_media_ViewItemClick(object sender, RoutedEventArgs e)
        {
            //alta_class_playlist playlist = sender as alta_class_playlist;
            //MessageBox.Show("Tinh nang dang phat trien: " + playlist.alta_id);
            //main_layout.Children.Remove(view_Playlist_of_media);
        }

        void HideViewClick(object sender, RoutedEventArgs e)
        {
            main_layout.Children.Remove(view_Playlist_of_media);
        }
        #endregion

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            String key = this.txt_Key_Search.Text.Trim();
            if (key.Length < 3)
            {
                MessageBox.Show("Hãy nhập tối thiểu 3 ký tự");
                return;
            }
            pageMedia = 0;
            this.cur_item_media = 0;
            if (!this.Search_Media(key))
            {
                MessageBox.Show("Không tìm thấy Camera");
            }
            optimize();
            UpdateView(this.List_media);
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
                pageMedia = 0;
                if (!this.Search_Media(key))
                {
                    MessageBox.Show("Không tìm thấy Camera");
                }
                optimize();
                UpdateView(this.List_media);
            }
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            alta_add_camera cameraAddView = new alta_add_camera();
            cameraAddView.Width = 1346;
            cameraAddView.Height = 664;
            cameraAddView.txt_Title = "Thêm Camera";
            cameraAddView.Close += cameraAddView_Close;
            cameraAddView.SaveData += cameraAddView_SaveData;
            main_layout.Children.Add(cameraAddView);
        }

        void cameraAddView_SaveData(object sender, RoutedEventArgs e)
        {
            start();
        }

        void cameraAddView_Close(object sender, RoutedEventArgs e)
        {
            alta_add_camera detailMedia = sender as alta_add_camera;
            main_layout.Children.Remove(detailMedia);
        }



        private void Cb_Sort_Selected_Change(object sender, SelectionChangedEventArgs e)
        {
            Label tmp = (Label)Cb_Sort.SelectedItem;
            string tmpMode = this.sql_sort;
            if (tmp == sort_name)
                this.sql_sort = " ORDER BY  `am_media`.`media_name` ASC";
            else
                this.sql_sort = " ORDER BY  `am_media`.`media_date` DESC";
            String key = this.txt_Key_Search.Text.Trim();
            if (key == String.Empty)
                start(true);
            else
            {
                pageMedia = 0;
                if (!this.Search_Media(key))
                {
                    MessageBox.Show("Không tìm thấy video");
                }
                optimize();
                UpdateView(this.List_media);
            }
        }
        public string sql_sort { get; set; }

        private void btn_backPage_Click(object sender, RoutedEventArgs e)
        {
            String key = this.txt_Key_Search.Text.Trim();
            if (key == String.Empty)
            {
                if (pageMedia > 0)
                {
                    pageMedia--;
                    start();
                    this.btn_nextPage.IsEnabled = true;
                }
                else
                {
                    this.btn_backPage.IsEnabled = false;
                }

            }
            else
            {
                if (pageMedia > 0)
                {
                    pageMedia--;
                    this.Search_Media(key);
                    optimize();
                    UpdateView(this.List_media);
                    this.btn_nextPage.IsEnabled = true;
                }
                else
                {
                    this.btn_backPage.IsEnabled = false;
                }

            }
        }

        private void btn_nextPage_Click(object sender, RoutedEventArgs e)
        {
            String key = this.txt_Key_Search.Text.Trim();
            // int totalPage = getTotalPage();
            if (key == String.Empty)
            {

                if (pageMedia < totalPage)
                {
                    pageMedia++;
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
                if (pageMedia < totalPage)
                {
                    pageMedia++;
                    this.Search_Media(key);
                    optimize();
                    UpdateView(this.List_media);
                    this.btn_backPage.IsEnabled = true;
                }
                else
                {
                    this.btn_nextPage.IsEnabled = false;
                }


            }
        }

        public static int type_camera;

        public int totalPage
        {
            get
            {
                int tmp = this.totalmedia / CommonUtilities.num_item_in_page;
                if (CommonUtilities.num_item_in_page * tmp < this.totalmedia)
                    tmp++;
                return tmp;
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            if (backNavigation != null)
                backNavigation(this, new RoutedEventArgs());
        }
        public event RoutedEventHandler backNavigation;
    }
}
