using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;

namespace AsyncDelegates1
{
    class Program
    {
        static void Main(string[] args)
        {
            //«выстрелил и забыл» (fire and forget)
            // создадим лямбду, чтобы вычислять факторал
            Func<uint, BigInteger> factorial = null;
            factorial = n => (n == 0) ? 1 : n * factorial(n - 1);

            // создадим лямбду, чтобы печатать факторал
            Action<uint> print = n => Console.WriteLine(factorial(n));

            // запустим метод асинхроно, игнорируя дополнительные параметры
            //print.BeginInvoke(8000, null, null);
            
            // объект print не изменился
            // функция завершения будет выводить время выполнения метода
            AsyncCallback timer = ar =>
            {
                var dt = (DateTime)ar.AsyncState;
                Console.WriteLine(DateTime.Now - dt);
            };

            print.BeginInvoke(8000, timer, DateTime.Now);
            print.BeginInvoke(1000, timer, DateTime.Now);

            // эмулируем работу
            for (int i = 1; i < 10; i++)
            {
                Console.Write("Do some work...");
                Thread.Sleep(1000);
            }
        }
    }
}
