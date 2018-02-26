using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace FileWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            #region No mutex
            //var rnd = new Random();
            //for (int i = 0; i < 10000; i++)
            //{
            //    var sw = new StreamWriter("1.txt", true);
            //    sw.WriteLine(rnd.Next(100000));
            //    Console.WriteLine("Записано {0}", i);
            //    sw.Close();
            //} 
            #endregion

            #region Mutex
            Mutex mut = Mutex.OpenExisting("MutexForFile");
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                mut.WaitOne();
                var sw = new StreamWriter("1.txt", true);
                int j = rnd.Next(1000);
                sw.WriteLine(j);
                Console.WriteLine("Write {0}", j);
                sw.Close();
                mut.ReleaseMutex();
                Thread.Sleep(100);
            }    
            #endregion
        }
    }
}
