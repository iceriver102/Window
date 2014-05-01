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
    /// Interaction logic for Item_Schedule_details.xaml
    /// </summary>
    public partial class Item_Schedule_details : UserControl
    {
        private Class.alta_class_schedules_details _scheduleDetails;
        public Class.alta_class_schedules_details ScheduleDetails
        {
            get
            {
                return _scheduleDetails;
            }
            set
            {
                _scheduleDetails = value;
                if (value != null && value.alta_id != 0)
                {
                    this.lb_date_start.Content = String.Format("{0:dd/MM/yyyy}", value.alta_time_play);
                    this.lb_date_End.Content = String.Format("{0:dd/MM/yyyy}", value.alta_time_end);
                    this.User = value.alta_user;
                    this.Terminal=value.alta_schedules.alta_termiral;
                    this.Playlist=value.alta_playlist;  
        
                }
            }
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
                _playlist=value;
                if(value!=null && value.alta_id!=0)
                {

                }
            }
        }
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
                if (value != null && value.alta_id != 0)
                {
                    this.lb_name.Content = value.alta_name;
                }
            }
        }
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
                if (value != null && value.alta_id != 0)
                {
                    this.lb_user.Content = value.alta_full_name;
                }
            }
        }
        public Item_Schedule_details()
        {
            InitializeComponent();
            this.Width = 298;
            this.Height = 177;
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (DeleteDetails != null)
            {
                DeleteDetails(this, this.ScheduleDetails);
            }
        }
        public event EventHandler<Class.alta_class_schedules_details> DeleteDetails;
        public event EventHandler<Class.alta_class_schedules_details> EditEvent;
        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (EditEvent != null)
            {
                EditEvent(this, this.ScheduleDetails);
            }
        }

    }
}
