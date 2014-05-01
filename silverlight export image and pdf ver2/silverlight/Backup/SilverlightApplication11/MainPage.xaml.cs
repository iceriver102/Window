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
using System.IO;
using FluxJpeg.Core;
using silverPDF;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
namespace SilverlightApplication11
{
    public class row
    {
        public string title {get;set;}
        public string w { get; set; }
        public string h { get; set; }
        public string cabinetW { get; set; }
        public string cabinetH { get; set; }
        public string num { get; set; }
        public string dientich { get; set; }
        public string pixel { get; set; }
        public string note { get; set; }

    }
    public partial class MainPage : UserControl
    {
        string _id;
        public MainPage(string Id)
        {
            InitializeComponent();
            _id = Id;
            PopulateCustomersList();
        }
        private void PopulateCustomersList()
        {
            WebClient xmlClient = new WebClient();
            xmlClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(xmlClient_DownloadStringCompleted);
            xmlClient.DownloadStringAsync(new Uri("led_print_order_xml.php?id=" + _id, UriKind.RelativeOrAbsolute));
            txt_today.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();

        }

        void xmlClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
          
            if (e.Error == null)
            {
                string xmlData = e.Result;
                XDocument doc = XDocument.Parse(xmlData);
                string barcode = doc.Element("led").Element("barcode").Value;
                imbarcode.Source = new BitmapImage(new Uri("http://quanlyled.altamedia.vn/barcode/index.php?code=" + barcode));
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
                if (doc.Element("led").Element("Backdrop").Value == "0")
                    backdrop.IsChecked = true;
                else backdrop.IsChecked = false;


                //thông tin của chi tiết led nắm trong element info
                // mỗi row tương ứng với một dòng trong table;

                var lines =from line in doc.Descendants("row")
                           select new row{
                               title=(string)line.Attribute("title"),
                               w=(string)line.Attribute("width"),
                               h=(string)line.Attribute("height"),
                               cabinetH=(string)line.Attribute("cabinetH"),
                               cabinetW=(string)line.Attribute("cabinetW"),
                               num=(string)line.Attribute("num"),
                               dientich=(string)line.Attribute("dientich"),
                               pixel=(string)line.Attribute("pixel"),
                               note=(string)line.Attribute("note")
                           };
                listLed.ItemsSource = lines;
              
                txt_codecontract.Text = doc.Element("led").Element("codecontract").Value;
             
                string totalLed = ((float.Parse(doc.Element("led").Element("heightled").Value) * float.Parse(doc.Element("led").Element("widthled").Value)).ToString());
                if (totalLed.Length >= 6) {
                    totalLed = totalLed.Substring(0, 6);
                }
               
                if (doc.Element("led").Element("connectpclab").Value != "0")
                {
                    connectpc.IsChecked=true;
                    connectpc.Content = "Có kết nối với laptop/PC " + doc.Element("led").Element("connectpclab").Value + " cái";
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
                txtgroundheight5.Text = doc.Element("led").Element("groundheight5").Value;
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
                if (connects == "0") { cbconnect.IsChecked = false; } else { cbconnect.IsChecked = true; }
               
            }


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PrintDocument document = new PrintDocument();

            document.PrintPage += (s, args) =>
            {
                var letter = new Canvas();

                args.PageVisual = this.content;
                args.HasMorePages = false;
                
            };
            document.Print("AltaMedia Led");
     
        }
        private void SaveToImage(Grid grid)
        {
            try
            {
                WriteableBitmap bitmap = new WriteableBitmap(grid, null);

                if (bitmap != null)
                {
                    SaveFileDialog saveDlg = new SaveFileDialog();
                    saveDlg.Filter = "JPEG Files (*.jpeg)|*.jpeg";
                    saveDlg.DefaultExt = ".jpeg";

                    if ((bool)saveDlg.ShowDialog())
                    {
                        using (Stream fs = saveDlg.OpenFile())
                        {
                            MemoryStream stream = GetImageStream(bitmap);
                            byte[] binaryData = new Byte[stream.Length];
                            long bytesRead = stream.Read(binaryData, 0, (int)stream.Length);
                            fs.Write(binaryData, 0, binaryData.Length);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Note: Please make sure that Height and Width of the chart is set properly.");
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }


        public static MemoryStream GetImageStream(WriteableBitmap bitmap)
        {
            byte[][,] raster = ReadRasterInformation(bitmap);
            return EncodeRasterInformationToStream(raster, ColorSpace.RGB);
        }

       
        public static byte[][,] ReadRasterInformation(WriteableBitmap bitmap)
        {
            int width = bitmap.PixelWidth;
            int height = bitmap.PixelHeight;
            int bands = 3;
            byte[][,] raster = new byte[bands][,];

            for (int i = 0; i < bands; i++)
            {
                raster[i] = new byte[width, height];
            }

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    int pixel = bitmap.Pixels[width * row + column];
                    raster[0][column, row] = (byte)(pixel >> 16);
                    raster[1][column, row] = (byte)(pixel >> 8);
                    raster[2][column, row] = (byte)pixel;
                }
            }

            return raster;
        }

     
        public static MemoryStream EncodeRasterInformationToStream(byte[][,] raster, ColorSpace colorSpace)
        {
            ColorModel model = new ColorModel { colorspace = ColorSpace.RGB };
            FluxJpeg.Core.Image img = new FluxJpeg.Core.Image(model, raster);

            //Encode the Image as a JPEG
            MemoryStream stream = new MemoryStream();
            FluxJpeg.Core.Encoder.JpegEncoder encoder = new FluxJpeg.Core.Encoder.JpegEncoder(img, 100, stream);
            encoder.Encode();

            // Back to the start
            stream.Seek(0, SeekOrigin.Begin);

            return stream;
        }

        public void SaveToPDF(Grid grid)
        {
            WriteableBitmap bitmap = new WriteableBitmap(grid, null);
            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "PDF file format|*.pdf";

            // Save the document...
            if (d.ShowDialog() == true)
            {
                // Create a new PDF document
                PdfDocument document = new PdfDocument();

                // Create an empty page
                PdfPage page = document.AddPage();
                //page.Contents.CreateSingleContent().Stream.UnfilteredValue;

                // Get an XGraphics object for drawing
                XGraphics gfx = XGraphics.FromPdfPage(page);

                XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);

                MemoryStream stream = GetImageStream(bitmap);

                XImage pdfImg = XImage.FromStream(stream);
                gfx.DrawImage(pdfImg, 10, 0);

                document.Save(d.OpenFile());
            }
        }
        private void CVimages_Click(object sender, RoutedEventArgs e)
        {
            SaveToImage(content);
        }

        private void ExPDF_Click(object sender, RoutedEventArgs e)
        {
            SaveToPDF(content);
        }
    }
}
