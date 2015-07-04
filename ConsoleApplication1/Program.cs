using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string loggerType = System.Configuration.ConfigurationManager.AppSettings["loggerType"];
            string host = System.Configuration.ConfigurationManager.AppSettings["host"];

            iocInit(loggerType);

            var checker = Ioc.Get<IChecker>();
            var logger = Ioc.Get<ILogger>();

            Console.WriteLine("Checking {0} availability ...", host);
            Console.WriteLine("Press any key to quit\n");

            do
            {
                var result = checker.Check();
                logger.Log(host, result);
                Thread.Sleep(800);
            }
            while (Console.KeyAvailable == false);
        }

        private static void iocInit(string loggerType)
        {
            Ioc.Init((kernel) =>
            {
                kernel.Bind<IChecker>().To<Checker>().InTransientScope();

                if (loggerType == LoggerType.console.ToString())
                {
                    kernel.Bind<ILogger>().To<ConsoleLogger>().InTransientScope();
                }
                else if (loggerType == LoggerType.txtFile.ToString())
                {
                    kernel.Bind<ILogger>().To<TxtFileLogger>().InTransientScope();
                }
                else
                {
                    // default log to console
                    kernel.Bind<ILogger>().To<ConsoleLogger>().InTransientScope();
                }
            });

        }

        public enum LoggerType
        {
            console,
            txtFile
        };
    }
}
