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

namespace BMS_Altamedia_Reminder
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor

        BackgroundWorker backroungWorker;
        private Popup popup;
      
        private IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;

        public MainPage()
        {
            InitializeComponent();
            ShowSplash();
          //  lbDemo.Text = "Hello, World";
           // Write();
            Data();
            Write();
          //  DemoLdb.Text = "Phan thanh giang";
        }


        private void StartLoadingData()
        {
            backroungWorker = new BackgroundWorker();
            backroungWorker.DoWork += new DoWorkEventHandler(backroungWorker_DoWork);
            backroungWorker.RunWorkerCompleted +=
          new RunWorkerCompletedEventHandler(backroungWorker_RunWorkerCompleted);
            backroungWorker.RunWorkerAsync();
        }

        public void Data()
        {
            try
            {
                string name = (string)userSettings["name"];
                DemoLdb.Text = "Hello, " + name;
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                // No preference is saved.
                try
                {
                    DemoLdb.Text = "Hello, World";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
            Thread.Sleep(9000);
        }
        void backroungWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                this.popup.IsOpen = false;
            });
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