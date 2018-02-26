using System;
using System.Threading;

namespace SemaphoreDemo
{
    class SemaphoreTest
    {
        //static Semaphore s = new Semaphore(3, 3);  // Available=3; Capacity=3
        static readonly SemaphoreSlim semafore = new SemaphoreSlim(3);
        
        static void Main()
        {
            for (int i = 1; i <= 5; i++) new Thread(Enter).Start(i);
        }

        static void Enter(object id)
        {
            Console.WriteLine(id + " wants to enter");
            semafore.Wait();
            Console.WriteLine(id + " is in!");           // Only three threads
            //// Только 3 потока могут находиться здесь одновременно
            Thread.Sleep(1000);               // can be here at
            Console.WriteLine(id + " is leaving");       // a time.
            semafore.Release();
        }
    }
}
