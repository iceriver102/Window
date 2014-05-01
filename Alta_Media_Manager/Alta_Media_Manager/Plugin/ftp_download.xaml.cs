using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Alta_Media_Manager.Class;
using System.IO;

namespace Alta_Media_Manager.Plugin
{
    /// <summary>
    /// Interaction logic for ftp_upload.xaml
    /// </summary>
    public partial class ftp_download : UserControl
    {
        private BackgroundWorker bw = new BackgroundWorker();
        public static DependencyProperty PercentProperty;
        private bool _isCompleted;
        public bool isCompleted { 
            get { return _isCompleted;}
            private set
            {
                _isCompleted = value;
                if (value && Completed != null)
                    Completed(this, new EventArgs());
            }
        }
        private string _source;
        public static String DefaultPath = @"tmp";
        public event EventHandler Completed;
        public string Source
        {
            get { return _source; }
            private set
            {
                _source = value;
                if (!File.Exists(value))
                {
                    Start();
                }
                else
                {
                    isCompleted = true;
                }
            }
        }
        public double Percent;
        public static string file = "";

        public double WidthUC
        {
            get { return (double)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); this.Width = value; }
        }
        public double HeightUC
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); this.Height = value; }
        }
        private String _ftpPath;
        public string FtpPath
        {
            get { return _ftpPath; }
            set
            {
                _ftpPath = value;
                string[] expode = _ftpPath.Split(new char[] { '/', '\\' });
                string fileName = expode[expode.Length - 1];
                Source = DefaultPath + @"\" + fileName;
            }
        }
        public ftp_download()
        {
            try
            {
                PercentProperty = DependencyProperty.Register("Percent", typeof(double), typeof(ftp_upload));
            }
            catch (Exception)
            {
            }
            InitializeComponent();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            isCompleted = false;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {

            }
            else if (!(e.Error == null))
            {

            }
            else
            {
                isCompleted = true;
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progress.Value = (e.ProgressPercentage);
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker worker = sender as BackgroundWorker;
                var ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(CommonUtilities.config.Ftp_Server + FtpPath));
                ftpWebRequest.Credentials = new NetworkCredential(CommonUtilities.config.Ftp_user, CommonUtilities.config.Ftp_pass);
                ftpWebRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                FileInfo fileInfo = new FileInfo(Source);
                ftpWebRequest.UseBinary = true;
                
                using (Stream outputStream = ftpWebRequest.GetResponse().GetResponseStream())
                {
                   
                    using (FileStream inputStream = fileInfo.Create())
                    {
                        byte[] buffer = new byte[1024 * 1024];
                        int totalReadBytesCount = 0;
                        int readBytesCount;
                        while ((readBytesCount = outputStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            inputStream.Write(buffer, 0, readBytesCount);
                            totalReadBytesCount += readBytesCount;
                            var progress = totalReadBytesCount * 100.0 / outputStream.Length;
                            worker.ReportProgress((int)progress);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public event EventHandler StartDownload;
        public void Start()
        {
            if (bw.IsBusy != true)
            {
                if (StartDownload != null)
                {
                    StartDownload(this, new EventArgs());
                }
                bw.RunWorkerAsync();
            }
        }
        public void Cancel()
        {
            if (bw.WorkerSupportsCancellation == true)
            {
                bw.CancelAsync();
            }
        }
    }
}
