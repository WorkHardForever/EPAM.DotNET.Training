using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _22
{
    class Program
    {
        static int value = 0;

        static void Inc()
        {
            for (int i = 0; i < 1000000; i++)
            {
                //value++;
                Interlocked.Increment(ref value);
            }
        }

        static void Dec()
        {
            for (int i = 0; i < 1000000; i++)
            {
                //value--;
                Interlocked.Decrement(ref value);
            }
        }

        static void Main(string[] args)
        {
            Thread inc = new Thread(new ThreadStart(Inc));
            Thread dec = new Thread(new ThreadStart(Dec));
            inc.Start();
            dec.Start();
            inc.Join();
            dec.Join();
            Console.WriteLine(value);
            Console.ReadKey();
        }
    }
}
