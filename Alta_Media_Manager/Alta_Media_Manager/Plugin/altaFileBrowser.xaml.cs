using Microsoft.Win32;
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

namespace Alta_Media_Manager.Plugin
{
    /// <summary>
    /// Interaction logic for altaFileBrowser.xaml
    /// </summary>
    public partial class altaFileBrowser : UserControl
    {
        public String Text { get { return txtFile.Text.Trim(); } set { this.txtFile.Text = value; } }
        public altaFileBrowser()
        {
            InitializeComponent();
        }
        private void Browser_Click_btn(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a Video";
            op.Filter = "Video File(*.mov,*.wmv,*.avi,*.mp4,*.mpg,*.flv,*.h264,*.wp3)|*.mov;*.wmv;*.avi;*.mp4;*.mpg;*.flv;*.h264;*.wp3|" +
                "All type(*.*)|*.*";
            if (op.ShowDialog() == true)
            {
                txtFile.Text = op.FileName;
                Text = op.FileName;
            }
        }
    }
}
