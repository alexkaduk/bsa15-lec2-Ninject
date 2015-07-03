using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Logger : ILogger
    {
        public void Log(bool result)
        {
            if (result)
            {
                Console.WriteLine("result true");
            }
            else
            {
                Console.WriteLine("result fasle");
            }
        }
    }
}
