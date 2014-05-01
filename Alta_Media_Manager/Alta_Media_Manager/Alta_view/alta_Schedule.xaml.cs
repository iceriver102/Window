using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfScheduler;

namespace Alta_Media_Manager.Alta_view
{
    /// <summary>
    /// Interaction logic for alta_Schedule.xaml
    /// </summary>
    public partial class alta_Schedule : UserControl
    {
        ObservableCollection<Event> list_event;
        BackgroundWorker bw;
        List<Class.alta_class_schedules> list_schedule;
        public alta_Schedule()
        {
            InitializeComponent();
            list_event = new ObservableCollection<Event>();
            list_schedule = new List<Class.alta_class_schedules>();
            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
           // StartUp();

        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadEvents();
        }

        private void LoadEvents()
        {
            int count = this.list_schedule.Count;
            this.Alta_Schedule.Events.Clear();
            for (int i = 0; i < count; i++)
            {
                Event tmpEvent = new Event();
                tmpEvent.Tag = this.list_schedule[i];
                tmpEvent.Start = this.list_schedule[i].alta_schedules_date_begin.Date;
                tmpEvent.End = this.list_schedule[i].alta_schedules_date_end.Date;
                tmpEvent.Subject =  this.list_schedule[i].alta_termiral.alta_name;
                tmpEvent.Description = this.list_schedule[i].alta_user.alta_full_name +" kết nối "+ this.list_schedule[i].alta_termiral.alta_name;
                tmpEvent.Color = Brushes.Brown;
                tmpEvent.User = this.list_schedule[i].alta_user.alta_full_name;                
                Alta_Schedule.AddEvent( tmpEvent);
               // list_event.Add(tmpEvent);
            }
        //    Alta_Schedule.Events = list_event;    
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {          
            this.list_schedule = Mysql_helpper.mysql_alta_helpper.getListScheduleofMonth(this.Alta_Schedule.FirstDay,this.Alta_Schedule.LastDay);
        }

        public void StartUp()
        {
            if (!bw.IsBusy)
            {
                bw.RunWorkerAsync();
            }
        }

        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
            Alta_Schedule.NextPage();
            StartUp();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            Alta_Schedule.PrevPage();
            StartUp();
        }

        private void btn_month_click(object sender, RoutedEventArgs e)
        {
            Alta_Schedule.Mode = Mode.Month;
            StartUp();
        }

        private void btn_week_click(object sender, RoutedEventArgs e)
        {
            Alta_Schedule.Mode = Mode.Week;
            StartUp();
        }

        private void btn_click_Day(object sender, RoutedEventArgs e)
        {
            Alta_Schedule.Mode = Mode.Day;
            StartUp();
        }

        private void LoadSchedule(object sender, RoutedEventArgs e)
        {
            StartUp();
        }

        private void btn_add_schedule_click(object sender, RoutedEventArgs e)
        {
            View_list_user list_view = new View_list_user();
            list_view.InsertEvent += list_view_InsertEvent;
            list_view.compledInsertData += list_view_compledInsertData;
            list_view.CloseClick += list_view_CloseClick;
            this.main_layout.Children.Add(list_view);
        }

        void list_view_compledInsertData(object sender, RoutedEventArgs e)
        {
            this.main_layout.Children.Remove(sender as View_list_user);
            StartUp();
        }

        void list_view_CloseClick(object sender, RoutedEventArgs e)
        {
            this.main_layout.Children.Remove(sender as View_list_user);
        }

        void list_view_InsertEvent(object sender, RoutedEventArgs e)
        {
            
        }
        private void EventDoubleClick(object sender, Event e)
        {
            admin_add_user_schedule view = new admin_add_user_schedule();
            view.Schedule = (e.Tag as Class.alta_class_schedules);
            view.CloseClick += view_CloseClick;
            view.UpdateEvent += view_UpdateEvent;
            view.DeleteEvent += view_DeleteEvent;
            this.main_layout.Children.Add(view);
            
        }

        void view_DeleteEvent(object sender, Class.alta_class_schedules e)
        {
            if (MessageBox.Show("Bạn có muốn xóa lịch phát này không?", "Thông báo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Mysql_helpper.mysql_alta_helpper.deleteScheDule(e.alta_id);
                this.main_layout.Children.Remove(sender as admin_add_user_schedule);
            }
        }

        void view_UpdateEvent(object sender, DateTimeEventAltamedia e)
        {
            admin_add_user_schedule Event= (sender as admin_add_user_schedule);
            Mysql_helpper.mysql_alta_helpper.upDateScheDule(Event.Schedule.alta_id,Event.Terminal.alta_id,Event.User.alta_id,e.StartTime,e.EndTime);
            this.main_layout.Children.Remove(sender as admin_add_user_schedule);
            this.StartUp();
        }
        void view_CloseClick(object sender, RoutedEventArgs e)
        {
            this.main_layout.Children.Remove(sender as admin_add_user_schedule);
        }

    }
}
