using Alta_Media_Manager.Alta_view.Class;
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

namespace Alta_Media_Manager.Alta_view
{
    /// <summary>
    /// Interaction logic for playlist_view_add_shcedule.xaml
    /// </summary>
    public partial class admin_add_playlist_terminal : UserControl
    {
        public admin_add_playlist_terminal()
        {
            InitializeComponent();
           // ScheduleDetails = null;
        }
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
                if (value != null && value.alta_id != 0)
                {
                    bar_action_new.Visibility = Visibility.Visible;
                    bar_action.Visibility = Visibility.Hidden;
                }
                
            }
        }
        private Class.alta_class_schedules_details _scheduleDetails;
        public Class.alta_class_schedules_details ScheduleDetails
        {
            get { return _scheduleDetails; }
            set
            {
                _scheduleDetails = value;
                if (value != null || value.alta_id != 0)
                {
                    this.Schedule = value.alta_schedules.getData();
                    this.txtDateStd.Text = String.Format("{0:dd/MM/yyyy}", value.alta_time_play);
                    this.txtDateEnd.Text = String.Format("{0:dd/MM/yyyy}", value.alta_time_end);
                    bar_action_new.Visibility = Visibility.Hidden;
                    bar_action.Visibility = Visibility.Visible;
                }
                
            }
        }

        private void btn_click(object sender, RoutedEventArgs e)
        {
            if (CloseClick != null)
            {
                CloseClick(this, new RoutedEventArgs());
            }
        }

        public event RoutedEventHandler CloseClick;


        void list_user_CloseClick(object sender, RoutedEventArgs e)
        {
            this.mainlayout.Children.Remove(sender as View_list_user);
        }
        private void btn_update_Click(object sender, RoutedEventArgs e)
        {

            if (this.Terminal == null || this.Terminal.alta_id == 0)
            {
                MessageBox.Show("Hãy chọn một màn hình");
                return;
            }
            if (this.txtDateStd.Text == String.Empty)
            {
                MessageBox.Show("Hãy nhập ngày bắt đầu");
                return;
            }
            if (this.txtDateEnd.Text == String.Empty)
            {
                MessageBox.Show("Hãy nhập ngày kết thúc");
                return;
            }
            if (txtDateEnd.data < txtDateStd.data)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu?", "Thông báo", MessageBoxButton.OK);
                return;
            }
            if (this.Schedule.alta_schedules_date_begin.Date > txtDateStd.data.Value.Date || this.Schedule.alta_schedules_date_end.Date < txtDateEnd.data.Value)
            {
                MessageBox.Show(String.Format("Bạn chỉ được phát trên màn hình này từ {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", this.Schedule.alta_schedules_date_begin, this.Schedule.alta_schedules_date_end));
                return;
            }
            DateTimeEventAltamedia Event = new DateTimeEventAltamedia();
            if (txtDateStd.data != null)
            {
                Event.StartTime = txtDateStd.data.Value;
            }
            if (txtDateEnd.data != null)
            {
                Event.EndTime = txtDateEnd.data.Value;
            }
            // DateTime std = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //  DateTime etd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(this.hour_end.Text), Convert.ToInt32(this.minute_end.Text), 0);


            if (UpdateEvent != null)
            {
                UpdateEvent(this, Event);
            }
        }
        public event EventHandler<DateTimeEventAltamedia> UpdateEvent;
        public event EventHandler<DateTimeEventAltamedia> SaveEvent;
        public event EventHandler<Class.alta_class_schedules_details> DeleteEvent;

        private Class.alta_class_termiral _terminal;
        public Class.alta_class_termiral Terminal
        {
            get { return _terminal; }
            set
            {
                this._terminal = value;
                if (value != null || value.alta_id == 0)
                    this.txt_name_terminal.Text = value.alta_name;
            }
        }
        private void btn_Chon_terminal_Click(object sender, RoutedEventArgs e)
        {
            View_List_Terminal_In_Schedule view_terminal = new View_List_Terminal_In_Schedule();
            if (this.Playlist == null)
            {
                view_terminal.User = this.Schedule.alta_user;
            }
            else
            {
                view_terminal.User = this.Playlist.alta_user;
            }
            view_terminal.CloseClick += view_terminal_CloseClick;
            view_terminal.selectSchedule += view_Schedule_selectEvent;
            this.mainlayout.Children.Add(view_terminal);
        }

        private void view_Schedule_selectEvent(object sender, alta_class_schedules e)
        {
            this.mainlayout.Children.Remove(sender as View_List_Terminal_In_Schedule);
            this.Schedule = e;

        }       

        void view_terminal_CloseClick(object sender, RoutedEventArgs e)
        {
            this.mainlayout.Children.Remove(sender as View_List_Terminal_In_Schedule);
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (DeleteEvent != null)
            {
                DeleteEvent(this, this.ScheduleDetails);
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (this.Terminal == null || this.Terminal.alta_id == 0)
            {
                MessageBox.Show("Hãy chọn một màn hình");
                return;
            }
            if (this.txtDateStd.Text == String.Empty)
            {
                MessageBox.Show("Hãy nhập ngày bắt đầu");
                return;
            }
            if (this.txtDateEnd.Text == String.Empty)
            {
                MessageBox.Show("Hãy nhập ngày kết thúc");
                return;
            }
            if (txtDateEnd.data < txtDateStd.data)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu?", "Thông báo", MessageBoxButton.OK);
                return;
            }
            if (this.Schedule.alta_schedules_date_begin.Date > txtDateStd.data.Value.Date || this.Schedule.alta_schedules_date_end.Date < txtDateEnd.data.Value)
            {
                MessageBox.Show(String.Format("Bạn chỉ được phát trên màn hình này từ {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}",this.Schedule.alta_schedules_date_begin,this.Schedule.alta_schedules_date_end));
                return;
            }
            DateTimeEventAltamedia Event = new DateTimeEventAltamedia();
            if (txtDateStd.data != null)
            {
                Event.StartTime = txtDateStd.data.Value;
            }
            if (txtDateEnd.data != null)
            {
                Event.EndTime = txtDateEnd.data.Value;
            }
            // DateTime std = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //  DateTime etd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(this.hour_end.Text), Convert.ToInt32(this.minute_end.Text), 0);


            if (SaveEvent != null)
            {
                SaveEvent(this, Event);
            }
        }
        private alta_class_schedules _schedule;
        public alta_class_schedules Schedule
        {
            get { return _schedule; }
            set { 
                _schedule = value;
                if (_schedule != null && _schedule.alta_id != 0)
                {
                    this.Terminal = value.alta_termiral;
                }
            }
        }
    }

}
