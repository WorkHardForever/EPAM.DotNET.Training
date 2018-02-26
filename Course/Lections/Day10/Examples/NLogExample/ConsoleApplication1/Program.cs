using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NLog;

namespace ConsoleApplication1
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            try
            {
                throw new FileNotFoundException("File not found!");
            }
            catch (Exception e)
            {
                logger.Info("Unhandled exception:");
                logger.Info(e.Message);
                logger.Error(e.StackTrace);
            }
            Console.ReadKey();
        }
    }
}
