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

namespace Alta_Media_Manager.Alta_view.Item_mana
{
    /// <summary>
    /// Interaction logic for Item_Schedule.xaml
    /// </summary>
    public partial class Item_Schedule : UserControl
    {
        public Class.alta_class_user User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                if (_user != null)
                {
                    this.lb_userName.Content = value.alta_full_name;
                }
                else
                {
                    this.lb_userName.Content = "";
                }
            }
        }
        private Class.alta_class_user _user;

        private Class.alta_class_termiral _terminal;
        public Class.alta_class_termiral Terminal
        {
            get
            {
                return _terminal;
            }
            set
            {
                _terminal = value;
                if (value != null)
                    this.lbName.Content = value.alta_name;
                else
                {
                    this.lbName.Content = "";
                }
            }
        }
        private Class.alta_class_schedules _schedule;
        public Class.alta_class_schedules Schedule
        {
            get
            {
                return _schedule;
            }
            set
            {
                _schedule = value;
                if (value != null)
                {
                    this.Terminal = value.alta_termiral;
                    this.User = value.alta_user;
                    this.lb_DateStd.Content = String.Format("{0:dd/MM/yyyy}", value.alta_schedules_date_begin);
                    this.lb_DateEnd.Content = String.Format("{0:dd/MM/yyyy}", value.alta_schedules_date_end);

                }
                else
                {
                    this.lb_DateEnd.Content = "";
                    this.lb_DateStd.Content = "";
                }
            }
        }
        public Item_Schedule()
        {
            InitializeComponent();
            this.Width = 298;
            this.Height = 177;
        }

        private void btn_add_click(object sender, RoutedEventArgs e)
        {
            if (AddClick != null)
            {
                AddClick(this, this.Schedule);
            }
        }
        public event EventHandler<Class.alta_class_schedules> AddClick;
    }
}
