using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _7
{
    //Для создания потоков используется конструктор класса Thread, 
    //принимающий в качестве параметра делегат типа ThreadStart, 
    //указывающий метод, который нужно выполнить
    //public delegate void ThreadStart();
    class Program
    {
        static void Main(string[] args)
        {
            //Thread t = new Thread(new ThreadStart(Go));//Явное создание объекта ThreadStart
            var t = new Thread(Go); // Без явного использования ThreadStart
            //Thread t = new Thread(delegate()
            //                          {
            //                              Console.WriteLine("Hello!");
            //                          });//анонимный метод
            //Thread t = new Thread(() => Console.WriteLine("Hello!"));//лямда-выражение
            t.Start();   // Выполнить Go() в новом потоке.
            Go();        // Одновременно запустить Go() в главном потоке.
            Console.ReadKey();
        }

        static void Go()
        {
            Console.WriteLine("hello!");
        }
    }
}
