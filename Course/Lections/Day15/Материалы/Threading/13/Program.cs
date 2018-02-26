using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _13
{
    class ThreadUnsafe
    {
        public static int value1, value2;

        public static void Go()
        {
            if (value2 != 0)
                Console.WriteLine(value1 / value2);
            value2 = 0;
        }
    }
    
    class ThreadSafe
    {
        static object locker = new object();
        public static int value1, value2;

        static void Go()
        {
            lock (locker)
            {
                if (value2 != 0)
                    Console.WriteLine(value1 / value2);

                value2 = 0;
            }
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ThreadUnsafe.value1 = 12;
            ThreadUnsafe.value2 = 4;
            Thread thread = new Thread(ThreadUnsafe.Go);
            thread.Start();
            ThreadUnsafe.Go();
            Console.ReadKey();
        }
    }
}
