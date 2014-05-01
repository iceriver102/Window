using Alta_Media_Manager.Alta_view.Class;
using Alta_Media_Manager.Alta_view.Item_mana;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Alta_Media_Manager.Alta_view
{
    /// <summary>
    /// Interaction logic for View_list_user.xaml
    /// </summary>
    public partial class View_list_user : UserControl
    {
        public event RoutedEventHandler CloseClick;
        public List<alta_class_user> list_user;
        public event RoutedEventHandler InsertEvent;
        public delegate void moveLeftFunction();

        int total = 0;
        BackgroundWorker bw;
        String sql_sort = " ORDER BY  `username` ASC";
        public View_list_user()
        {
            InitializeComponent();
            this.Height = 663;
            this.Width = 1346;
            Canvas.SetTop(this, 0);
            //Canvas.SetLeft(this, 0);
            this.lb_data.IsSynchronizedWithCurrentItem = true;
            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            this.lb_data.ItemsSource = list_user;
            Canvas.SetTop(this, 0);
            Canvas.SetLeft(this, 0);
            this.Opacity = 0;
            StaticFunction.aniChangeOpacity(this,1,0.4);
            // list_media = new List<alta_class_media>();
            Startup();
        }
        private void Startup()
        {
            if (!bw.IsBusy)
                bw.RunWorkerAsync();
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            list_user = Mysql_helpper.mysql_alta_helpper.getListUser(ref total, this.sql_sort, true,0, CommonUtilities.num_item_in_page);
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadView(this.list_user);
            // this.List_media = mysql_alta_helpper.getListMedia(ref this.totalmedia, this.sql_sort, -1, type_video, false, CommonUtilities.num_item_in_page * pageMedia, CommonUtilities.num_item_in_page);

        }
        void LoadView(List<alta_class_user> list_user)
        {
            alta_class_playlist playlist = this.Tag as alta_class_playlist;
            int count = list_user.Count;
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                    delegate()
                    {
                        this.lb_data.Items.Clear();
                    }));
            if (count > 0)
            {
                this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                      delegate()
                      {
                          for (int i = 0; i < count; i++)
                          {
                              //    list_media[i].alta_user = CommonUtilities.alta_curUser;
                              Item_user_select item = new Item_user_select(list_user[i]);
                              item.SelectItemEvent += item_SelectItemEvent;
                              //  item.AddUserToSchedule += item_AddMediaToPlaylist;
                              this.lb_data.Items.Add(item);
                          }
                      }));
            }
        }

        private void item_SelectItemEvent(object sender, alta_class_user e)
        {
             if (SelectUser == null)
            {
                StaticFunction.aniMoveTo(this.layoutContent, 1370, 50, 0.4);
                View_List_TerminalFree view_terminal = new View_List_TerminalFree();
                view_terminal.UIControl = sender as Item_user_select;
                view_terminal.CloseClick += view_terminal_CloseClick;
                view_terminal.selectEvent += view_terminal_selectEvent;
                this.mainLayout.Children.Add(view_terminal);
            }
            else
            {
                SelectUser(this, e);
            }
        }

       

        public event EventHandler<Class.alta_class_user> SelectUser;

        void view_terminal_selectEvent(object sender, RoutedEventArgs e)
        {
           
            DateChooserControl viewChooseDate = new DateChooserControl();
            viewChooseDate.Tag = sender as View_List_TerminalFree;           
            StaticFunction.aniMoveTo(sender as View_List_TerminalFree, 1370, 0, 0.4, new PowerEase() { Power = 1.0, EasingMode = EasingMode.EaseInOut });
            viewChooseDate.SaveClick += viewChooseDate_SaveClick;
            viewChooseDate.CloseClick += viewChooseDate_CloseClick;
            this.mainLayout.Children.Add(viewChooseDate);            
        }

        void viewChooseDate_CloseClick(object sender, RoutedEventArgs e)
        {
            DateChooserControl viewChooseDate = sender as DateChooserControl;
            StaticFunction.aniMoveTo(viewChooseDate.Tag as View_List_TerminalFree, 0, 0, 0.4);
            StaticFunction.aniMoveToFunction(viewChooseDate, -1370, 50, 0.4,null,()=>Removefunction(viewChooseDate));
        }
        void viewChooseDate_SaveClick(object sender, RoutedEventArgs e)
        {
            DateChooserControl viewChooseDate = sender as DateChooserControl;
            View_List_TerminalFree termiral = viewChooseDate.Tag as View_List_TerminalFree;
            if(viewChooseDate.beginDate.Text!=String.Empty && viewChooseDate.endDate.Text!=String.Empty)
            {
                DateTime beginDate= DateTime.ParseExact(viewChooseDate.beginDate.Text,"dd/MM/yyyy",null);
                DateTime endDate= DateTime.ParseExact(viewChooseDate.endDate.Text,"dd/MM/yyyy", null);
                if(beginDate>endDate){
                    MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu");
                    return;
                }
                if (Mysql_helpper.mysql_alta_helpper.checkTimeScheDule(beginDate, endDate, termiral.select_id_terminal))
                {
                    Mysql_helpper.mysql_alta_helpper.connectUserTermiral((termiral.UIControl as Item_user_select).Id, termiral.select_id_terminal, beginDate, endDate);
                    if (compledInsertData != null)
                    {
                        compledInsertData(this, new RoutedEventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Đã có một user được kết nối vào màn hình trong khoản thời gian này");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập thời gian bắt đầu và thời gian kết thúc");
            }
        }
        public event RoutedEventHandler compledInsertData;

        void Removefunction(UIElement ob)
        {
            this.mainLayout.Children.Remove(ob);           
        }

        void view_terminal_CloseClick(object sender, RoutedEventArgs e)
        {
            StaticFunction.aniMoveToFunction(sender as View_List_TerminalFree, -1370, 0, 0.4, null, () => Removefunction(sender as View_List_TerminalFree));
           // this.mainLayout.Children.Remove(sender as View_List_TerminalFree);
            StaticFunction.aniMoveTo(this.layoutContent, 150, 50, 0.4, new PowerEase() { Power = 1.0, EasingMode = EasingMode.EaseInOut });
        }
      

        private void btnRefreshData(object sender, RoutedEventArgs e)
        {
            this.txt_Search.Text = "";
            this.Startup();
        }

        private void btn_close_box_Click(object sender, RoutedEventArgs e)
        {
            if (CloseClick != null)
                CloseClick(this, new RoutedEventArgs());
        }

        private void Search_Completed(object sender, RoutedEventArgs e)
        {
            list_user = sender as List<alta_class_user>;
            LoadView(list_user);
        }

        private void ReLoad_Data(object sender, RoutedEventArgs e)
        {

        }
    }
}
