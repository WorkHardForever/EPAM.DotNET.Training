using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _12
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread.Sleep(0);   // отказаться от одного кванта времени CPU
            //Thread.Sleep(1000);                   // заснуть на 1000 миллисекунд
            //Thread.Sleep(TimeSpan.FromHours(1));  // заснуть на 1 час
            //Thread.Sleep(Timeout.Infinite);       // заснуть до прерывания

            Thread t = new Thread(() => Console.ReadLine());
            t.Start();
            t.Join();    // ожидать, пока поток не завершится
            Console.WriteLine("Thread t's ReadLine complete!");

            Thread.Sleep(1000);
            Thread.CurrentThread.Join(1000);
            Console.ReadLine();
        }
    }
}
