using Alta_Media_Manager.Class;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Alta_Media_Manager.Alta_view
{
    /// <summary>
    /// Interaction logic for DateChooserControl.xaml
    /// </summary>
    public partial class DateChooserControl : UserControl
    {
        public object secondTag;
        public DateChooserControl()
        {
            InitializeComponent();
            this.Width = 1346;
            this.Height = 663;
            Canvas.SetLeft(this, -1370);
            Canvas.SetTop(this, 0);
            StaticFunction.aniMoveTo(this, 0, 0, 0.4, new PowerEase() { Power = 1.0, EasingMode = EasingMode.EaseInOut });
        }
        public event RoutedEventHandler CloseClick;
        public event RoutedEventHandler SaveClick;
        private void btn_close_click(object sender, RoutedEventArgs e)
        {
            if (CloseClick != null)
                CloseClick(this, new RoutedEventArgs());
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if(SaveClick!=null)
                SaveClick(this, new RoutedEventArgs());
        }
    }
}
