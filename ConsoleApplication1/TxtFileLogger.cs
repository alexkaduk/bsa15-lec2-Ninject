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
                message = "check " + host + " --> available";
            }
            else
            {
                message = "check " + host + " --> unavailable";
            }

            using (StreamWriter file = File.AppendText(filePath)) 
            {
                file.WriteLine(DateTime.Today.ToString() + " | " + message);
            }

            Console.WriteLine("result writes to txt file...");
        }
    }
}
