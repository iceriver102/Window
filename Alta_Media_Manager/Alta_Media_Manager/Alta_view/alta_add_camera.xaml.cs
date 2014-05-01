using Alta_Media_Manager.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for alta_add_camera.xaml
    /// </summary>
    public partial class alta_add_camera : UserControl
    {
        public event RoutedEventHandler Close;
        public event RoutedEventHandler SaveData;
        private Thread query;
        public String txt_Title
        {
            get { return this.title_txt.Text; }
            set { this.title_txt.Text = value; }
        }
        public alta_add_camera()
        {
            InitializeComponent();
            flagMysql = true;
            Canvas.SetLeft(this, 0);
            Canvas.SetTop(this, 0);
            this.Opacity = 0;
            StaticFunction.aniChangeOpacity(this, 1, 0.4);
        }
        private void close_dialog(object sender, MouseButtonEventArgs e)
        {
            Video_Closed();
        }
        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Video_Closed();
        }
        void Video_Closed()
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
        private void btn_save_click(object sender, RoutedEventArgs e)
        {
            Class.alta_class_media video = (Class.alta_class_media)this.Tag;
            if (txt_file.Text == string.Empty && video == null)
            {
                MessageBox.Show("Hãy nhập url camera muốn tạo");
                return;
            }
            if (txt_name.Text == string.Empty)
            {
                MessageBox.Show("Hãy điền tên camera");
                return;
            }
            if (video == null)
            {
                query = new Thread(insertQuery);
                query.IsBackground = true;
                query.Start();
            }
            else
            {
                query = new Thread(UpdateQuery);
                query.IsBackground = true;
                query.Start();
            }

        }
        private void UpdateQuery()
        {
            while (true)
            {
                Msql_Update();
                Thread.Sleep(80);
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
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
               delegate()
               {
                   if (this.flagMysql)
                   {
                       try
                       {
                           using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                           {
                               conn.Open();
                               string insert_query = "INSERT INTO `am_media`( `media_name`, `media_url`, `media_content`, `media_type_id`, `user_id`) VALUES (@name,@localtion,@mota,2,@id_user)";
                               using (MySqlCommand cmd = new MySqlCommand(insert_query, conn))
                               {
                                   cmd.Parameters.AddWithValue("@name", txt_name.Text.Trim());
                                   cmd.Parameters.AddWithValue("@localtion", txt_file.Text);
                                   cmd.Parameters.AddWithValue("@id_user", CommonUtilities.alta_curUser.alta_id);
                                   cmd.Parameters.AddWithValue("@mota", txt_content.Text.Trim());
                                   cmd.ExecuteNonQuery();
                                   this.flagMysql = false;
                               }
                               conn.Close();
                           }
                       }
                       catch (Exception)
                       {

                       }
                   }
                   else if (this.flagMysql == false)
                   {
                       //query.Abort();
                       Video_Closed();
                   }
               }));

        }
        private void Msql_Update()
        {
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                delegate()
                {
                    if (this.flagMysql)
                    {
                        try
                        {
                            Class.alta_class_media media = (Class.alta_class_media)this.Tag;
                            using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                            {
                                conn.Open();
                                string insert_query = "UPDATE `am_media` SET `media_name`=@name,`media_url`=@localtion,`media_content`=@mota WHERE `media_id`=@id_video";
                                using (MySqlCommand cmd = new MySqlCommand(insert_query, conn))
                                {
                                    cmd.Parameters.AddWithValue("@name", txt_name.Text);
                                    cmd.Parameters.AddWithValue("@localtion", txt_file.Text);
                                    cmd.Parameters.AddWithValue("@id_video", media.alta_id);
                                    cmd.Parameters.AddWithValue("@mota", txt_content.Text);
                                    cmd.ExecuteNonQuery();
                                    this.flagMysql = false;
                                }
                                conn.Close();
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                    else if (this.flagMysql == false)
                    {

                        this.Video_Closed();
                    }
                }));
        }
       


        private void Hide_View_Click(object sender, MouseButtonEventArgs e)
        {
            Video_Closed();
        }

        private void nothing_click(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        public void LoadData(Class.alta_class_media media)
        {
            if (media != null)
            {
                this.flag_edit = true;
                this.Tag = media;
                this.txt_name.Text = media.alta_name;
                this.txt_file.Text = media.alta_url;
                this.txt_content.Text = media.alta_content;
            }
        }
        public bool flag_edit { get; set; }
        public bool flagMysql { get; set; }
    }
}
