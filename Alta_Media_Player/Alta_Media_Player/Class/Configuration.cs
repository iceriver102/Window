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

        public string MySql_server = "192.168.0.101";
        public string MySql_user = "root";
        public string MySql_pass = "roottest";
        public string MySql_database = "alta_mana_media";

        public string Ftp_Server = "ftp://192.168.0.101";
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
                FileStream stream = new FileStream(ConfigFileName, FileMode.Create);
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

        public static Configuration ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Configuration obj = (Configuration)binForm.Deserialize(memStream);
            obj.ConfigFileName = CommonUtilities.config.ConfigFileName;
            return obj;
        }
        public static byte[] getBytesWithBinaryFormatter(Configuration conf)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, conf);
            return stream.ToArray();
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

        public string getConnectionString()
        {
            return @"server=" + MySql_server + ";uid=" + MySql_user + ";pwd=" + MySql_pass + ";database=" + MySql_database + ";";
        }

        public string getXPOConnectString()
        {
            return @"XpoProvider=MySql;server=" + MySql_server + ";user id=" + MySql_user + "; password=" + MySql_pass + "; database=" + MySql_database + ";persist security info=true;CharSet=utf8;";
        }

    }
}
