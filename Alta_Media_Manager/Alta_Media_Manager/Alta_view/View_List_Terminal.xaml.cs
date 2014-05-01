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
using Alta_Media_Manager.Alta_view.Class;
using Alta_Media_Manager.Class;
using System.Globalization;

namespace Alta_Media_Manager.Alta_view
{
    /// <summary>
    /// Interaction logic for View_List_Terminal.xaml
    /// </summary>
    public partial class View_List_Terminal : UserControl
    {
        public List<alta_class_termiral> list_terminal;
        public event RoutedEventHandler CloseClick;
        public event EventHandler<DateTimeEventAltamedia> InsertEvent;
        public object UIControl;
        public int select_id_terminal;        
        public int terminal_id;
        String sql_sort = " ORDER BY  `termiral_name` ASC";
        public View_List_Terminal()
        {
            InitializeComponent();
            this.Height = 663;
            this.Width = 1346;
            list_terminal = new List<alta_class_termiral>();
            this.lb_data.IsSynchronizedWithCurrentItem = true;
            list_terminal = new List<alta_class_termiral>();
            int total=0;
            list_terminal = Mysql_helpper.mysql_alta_helpper.getListTerminal(ref total, CommonUtilities.alta_curUser.alta_id, this.sql_sort, true, -1,-1 );
            this.lb_data.ItemsSource = list_terminal;
            this.DateChooseView.Visibility = Visibility.Hidden;
            terminal_id = 0;
            this.txt_date_start.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now.Date);
        }
        public void LoadData(alta_class_playlist data)
        {
            if (data != null)
                this.Tag = data;
        }

        private void btn_close_box_Click(object sender, RoutedEventArgs e)
        {
            if (CloseClick != null)
                CloseClick(this, new RoutedEventArgs());

        }
        public void Search_Completed(object sender, RoutedEventArgs e)
        {
            list_terminal = sender as List<alta_class_termiral>;
            this.lb_data.ItemsSource = list_terminal;
        }
        public event RoutedEventHandler selectEvent;
        private void btn_Select_Click(object sender, RoutedEventArgs e)
        {
            Button tmp = sender as Button;
            terminal_id = (int)tmp.Tag;
            if (selectEvent == null)
            {
                this.DateChooseView.Visibility = Visibility.Visible;
                this.MainView.Visibility = Visibility.Hidden;
            }
            else
            {
                this.select_id_terminal = terminal_id;
                selectEvent(this, new RoutedEventArgs());
            }

        }

        private void btn_date_close(object sender, RoutedEventArgs e)
        {
            this.DateChooseView.Visibility = Visibility.Hidden;
            this.MainView.Visibility = Visibility.Visible;
        }

        private void btn_save_click(object sender, RoutedEventArgs e)
        {
            if (this.txt_date_start.Text == "")
            {
                MessageBox.Show("Hãy nhập và ngày băt đầu");
                return;

            }
            if (this.txt_date_end.Text == "")
            {
                MessageBox.Show("Hãy nhập vào ngày kết thúc");
                return;
            }
            if(this.txt_date_end.data<this.txt_date_start.data)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hòn ngày bắt đầu");
                return;
            }
            DateTimeEventAltamedia Event = new DateTimeEventAltamedia();
            if (this.txt_date_start.data != null)
            {
                Event.StartTime = (DateTime)txt_date_start.data;
            }
            if (this.txt_date_end.data != null)
            {
                Event.EndTime = (DateTime)txt_date_end.data;
            }
            
            if (InsertEvent != null)
                InsertEvent(this, Event);
            
        }
    }
}
