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
       
       // public String title { get{return this.txt_Title.Text;} set { this.title = value; this.txt_Title.Text = value; } }
        public Alta_Title()
        {
            InitializeComponent();
           
            EventArgs e = new EventArgs();
            if (Show != null)
                Show(this, e);
            if (Hide != null)
                Hide(this, e);

        }
        public event EventHandler Hide;
        public event EventHandler Show;

    }
}
