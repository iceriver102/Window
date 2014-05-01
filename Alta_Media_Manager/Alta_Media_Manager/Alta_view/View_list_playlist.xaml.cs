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
using Alta_Media_Manager.Class;

namespace Alta_Media_Manager.Alta_view
{
    /// <summary>
    /// Interaction logic for View_list_playlist.xaml
    /// </summary>
    public partial class View_list_playlist : UserControl
    {
        public event RoutedEventHandler CloseClick;
        public List<alta_class_playlist> playlist;
        public event RoutedEventHandler InsertEvent;
        public object UIControl;
        public View_list_playlist()
        {         
            InitializeComponent();
            this.Height = 663;
            this.Width = 1346;
            Canvas.SetLeft(this, 0);
            Canvas.SetLeft(this, 0);
            this.lb_data.IsSynchronizedWithCurrentItem = true;
            String sql_sort = " ORDER BY  `plan_name` ASC";
            playlist = new List<alta_class_playlist>();
            playlist = Mysql_helpper.mysql_alta_helpper.getListPlaylist(CommonUtilities.alta_curUser.alta_id, true, 0, CommonUtilities.num_item_in_page, sql_sort);
            this.lb_data.ItemsSource = playlist;
            
        }
        public void LoadData(alta_class_media media)
        {
            if (media != null)
                this.Tag = media;
        }

        private void btn_close_box_Click(object sender, RoutedEventArgs e)
        {
            if (CloseClick != null)
                CloseClick(this, new RoutedEventArgs());

        }
        public void Search_Completed(object sender, RoutedEventArgs e)
        {
            playlist = sender as List<alta_class_playlist>;           
            this.lb_data.ItemsSource = playlist;
        }
        private void btn_Select_Click(object sender, RoutedEventArgs e)
        {
            Button tmp = sender as Button;
            int alta_id =(int) tmp.Tag;
            alta_class_media media=this.Tag as alta_class_media;
            if (media != null)
                Mysql_helpper.mysql_alta_helpper.addMediaToPlaylist(media.alta_id, alta_id);
            if (InsertEvent != null)
                InsertEvent(this, new RoutedEventArgs());
            
        }
    }
}
