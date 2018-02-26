using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace TimerDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tmr = new Timer {Interval = 1000}; // Конструктор без параметров
            tmr.Elapsed += tmr_Elapsed; // Событие вместо делегата
            tmr.Start(); // Запустить таймер
            Console.ReadLine();

            tmr.Stop(); // Остановить таймер
            Console.ReadLine();

            tmr.Start(); // Продолжить
            Console.ReadLine();

            tmr.Dispose(); // Остановить навсегда
        }

        private static void tmr_Elapsed(object sender, EventArgs e)
        {
            Console.WriteLine("Tick");
        }
    }
}
