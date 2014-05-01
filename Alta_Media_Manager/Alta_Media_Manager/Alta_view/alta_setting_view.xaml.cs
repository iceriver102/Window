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
    /// Interaction logic for alta_setting_view.xaml
    /// </summary>
    public partial class alta_setting_view : UserControl
    {
        public alta_setting_view()
        {
            InitializeComponent();
            Canvas.SetLeft(this, 0);
            Canvas.SetTop(this, 0);
            this.Width = 1346;
            this.Height = 663;
        }

        public void loadConfig()
        {
            this.txt_ftp_ip.Text = CommonUtilities.config.Ftp_Server;
            this.txt_ftp_user.Text = CommonUtilities.config.Ftp_user;
            this.txt_ftp_pass.Password = CommonUtilities.config.Ftp_pass;
            this.txt_ftp_root.Text = CommonUtilities.config.Ftp_root_path;
            this.txt_ftp_port.Text = CommonUtilities.config.Ftp_port;
            this.txt_ftp_time_out.Text = CommonUtilities.config.Ftp_TimeOut;

            this.txt_sql_db.Text = CommonUtilities.config.MySql_database;
            this.txt_sql_ip.Text = CommonUtilities.config.MySql_server;
            this.txt_sql_pass.Password = CommonUtilities.config.MySql_pass;
            this.txt_sql_port.Text = CommonUtilities.config.MySql_port;
            this.txt_sql_time.Text = CommonUtilities.config.MySql_timeOut;
            this.txt_sql_user.Text = CommonUtilities.config.MySql_user;

            this.txt_st_buffer.Text = CommonUtilities.config.buffer_Size.ToString();
            this.txt_st_name.Text = CommonUtilities.config.Stream_Sever;
            this.txt_st_port.Text = CommonUtilities.config.Outport_Stream.ToString();
            this.txt_timeout.Text = CommonUtilities.config.Time.ToString();

        }

        private void btn_save_streaming_click(object sender, RoutedEventArgs e)
        {
            CommonUtilities.config.buffer_Size = Convert.ToInt32(this.txt_st_buffer.Text.Trim());
            CommonUtilities.config.Stream_Sever=this.txt_st_name.Text.Trim();
            CommonUtilities.config.Outport_Stream=Convert.ToInt32(this.txt_st_port.Text.Trim());
            CommonUtilities.config.Time=Convert.ToInt32(this.txt_timeout.Text.Trim());
            FileOperations tmp = new FileOperations();
            tmp.wirteFile(CommonUtilities.config);
        }

        private void btn_click_ftp_server(object sender, RoutedEventArgs e)
        {
            CommonUtilities.config.Ftp_Server=this.txt_ftp_ip.Text.Trim();
            CommonUtilities.config.Ftp_user=this.txt_ftp_user.Text.Trim();
            CommonUtilities.config.Ftp_pass=this.txt_ftp_pass.Password;
            CommonUtilities.config.Ftp_root_path=this.txt_ftp_root.Text.Trim();
            CommonUtilities.config.Ftp_port=this.txt_ftp_port.Text.Trim();
            CommonUtilities.config.Ftp_TimeOut=this.txt_ftp_time_out.Text.Trim();
            FileOperations tmp = new FileOperations();
            tmp.wirteFile(CommonUtilities.config);
        }

        private void btn_Click_Mysql_save(object sender, RoutedEventArgs e)
        {
            CommonUtilities.config.MySql_database=this.txt_sql_db.Text;
            CommonUtilities.config.MySql_server=this.txt_sql_ip.Text;
            CommonUtilities.config.MySql_pass=this.txt_sql_pass.Password;
            CommonUtilities.config.MySql_port=this.txt_sql_port.Text;
            CommonUtilities.config.MySql_timeOut=this.txt_sql_time.Text;
            CommonUtilities.config.MySql_user=this.txt_sql_user.Text;
            FileOperations tmp = new FileOperations();
            tmp.wirteFile(CommonUtilities.config);
        }
    }
}
