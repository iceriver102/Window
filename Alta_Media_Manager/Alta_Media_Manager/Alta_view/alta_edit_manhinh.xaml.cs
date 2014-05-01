﻿using Alta_Media_Manager.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for alta_edit_manhinh.xaml
    /// </summary>
    public partial class alta_edit_manhinh : UserControl
    {
       
        public event RoutedEventHandler Close;
        public event RoutedEventHandler SaveData;
        private Thread query;
        public String txt_Title
        {
            get { return this.title_txt.Text; }
            set { this.title_txt.Text = value; }
        }
        public alta_edit_manhinh()
        {
            InitializeComponent();
            flagMysql = true;
            Canvas.SetLeft(this, 0);
            Canvas.SetTop(this, 0);
            this.Opacity = 0;
            List<Class.alta_class_terminal_type> listcb = Mysql_helpper.mysql_alta_helpper.getListTypeTerminal();
            cb_type_terminal.ItemsSource = listcb;
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
            String passMD5="";
            Class.alta_class_termiral termiral = (Class.alta_class_termiral)this.Tag;
            if (txt_file.Text == string.Empty && termiral == null)
            {
                MessageBox.Show("Hãy nhập Ip màn hình");
                return;
            }
            if (txt_name.Text == string.Empty)
            {
                MessageBox.Show("Hãy điền tên màn hình");
                return;
            }
            if (txt_Pass_Old.Password == String.Empty)
            {
                MessageBox.Show("Hãy nhập mật khẩu của màn hình");
                return;
            }
            
            if (txt_Pass_retype.Password != txt_Pass.Password && txt_Pass.Password!=String.Empty)
            {
                MessageBox.Show("Mật khẩu không khớp nhau hãy kiểm tra lại");
                return;
            }
            using (MD5 md5Hash = MD5.Create())
            {
                passMD5 = CommonUtilities.GetMd5Hash(md5Hash, txt_Pass_Old.Password);
            }
            if (passMD5 != termiral.alta_pass && termiral != null)
            {
                MessageBox.Show("Mật khẩu không đúng nhập lại mật khẩu của màn hình");
                return;
            }
            if (termiral == null)
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
                               string insert_query = "INSERT INTO `am_termiral`(`termiral_name`, `termiral_ip`, `termiral_content`, `termiral_status`,`termiral_pass`) VALUES (@termiral_name,@termiral_ip,@termiral_content,1,MD5(@pass))";
                               using (MySqlCommand cmd = new MySqlCommand(insert_query, conn))
                               {
                                   cmd.Parameters.AddWithValue("@termiral_name", txt_name.Text.Trim());
                                   cmd.Parameters.AddWithValue("@termiral_ip", txt_file.Text);
                                   cmd.Parameters.AddWithValue("@termiral_content", txt_content.Text.Trim());
                                   cmd.Parameters.AddWithValue("@pass", txt_Pass.Password);
                                   //cmd.Parameters.AddWithValue("@mota", txt_content.Text.Trim());
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
                            Class.alta_class_termiral Termiral = (Class.alta_class_termiral)this.Tag;
                            using (MySqlConnection conn = new MySqlConnection(CommonUtilities.config.getConnectionString()))
                            {
                                string insert_query = "";
                                conn.Open();
                                if (this.txt_Pass.Password == String.Empty) {
                                    insert_query = "UPDATE `am_termiral` SET `terminal_type_id`=@type, `termiral_name`=@name,`termiral_ip`=@localtion,`termiral_content`=@mota WHERE `termiral_id`=@termiral_id and termiral_pass=MD5(@old_Pass)";
                                }
                                else
                                {
                                    insert_query = "UPDATE `am_termiral` SET `terminal_type_id`=@type, `termiral_name`=@name,`termiral_ip`=@localtion,`termiral_content`=@mota, `termiral_pass`=@pass WHERE `termiral_id`=@termiral_id and termiral_pass=MD5(@old_Pass)";
                                }
                                using (MySqlCommand cmd = new MySqlCommand(insert_query, conn))
                                {
                                    cmd.Parameters.AddWithValue("@name", txt_name.Text);
                                    cmd.Parameters.AddWithValue("@localtion", txt_file.Text);
                                    cmd.Parameters.AddWithValue("@termiral_id", Termiral.alta_id);
                                    cmd.Parameters.AddWithValue("@mota", txt_content.Text);
                                    if (this.txt_Pass.Password != String.Empty)
                                        cmd.Parameters.AddWithValue("@pass", txt_Pass.Password);
                                    cmd.Parameters.AddWithValue("@old_Pass", txt_Pass_Old.Password);
                                    cmd.Parameters.AddWithValue("@type", (cb_type_terminal.SelectedItem as Class.alta_class_terminal_type).alta_id);
                                    cmd.ExecuteNonQuery();
                                    this.flagMysql = false;
                                }
                                conn.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            this.flagMysql = false;
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

        public void LoadData(Class.alta_class_termiral data)
        {
            if (data != null)
            {
                this.flag_edit = true;
                this.Tag = data;
                this.txt_name.Text = data.alta_name;
                this.txt_file.Text = data.alta_ip;
                this.txt_content.Text = data.alta_content;
                int count =this.cb_type_terminal.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    Class.alta_class_terminal_type type=this.cb_type_terminal.Items[i] as Class.alta_class_terminal_type;
                    if (type.alta_id == data.alta_type.alta_id)
                        this.cb_type_terminal.SelectedIndex = i;
                }
                  //  this.cb_type_terminal.SelectedItem = data.alta_type;
            }
        }
        public bool flag_edit { get; set; }
        public bool flagMysql { get; set; }
    }
}
