using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ES.MODELS;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Web.Configuration;
using System.Text.RegularExpressions;
using System.Reflection;
using System.ComponentModel;
namespace ES.WEB
{


    public static class Helper
    {

        private static ApplicationSignInManager _signInManager;
        private static ApplicationUserManager _userManager;
        public static ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set { _signInManager = value; }
        }

        public static ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public static string GetMasterCode(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = WebConfigurationManager.AppSettings["SecretKey"];
            byte[] clearBytes = Encoding.ASCII.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = WebConfigurationManager.AppSettings["SecretKey"];
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        public static string GetRandomNumber()
        {
            string year =Convert.ToString(DateTime.Now.Year).PadLeft(4,'0');
            string date = Convert.ToString(DateTime.Now.Day).PadLeft(2, '0');
            string month = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            string hour = Convert.ToString(DateTime.Now.Hour).PadLeft(2, '0');
            string minite = Convert.ToString(DateTime.Now.Minute).PadLeft(2, '0');
            string second = Convert.ToString(DateTime.Now.Second).PadLeft(2, '0');
            string msecong = Convert.ToString(DateTime.Now.Millisecond).PadLeft(2, '0');

            return Convert.ToString(year + month + date + hour + minite + second + msecong);
            //Random generator = new Random();
            //return generator.Next(0, 1000000).ToString("D6");
            //return requsetNumber.PadRight(15,0);
        }

        public static string ReplaceInFile(
                      string filePath, string Approver_Name,string  Reference_No, string Master_Name,string level_Name,string Status_Name,string Comments,string  email_Name,string email_RequestNo, string email_MasterName,string email_levelName,string email_StatusName,string email_Comments)
        {

            var content = string.Empty;
            using (StreamReader reader = new StreamReader(filePath))
            {
                content = reader.ReadToEnd();
                reader.Close();
            }

            content = Regex.Replace(content, Approver_Name, email_Name);
            content = Regex.Replace(content, Reference_No, email_RequestNo);
            content = Regex.Replace(content, Master_Name, email_MasterName);
            if (email_levelName != null)
            {
                content = Regex.Replace(content, level_Name, email_levelName);
            }

            if (email_StatusName != null)
            {
                content = Regex.Replace(content, Status_Name, email_StatusName);
            }
            if (email_Comments != null)
            {
                content = Regex.Replace(content, Comments, email_Comments);
            }
            //using (StreamWriter writer = new StreamWriter(filePath))
            //{
            //    writer.Write(content);
            //    writer.Close();
            //}


            return content;
        }


    }

 


}




