using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Text;namespace ConsoleApplication1
{
    class TxtFileLogger : ILogger
    {
        string filePath = @"..\..\log.txt";
        string message;

        public void Log(string host, bool result)
        {
            if (result)
            {
                message = "log to txt file: check " + host + " --> true";
            }
            else
            {
                message = "log to txt file: check " + host + " --> false";
            }

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (FileStream fs = File.Create(filePath))
            {
                AddText(fs, message);
            }

            Console.WriteLine("results write to txt file");
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
