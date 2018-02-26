using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace FileReader
{
    class Program
    {
        private static void Main(string[] args)
        {
            #region No mutext
            //int i = 0;
            //while (i < 10000)
            //{
            //    if (File.Exists("1.txt"))
            //    {
            //        var sr = new StreamReader("1.txt");
            //        while (!sr.EndOfStream)
            //        {
            //            Console.WriteLine(sr.ReadLine());
            //            i++;
            //        }
            //        sr.Close();
            //        //File.Delete("1.txt");
            //    }
            //} 
            #endregion

            #region Mutex
            Mutex mut = Mutex.OpenExisting("MutexForFile");
            int i = 0;
            while (i < 100)
            {
                mut.WaitOne();
                if (File.Exists("1.txt"))
                {

                    var sr = new StreamReader("1.txt");
                    while (!sr.EndOfStream)
                    {
                        Console.WriteLine(sr.ReadLine());
                        i++;
                    }
                    sr.Close();
                    File.Delete("1.txt");
                }
                mut.ReleaseMutex();
            }
            #endregion
        }
    }
}
