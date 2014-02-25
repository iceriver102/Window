using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.ComponentModel;
using System.Threading;

namespace BMS_Altamedia_Reminder.UCXaml
{
    public partial class Alta_Title : UserControl
    {
        BackgroundWorker backroungWorker;
        int time;
        public Alta_Title(String title,int time=3000)
        {
            InitializeComponent();
            EventArgs e = new EventArgs();
            this.time = time;
            backroungWorker = new BackgroundWorker();
            backroungWorker.DoWork += new DoWorkEventHandler(backroungWorker_DoWork);
            backroungWorker.RunWorkerCompleted +=
          new RunWorkerCompletedEventHandler(backroungWorker_RunWorkerCompleted);
            backroungWorker.RunWorkerAsync();
            txt_Tile.Text = title;

            if(Show!=null)
                Show(this,e);
        }

        private void backroungWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                this.Visibility = Visibility.Collapsed;
                EventArgs ex = new EventArgs();
                if (Hide != null)
                    Hide(this, ex);
            });
        }

        private void backroungWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(time);
        }
        public event EventHandler Hide;
        public event EventHandler Show;

    }
}
