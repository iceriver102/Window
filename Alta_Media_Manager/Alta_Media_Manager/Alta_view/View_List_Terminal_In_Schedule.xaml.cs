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
    /// Interaction logic for View_List_Terminal_In_Schedule.xaml
    /// </summary>
    public partial class View_List_Terminal_In_Schedule : UserControl
    {
        List<Class.alta_class_schedules> listSchedule;
        private Class.alta_class_user _user;
        public Class.alta_class_user User            
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                this.StartUp();
            }
        }
        BackgroundWorker bw;

        private void StartUp()
        {
            if (!bw.IsBusy)
                bw.RunWorkerAsync();
        }
        public View_List_Terminal_In_Schedule()
        {
            InitializeComponent();
            bw = new BackgroundWorker();
            listSchedule = new List<Class.alta_class_schedules>();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadView();
        }

        private void LoadView()
        {
            int count = this.listSchedule.Count;
            if (count > 0)
            {
                 this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                    delegate()
                    {
                            for (int i = 0; i < count; i++)
                            {
                                Item_mana.Item_Schedule item = new Item_mana.Item_Schedule();
                                item.Schedule = this.listSchedule[i];
                                item.AddClick += item_AddClick;
                                this.lb_data.Items.Add(item);
                            }
                    }));
            }
        }

        void item_AddClick(object sender, Class.alta_class_schedules e)
        {
            if (selectSchedule != null)
            {
                selectSchedule(this, e);
            }
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            listSchedule = Mysql_helpper.mysql_alta_helpper.getListSchedule(this.User.alta_id);
        }

        private void btnRefreshData(object sender, RoutedEventArgs e)
        {
            this.StartUp();
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btn_close_box_Click(object sender, RoutedEventArgs e)
        {
            if (CloseClick != null)
            {
                CloseClick(this, new RoutedEventArgs());
            }
        }
        public event RoutedEventHandler CloseClick;
        public event EventHandler<Class.alta_class_schedules> selectSchedule;
    }
}
