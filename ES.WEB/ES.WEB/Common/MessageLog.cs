using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ES.WEB.Common
{
    public static class MessageLog
    {
        public static void Log(string logMessage)
        {
           

            var path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + @"\Errorlog\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string str = DateTime.Now.ToShortDateString();
            StreamWriter w = new StreamWriter(path + "log" + DateTime.Now.ToShortDateString().Replace('/', ' ') + ".txt", true);//File.CreateText(ConfigurationManager.AppSettings["LogPath"]);
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine(":");
            w.WriteLine("{0}", logMessage);
            w.WriteLine("-------------------------------");
            w.Flush();
            w.Close();
            w.Dispose();
        }

    }
}