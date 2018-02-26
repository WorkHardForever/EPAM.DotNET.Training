using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication2
{
    class Program
    {
        static void Foo(int a, int b)
        {
            Thread.Sleep(5000);
            Console.WriteLine(a + "  " + b);
        }

        private static void Main(string[] args)
        {
            AutoResetEvent autoReset = new AutoResetEvent(false);
            Action<int, int> action = Foo;
            IAsyncResult ar = action.BeginInvoke(12, 13, (a) =>
            {
                Console.WriteLine("Foo final");
                autoReset.Set();
            }

            , null);
            int i = 1;
            while (i < 10)
            {
                Thread.Sleep(1000);
                autoReset.WaitOne();
                Console.WriteLine("main thread works");
                i++;
            }

            Console.ReadKey();
        }
    }
}
