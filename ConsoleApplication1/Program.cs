using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var result = checker.Check();
            
            var logger = Ioc.Get<ILogger>();
            logger.Log(host, result);
            
            Console.ReadKey();
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
