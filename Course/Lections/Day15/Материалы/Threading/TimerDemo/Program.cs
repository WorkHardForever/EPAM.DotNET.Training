using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace TimerDemo
{
    class Program
    {
        static void Main()
        {
            var tmr = new System.Threading.Timer(Tick, "tick...", 5000, 1000);
            Console.ReadLine();
            tmr.Dispose();           // Остановка таймера


            //var tmr = new System.Timers.Timer { Interval = 500 };       // Конструктор без параметров
            //tmr.Elapsed += tmr_Elapsed;    // Событие вместо делегата
            //tmr.Start();                   // Запустить таймер
            //Console.ReadLine();

            //tmr.Stop();                    // Остановить таймер
            //Console.ReadLine();

            //tmr.Start();                   // Продолжить
            //Console.ReadLine();

            //tmr.Dispose();                 // Остановить навсегда
        }

        static void Tick(object data)
        {
            // Этот код выполняется на потоке из пула
            Console.WriteLine(data); // Печать: "tick..."
        }

        static void tmr_Elapsed(object sender, EventArgs e)
        {
            Console.WriteLine("Tick");
        }
    }
}
