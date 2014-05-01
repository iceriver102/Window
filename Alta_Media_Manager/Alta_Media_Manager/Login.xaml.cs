using Alta_Media_Manager.Alta_view.Mysql_helpper;
using Alta_Media_Manager.Class;
using Alta_Media_Manager.View;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace Alta_Media_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
      //  public Configuration conf;
        public Login()
        {
            InitializeComponent();
           // conf = new Configuration();            
            fixResoulution();
            LoadConfig();
        }
        private void fixResoulution()
        {
            CommonUtilities.width = this.Width;
            CommonUtilities.height = this.Height;
            Size scale = CommonUtilities.getScaleSize();
            ScaleTransform s = new ScaleTransform(scale.Width, scale.Height);
            mainLayout.RenderTransform = s;
        }
        private void LoadConfig()
        {
            try
            {
                if (File.Exists(CommonUtilities.config.ConfigFileName))
                {
                    FileOperations tmp = new FileOperations();
                    CommonUtilities.config = tmp.readFile(CommonUtilities.config.ConfigFileName);
                }
                          
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                CommonUtilities.config = CommonUtilities.config.LoadXML();
            }
        }
        private void ShowAlert(String msg = "")
        {
            this.txt_msg.Text = msg;
        }

        private void LoginBtn(object sender, RoutedEventArgs e)
        {
            submitData();         
        }
        private void Key_Up(object sender, KeyEventArgs e)
        {
            if (Key.Enter == e.Key)
            {
                submitData();
            }
        }

        private void submitData()
        {
            if (txt_user.Text == String.Empty)
            {
                ShowAlert("Hãy nhập tên đăng nhập!");
                return;
            };
            if (txt_pass.Password == String.Empty)
            {
                ShowAlert("Hãy nhập mật khẩu đăng nhập!");
                return;
            };
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                {
                    conn.Open();
                    string query =" SELECT `user_id`, `username`, `user_pass`, `full_name`, `user_type_id`, `user_status` FROM `am_user` ";
                    query += "WHERE `username`=@name_user and `user_pass`=MD5(@pass_user) and `user_status`=1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name_user", txt_user.Text);
                        cmd.Parameters.AddWithValue("@pass_user", txt_pass.Password);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) != 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                CommonUtilities.alta_curUser = mysql_alta_helpper.getUser(reader);
                            };
                            if (CommonUtilities.alta_curUser.alta_id != 0)
                            {
                                Window_Main Main = new Window_Main();
                                Main.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
                            }
                            
                        }
                    };
                };
            }
            catch (Exception ex)
            {

            }

        }

        private void WindowMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void WindowClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSetting(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                View_setting_mysql viewDataSetting = new View_setting_mysql();
                viewDataSetting.Show();
                this.Hide();
            }
        }
    }
}
