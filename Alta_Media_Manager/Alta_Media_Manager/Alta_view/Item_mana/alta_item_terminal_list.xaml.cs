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
    /// Interaction logic for alta_item_terminal_list.xaml
    /// </summary>
    public partial class alta_item_terminal_list : UserControl
    {
        public alta_item_terminal_list()
        {
            InitializeComponent();
        }
        public void LoadData(alta_class_termiral terminal)
        {
            if(terminal!=null)
            {
                this.Tag = terminal;
                this.lb_name.Content = terminal.alta_name;
            }
        }
    }
}
