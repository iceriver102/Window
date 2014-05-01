using Alta_Media_Manager.Alta_view.Class;
using Alta_Media_Manager.Alta_view.Item_mana;
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
    /// Interaction logic for alta_load_playlist_of_media.xaml
    /// </summary>
    public partial class alta_load_playlist_of_media : UserControl
    {
        public event RoutedEventHandler HideViewClick;
        public event RoutedEventHandler ViewItemClick;
        public alta_load_playlist_of_media()
        {
            InitializeComponent();
            Canvas.SetLeft(this, 0);
            Canvas.SetTop(this, 0);
            this.Width = 1346;
            this.Height = 693;
        }
        public void LoadItem(List<alta_class_playlist> list_playlist)
        {
            int count = list_playlist.Count;
            for (int i = 0; i < count; i++)
            {
                alta_item_list_view tmp = new alta_item_list_view();
                tmp.Width = 388;
                tmp.Height = 26;
                tmp.LoadData(list_playlist[i]);
                tmp.infoClick += tmp_infoClick;
                List_view_playlist.Items.Add(tmp);
            }
        }

        void tmp_infoClick(object sender, RoutedEventArgs e)
        {
            alta_class_playlist playlist = sender as alta_class_playlist;
            if (ViewItemClick != null)
                ViewItemClick(playlist, new RoutedEventArgs());
        }
       

        private void Hide_View_Click(object sender, MouseButtonEventArgs e)
        {
            if (HideViewClick != null)
                HideViewClick(this, new RoutedEventArgs());
        }

        private void nothing_click(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            return;
        }
       
    }
}
