﻿#pragma checksum "D:\thanh giang\Window\BMS Altamedia Reminder\BMS Altamedia Reminder\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3D0107CA50EA6ED594CA19A60BCD92A9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BMS_Altamedia_Reminder.UCXaml;
using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace BMS_Altamedia_Reminder {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Image img_refresh;
        
        internal System.Windows.Controls.Canvas layout_Msg;
        
        internal BMS_Altamedia_Reminder.UCXaml.Alta_Title viewTitle;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/BMS%20Altamedia%20Reminder;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.img_refresh = ((System.Windows.Controls.Image)(this.FindName("img_refresh")));
            this.layout_Msg = ((System.Windows.Controls.Canvas)(this.FindName("layout_Msg")));
            this.viewTitle = ((BMS_Altamedia_Reminder.UCXaml.Alta_Title)(this.FindName("viewTitle")));
        }
    }
}

