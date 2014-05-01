using Microsoft.Expression.Encoder.Devices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using Vlc.DotNet.Core.Medias;
using WebcamControl;

namespace Alta_Media_Manager.Alta_view
{
    /// <summary>
    /// Interaction logic for Streaming_view.xaml
    /// </summary>
    /// 
    public class alta_Device
    {
        public String Name { get; set; }
        public String value { get; set; }
    }
    public partial class Streaming_view : UserControl
    {
        public event RoutedEventHandler Streaming;
        public event RoutedEventHandler RunbackGround;
        public event RoutedEventHandler Close;
        public Streaming_view()
        {
            InitializeComponent();         
            Collection<alta_Device> videoDevice = new Collection<alta_Device>();
            videoDevice.Add(new alta_Device() { Name = "None", value = "none" });
            Collection<alta_Device> audioDevice = new Collection<alta_Device>();
            audioDevice.Add(new alta_Device() { Name = "None", value = "none" });
            this.isStreaming = false;
            var vidDevices = EncoderDevices.FindDevices(EncoderDeviceType.Video);
            var audDevices = EncoderDevices.FindDevices(EncoderDeviceType.Audio);
            int countVideo = vidDevices.Count;
            for (int i = 0; i < countVideo; i++)
            {
                alta_Device tmp = new alta_Device() { Name = vidDevices[i].Name, value = vidDevices[i].Name };
                videoDevice.Add(tmp);
            }
            int countAudio = audDevices.Count;
            for (int i = 0; i < countAudio; i++)
            {
                alta_Device tmp = new alta_Device() { Name = audDevices[i].Name, value = audDevices[i].Name };
                audioDevice.Add(tmp);
            }
            cb_video.ItemsSource = videoDevice;
            cb_audio.ItemsSource = audioDevice;
            cb_video.SelectedIndex = 0;
            cb_audio.SelectedIndex = 0;
           
        }

        private void StartCaptureButton_Click(object sender, RoutedEventArgs e)
        {
            myVlcControl.Stop();
          // :dshow-vdev=HP Truevision HD :dshow-adev=Microphone (2- High Definition Audio Device)  :live-caching=300
            MediaBase tmpMedia = new LocationMedia("dshow://");
            alta_Device audio = (alta_Device)cb_audio.SelectedItem;
            alta_Device video = (alta_Device)cb_video.SelectedItem;
            String[] parr = { @"dshow-vdev=" + video.value, @"dshow-adev="+audio.value };
            tmpMedia.AddOption(parr[0]);
            tmpMedia.AddOption(parr[1]);      
            //option = @" :dshow-vdev=Logitech HD Pro Webcam C920 :dshow-adev=none";
           // tmpMedia.AddOption(option);
            myVlcControl.Media = tmpMedia;
            myVlcControl.Play();
        }
        private void StartStreaming(object sender, RoutedEventArgs e)
        {
            
            myVlcControl.Stop();
            //MediaBase tmpMedia = new PathMedia(@"C:\Users\phan\Downloads\Video\demo.MP4");
            MediaBase tmpMedia = new LocationMedia("dshow://");
            alta_Device audio = (alta_Device)cb_audio.SelectedItem;
            alta_Device video = (alta_Device)cb_video.SelectedItem;
            String[] parr = { @"dshow-vdev=" + video.value, @"dshow-adev=" + audio.value };
            tmpMedia.AddOption(parr[0]);
            tmpMedia.AddOption(parr[1]);
            //option = @" :dshow-vdev=Logitech HD Pro Webcam C920 :dshow-adev=none";
            // tmpMedia.AddOption(option);
            myVlcControl.Media = tmpMedia;
            string output = @":sout=#transcode{vcodec=mp4v,acodec=mpga,ab=128,channels=2,samplerate=44100}:rtp{sdp=rtsp://:8554/demo}";
            tmpMedia.AddOption(output);
           // myVlcControl.Media.AddOption(output);               
            myVlcControl.Media = tmpMedia;
            myVlcControl.Play();
            this.isStreaming = true;
            if (Streaming != null)
            {
                Streaming(this.Tag, new RoutedEventArgs());
            } 
            
        }

        internal void loadClient(Item_mana.Item_thietbi sender)
        {
            this.Tag = sender;
        }
        public event RoutedEventHandler StopStreaming;

        private void StopStream_Click(object sender, RoutedEventArgs e)
        {
            myVlcControl.Stop();
            if (StopStreaming != null)
            {
                StopStreaming(this.Tag, new RoutedEventArgs());
            }
            this.isStreaming = false;
           
        }
        ~Streaming_view()
        {
           
        }

        private void Runbackground_Click(object sender, RoutedEventArgs e)
        {
            if (RunbackGround != null)
            {
                RunbackGround(this, new RoutedEventArgs());
            }
        }

        private void CloseBox_Click(object sender, RoutedEventArgs e)
        {
            this.myVlcControl.Stop();
            if (Close != null)
                Close(this, new RoutedEventArgs());
        }
        public bool isStreaming { get; set; }
    }
}
