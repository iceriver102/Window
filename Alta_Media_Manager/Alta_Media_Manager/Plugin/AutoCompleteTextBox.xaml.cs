using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Alta_Media_Manager.Alta_view.Class;
using Alta_Media_Manager.Class;
using System.ComponentModel;
using System.Windows.Threading;
using Alta_Media_Manager.Alta_view.Mysql_helpper;


namespace Alta_Media_Manager.Plugin
{
    public partial class AutoCompleteTextBox : Canvas
    {
        #region Members
        private VisualCollection controls;
        private TextBox textBox;
       // private ComboBox comboBox;
        private ObservableCollection<alta_class_playlist> autoCompletionList;
        private System.Timers.Timer keypressTimer;
        private delegate void TextChangedCallback();
        private bool insertText;
        private int delayTime;
        private int searchThreshold;
        private BackgroundWorker bw;
        private int demoInt;
        private int totalPlaylist;
        public event RoutedEventHandler Compled;
        public String key;
        #endregion

        #region Constructor
        public AutoCompleteTextBox()
        {
            controls = new VisualCollection(this);
            InitializeComponent();            
            List_playlist = new List<alta_class_playlist>();
            demoInt = 0;
            autoCompletionList = new ObservableCollection<alta_class_playlist>();
            searchThreshold = 2;        // default threshold to 2 char

            // set up the key press timer
            keypressTimer = new System.Timers.Timer();
            keypressTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            sql_sort = " ORDER BY  `plan_name` ASC";

            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;

            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.DoWork += bw_DoWork;
           // Startup();

            // set up the text box and the combo box
           //  comboBox = new ComboBox();
           // comboBox.IsSynchronizedWithCurrentItem = true;
           // comboBox.IsTabStop = false;
            //comboBox.SelectionChanged += new SelectionChangedEventHandler(comboBox_SelectionChanged);

            textBox = new TextBox();
            
            textBox.VerticalContentAlignment = VerticalAlignment.Center;
            this.textBox.KeyUp += textBox_KeyUp;
            textBox.TextChanged += new TextChangedEventHandler(textBox_TextChanged);
          
            //controls.Add(comboBox);
            controls.Add(textBox);
        }

        void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !this.AutoSearch)
            {
                bw.CancelAsync();
                Startup();
            }
        }

        private void Startup()
        {
            if (!bw.IsBusy)
                bw.RunWorkerAsync();
            
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                   delegate()
                   {
                       key = this.Text;
                   }));
                this.List_playlist = mysql_alta_helpper.SearchPlaylist(ref this.totalPlaylist, key, 0, CommonUtilities.num_item_in_page, CommonUtilities.alta_curUser.alta_id, this.sql_sort,true);
            }
            catch (Exception)
            {

            }
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Compled != null)
            {
                Compled(this.List_playlist, new RoutedEventArgs());
            }
        }
        #endregion

        #region Methods

        public bool AutoSearch
        {
            get { return autosearch; }
            set { this.autosearch = value; }
        }
        public string Text
        {
            get { return textBox.Text; }
            set
            {
                insertText = true;
                textBox.Text = value;
            }
        }

        public int DelayTime
        {
            get { return delayTime; }
            set { delayTime = value; }
        }

        public int Threshold
        {
            get { return searchThreshold; }
            set { searchThreshold = value; }
        }

        public void AddItem(alta_class_playlist entry)
        {
            autoCompletionList.Add(entry);
        }
        

        //private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (null != comboBox.SelectedItem)
        //    {
        //        insertText = true;
        //        ComboBoxItem cbItem = (ComboBoxItem)comboBox.SelectedItem;
        //        textBox.Text = cbItem.Content.ToString();
        //    }
        //}

        private void TextChanged()
        {
            try
            {
               // comboBox.Items.Clear();
                if (textBox.Text.Length >= searchThreshold && this.AutoSearch)
                {
                    bw.CancelAsync();
                    Startup();
                    //foreach (alta_class_playlist entry in autoCompletionList)
                    //{
                    //    foreach (string word in entry.KeywordStrings)
                    //    {
                    //        if (word.StartsWith(textBox.Text, StringComparison.CurrentCultureIgnoreCase))
                    //        {
                    //            ComboBoxItem cbItem = new ComboBoxItem();
                    //            cbItem.Content = entry.ToString();
                    //            comboBox.Items.Add(cbItem);
                    //            break;
                    //        }
                    //    }
                    //}
                    //comboBox.IsDropDownOpen = comboBox.HasItems;
                }
                else
                {
                    //comboBox.IsDropDownOpen = false;
                }
            }
            catch { }
        }

        private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            keypressTimer.Stop();
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                new TextChangedCallback(this.TextChanged));
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // text was not typed, do nothing and consume the flag
            if (insertText == true) insertText = false;

            // if the delay time is set, delay handling of text changed
            else
            {
                if (delayTime > 0)
                {
                    keypressTimer.Interval = delayTime;
                    keypressTimer.Start();
                }
                else TextChanged();
            }
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            textBox.Arrange(new Rect(arrangeSize));          
            return base.ArrangeOverride(arrangeSize);
        }

        protected override Visual GetVisualChild(int index)
        {
            return controls[index];
        }

        protected override int VisualChildrenCount
        {
            get { return controls.Count; }
        }
        #endregion

        public string sql_sort { get; set; }
        public List<alta_class_playlist> List_playlist { get; set; }

        private bool autosearch;
    }
}
