using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsyncDelegates_2
{
    public delegate int BinaryOp(int data, int time);

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Sync method call: \n");
            // Синхронный вызов метода
            BinaryOp bo = DelegateThread;
            Console.WriteLine("Result: " + bo(1, 1000));

            Console.WriteLine("\nAsync method call: \n");
            // Асинхронный вызов метода с применением делегата

            //IAsyncResult ar = bo.BeginInvoke(1, 4000, null, null);
            //ar.AsyncWaitHandle.WaitOne(1000);//3-й способ
            //while (!ar.IsCompleted)//1-й способ
            //{
            //    // Выполнение операций в главном потоке
            //    Console.Write(".");
            //    Thread.Sleep(50);
            //}
            //int result = bo.EndInvoke(ar);//Метод EndInvoke() сам ожидает, когда делегат завершит свою работу - 2-й способ
            //ar.AsyncWaitHandle.Close();
            //Console.WriteLine("Result: " + result);

            //Console.ReadLine();

            bo.BeginInvoke(1, 5000, TakesAWhileCompleted, bo);
            for (int i = 0; i < 100; i++)
            {
                // Выполнение операций в главном потоке
                Console.Write(".");
                Thread.Sleep(100);
            }
        }
        
        static int DelegateThread(int data, int time)
        {
            Console.WriteLine("DelegateThread works");
            // Делаем задержку, для эмуляции длительной операции
            Thread.Sleep(time);
            Console.WriteLine("DelegateThread is completed");
            return ++data;
        }

        static void TakesAWhileCompleted(IAsyncResult ar)
        {
            if (ar == null) 
                throw new ArgumentNullException("ar");

            var bo = ar.AsyncState as BinaryOp;
            //Trace.Assert(bo != null, "Неверный тип объекта");
            if (bo == null) return;
            int result = bo.EndInvoke(ar);
            Console.WriteLine("Result: " + result);
        }
    }
}
