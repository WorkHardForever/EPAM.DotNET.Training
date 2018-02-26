using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadLocalStorage
{
    class Program
    {
        //[ThreadStatic]
        //static int _x;

        static ThreadLocal<int> _x = new ThreadLocal<int>(() => 3);

        static void Main()
        {
            new Thread(() => { Thread.Sleep(1000); _x.Value++; Console.WriteLine(_x); }).Start();
            new Thread(() => { Thread.Sleep(2000); _x.Value++; Console.WriteLine(_x); }).Start();
            new Thread(() => { Thread.Sleep(3000); _x.Value++; Console.WriteLine(_x); }).Start();
            //new Thread(() => { Thread.Sleep(1000); _x++; Console.WriteLine(_x); }).Start();
            //new Thread(() => { Thread.Sleep(2000); _x++; Console.WriteLine(_x); }).Start();
            //new Thread(() => { Thread.Sleep(3000); _x++; Console.WriteLine(_x); }).Start();

            var localRandom = new ThreadLocal<Random>(() => new Random());
            Console.WriteLine(localRandom.Value.Next());

            var localRandom1 = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));
            Console.WriteLine(localRandom1.Value.Next());
        }
    }
}
