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
    /// Interaction logic for view_schedule_details.xaml
    /// </summary>
    public partial class view_schedule_details : UserControl
    {
        BackgroundWorker bw;
        private Class.alta_class_playlist _playlist;
        public Class.alta_class_playlist Playlist
        {
            get
            {
                return _playlist;
            }
            set
            {
                _playlist = value;
                if (value != null || value.alta_id != 0)
                    StartUp();
            }
        }
        List<Class.alta_class_schedules_details> List_Schedule_details;
        public view_schedule_details()
        {
            InitializeComponent();
            bw = new BackgroundWorker();
            List_Schedule_details = new List<Class.alta_class_schedules_details>();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }
        public void StartUp()
        {
            if (!bw.IsBusy)
                bw.RunWorkerAsync();
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadView();
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            List_Schedule_details = Mysql_helpper.mysql_alta_helpper.getListScheduleDetails(Playlist);
        }
        void LoadView()
        {
            int count = this.List_Schedule_details.Count;
            if (count > 0)
            {
                this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                      delegate()
                      {
                          this.lb_data.Items.Clear();
                            for (int i = 0; i < count; i++)
                            {
                                Item_mana.Item_Schedule_details item = new Item_mana.Item_Schedule_details();
                                item.ScheduleDetails = List_Schedule_details[i];
                                item.DeleteDetails+=item_DeleteDetails;
                                item.EditEvent += item_EditEvent;
                                this.lb_data.Items.Add(item);
                            }
                      }));
            }
        }

        void item_EditEvent(object sender, Class.alta_class_schedules_details e)
        {
            admin_add_playlist_terminal view = new admin_add_playlist_terminal();
            view.CloseClick += view_CloseClick;
            view.ScheduleDetails = e;
            view.UpdateEvent += view_UpdateEvent;
            this.mainLayout.Children.Add(view);
        }

        void view_UpdateEvent(object sender, DateTimeEventAltamedia e)
        {
            admin_add_playlist_terminal tmp= (sender as admin_add_playlist_terminal);
            if (!Mysql_helpper.mysql_alta_helpper.checkTimeScheDuleDetails(tmp.Schedule.alta_id,e.StartTime, e.EndTime, tmp.ScheduleDetails.alta_id))
                Mysql_helpper.mysql_alta_helpper.updateScheduleDetails(tmp.ScheduleDetails.alta_id,this.Playlist.alta_id, tmp.Schedule, e.StartTime, e.EndTime);
            else
            {
                MessageBox.Show("Thời gian này đã được đặt lịch phát");
            }
            this.StartUp();
            this.mainLayout.Children.Remove(sender as admin_add_playlist_terminal);
        }

        void view_CloseClick(object sender, RoutedEventArgs e)
        {
            this.mainLayout.Children.Remove(sender as admin_add_playlist_terminal);
        }
        private void item_DeleteDetails(object sender, Class.alta_class_schedules_details e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa Playlist khỏi màn hình này không?", "Thông báo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Mysql_helpper.mysql_alta_helpper.deleteScheduleDetails(e.alta_id);
                this.mainLayout.Children.Remove(sender as admin_add_playlist_terminal);
                this.StartUp();
            }
        }
        public event EventHandler CloseClick;
        private void btn_close_box_Click(object sender, RoutedEventArgs e)
        {
            if (CloseClick != null)
            {
                CloseClick(this, new EventArgs());
            }
        }

        private void btnRefreshData(object sender, RoutedEventArgs e)
        {
            this.StartUp();
        }
    }


}
