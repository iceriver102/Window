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
    public partial class View_list_user_of_parent : UserControl
    {
        public event RoutedEventHandler CloseClick;
        public List<alta_class_user> list_user;
        public event RoutedEventHandler InsertEvent;
        public delegate void moveLeftFunction();
        private Class.alta_class_user _userParent;
        public Class.alta_class_user userParent
        {
            get
            {
                return _userParent;
            }
            set
            {
                _userParent = value;
                if (_userParent != null)
                {
                    Startup();
                }
            }
        }

        int total = 0;
        BackgroundWorker bw;
        String sql_sort = " ORDER BY  `username` ASC";
        public View_list_user_of_parent(bool flag = false)
        {
            InitializeComponent();
            this.Height = 663;
            this.Width = 1346;
            Canvas.SetTop(this, 0);
            //Canvas.SetLeft(this, 0);
            this.lb_data.IsSynchronizedWithCurrentItem = true;
            list_user = new List<alta_class_user>();
            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            //this.lb_data.ItemsSource = list_user;
            Canvas.SetTop(this, 0);
            Canvas.SetLeft(this, 0);
            this.Opacity = 0;
            StaticFunction.aniChangeOpacity(this, 1, 0.4);
            // list_media = new List<alta_class_media>();
            if (!flag)
                Startup();
        }
        private void Startup()
        {
            if (!bw.IsBusy)
                bw.RunWorkerAsync();
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                 delegate()
                 {
                     this.list_user.Clear();
                 }));
            this.list_user = Mysql_helpper.mysql_alta_helpper.getListUser(ref total,2, this.sql_sort);

        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadView(this.list_user);
            // this.List_media = mysql_alta_helpper.getListMedia(ref this.totalmedia, this.sql_sort, -1, type_video, false, CommonUtilities.num_item_in_page * pageMedia, CommonUtilities.num_item_in_page);

        }
        void LoadView(List<alta_class_user> list_user)
        {           
            // alta_class_playlist playlist = this.Tag as alta_class_playlist;
            int count = list_user.Count;
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                    delegate()
                    {
                        try
                        {
                            this.lb_data.Items.Clear();
                        }
                        catch (Exception)
                        {

                        }
                    }));
            if (count > 0)
            {
                int countChildren = userParent.Children.Count;
                this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                      delegate()
                      {
                          for (int i = 0; i < count; i++)
                          {                             
                              Item_user_select item = new Item_user_select(list_user[i]);
                              item.ShowBar = true;                              
                              item.RemoveEvent += item_RemoveEvent;
                              item.AddEvent += item_AddEvent;
                              int j=0;
                              while(j<countChildren && !list_user[i].Equals(userParent.Children[j].alta_user)) j++;
                              if (j >= countChildren)
                              {
                                 
                                  item.isAdd = true;
                              }
                              else
                              {
                                  item.isRemove = true;
                              }

                                  this.lb_data.Items.Add(item);
                          }
                      }));
            }
        }

        void item_AddEvent(object sender, alta_class_user e)
        {
            userParent.AddChildren(e);
            Startup(); 
        }

        void item_RemoveEvent(object sender, alta_class_user e)
        {
            userParent.removeChildren(e);
            Startup();            
        }
        public event RoutedEventHandler compledInsertData;      


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
