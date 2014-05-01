using Alta_Media_Manager.Alta_view.Class;
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
    public partial class admin_add_user_schedule : UserControl
    {
        public admin_add_user_schedule()
        {
            InitializeComponent();
        }


        public Class.alta_class_schedules _schedule;
        public Class.alta_class_schedules Schedule
        {
            get { return _schedule; }
            set
            {
                _schedule = value;
                if (value != null || value.alta_id != 0)
                {
                    this.Terminal = value.alta_termiral;
                    this.User = value.alta_user;
                    this.txtDateStd.Text = String.Format("{0:dd/MM/yyyy}", value.alta_schedules_date_begin);
                    this.txtDateEnd.Text = String.Format("{0:dd/MM/yyyy}", value.alta_schedules_date_end);
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
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {


        }
        public event EventHandler<DateTimeEventAltamedia> SaveClick;

        private void btn_Chon_Click(object sender, RoutedEventArgs e)
        {
            list_user = new View_list_user();
            list_user.SelectUser += list_user_SelectUser;
            list_user.CloseClick += list_user_CloseClick;
            this.mainlayout.Children.Add(list_user);
        }

        void list_user_SelectUser(object sender, alta_class_user e)
        {
            this.User = e;
            this.mainlayout.Children.Remove(sender as View_list_user);
        }

        void list_user_CloseClick(object sender, RoutedEventArgs e)
        {
            this.mainlayout.Children.Remove(sender as View_list_user);
        }

        void list_media_CloseClick(object sender, RoutedEventArgs e)
        {
            this.mainlayout.Children.Remove(list_user);
        }
        private void list_media_ItemDoubleClick(object sender, alta_class_media e)
        {

            this.mainlayout.Children.Remove(list_user);
        }

        public View_list_user list_user { get; set; }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (this.Schedule != null)
            {
                if (this.DeleteEvent != null)
                {
                    this.DeleteEvent(this, this.Schedule);
                }
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (this.User == null || this.User.alta_id == 0)
            {
                MessageBox.Show("Hãy chọn một user");
                return;
            }
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
            DateTimeEventAltamedia Event = new DateTimeEventAltamedia();
            if (txtDateStd.data != null)
            {
                Event.StartTime = (DateTime)txtDateStd.data;
            }
            if (txtDateEnd.data != null)
            {
                Event.EndTime = (DateTime)txtDateEnd.data;
            }
            // DateTime std = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //  DateTime etd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(this.hour_end.Text), Convert.ToInt32(this.minute_end.Text), 0);

            
            if (UpdateEvent != null)
            {
                UpdateEvent(this, Event);
            }
        }
        public event EventHandler<DateTimeEventAltamedia> UpdateEvent;
        public event EventHandler<Class.alta_class_schedules> DeleteEvent;
        private Class.alta_class_user _user;
        public Class.alta_class_user User
        {
            get { return _user; }
            set
            {
                _user = value;
                if (value != null || value.alta_id != 0)
                {
                    this.txt_name.Text = value.alta_full_name;
                }
            }
        }
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
            View_List_TerminalFree view_terminal = new View_List_TerminalFree();
            view_terminal.CloseClick += view_terminal_CloseClick;
            view_terminal.selectTerminal += view_terminal_selectEvent;
            this.mainlayout.Children.Add(view_terminal);
        }

        private void view_terminal_selectEvent(object sender, alta_class_termiral e)
        {
            this.Terminal = e;
            this.mainlayout.Children.Remove(sender as View_List_TerminalFree);
        }

        void view_terminal_CloseClick(object sender, RoutedEventArgs e)
        {
            this.mainlayout.Children.Remove(sender as View_List_TerminalFree);
        }
    }

}
