using Alta_Media_Manager.Alta_view.Mysql_helpper;
using Alta_Media_Manager.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Alta_Media_Player
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            fixResoulution();
            LoadConfig();
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
                else
                {
                    FileOperations tmp = new FileOperations();
                    tmp.wirteFile(CommonUtilities.config);
                }

            }
            catch (Exception ex)
            {
                CommonUtilities.config = CommonUtilities.config.LoadXML();
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }
        private void fixResoulution()
        {
            CommonUtilities.width = this.Width;
            CommonUtilities.height = this.Height;
            Size scale = CommonUtilities.getScaleSize();
            ScaleTransform s = new ScaleTransform(scale.Width, scale.Height);
            this.mainLayout.RenderTransform = s;
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
        public bool IsValidIp(string addr)
        {
            IPAddress ip;
            bool valid = !string.IsNullOrEmpty(addr) && IPAddress.TryParse(addr, out ip);
            return valid;
        }
        private void submitData()
        {
            if (txt_user.Text == String.Empty)
            {
                ShowAlert("Hãy nhập IP của màn hình!");
                return;
            };
            if(!IsValidIp(txt_user.Text.Trim()))
            {
                ShowAlert("IP không đúng định dạng");
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
                    string query = "SELECT `termiral_id`, `termiral_name`, `termiral_ip`, `termiral_content`, `termiral_status`, `termiral_pass` FROM `am_termiral` ";
                    query += "WHERE `termiral_ip`=@termiral_ip and `termiral_pass`=MD5(@termiral_pass) and `termiral_status`=1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@termiral_ip", txt_user.Text);
                        cmd.Parameters.AddWithValue("@termiral_pass", txt_pass.Password);
                        var tmp = cmd.ExecuteScalar();
                        if (Convert.ToInt32(tmp) != 0)
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                CommonUtilities.This = mysql_alta_helpper.getTermiral(reader);
                            };
                            if (CommonUtilities.This.alta_id != 0)
                            {
                                CommonUtilities.id_termiral = CommonUtilities.This.alta_id;
                                MainWindow Main = new MainWindow();
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
        private void WindowClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Size_Change(object sender, SizeChangedEventArgs e)
        {
            fixResoulution();
        }
    }
}
