using Alta_Media_Manager.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Alta_Media_Manager.Alta_view
{
    /// <summary>
    /// Interaction logic for add_user_view.xaml
    /// </summary>
    public partial class add_user_view : UserControl
    {
        public event RoutedEventHandler Close;
        public event RoutedEventHandler SaveData;
        private Thread query;
        public object UIControl;
        public bool checkPass;
        public String txt_Title
        {
            get { return this.title_txt.Text; }
            set { this.title_txt.Text = value; }
        }
        public add_user_view()
        {
            InitializeComponent();
            List<Class.alta_class_user_type> list_type_user = Mysql_helpper.mysql_alta_helpper.getListTypeUser();
            cb_type_user.ItemsSource = list_type_user;
            flagMysql = true;
            Canvas.SetLeft(this, 0);
            Canvas.SetTop(this, 0);
            this.Opacity = 0;
            StaticFunction.aniChangeOpacity(this, 1, 0.4);
            checkPass = true;
            this.cb_type_user.SelectedIndex = 1;
        }

        public void loadData(Class.alta_class_user data,bool flag=false)
        {
            if (data != null)
            {
                this.Tag = data;
                this.txt_email.Text = data.alta_email;
                this.txt_name.Text = data.alta_full_name;
                this.txt_username.Text = data.alta_username;
                this.txt_username.IsEnabled = false;
                this.txt_pass.IsEnabled = flag;
                checkPass = flag;
                this.txt_phone.Text = data.alta_phone;
                for (int i = 0; i < this.cb_type_user.Items.Count; i++)
                {
                    Class.alta_class_user_type type=this.cb_type_user.Items[i] as Class.alta_class_user_type;
                    if (type.alta_id == data.alta_type_user.alta_id)
                    {
                        this.cb_type_user.SelectedIndex = i;
                        break;
                    }
                }
                if (CommonUtilities.alta_curUser.alta_type_user.alta_permision != 2)
                {
                    this.cb_type_user.IsEnabled = false;
                }
                else
                {
                    this.cb_type_user.IsEnabled = true;
                }               
            }
        }
        private void btn_save_click(object sender, RoutedEventArgs e)
        {

            Class.alta_class_user user = this.Tag as Class.alta_class_user;
            if (this.txt_name.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Hãy nhập tên của user");
                return;
            }
            if (this.txt_username.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Hãy nhập tên đăng nhập của user");
                return;
            }
            if (this.txt_pass.Password.Length < 6 && checkPass)
            {
                MessageBox.Show("Mật khẩu phải trên 6 ký tự.");
                return;
            }
            if (user == null)
            {
                if (query == null || query.IsAlive == false)
                {
                    flagMysql = true;
                    query = new Thread(insertQuery);
                    query.IsBackground = true;
                    query.Start();
                }
            }
            else
            {
                if (query == null || query.IsAlive == false)
                {
                    query = new Thread(UpdateQuery);
                    query.IsBackground = true;
                    query.Start();
                }
            }
        }
        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Window_Closed();
        }

        void Window_Closed()
        {
            // Window1.flag_Window_Enabled = true;
            try
            {
                if (query.IsAlive)
                    query.Abort();
                query = null;
            }
            catch (Exception)
            {
            }
            if (this.Close != null)
                this.Close(this, new RoutedEventArgs());
            if (!flagMysql && SaveData != null)
                SaveData(this, new RoutedEventArgs());
        }

        private void UpdateQuery()
        {
            while (true)
            {
                Msql_Update();
                Thread.Sleep(80);
            }
        }

        private void Msql_Update()
        {
            if (flagMysql)
            {
                String _query = "UPDATE `am_user` SET `full_name`=@full_name,`user_email`=@user_email,`user_phone`=@user_phone,`user_type_id`=@type_id";
                    if(checkPass){
                        _query+=",`user_pass`=@user_pass";
                    }
                    _query+=" WHERE `user_id`=@user_id";
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                    {
                        conn.Open();
                        Class.alta_class_user_type type = new Class.alta_class_user_type();
                        using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                        {
                            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                              delegate()
                              {
                                  Class.alta_class_user user =this.Tag as Class.alta_class_user;
                                  type = this.cb_type_user.SelectedItem as Class.alta_class_user_type;
                                  cmd.Parameters.AddWithValue("@user_id", user.alta_id);
                                  //cmd.Parameters.AddWithValue("@user_name", this.txt_username.Text.Trim());
                                  if(checkPass){
                                    cmd.Parameters.AddWithValue("@user_pass", this.txt_pass.Password);
                                  }
                                  cmd.Parameters.AddWithValue("@full_name", this.txt_name.Text.Trim());
                                  cmd.Parameters.AddWithValue("@user_email", this.txt_email.Text.Trim());
                                  cmd.Parameters.AddWithValue("@user_phone", this.txt_phone.Text.Trim());
                                  if (type == null)
                                  {
                                      query.Abort();
                                  }
                                  cmd.Parameters.AddWithValue("@type_id", type.alta_id);
                              }));
                            var tmp = cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                    //  return true;
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.Message);
#endif
                }
                flagMysql = false;
                if (SaveData != null)
                {
                    SaveData(this, new RoutedEventArgs());
                }
                query.Abort();
                // return false;
            }
        }
        private void insertQuery()
        {
            while (true)
            {
                Mysql_Query();
                Thread.Sleep(80);
            }
        }

        private void Mysql_Query()
        {
            if (flagMysql)
            {
                String _query = "INSERT INTO `am_user`(`username`, `user_pass`, `full_name`, `user_email`, `user_phone`, `user_type_id`) VALUES (@user_name,MD5(@user_pass),@full_name,@user_email,@user_phone,@type_id);";
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                    {
                        conn.Open();
                        Class.alta_class_user_type type= new Class.alta_class_user_type();
                        using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                        {
                            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                              delegate()
                              {
                                    type = this.cb_type_user.SelectedItem as Class.alta_class_user_type;
                             
                                    cmd.Parameters.AddWithValue("@user_name", this.txt_username.Text.Trim());
                                    cmd.Parameters.AddWithValue("@user_pass", this.txt_pass.Password);
                                    cmd.Parameters.AddWithValue("@full_name", this.txt_name.Text.Trim());
                                    cmd.Parameters.AddWithValue("@user_email", this.txt_email.Text.Trim());
                                    cmd.Parameters.AddWithValue("@user_phone", this.txt_phone.Text.Trim());
                                    if (type == null)
                                    {
                                        query.Abort();                                       
                                    }
                                    cmd.Parameters.AddWithValue("@type_id", type.alta_id);
                              }));
                            var tmp = cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                  //  return true;
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.Message);
#endif
                }
                flagMysql = false;                
                if (SaveData != null)
                {
                    SaveData(this, new RoutedEventArgs());
                }
                query.Abort();
               // return false;
            }
        }
        public bool flagMysql { get; set; }

        private void Hide_View_Click(object sender, MouseButtonEventArgs e)
        {
            Window_Closed();
        }

        private void nothing_click(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

     
    }
}
