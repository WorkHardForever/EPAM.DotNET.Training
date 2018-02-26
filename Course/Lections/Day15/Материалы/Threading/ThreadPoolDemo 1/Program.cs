using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadPoolDemo_1
{
    internal class Test
    {
        private static object workerLocker = new object();
        private static int runningWorkers = 100;

        public static void Main()
        {
            for (int i = 0; i < runningWorkers; i++)
                ThreadPool.QueueUserWorkItem(Go, i);

            Console.WriteLine("Ожидаем завершения работы...");

            lock (workerLocker)
                while (runningWorkers > 0)
                    Monitor.Wait(workerLocker);

            Console.WriteLine("Готово!");
            Console.ReadLine();
        }

        public static void Go(object instance)
        {
            Console.WriteLine("Запущен:  " + instance);
            Thread.Sleep(1000);
            Console.WriteLine("Завершен: " + instance);

            lock (workerLocker)
            {
                runningWorkers--;
                Monitor.Pulse(workerLocker);
            }
        }
    }
}
