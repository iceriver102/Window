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
using Alta_Media_Manager.Alta_view.Class;
using Alta_Media_Manager.Class;
using Alta_Media_Manager.Alta_view.Mysql_helpper;
using System.Windows.Threading;
using Alta_Media_Manager.Alta_view.Item_mana;

namespace Alta_Media_Manager.Alta_view
{
    /// <summary>
    /// Interaction logic for Mana_user.xaml
    /// </summary>
    public partial class Mana_user : UserControl
    {
        private BackgroundWorker bw = new BackgroundWorker();
        private List<alta_class_user> list_user;
        public int totalItem;
        mana_Thiet_bi thietbiView;
        Mana_camera cameraView;
        Mana_Video videoView;
        Mana_Plan playlistView;
        public string sql_sort { get; set; }
        public int totalPage
        {
            get
            {
                int tmp = this.totalItem / CommonUtilities.num_item_in_page;
                if (CommonUtilities.num_item_in_page * tmp < this.totalItem)
                    tmp++;
                return tmp;
            }
        }
        private int cur_item;
        public int CurTerminalItem
        {
            get { return cur_item; }
            set
            {
                if (value >= this.totalItem)
                    cur_item = this.totalItem;
                else cur_item = value;
            }
        }
        public Mana_user()
        {
            InitializeComponent();
            this.sql_sort = " ORDER BY  `full_name` ASC";           
            list_user = new List<alta_class_user>();
            totalItem = 0;
            flag_load_data = false;
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = false;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            this.Cb_Sort.SelectedIndex = 1;
            if (CommonUtilities.alta_curUser.alta_type_user.alta_permision != 2)
            {
                this.btnAdd.IsEnabled = false;
                this.btnSearch.IsEnabled = false;
            }
            else
            {
                this.btnAdd.IsEnabled = true;
                btnSearch.IsEnabled = true;
            }
           
        }

        public void StartUp(bool flag=false)
        {

            if (!bw.IsBusy)
            {
                if (flag)
                    this.page = 0;
                bw.RunWorkerAsync();
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            flag_load_data = true;
            // LoadPlaylist();
            if (flag_load_data)
            {
                LoadView();
            }
        }

        public void LoadView()
        {            
            int count = this.list_user.Count;
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                   delegate()
                   {
                       int countUI = this.main_layout.Children.Count;
                       for (int i = 0; i < countUI; i++)
                       {
                           if (this.main_layout.Children[i].GetType().ToString() == "Alta_Media_Manager.ManaView.mana_Thiet_bi")
                           {
                               this.main_layout.Children.RemoveAt(i);
                           }
                           else if (this.main_layout.Children[i].GetType().ToString() == "Alta_Media_Manager.ManaView.Mana_Video")
                           {
                               this.main_layout.Children.RemoveAt(i);
                           }
                           else if (this.main_layout.Children[0].GetType().ToString() == "Alta_Media_Manager.ManaView.Mana_Plan")
                           {
                               this.main_layout.Children.RemoveAt(i);
                           }
                           else if (this.main_layout.Children[i].GetType().ToString() == "Alta_Media_Manager.ManaView.Mana_camera")
                           {
                               this.main_layout.Children.RemoveAt(i);
                           }
                       }
                       this.Grid_content.Visibility = Visibility.Visible;
                       this.list_Box_Item.Items.Clear();
                   }));
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    Item_User item = new Item_User();
                    item.Width = 298;
                    item.Height = 177;
                    this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                    delegate()
                    {
                        item.LoadData(this.list_user[i]);
                        item.deleteItem += item_deleteItem;
                        item.EditItem += item_EditItem;
                        item.viewTerminal += item_viewTerminal;
                        item.viewCamera += item_viewCamera;
                        item.viewPlaylist += item_viewPlaylist;
                        item.viewVideo += item_viewVideo;
                        item.connectTermiral += item_connectTermiral;
                        item.viewParent += item_viewParent;
                        list_Box_Item.Items.Add(item);
                    }));
                }
            }
            else
            {
                MessageBox.Show("Không tồn tại User nào trong hệ thống");
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

        void item_viewParent(object sender, alta_class_user e)
        {
            View_list_user_of_parent listUser = new View_list_user_of_parent(true);
            listUser.userParent = e;
            listUser.CloseClick += listUser_CloseClick;
            this.main_layout.Children.Add(listUser);
            
        }

        void listUser_CloseClick(object sender, RoutedEventArgs e)
        {
            this.main_layout.Children.Remove(sender as View_list_user_of_parent);
        }

        private void item_connectTermiral(object sender, alta_class_user e)
        {
           // Item_User userView = sender as Item_User;
            //alta_class_user user = userView.Tag as alta_class_user;
            View_List_TerminalFree list_termiral = new View_List_TerminalFree();
            list_termiral.Tag = e;
            list_termiral.CloseClick += list_termiral_CloseClick;
            list_termiral.selectEvent += list_termiral_selectEvent;
            this.main_layout.Children.Add(list_termiral);
        }

        private void item_viewVideo(object sender, alta_class_user e)
        {
            this.Grid_content.Visibility = Visibility.Hidden;
           // Item_User userView = sender as Item_User;
            //alta_class_user user = userView.Tag as alta_class_user;
            videoView = new Mana_Video(true);
            videoView.Height = 643;
            videoView.Width = 1346;
            videoView.backNavigation += videoView_backNavigation;
            videoView.UserFilter = e;
           // videoView.cancel();
          //  videoView.start();
            this.main_layout.Children.Add(videoView);
        }

        private void item_viewPlaylist(object sender, alta_class_user e)
        {
            this.Grid_content.Visibility = Visibility.Hidden;
           // Item_User userView = sender as Item_User;
           // alta_class_user user = userView.Tag as alta_class_user;
            playlistView = new Mana_Plan(true);
            playlistView.backNavigation += playlistView_backNavigation;
            playlistView.Height = 643;
            playlistView.Width = 1346;
            playlistView.UserFilter = e;
           // playlistView.start();
            this.main_layout.Children.Add(playlistView);
        }

        private void item_viewCamera(object sender, alta_class_user e)
        {
            this.Grid_content.Visibility = Visibility.Hidden;
          //  Item_User userView = sender as Item_User;
          //  alta_class_user user = userView.Tag as alta_class_user;
            cameraView = new Mana_camera(true);
            cameraView.backNavigation += cameraView_backNavigation;
            cameraView.Width = 1346;
            cameraView.Height = 643;
            cameraView.UserFilter = e;
           // cameraView.start();
            this.main_layout.Children.Add(cameraView);
        }

        private void item_viewTerminal(object sender, alta_class_user e)
        {
            this.Grid_content.Visibility = Visibility.Hidden;
           // Item_User userView = sender as Item_User;
           // alta_class_user user = userView.Tag as alta_class_user;
            thietbiView = new mana_Thiet_bi(true);
            thietbiView.backNavigation += thietbiView_backNavigation;
            thietbiView.Width = 1346;
            thietbiView.Height = 663;
            thietbiView.UserFilter = e;
            //thietbiView.start();
            this.main_layout.Children.Add(thietbiView);
        }
        void item_connectTermiral(object sender, RoutedEventArgs e)
        {
            Item_User userView = sender as Item_User;
            alta_class_user user = userView.Tag as alta_class_user;
            View_List_TerminalFree list_termiral = new View_List_TerminalFree();
            list_termiral.Tag = user;
            list_termiral.CloseClick += list_termiral_CloseClick;
            list_termiral.selectEvent += list_termiral_selectEvent;
            this.main_layout.Children.Add(list_termiral);
        }

        void list_termiral_selectEvent(object sender, RoutedEventArgs e)
        {
            View_List_TerminalFree viewTermiral = sender as View_List_TerminalFree;
            alta_class_user user = viewTermiral.Tag as alta_class_user;
            DateChooserControl DateChoose = new DateChooserControl();
            DateChoose.Tag = user;
            DateChoose.secondTag = viewTermiral.select_id_terminal;
            DateChoose.CloseClick += DateChoose_CloseClick;
            DateChoose.SaveClick += DateChoose_SaveClick;
            this.main_layout.Children.Add(DateChoose);

          //  mysql_alta_helpper.connectUserTermiral(user.alta_id, viewTermiral.select_id_terminal);
        }

        void DateChoose_SaveClick(object sender, RoutedEventArgs e)
        {
            DateChooserControl DateChoose = sender as DateChooserControl;
            alta_class_user user = DateChoose.Tag as alta_class_user;
            int termiral_id = (int)DateChoose.secondTag;
            if (termiral_id != 0 && user != null)
            {
                String strBeginDate=  DateChoose.beginDate.Text.Trim();
                String strEndDate = DateChoose.endDate.Text.Trim();
                DateTime timeBegin = DateTime.ParseExact(strBeginDate, "dd/MM/yyyy", null);
                DateTime timeEnd = DateTime.ParseExact(strEndDate, "dd/MM/yyyy", null);
                if (timeEnd.Date > timeBegin.Date)
                {
                    if (mysql_alta_helpper.checkTimeScheDule(timeBegin, timeEnd,termiral_id))
                    {
                        mysql_alta_helpper.connectUserTermiral(user.alta_id, termiral_id, timeBegin, timeEnd);
                    }
                    else
                    {
                        MessageBox.Show("Màn hình này đã được kết nối với một user khác từ ngày " + strBeginDate +" đến ngày " +strEndDate);
                    }
                }
                else
                {
                    MessageBox.Show("ngày kết thúc phải lớn hơn ngày bắt đầu");
                }
            }
        }

        void DateChoose_CloseClick(object sender, RoutedEventArgs e)
        {
            this.main_layout.Children.Remove(sender as DateChooserControl);
        }

        void list_termiral_CloseClick(object sender, RoutedEventArgs e)
        {
            this.main_layout.Children.Remove(sender as View_List_TerminalFree);
        }

        

        void videoView_backNavigation(object sender, RoutedEventArgs e)
        {
            this.Grid_content.Visibility = Visibility.Visible;
            this.main_layout.Children.Remove(sender as Mana_Video);
        }
        
        void playlistView_backNavigation(object sender, RoutedEventArgs e)
        {
            this.Grid_content.Visibility = Visibility.Visible;
            this.main_layout.Children.Remove(sender as Mana_Plan);
        }

       
        void cameraView_backNavigation(object sender, RoutedEventArgs e)
        {
            this.Grid_content.Visibility = Visibility.Visible;
            this.main_layout.Children.Remove(sender as Mana_camera);
        }

        

        void thietbiView_backNavigation(object sender, RoutedEventArgs e)
        {
            this.Grid_content.Visibility = Visibility.Visible;
            this.main_layout.Children.Remove(sender as mana_Thiet_bi);
        }

       

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            this.list_user.Clear();
            if (CommonUtilities.alta_curUser.alta_type_user.alta_permision == 2)
            {
                this.list_user = mysql_alta_helpper.getListUser(ref this.totalItem, this.sql_sort, false, CommonUtilities.num_item_in_page * this.page, CommonUtilities.num_item_in_page);
            }
            else if (CommonUtilities.alta_curUser.alta_type_user.alta_permision == 1)
            {
                int count =CommonUtilities.alta_curUser.Children.Count;
                this.list_user.Add(CommonUtilities.alta_curUser);
                for(int i=0;i<count;i++){
                    this.list_user.Add(CommonUtilities.alta_curUser.Children[i].alta_user);
                }
                
            }
            else
            {
                this.list_user.Add(CommonUtilities.alta_curUser);
            }
                this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                     delegate()
                     {
                         this.CurUserItem = page * CommonUtilities.num_item_in_page;
                         this.lb_status.Content = "có " + this.totalItem + " user đang xem user thứ " + (this.CurUserItem + 1) + " đến " + (this.CurUserItem + this.list_user.Count);
                         if (page < 1)
                         {
                             this.btn_backPage.IsEnabled = false;
                             this.btn_backPage.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/btn_back_disable.png")));
                         }
                         else
                         {
                             this.btn_backPage.IsEnabled = true;
                             this.btn_backPage.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/btn_back.png")));

                         }
                         if (page >= this.totalPage - 1)
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
           
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            add_user_view view = new add_user_view();
            view.txt_Title = "Thêm User";
            view.Close += view_Close;
            view.SaveData += view_SaveData;
            view.Height = 663;
            view.Width = 1346;
            this.main_layout.Children.Add(view);
        }
        void item_EditItem(object sender, RoutedEventArgs e)
        {
            add_user_view view = new add_user_view();
            Item_User user_view= sender as Item_User;
            view.UIControl = user_view;
            view.loadData(user_view.Tag as alta_class_user);
            view.txt_Title = "Sửa User";
            view.Close += view_Close;
            view.SaveData += view_SaveData;
            view.Height = 663;
            view.Width = 1346;
            this.main_layout.Children.Add(view);
        }

        void item_deleteItem(object sender, RoutedEventArgs e)
        {
            Item_User item = sender as Item_User;
            alta_class_user user = item.Tag as alta_class_user;
            if (user != null)
            {
                if (MessageBox.Show("Bạn có muốn xoá user này không?", "Thông báo", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    if (Mysql_helpper.mysql_alta_helpper.delete_user(user.alta_id))
                    {
                        this.list_user.Remove(user);
                        this.list_Box_Item.Items.Remove(item);
                    }
                }
            }
        }

        void view_SaveData(object sender, RoutedEventArgs e)
        {
            add_user_view view = sender as add_user_view;
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
               delegate()
               {
                   Class.alta_class_user user = view.Tag as alta_class_user;
                   if (user == null)
                   {
                       this.main_layout.Children.Remove(view);
                       this.StartUp();
                   }
                   else
                   {
                       Item_User user_view = view.UIControl as Item_User;
                       user_view.reloadData();
                       this.main_layout.Children.Remove(view);
                   }
               }));

        }

        void view_Close(object sender, RoutedEventArgs e)
        {
            this.main_layout.Children.Remove(sender as add_user_view);
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            String key = this.txt_Key_Search.Text;
            page = 0;
            if (key.Length > 2)
            {
                if (Search(key))
                {
                    
                }
                else
                {
                    MessageBox.Show("Không tìm thấy user");
                }
                LoadView();
            }
            else
            {
                MessageBox.Show("Hãy nhập tối thiểu 3 ký tự");
            }
        }
        private bool Search(String key)
        {
            
            if (key.Length > 2)
            {
                this.list_user = mysql_alta_helpper.SearchUser(ref this.totalItem,key, this.sql_sort, false, CommonUtilities.num_item_in_page * this.page, CommonUtilities.num_item_in_page);
            }
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                 delegate()
                 {
                     this.CurUserItem = page * CommonUtilities.num_item_in_page;
                     this.lb_status.Content = "có " + this.totalItem + " user đang xem user thứ " + (this.CurUserItem + 1) + " đến " + (this.CurUserItem + this.list_user.Count);
                     if (page < 1)
                     {
                         this.btn_backPage.IsEnabled = false;
                         this.btn_backPage.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/btn_back_disable.png")));
                     }
                     else
                     {
                         this.btn_backPage.IsEnabled = true;
                         this.btn_backPage.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Alta_Media_Manager;component/Asset/Alta_Btn/btn_back.png")));

                     }
                     if (page >= this.totalPage - 1)
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
            if (this.list_user.Count > 0)
                return true;
            return false;
        }

        private void KeyUpEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                String key = this.txt_Key_Search.Text;
                page = 0;
                if (key.Length > 2)
                {
                    if (Search(key))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy user");
                    }
                    LoadView();
                }
                else
                {
                    MessageBox.Show("Hãy nhập tối thiểu 3 ký tự");
                }
            }
        }

        private void Cb_Sort_Selected_Change(object sender, SelectionChangedEventArgs e)
        {
            Label tmp = (Label)Cb_Sort.SelectedItem;
            string tmpMode = this.sql_sort;
            if (tmp == sort_name)
                this.sql_sort = " ORDER BY  `full_name` ASC";
            else
                this.sql_sort = " ORDER BY  `user_time_create` DESC";
            String key = this.txt_Key_Search.Text.Trim();
            if (key == String.Empty)
                this.StartUp(true);
            else
            {
                page = 0;
                if (!this.Search(key))
                {
                    MessageBox.Show("Không tìm thấy User");
                }
              //  getTerminalPlaylist();
                LoadView();
            }
        }
        public int page { get; set; }
        public bool flag_load_data { get; set; }

        private void btn_backPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_nextPage_Click(object sender, RoutedEventArgs e)
        {

        }


        public int CurUserItem { get; set; }
    }
}
