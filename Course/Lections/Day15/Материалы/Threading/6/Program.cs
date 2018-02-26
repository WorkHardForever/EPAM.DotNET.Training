using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _6
{
    class ThreadTest
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(Go);
            t.Start();
            t.Join();
            Console.WriteLine("\nThread t has ended!");
            //Thread.Sleep(TimeSpan.FromHours(1));  // sleep for 1 hour
            //Thread.Sleep(500);                    // sleep for 500 milliseconds
            Console.WriteLine(Environment.ProcessorCount);
            Console.ReadKey();
        }

        static void Go()
        {
            for (int i = 0; i < 100; i++) Console.Write("y");
        }
    }
}
