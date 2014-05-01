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
    /// Interaction logic for mana_Thiet_bi.xaml
    /// </summary>
    public partial class mana_Thiet_bi : UserControl
    {
        private BackgroundWorker bw ;
        private alta_class_user user;
        public alta_class_user UserFilter 
        { 
            get 
            { 
                return user;
            }
            set 
            {
                user=value;
                if (user.alta_id == 0)
                {
                    this.btn_back_navigation.Visibility = Visibility.Hidden;
                }
                else
                {
                    start();
                    this.btn_back_navigation.Visibility = Visibility.Visible;
                }
            } 
        }
        private List<alta_class_termiral> list_terminal;
        public int totalItem;        
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
        private int cur_item_terminal;
        public int CurTerminalItem
        {
            get { return cur_item_terminal; }
            set
            {
                if (value >= this.totalItem)
                    cur_item_terminal = this.totalItem;
                else cur_item_terminal = value;
            }
        }

        public mana_Thiet_bi(bool flag=false)
        {
            InitializeComponent();
            UserFilter = new alta_class_user();
            list_terminal = new List<alta_class_termiral>();
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = false;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            if(!flag)
             start();
        }

        public void start(bool reset=false)
        {
 	        if(!bw.IsBusy){
                if (reset)
                    this.page = 0;
                flag_load_data = false;
                bw.RunWorkerAsync();
            };
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

        private void LoadView()
        {
           
            int count= this.list_terminal.Count;
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                   delegate()
                   {
                       
                       this.list_Box_Item.Items.Clear();
                   }));
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    Item_thietbi item = new Item_thietbi();
                    item.Width = 298;
                    item.Height = 177;                 
                    this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                    delegate()
                    {
                        item.LoadData(this.list_terminal[i]);
                        item.viewStreaming += item_viewStreaming;
                        item.EditTermiral += item_EditTermiral;
                        item.DeleteEvent += item_DeleteEvent;
                        item.ViewPlaylistEvent += item_ViewPlaylistEvent;
                        item.viewFilePlaying += item_viewFilePlaying;
                        list_Box_Item.Items.Add(item);
                    }));
                }
            }
            else
            {
                MessageBox.Show("Danh sách thiết bị trống");
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

        private void item_viewFilePlaying(object sender, PlayEvent e)
        {
            if (e.isMedia)
            {
                alta_class_media media = e.media;
                alta_Media_Player Player = new alta_Media_Player();
                Player.LoadData(media);
                Player.Width = 1346;
                Player.Height = 690;
               // Player.CheckItemClick += item_CheckItemClick;
                Player.CloseClick += Player_CloseClick;
                this.main_layout.Children.Add(Player);
            }
        }

        private void Player_CloseClick(object sender, RoutedEventArgs e)
        {
            this.main_layout.Children.Remove(sender as alta_Media_Player);
        }

       

        void item_ViewPlaylistEvent(object sender, alta_class_playlist e)
        {
            if (e != null)
            {
                alta_load_schedule viewDetailsPlaylist = new alta_load_schedule();
                viewDetailsPlaylist.Playlist = e;
                viewDetailsPlaylist.BackEvent = true;
                viewDetailsPlaylist.BackNavigationEvent += viewDetailsPlaylist_BackNavigationEvent;
                this.main_layout.Children.Add(viewDetailsPlaylist);
            }
            else
            {
                MessageBox.Show("Không có playlist được phát trên màn hình này");
            }
        }

        void viewDetailsPlaylist_BackNavigationEvent(object sender, EventArgs e)
        {
            this.main_layout.Children.Remove(sender as alta_load_schedule);

        }

        void item_DeleteEvent(object sender, alta_class_termiral e)
        {
            if (MessageBox.Show("Bạn có muốn xóa màn hình này không?", "Thông báo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                mysql_alta_helpper.delete_termiral(e.alta_id);
                start();
            }
        }

        void item_EditTermiral(object sender, alta_class_termiral e)
        {
            alta_edit_manhinh viewManhinh = new alta_edit_manhinh();
            viewManhinh.LoadData(e);
            viewManhinh.SaveData += viewManhinh_SaveData;
            viewManhinh.Close += viewManhinh_Close;
            this.main_layout.Children.Add(viewManhinh);
        }

        private void viewManhinh_Close(object sender, RoutedEventArgs e)
        {
            this.main_layout.Children.Remove(sender as alta_edit_manhinh);
        }

        void viewManhinh_SaveData(object sender, RoutedEventArgs e)
        {
            start();
            this.main_layout.Children.Remove(sender as alta_edit_manhinh);
        }
        void item_viewStreaming(object sender, RoutedEventArgs e)
        {
            Item_thietbi terminal = sender as Item_thietbi;
            if (terminal.view_Stream != null)
            {
                Streaming_view view = terminal.view_Stream as Streaming_view;
                view.Visibility = Visibility.Visible;
            }
            else
            {
                Streaming_view view = new Streaming_view();
                view.loadClient(sender as Item_thietbi);
                view.Streaming += view_Streaming;
                view.RunbackGround += view_RunbackGround;
                view.StopStreaming += view_StopStreaming;
                view.Close += view_Close;
                view.Width = 1346;
                view.Height = 663;
                Canvas.SetLeft(view, 0);
                Canvas.SetTop(view, 0);
                terminal.view_Stream = view;
                main_layout.Children.Add(view);
            }
        }

        void view_Close(object sender, RoutedEventArgs e)
        {
            Streaming_view view = sender as Streaming_view;
            Item_thietbi thietbi = view.Tag as Item_thietbi;
            thietbi.view_Stream = null;
            if (view.isStreaming)
            {
                thietbi.SendControl("STOPSTREAM");
            }
            main_layout.Children.Remove(view);
        }

        void view_RunbackGround(object sender, RoutedEventArgs e)
        {
            Streaming_view view = sender as Streaming_view;
            view.Visibility = Visibility.Hidden;
        }

        void view_StopStreaming(object sender, RoutedEventArgs e)
        {
            Item_thietbi tmp = sender as Item_thietbi;
            if (tmp.client.isConnected)
            {
                tmp.SendControl("STOPSTREAM");
            }
        }

        void view_Streaming(object sender, RoutedEventArgs e)
        {
            Item_thietbi tmp = sender as Item_thietbi;
            if (tmp.client.isConnected)
            {
                tmp.SendControl("STREAM");
            }
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (UserFilter.alta_id == 0)
            {
               
                //throw new NotImplementedException();
                if (CommonUtilities.alta_curUser.alta_type_user.alta_id == 1)
                {
                    this.list_terminal = mysql_alta_helpper.getListTerminal(ref this.totalItem, this.sql_sort, false, CommonUtilities.num_item_in_page * this.page, CommonUtilities.num_item_in_page);
                }
                else
                {
                    this.list_terminal = mysql_alta_helpper.getListTerminal(ref this.totalItem, CommonUtilities.alta_curUser.alta_id, this.sql_sort, false, CommonUtilities.num_item_in_page * this.page, CommonUtilities.num_item_in_page);
                }
            }
            else
            {
               
                this.list_terminal = mysql_alta_helpper.getListTerminal(ref this.totalItem,this.UserFilter.alta_id, this.sql_sort, false, CommonUtilities.num_item_in_page * this.page, CommonUtilities.num_item_in_page);
            }
        }



        private void KeyUpEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                String key = this.txt_Key_Search.Text.Trim();
                if (key.Length > 3)
                {
                    Search(key);
                }
                else
                {
                    MessageBox.Show("Hãy nhập tối thiểu 3 ký tự");
                }
            }
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            String key=this.txt_Key_Search.Text.Trim();
            if (key.Length > 3)
            {
                Search(key);
            }
            else
            {
                MessageBox.Show("Hãy nhập tối thiểu 3 ký tự");
            }
        }
        private void Search(String key)
        {
            if (this.UserFilter.alta_id == 0)
            {
                if (CommonUtilities.alta_curUser.alta_type_user.alta_id == 1)
                {
                    this.list_terminal = mysql_alta_helpper.SearchTerminal(ref this.totalItem, key, -1, this.sql_sort);
                }
                else
                {
                    this.list_terminal = mysql_alta_helpper.SearchTerminal(ref this.totalItem, key, CommonUtilities.alta_curUser.alta_id, this.sql_sort);
                }
            }
            else
            {
                this.list_terminal = mysql_alta_helpper.SearchTerminal(ref this.totalItem, key, this.UserFilter.alta_id, this.sql_sort);
            }
            this.LoadView();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            alta_add_manhinh termiral_View = new alta_add_manhinh();
            termiral_View.Width = 1346;
            termiral_View.Height = 664;
            termiral_View.txt_Title = "Thêm Màn Hình";
            termiral_View.Close += termiral_ViewClose;
            termiral_View.SaveData += termiral_ViewSaveData;
            main_layout.Children.Add(termiral_View);
        }

        private void termiral_ViewSaveData(object sender, RoutedEventArgs e)
        {
            start();
        }

        private void termiral_ViewClose(object sender, RoutedEventArgs e)
        {
            alta_add_manhinh tmp = sender as alta_add_manhinh;
            this.main_layout.Children.Remove(tmp);
        }
        private void btn_backPage_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btn_nextPage_Click(object sender, RoutedEventArgs e)
        {

        }

        public int page { get; set; }

        public bool flag_load_data { get; set; }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            if (backNavigation != null)
                backNavigation(this, new RoutedEventArgs());
        }
        public event RoutedEventHandler backNavigation;
    }
}
