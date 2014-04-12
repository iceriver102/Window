using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Alta_Media_Manager.Class
{
    public class FileOperations
    {
        public void wirteFile(Configuration conf)
        {
            FileStream fs ;
            if (File.Exists(conf.ConfigFileName))
            {
                fs = new FileStream(conf.ConfigFileName, FileMode.Create);
            }else
                fs= new FileStream(conf.ConfigFileName, FileMode.Append);
            // Create the writer for data.
            BinaryWriter w = new BinaryWriter(fs);
            // Write data to Test.data.

            byte[] data = Configuration.getBytesWithBinaryFormatter(conf);
            w.Write(data);
            
            w.Close();
            fs.Close();
           
        }
       
        public Configuration readFile(String fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine(fileName + " already exists!");
                return null;
            }
            FileStream fs= new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);
            // Read data from Test.data.           
            byte[] data= r.ReadBytes((int)fs.Length);            
            r.Close();
            fs.Close();
            return Configuration.ByteArrayToObject(data);
        }
    }
}
