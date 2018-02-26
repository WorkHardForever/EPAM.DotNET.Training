using System;
using NLog;

namespace SimpleExampleNLog
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void C()
        {
            logger.Info("Info CCC");
        }

        static void B()
        {
            logger.Trace("Trace BBB");
            logger.Debug("Debug BBB");
            logger.Info("Info BBB");
            C();
            logger.Warn("Warn BBB");
            logger.Error("Error BBB");
            logger.Fatal("Fatal BBB");
        }

        static void A()
        {
            logger.Trace("Trace AAA");
            logger.Debug("Debug AAA");
            logger.Info("Info AAA");
            B();
            logger.Warn("Warn AAA");
            logger.Error("Error AAA");
            logger.Fatal("Fatal AAA");
        }

        static void Main(string[] args)
        {
            logger.Trace("This is a Trace message");
            logger.Debug("This is a Debug message");
            logger.Info("This is an Info message");
            A();
            logger.Warn("This is a Warn message");
            logger.Error("This is an Error message");
            logger.Fatal("This is a Fatal error message");

            Console.ReadKey();
        }
    }
}
