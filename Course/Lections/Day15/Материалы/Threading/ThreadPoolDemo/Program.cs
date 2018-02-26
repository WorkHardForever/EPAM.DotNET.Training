using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

//Cначала читается и выводится на консоль информация о максимальном количестве 
//рабочих потоков и потоков ввода-вывода. Затем в цикле for метод JobForAThread
//назначается потоку из пула потоков за счет вызова метода ThreadPool.QueueUserWorkltem
//и передачи делегата типа WaitCallback. Пул потоков получает этот запрос и выбирает 
//из пула один из потоков для вызова метода. Если пул еще не существует, он создается 
//и запускается первый поток. Если же пул существует и в нем имеется один свободный поток,
//задание переадресовывается этому потоку

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main()
        {
            int nWorkerThreads;
            int nCompletionThreads;
            ThreadPool.GetMaxThreads(out nWorkerThreads, out nCompletionThreads);
            Console.WriteLine("Максимальное количество потоков: {0} \nПотоков ввода-вывода доступно: {1}", 
                nWorkerThreads, nCompletionThreads);
            for (int i = 0; i < 5; i++)
                ThreadPool.QueueUserWorkItem(JobForAThread);
            Thread.Sleep(5000);

            Console.ReadLine();
        }

        static void JobForAThread(object state)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("цикл {0}, выполнение внутри потока из пула {1}", 
                    i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(5000);
            }
        }
    }
}
