using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _9
{
    //Другой способ передачи данных в поток состоит в запуске в потоке метода
    //определенного экземпляра объекта, а не статического метода.
    //Тогда свойства выбранного экземпляра объекта будут определять поведение потока
    internal class ThreadTest
    {
        private bool upper;

        private static void Main()
        {
            var instance1 = new ThreadTest { upper = true };
            var t = new Thread(instance1.Go) { Name = "Additional" };
            t.Start();// Запуск в дополнительном потоке - с upper = true
            //Thread.Sleep(1000);
            Console.WriteLine(t.ThreadState);
            var instance2 = new ThreadTest();
            Thread.CurrentThread.Name = "Primary";
            instance2.Go(); // Запуск в главном потоке - с upper = false
            Console.ReadKey();
        }

        private void Go()
        {
            Console.WriteLine(upper ? "HELLO!" : "hello!");
            Console.WriteLine("Work thread with name = {0} and id = {1}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId);
        }
    }
}
