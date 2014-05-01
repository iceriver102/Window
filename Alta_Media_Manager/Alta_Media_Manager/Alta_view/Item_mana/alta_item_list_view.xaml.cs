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

namespace Alta_Media_Manager.Alta_view.Item_mana
{
    /// <summary>
    /// Interaction logic for alta_item_list_view.xaml
    /// </summary>
    public partial class alta_item_list_view : UserControl
    {
        public event RoutedEventHandler infoClick;
        public alta_item_list_view()
        {
            InitializeComponent();
        }
        public void LoadData(alta_class_playlist playlist)
        {            
            this.txt_name.Text = playlist.alta_name;
            alta_item_list_view tmp = new alta_item_list_view();
            this.btn_info.Tag = playlist;

        }

        private void ViewInfo_btn_Click(object sender, RoutedEventArgs e)
        {
            if (infoClick!=null)
            {
                infoClick(this.btn_info.Tag, new RoutedEventArgs());
            }
        }
    }
}
