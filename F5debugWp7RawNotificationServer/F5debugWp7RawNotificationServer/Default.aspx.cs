using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace F5debugWp7RawNotificationServer
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
         protected void Button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string strChannelURI = TextBox1.Text.ToString();
            //    HttpWebRequest sendRawNotification = (HttpWebRequest)WebRequest.Create(strChannelURI);
 
            //    sendRawNotification.Method = "POST";
 
            //    string strRawMessage = "<!--?xml version=\"1.0\" encoding=\"utf-8\"?-->" +
            //     "" +
            //     "" + TextBox2.Text.ToString() + "" +
            //     "" + TextBox3.Text.ToString() + "" +
            //     "";
 
            //    byte[] notificationMessage = Encoding.Default.GetBytes(strRawMessage);
 
            //    sendRawNotification.ContentLength = notificationMessage.Length;
            //    sendRawNotification.ContentType = "text/xml";
            //    sendRawNotification.Headers.Add("X-NotificationClass", "3");
 
            //    using (Stream requestStream = sendRawNotification.GetRequestStream())
            //    {
            //        requestStream.Write(notificationMessage, 0, notificationMessage.Length);
            //    }
 
            //    HttpWebResponse response = (HttpWebResponse)sendRawNotification.GetResponse();
            //    string notificationStatus = response.Headers["X-NotificationStatus"];
            //    string notificationChannelStatus = response.Headers["X-SubscriptionStatus"];
            //    string deviceConnectionStatus = response.Headers["X-DeviceConnectionStatus"];
 
            //    lblresult.Text = notificationStatus + " | " + deviceConnectionStatus + " | " + notificationChannelStatus;
            //}
            //catch (Exception ex)
            //{
            //    lblresult.Text = "Exception caught: " + ex.ToString();
            //}

            string PushNotificationXML = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<wp:Notification xmlns:wp=\"WPNotification\">" + "<wp:Toast>" + "<wp:Text1>{0}</wp:Text1>" + "<wp:Text2>{1}</wp:Text2>" + "</wp:Toast>" + "</wp:Notification>";
            string strChannelURI = TextBox1.Text.ToString();
            string strNotifitcationTitle = TextBox2.Text.ToString();
            string strNotifitcationsubTitle = TextBox3.Text.ToString();
            if (strChannelURI == string.Empty || strNotifitcationTitle == string.Empty || strNotifitcationsubTitle == string.Empty)
            {
                lblresult.Text = "All the fields are Mandatory!!!";
                return;
            }
            HttpWebRequest sendNotificationRequest = (HttpWebRequest)WebRequest.Create(strChannelURI);
            sendNotificationRequest.Method = "POST";
            sendNotificationRequest.Headers = new WebHeaderCollection();
            sendNotificationRequest.ContentType = "text/xml";
            sendNotificationRequest.Headers.Add("X-WindowsPhone-Target", "toast");
            sendNotificationRequest.Headers.Add("X-NotificationClass", "2");
            string str = string.Format(PushNotificationXML, strNotifitcationTitle, strNotifitcationsubTitle);
            byte[] strBytes = new UTF8Encoding().GetBytes(str);
            sendNotificationRequest.ContentLength = strBytes.Length;
            using (Stream requestStream = sendNotificationRequest.GetRequestStream())
            {
                requestStream.Write(strBytes, 0, strBytes.Length);
            }
            HttpWebResponse response = (HttpWebResponse)sendNotificationRequest.GetResponse();
            string notificationStatus = response.Headers["X-NotificationStatus"];
            string deviceConnectionStatus = response.Headers["X-DeviceConnectionStatus"];

            lblresult.Text = "Status: " + notificationStatus + " : " + deviceConnectionStatus;
 
        }
    }
}