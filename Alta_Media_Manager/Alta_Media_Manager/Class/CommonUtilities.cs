using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Alta_Media_Manager.Alta_view.Class;
using System.Security.Cryptography;

namespace Alta_Media_Manager.Class
{
    public static class CommonUtilities
    {
        public static double D_height = 768;
        public static double D_width = 1366;
        public static double height;
        public static double width;
        public static Configuration config= new Configuration();
       // public static User curUser= new User();
        public static alta_class_user alta_curUser = new alta_class_user();
        public static List<alta_class_user_type> list_Type_User = new List<alta_class_user_type>();
        public static List<alta_class_media_type> list_Type_Media = new List<alta_class_media_type>();
        public static List<alta_class_user> List_user= new List<alta_class_user>();

        public static bool flag_menu_animation = true;
        public static int num_item_in_page = 10;
        public static string keySerect = "db8a04d2a0b07f841158fd9da9eaffb6";
        public static Size getScaleSize()
        {
            return new Size(width / D_width, height / D_height);
        }
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }

        // Verify a hash against a string. 
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input. 
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static int typeVideo=1;
        private static int typeCamera=2;
        public static int Type_video { get { return typeVideo; } private set { typeVideo = value; } }
        public static int Type_camera { get { return typeCamera; } private set { typeCamera = value; } }
    }
}
