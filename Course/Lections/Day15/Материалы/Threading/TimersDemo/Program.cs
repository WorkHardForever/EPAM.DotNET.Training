using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TimersDemo
{
    class Program
    {
        static void Main()
        {
            Timer tmr = new Timer(Tick, "tick...", 5000, 1000);
            Console.ReadLine();
            tmr.Dispose();           // Остановка таймера
        }

        static void Tick(object data)
        {
            // Этот код выполняется на потоке из пула
            Console.WriteLine(data); // Печать: "tick..."
        }
    }
}
