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
using Alta_Media_Manager.Alta_view.Class;
using System.Windows.Threading;



namespace Alta_Media_Manager.Alta_view.Item_mana
{
    /// <summary>
    /// Interaction logic for Item_Media.xaml
    /// </summary>
    public partial class Item_Media : UserControl
    {
        public Item_Media()
        {
            InitializeComponent();            
        }
        public void LoadData(alta_class_media media,List<alta_class_playlist> list)
        {
            this.Tag = media;
            this.txt_alta_name.Text = media.alta_name;
            this.txt_alta_url.Text = media.alta_url.Substring(9);
            this.txt_alta_date.Text = String.Format("{0:HH:mm dd/MM/yyyy}", media.alta_media_time);
            this.txt_alta_userCreate.Tag = media.alta_user;
            this.txt_alta_userCreate.Text = media.alta_user.alta_full_name;
            int count=list.Count;
            if (count < 1)
            {
                list_playlist.Visibility = Visibility.Hidden;
                return;
            }
            list_playlist.Visibility = Visibility.Visible;
            if (count < 3)
            {
                txt_link_more.Visibility = Visibility.Hidden;
            }
            else
            {
                txt_link_more.Visibility = Visibility.Visible;
            }
            for (int i = 0; i < count && i < 3; i++)
            {
                TextBlock tmp = new TextBlock();
                tmp.HorizontalAlignment = HorizontalAlignment.Stretch;
                tmp.VerticalAlignment = VerticalAlignment.Top;
                tmp.Margin = new Thickness(0, 5, 0, 0);
                tmp.TextAlignment = TextAlignment.Left;
                tmp.Foreground = Brushes.WhiteSmoke;
                tmp.FontSize = 13;
                tmp.Text = list[i].alta_name;
                this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                   delegate()
                   {
                       this.list_playlist.Children.Add(tmp);
                   }));
            }
            
        }

        private void Mouse_Enter(object sender, MouseEventArgs e)
        {

            border_out.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 255,177,10));
        }

        private void Mouse_Lease(object sender, MouseEventArgs e)
        {
            border_out.BorderBrush = Brushes.Transparent;
        }

        
    }
}
