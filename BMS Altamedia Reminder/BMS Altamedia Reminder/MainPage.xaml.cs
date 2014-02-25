using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BMS_Altamedia_Reminder.Resources;
using System.ComponentModel;
using System.Threading;
using System.Windows.Controls.Primitives;
using Windows.Storage;
using System.IO.IsolatedStorage;
using BMS_Altamedia_Reminder.Class;

namespace BMS_Altamedia_Reminder
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor

        BackgroundWorker backroungWorker;
        private Popup popup;
        private Boolean flag_flashing;
        private IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;
        userDataJson user;
        public MainPage()
        {
            InitializeComponent();
            LoadData();
            flag_flashing = false;
            ShowSplash();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Remove Page2 from the backstack
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.RemoveBackEntry();
            }
        }


        private void StartLoadingData()
        {
            this.flag_flashing = true;
            backroungWorker = new BackgroundWorker();
            backroungWorker.DoWork += new DoWorkEventHandler(backroungWorker_DoWork);
            backroungWorker.RunWorkerCompleted +=
          new RunWorkerCompletedEventHandler(backroungWorker_RunWorkerCompleted);
            backroungWorker.RunWorkerAsync();
        }

        public void LoadData()
        {
            try
            {
                user = new userDataJson();
                user.result = (Boolean)userSettings["login_result"];
                user.user_access_token = (String)userSettings["token"];
                user.user_id = (String)userSettings["user_id"];
                user.user_name = (String)userSettings["name"];
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                user = new userDataJson();
            }

        }
        public void Write()
        {
            try
            {
                userSettings.Add("name", "thanh giang");
                // tbResults.Text = "Name saved. Refresh page to see changes.";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void backroungWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.flag_flashing = true;
            Thread.Sleep(3000);
        }
        void backroungWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                this.popup.IsOpen = false;
                this.flag_flashing = false;
                if (!user.result)
                {
                    ShowLogin();
                }
            });
        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (this.flag_flashing)
                e.Cancel = true;
        }
        private void ShowLogin()
        {
            this.NavigationService.Navigate(new Uri("/Login.xaml?NavigatedFrom=Main Page", UriKind.Relative));

        }
        private void ShowSplash()
        {
            this.popup = new Popup();
            this.popup.Child = new SplashScreenControl();
            this.popup.IsOpen = true;
            StartLoadingData();
        }
    }
}