using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _15
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Thread(delegate()
            {
                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadInterruptedException)
                {
                    Console.Write("Forcibly ");
                }

                Console.WriteLine("Woken!");
            });

            t.Start();
            t.Interrupt();
        }
    }
}
