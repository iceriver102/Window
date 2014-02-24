using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Printing;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace ChitietChamCongKithuat
{

    public class row
    {
        public string STT { get; set; }
        public string itemName { get; set; }
        public string itemDV { get; set; }
        public string itemNum { get; set; }
        public string itemNote { get; set; }
        public string itemleave { get; set; }
        public string itemback { get; set; }
        public string itemKL { get; set; }
    }
    public partial class MainPage : UserControl
    {
        string _id;
        public MainPage(string id)
        {
            InitializeComponent();
            _id = id;
            PopulateCustomersList();
        }

        private void PopulateCustomersList()
        {
            WebClient xmlClient = new WebClient();
            xmlClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(xmlClient_DownloadStringCompleted);
            xmlClient.DownloadStringAsync(new Uri("led_print_thietbi_xml.php?id=" + _id, UriKind.RelativeOrAbsolute));
            lbDate.Content = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
        }
        private void xmlClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

            if (e.Error == null)
            {
                try
                {
                    string xmlData = e.Result;
                    XDocument doc = XDocument.Parse(xmlData);
                    var root = doc.Element("LEDSYSTEM");
                    string barcode = root.Element("barcode").Value;

                    imbarcode.Source = new BitmapImage(new Uri("http://bmsled.altamedia.vn/barcode/index.php?code=" + barcode));
                    nameOrder.Text = root.Element("nameOrder").Value;
                    tbDateStd.Text = root.Element("dateIntall").Value;
                    tbDateEnd.Text = root.Element("dateEnd").Value;
                    var lines = from line in doc.Descendants("row")
                                select new row
                                {
                                    STT = (string)line.Attribute("index"),
                                    itemName = (string)line.Attribute("name"),
                                    itemDV = (string)line.Attribute("donvi"),
                                    itemNum = (string)line.Attribute("soluong"),
                                    itemKL = (string)line.Attribute("khoiluong"),
                                    itemleave = (string)line.Attribute("itemGo"),
                                    itemback = (string)line.Attribute("itemBack"),
                                    itemNote = (string)line.Attribute("note")
                                };
                    table_data.ItemsSource = lines;
                    // MessageBox.Show(lines.ToString());
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("không tìm thấy file XML");
            }
        }
        private void Print_Event(object sender, RoutedEventArgs e)
        {
            PrintDocument document = new PrintDocument();
            double w = canvasPrint.ActualWidth;
            double h = canvasPrint.ActualHeight;
            //document.PrintedPageCount = 2;
            document.PrintPage += (s, args) =>
            {
                args.PageVisual = this.canvasPrint;
                double Width = args.PrintableArea.Width;
                double Height = args.PrintableArea.Height;               
                var transformGroup = new TransformGroup();
                transformGroup.Children.Add(new RotateTransform() { Angle = 90 });
                transformGroup.Children.Add(new TranslateTransform() { X = args.PrintableArea.Width});
                transformGroup.Children.Add(new ScaleTransform() { ScaleX=w/Width,ScaleY=h/Height});
                canvasPrint.RenderTransform = transformGroup;
                args.HasMorePages = false;

            };
            document.EndPrint += (s, r) =>
            {
                var transformGroup = new TransformGroup();
                transformGroup.Children.Add(new RotateTransform() { Angle = 0 });
                transformGroup.Children.Add(new TranslateTransform() { X = 0 });
                transformGroup.Children.Add(new ScaleTransform() { ScaleX = 1, ScaleY =1 });               
                canvasPrint.RenderTransform = transformGroup;
            };
            document.Print("Bảng kiểm kê thiết bị");
        }

       
    }
}
