
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Alta_Media_Manager.Item_UC
{
    /// <summary>
    /// Interaction logic for Item_Menu.xaml
    /// </summary>
    public partial class Item_Menu : UserControl
    {
        private string SourceProperty;
        private bool showProperty;
        private bool select = false;
        private String TextProperty;
        public String Text_display { get { return TextProperty; } set { TextProperty=value; } }
        private double h, w;
        public bool Show
        {
            get { return showProperty; }
            set
            {
                if (value) { this.Visibility = Visibility.Visible; StaticFunction.aniChangeOpacity(this, 1, 0.3); }
                else { this.Visibility = Visibility.Visible; StaticFunction.aniChangeOpacity(this, 0, 0.3); }
                this.showProperty = value;
            }
        }
        // private static DependencyProperty TooltipProperty;
        public Item_Menu()
        {
            InitializeComponent();
            //TooltipProperty = DependencyProperty.Register("Tooltip", typeof(string), typeof(Item_Menu));
        }
        public event RoutedEventHandler ItemClick;
        public String Source
        {
            get { return (string)SourceProperty; }
            set { SourceProperty = value; }
        }
        private void ZoomOut(object sender, MouseEventArgs e)
        {
            if (!this.select)
            {
                StaticFunction.aniScaleImage(this.imgItem, 0.5, 0.5, 1.3, 1.3, 0.7, null);
                shadow.Visibility = Visibility.Visible;
                //content.Effect = blur;
            }

        }

        private void LeftClick(object sender, MouseButtonEventArgs e)
        {
            if (ItemClick != null)
            {
                ItemClick(this, new RoutedEventArgs());
            }
        }
        private void ZoomIn(object sender, MouseEventArgs e)
        {
            StaticFunction.resetScaleImage(this.imgItem, 0.5, 0.5);
            shadow.Visibility = Visibility.Hidden;
        }
    }
}
