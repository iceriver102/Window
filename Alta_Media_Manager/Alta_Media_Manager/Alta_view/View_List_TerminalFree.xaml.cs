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
using System.Windows.Media.Animation;

namespace Alta_Media_Manager.Alta_view
{
    /// <summary>
    /// Interaction logic for View_List_Terminal.xaml
    /// </summary>
    public partial class View_List_TerminalFree : UserControl
    {
        public List<alta_class_termiral> list_terminal;
        public event RoutedEventHandler CloseClick;
       // public event RoutedEventHandler InsertEvent;
        public object UIControl;
        public int select_id_terminal;
        int terminal_id;
        String sql_sort = " ORDER BY  `termiral_name` ASC";
        public View_List_TerminalFree()
        {
            InitializeComponent();
            this.Height = 663;
            this.Width = 1346;
            Canvas.SetTop(this, 0);
            Canvas.SetLeft(this, -1355);
            PowerEase IE = new PowerEase();
            IE.EasingMode = EasingMode.EaseInOut;
            IE.Power = 1.0;
            StaticFunction.aniMoveTo(this, 0, 0, 0.4, IE);
            list_terminal = new List<alta_class_termiral>();
            this.lb_data.IsSynchronizedWithCurrentItem = true;
            list_terminal = new List<alta_class_termiral>();
            int total = 0;
            list_terminal = Mysql_helpper.mysql_alta_helpper.getListTerminal(ref total, this.sql_sort, true, 0, CommonUtilities.num_item_in_page);
            this.lb_data.ItemsSource = list_terminal;
            //this.DateChooseView.Visibility = Visibility.Hidden;
            terminal_id = 0;
         //   this.txt_date_start.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now.Date);
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
        public event EventHandler<Class.alta_class_termiral> selectTerminal;
        private void btn_Select_Click(object sender, RoutedEventArgs e)
        {
            Button tmp = sender as Button;
            terminal_id = (int)tmp.Tag;
           
            if (selectEvent != null)
            {
                this.select_id_terminal = terminal_id;
                selectEvent(this, new RoutedEventArgs());
            }
            if (selectTerminal != null)
            {
                int count = list_terminal.Count;
                for (int i = 0; i < count; i++)
                {
                    if (list_terminal[i].alta_id == terminal_id)
                    {
                        selectTerminal(this, list_terminal[i]);
                        break;
                    }

                }

            }

        }        
    }
}
