using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Alta_Media_Manager.Class
{
    [Serializable]
    public class Configuration
    {
        /// <summary>
        /// Config
        /// </summary>
        public Configuration()
        {

        }
        [NonSerialized]
        public String ConfigFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.data");
        //Attribute

        public string MySql_server = "192.168.10.28";
        public string MySql_user = "root";
        public string MySql_pass = "roottest";
        public string MySql_database = "alta_mana_media";
        public string MySql_port = "3306";
        public string MySql_timeOut = "24";
        public string Ftp_Server = "ftp://192.168.10.28";
        public string Ftp_user = "demo";
        public string Ftp_pass = "123";
        public string Ftp_port = "21";
        public string Ftp_root_path = "C:\\xampp\\htdocs";
        public string Ftp_TimeOut = "120";

        public string Stream_Sever = "";
        public int Outport_Stream = 11000;
        public int Time = 128;
        public string license_Server = "";
        public int OutPort_Cer = 11000;
        public int buffer_Size = 1024;
        public string IP_Sefl = "";
        public int Request_Stream = 11000;

        public int id_termiral = 1;

        public bool soketCamera = true;

        public void SaveConfigXml()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Configuration));
                FileStream stream = new FileStream(ConfigFileName + ".xml", FileMode.Create);
                ser.Serialize(stream, this);
                stream.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }
        public Configuration LoadXML()
        {
            Configuration tmp = new Configuration();
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Configuration));
                FileStream stream = new FileStream(ConfigFileName, FileMode.Open);
                tmp = (Configuration)ser.Deserialize(stream);
                stream.Close();
            }
            catch (Exception ex)
            {

            }
            return tmp;
        }

        public static Configuration ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            string data = (string)binForm.Deserialize(memStream);
            Configuration obj = DecodeFrom64(data);
            //Configuration obj = (Configuration)binForm.Deserialize(memStream);
            // obj.ConfigFileName = CommonUtilities.config.ConfigFileName;
            return obj;
        }
        public static byte[] getBytesWithBinaryFormatter(Configuration conf)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            String base64 = EncodeTo64(conf);
            formatter.Serialize(stream, base64);
            return stream.ToArray();
        }

        public string getConnectionString()
        {
            return @"server=" + MySql_server + ";uid=" + MySql_user + ";pwd=" + MySql_pass + ";database=" + MySql_database + ";";
        }

        public static string EncodeTo64(Configuration o)
        {
            // Serialize to a base 64 string
            byte[] bytes;
            long length = 0;
            MemoryStream ws = new MemoryStream();
            BinaryFormatter sf = new BinaryFormatter();
            sf.Serialize(ws, o);
            length = ws.Length;
            bytes = ws.GetBuffer();
            string encodedData = bytes.Length + ":" + Convert.ToBase64String(bytes, 0, bytes.Length, Base64FormattingOptions.None);
            return encodedData;
        }

        public static Configuration DecodeFrom64(string s)
        {
            // We need to know the exact length of the string - Base64 can sometimes pad us by a byte or two
            int p = s.IndexOf(':');
            int length = Convert.ToInt32(s.Substring(0, p));

            // Extract data from the base 64 string!
            byte[] memorydata = Convert.FromBase64String(s.Substring(p + 1));
            MemoryStream rs = new MemoryStream(memorydata, 0, length);
            BinaryFormatter sf = new BinaryFormatter();
            Configuration o = (Configuration)sf.Deserialize(rs);
            o.ConfigFileName = CommonUtilities.config.ConfigFileName;
            return o;
        }


        public string getXPOConnectString()
        {
            return @"XpoProvider=MySql;server=" + MySql_server + ";user id=" + MySql_user + "; password=" + MySql_pass + "; database=" + MySql_database + ";persist security info=true;CharSet=utf8;";
        }

    }
}
