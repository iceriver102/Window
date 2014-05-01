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
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Printing;
using System.Windows.Browser;
using System.Windows.Media.Imaging;

namespace SilverlightApplication11
{
    public partial class MainPage : UserControl
    {
        string _id;

     
 
        //private Dictionary<string, string> urlparams = HtmlPage.Document.QueryString as Dictionary<string, string>;
        public MainPage(string Id)
        {
            InitializeComponent();
            _id = Id;
            PopulateCustomersList();
           
           // MessageBox.Show(_id);
        }
        //private void Application_Startup(object sender, StartupEventArgs e)
        //{
        //    string uiculture = string.Empty;
        //    if (e.InitParams.ContainsKey("source"))
        //        MessageBox.Show(e.InitParams["source"]);
        //}
        private void PopulateCustomersList()
        {
           
            //string s = string.Empty;
            //urlparams.TryGetValue("Name", out s);
            //MessageBox.Show("name: " + s);
            WebClient xmlClient = new WebClient();
            //MessageBox.Show("Going To XMLFileLoaded");
            xmlClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(xmlClient_DownloadStringCompleted);
            xmlClient.DownloadStringAsync(new Uri("http://admin.solienlac.vn/quanlyled/index.php/xmls/data/" + _id, UriKind.RelativeOrAbsolute));
           
            //this.LayoutRoot = new Page();
            //var serviceUrl = e.InitParams["ServiceUrl"];

        }

        void xmlClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
          //  IDictionary<string, string> queryStrings = System.Windows.Browser.HtmlPage.Document.QueryString;
          //  MessageBox.Show((string)queryStrings["sss"]);
            //System.Windows.Browser.HtmlElement queryParam = System.Windows.Browser.HtmlPage.Document.QueryString["sss"];
           // string userID = queryParam.GetAttribute("sss");
           
           // MessageBox.Show(userID);
            if (e.Error == null)
            {
                string xmlData = e.Result;

                XDocument doc = XDocument.Parse(xmlData);

               // System.Windows.Browser.HtmlPage.Window.Alert(xmlData);

               // string s = doc.Element("led").Element("location").Value;

            //    System.Windows.Browser.HtmlPage.Window.Alert(s);

                //foreach (XElement str in doc.Descendants("location"))
                //{
                //    System.Windows.Browser.HtmlPage.Window.Alert(str.Value);
                //}     
                string barcode = doc.Element("led").Element("barcode").Value;
                imbarcode.Source = new BitmapImage(new Uri("http://admin.solienlac.vn/quanlyled/barcode/index.php?code=" + barcode));
                txtLocation.Text = doc.Element("led").Element("location").Value;
                txtEvent.Text = doc.Element("led").Element("event").Value;
                txtNameCustomer.Text = doc.Element("led").Element("namecustomer").Value;
                txtPhoneCustomer.Text = doc.Element("led").Element("phonecustomer").Value;
                txtPhoneSaler.Text = doc.Element("led").Element("phoneuser").Value;
                txtNameSaler.Text = doc.Element("led").Element("nameuser").Value;
                txtdaygetfile.Text = doc.Element("led").Element("daygetfile").Value;
                txtdaygetvideo.Text = doc.Element("led").Element("daygetvideo").Value;
                txttimeinstall.Content = doc.Element("led").Element("timeinstall").Value;
                txttimeruntest.Content = doc.Element("led").Element("timeruntest").Value;
                txttimerun.Content = doc.Element("led").Element("timerun").Value;
                txtdaygetfile.Text = doc.Element("led").Element("daygetfile").Value;
                txttypeled.Text = doc.Element("led").Element("typeled").Value;
                txtwidthled.Text = doc.Element("led").Element("widthled").Value;
                txtheightled.Text = doc.Element("led").Element("heightled").Value;
                string backdrop= doc.Element("led").Element("Backdrop").Value;
                if (backdrop == "0")
                {
                    cbBackdropyes.IsChecked = true;
                    cbBackdropno.IsChecked = false;
                }
                else {
                    cbBackdropyes.IsChecked = false;
                    cbBackdropno.IsChecked = true;
                }

                string ground = doc.Element("led").Element("ground").Value;

                if (ground == "2")
                {
                    cbouthouse.IsChecked = true;
                    cbinhouse.IsChecked = false;
                }
                else
                {
                    cbouthouse.IsChecked = false;
                    cbinhouse.IsChecked = true;
                }

                txtheightled.Text = doc.Element("led").Element("heightled").Value;
                string groundtype = doc.Element("led").Element("groundtype").Value;
                if (groundtype == "1")
                {
                    txttype.Text = "Có bạt che";
                }
                else {
                    txttype.Text = "Không có bạt che";
                }

                txtgroundheight1.Text = doc.Element("led").Element("groundheight1").Value;
                txtgroundheight2.Text = doc.Element("led").Element("groundheight2").Value;
                txtgroundheight3.Text = doc.Element("led").Element("groundheight3").Value;
                txtgroundheight4.Text = doc.Element("led").Element("groundheight4").Value;
                txtdescription.Text = doc.Element("led").Element("description").Value;
                string avis= doc.Element("led").Element("avi").Value;
                string mpegs = doc.Element("led").Element("mpeg").Value;
                string flvs = doc.Element("led").Element("flv").Value;
                string ppts = doc.Element("led").Element("ppt").Value;
                string jpegs = doc.Element("led").Element("jpeg").Value;
                string dvds = doc.Element("led").Element("dvd").Value;
                string cameras = doc.Element("led").Element("camera").Value;
                string audios = doc.Element("led").Element("audio").Value;
                string connects = doc.Element("led").Element("connect").Value;
  
                if(avis=="0"){ cbavi.IsChecked = false; } else{ cbavi.IsChecked = true;}
                if (mpegs == "0") { cbmpeg.IsChecked = false; } else { cbmpeg.IsChecked = true; }
                if (flvs == "0") { cbflv.IsChecked = false; } else { cbflv.IsChecked = true; }
                if (ppts == "0") { cbppt.IsChecked = false; } else { cbppt.IsChecked = true; }
                if (jpegs == "0") { cbjpeg.IsChecked = false; } else { cbjpeg.IsChecked = true; }
                if (dvds == "0") { cbdvd.IsChecked = false; } else { cbdvd.IsChecked = true; }
                if (cameras == "0") { cbcamera.IsChecked = false; } else { cbcamera.IsChecked = true; }
                if (audios == "0") { cbaudio.IsChecked = false; } else { cbaudio.IsChecked = true; }
                if (connects == "0") { cbconnect.IsChecked = false; } else { cbconnect.IsChecked = true; }
               
            }


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PrintDocument document = new PrintDocument();

            document.PrintPage += (s, args) =>
            {
                var letter = new Canvas();

                args.PageVisual = this.LayoutRoot;
                args.HasMorePages = false;
                
            };

            // call the Print() with a proper name which will be visible in the Print Queue
            document.Print("Silverlight Print Application Demo");
     
        }

    }
}
