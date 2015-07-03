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
            iocInit();

            var checker = Ioc.Get<IChecker>();

            var result = checker.Check();

            var logger = Ioc.Get<ILogger>();

            logger.Log(result);

        }

        private static void iocInit()
        {
            var simple = true;

            Ioc.Init((kernel) =>
            {
                if (simple)
                {
                    kernel.Bind<IChecker>().To<Checker>().InTransientScope();
                    kernel.Bind<ILogger>().To<Logger>().InTransientScope(); 
                    // kernel.Bind<ICalculator>().To<SimpleCalculator>().InSingletonScope();
                    // kernel.Bind<ICalculator>().To<SimpleCalculator>().InThreadScope(); // 1 instance pre thread
                }
                else
                {
                    kernel.Bind<IChecker>().To<Checker>().InTransientScope();
                    kernel.Bind<ILogger>().To<Logger>().InTransientScope(); 
                }
                //kernel.Bind<ServerProxy>().ToSelf();
            });
        }
    }
}
