using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ConsoleLogger : ILogger
    {
        public void Log(string host, bool result)
        {
            if (result)
            {
                Console.WriteLine("result: check {0} --> true", host);
            }
            else
            {
                Console.WriteLine("result: check {0} --> false", host);
            }
        }
    }
}
