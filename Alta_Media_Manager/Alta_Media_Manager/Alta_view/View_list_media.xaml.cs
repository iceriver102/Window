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
using Alta_Media_Manager.Class;
using System.ComponentModel;
using System.Windows.Threading;
using Alta_Media_Manager.Alta_view.Item_mana;

namespace Alta_Media_Manager.Alta_view
{
    /// <summary>
    /// Interaction logic for View_list_media.xaml
    /// </summary>
    public partial class View_list_media : UserControl
    {
        public event RoutedEventHandler CloseClick;
        public List<alta_class_media> list_media;
        public event RoutedEventHandler InsertEvent;
        private bool _showaction;
        public bool ShowAction { get { return _showaction; } set { _showaction = value; if (_showaction) this.btnAction.Visibility = Visibility.Visible; else { this.btnAction.Visibility = Visibility.Hidden; } } }
        public object UIControl;
        int total = 0;
        BackgroundWorker bw;
        String sql_sort = " ORDER BY  `media_name` ASC";
        public View_list_media()
        {
            InitializeComponent();
            ShowAction = true;
            this.Height = 663;
            this.Width = 1346;
            Canvas.SetLeft(this, 0);
            Canvas.SetLeft(this, 0);
            this.lb_data.IsSynchronizedWithCurrentItem = true;
            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            this.lb_data.ItemsSource = list_media;
            list_media = new List<alta_class_media>();
            Startup();

        }

        private void Startup()
        {
            if (!bw.IsBusy)
                bw.RunWorkerAsync();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadView(this.list_media);
            // this.List_media = mysql_alta_helpper.getListMedia(ref this.totalmedia, this.sql_sort, -1, type_video, false, CommonUtilities.num_item_in_page * pageMedia, CommonUtilities.num_item_in_page);

        }
        void LoadView(List<alta_class_media> list_media)
        {
            alta_class_playlist playlist = this.Tag as alta_class_playlist;
            playlist.LoadDetails();            
            int count = list_media.Count;
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                    delegate()
                    {
                        this.lb_data.Items.Clear();
                    }));
            if (count > 0)
            {
                this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                      delegate()
                      {
                          for (int i = 0; i < count; i++)
                          {
                              list_media[i].alta_user = CommonUtilities.alta_curUser;
                              Item_media_select item = new Item_media_select();
                              if (playlist != null)
                              {
                                  if (!kiemtratontai(list_media[i], playlist.alta_details))
                                  {

                                      item.LoadData(this.list_media[i], false);
                                  }
                                  else
                                  {
                                      item.LoadData(this.list_media[i], true);
                                  }
                              }
                              else
                              {
                                  item.LoadData(this.list_media[i], false);
                              }

                              item.AddMediaToPlaylist += item_AddMediaToPlaylist;
                              item.ItemDoubleClick += item_ItemDoubleClick;
                              this.lb_data.Items.Add(item);
                          }
                      }));
            }
        }

        private void item_ItemDoubleClick(object sender, alta_class_media e)
        {
            ItemDoubleClick(this, e);
        }

       
        public event EventHandler<alta_class_media> ItemDoubleClick;

        void item_AddMediaToPlaylist(object sender, RoutedEventArgs e)
        {
            alta_class_media media = sender as alta_class_media;
            selectMedia(media);
        }
        void selectMedia(alta_class_media media)
        {
            if (media != null && this.list_media != null)
            {
                int count = this.list_media.Count;
                for (int i = 0; i < count; i++)
                {
                    if (this.list_media[i].alta_id == media.alta_id)
                    {
                        this.list_media[i].isSelect = media.isSelect;
                        return;
                    }
                }
            }
            //if(this.list_media_se !=null)
        }
        void dongbo()
        {
            if (this.list_media != null)
            {
                int count = this.list_media_search.Count;
                int countItem = this.list_media.Count;
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < countItem; j++)
                    {
                        if (this.list_media_search[i].alta_id == this.list_media[j].alta_id)
                        {
                            this.list_media_search[i].isSelect = this.list_media[j].isSelect;
                        }
                    }
                }
                   
            }
        }
        private bool kiemtratontai(alta_class_media media, List<alta_class_playlist_details> list)
        {
            if (list == null || media == null)
                return false;
            int count = list.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (list[i].alta_media.alta_id == media.alta_id)
                    {
                        return true;
                    }
                }
            }
           
            return false;
        }
        bool kiemtratontai(alta_class_media media, List<alta_class_media> listMedia)
        {
            int count = listMedia.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (listMedia[i].alta_id == media.alta_id)
                    {
                        return true;
                    }
                }
            }
          

            return false;

        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            list_media = Mysql_helpper.mysql_alta_helpper.getListMedia(ref total, sql_sort, CommonUtilities.alta_curUser.alta_id, -1, true, -1, -1);
        }
        public void LoadData(alta_class_playlist playlist)
        {
            if (playlist != null)
                this.Tag = playlist;
        }

        private void btn_close_box_Click(object sender, RoutedEventArgs e)
        {
            if (CloseClick != null)
                CloseClick(this, new RoutedEventArgs());

        }
        public void Search_Completed(object sender, RoutedEventArgs e)
        {
            list_media_search = sender as List<alta_class_media>;
            dongbo();
            LoadView(list_media_search);
        }
        public void ReLoad_Data(object sender, RoutedEventArgs e)
        {
            LoadView(this.list_media);
        }
        private void btn_Select_Click(object sender, RoutedEventArgs e)
        {
            Button tmp = sender as Button;
            int alta_id = (int)tmp.Tag;
            alta_class_media media = this.Tag as alta_class_media;
            if (media != null)
                Mysql_helpper.mysql_alta_helpper.addMediaToPlaylist(media.alta_id, alta_id);
            if (InsertEvent != null)
                InsertEvent(this, new RoutedEventArgs());

        }

        private void btnRefreshData(object sender, RoutedEventArgs e)
        {
            this.txt_Search.Text = "";
            this.Startup();
        }

        public List<alta_class_media> list_media_search { get; set; }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            if(this.list_media==null)
                return;
            alta_class_playlist playlist = this.Tag as alta_class_playlist;
            if(playlist==null)
                return;
            int count = this.list_media.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.list_media[i].isSelect)
                {
                    Mysql_helpper.mysql_alta_helpper.addMediaToPlaylist(this.list_media[i].alta_id, playlist.alta_id);
                }
            }
            if (InsertEvent != null)
                InsertEvent(this, new RoutedEventArgs());
          
        }
    }
}
