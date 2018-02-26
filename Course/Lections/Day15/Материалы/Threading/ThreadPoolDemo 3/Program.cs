using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadPoolDemo_3
{
    class Test
    {
        static ManualResetEvent starter = new ManualResetEvent(false);

        public static void Main()
        {
            ThreadPool.RegisterWaitForSingleObject(starter, Go, "привет", -1, true);
            Thread.Sleep(5000);
            Console.WriteLine("Запускается рабочий поток...");
            starter.Set();
            Console.ReadLine();
        }

        public static void Go(object data, bool timedOut)
        {
            Console.WriteLine("Запущено: " + data);
            // Выполнение задачи...
        }
    }
}
