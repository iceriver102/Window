using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BMS_Altamedia_Reminder.Class;
using System.Windows.Media.Imaging;

namespace BMS_Altamedia_Reminder
{
    public partial class SplashScreenControl : UserControl
    {
        public SplashScreenControl()
        {
            InitializeComponent();
            MultiResImageChooserUri tmp = new MultiResImageChooserUri();
            tmp.Source = "/Assets/Splashing/SplashScreenImage.jpg";
            img_splashing.Source=  new BitmapImage(tmp.BestResolutionImage);
            Size ScreenSize= GetScreenResolution();
            this.Width = ScreenSize.Width;
            this.Height = ScreenSize.Height;
          
        }
       
        public Size GetScreenResolution()
        {
            double ScreenWidth = Application.Current.Host.Content.ActualWidth;
            double ScreenHeight = Application.Current.Host.Content.ActualHeight;
            return new Size(ScreenWidth, ScreenHeight);
        } 
    }
}
