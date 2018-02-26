using System;
using System.IO;
using System.Threading;
using NLog;

namespace NLogExample
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            try
            {
                FormatDataForDisplay();
            }
            catch (Exception e)
            {
                logger.Info("Unhandled exception:");
                logger.Error(e.StackTrace);
            }
            Console.ReadLine();
        }

        #region Function A
        static void FormatDataForDisplay()
        {
            logger.Trace("Method FormatDataForDisplay start");
            Thread.Sleep(1000);
            ProcessData();
            logger.Trace("Method FormatDataForDisplay end");
        }
        #endregion

        #region Function B
        static void ProcessData()
        {
            logger.Trace("Method ProcessData start");
            Thread.Sleep(1000);
            GetFile();
            logger.Trace("Method ProcessData end");
        }
        #endregion

        #region Function C
        static void GetFile()
        {
            logger.Trace("Method GetFile start");
            Thread.Sleep(1000);
            File.Copy("old.txt", "new.txt");
            //throw new IOException("Data File Data.txt was not found");
            logger.Trace("Method GetFile end");
        }
        #endregion
    }
}
