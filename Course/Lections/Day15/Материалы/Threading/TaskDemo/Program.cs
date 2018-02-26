using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo
{
    class Program
    {
        static void MyTask()
        {
            Console.WriteLine("MyTask() running in the thread {0}", Task.CurrentId);

            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("In method MyTask count is {0} in the thread {1}", count, Task.CurrentId);
            }
            //throw new NullReferenceException();
        }

        static void Main()
        {
            Console.WriteLine("The main thread running");

            var task = new Task(MyTask);
            //var task2 = new Task(MyTask);
            //Console.WriteLine(task.Id);
            // Запустить задачу
            task.Start();
            //task2.Start();
            for (int i = 0; i < 60; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            Console.WriteLine("The main thread is finished");

            var task3 = Task.Factory.StartNew(() =>
                                      {
                                          //Thread.Sleep(3000); 
                                          Console.WriteLine("Foo");
                                      });//Framework 4.5 Task.Run
            
            //new Thread(() => Console.WriteLine("Foo")).Start();

            //Task<int> task4 = Task<int>.Factory.StartNew(() =>
            //                            {
            //                                Thread.Sleep(2000);
            //                                Console.WriteLine("Foo");
            //                                return 3;
            //                            },
            //                            TaskCreationOptions.LongRunning
            //                            );
            //Console.WriteLine(task.IsCompleted); // False
            ////task.Wait(); // Blocks until task is complete
            //Console.WriteLine(task4.Result);

            //Task<int> primeNumberTask = Task<int>.Factory.StartNew(() =>
            //                                                            Enumerable.Range(2, 3000000)
            //                                                                      .Count 
            //                                                                      (n =>
            //                                                                          Enumerable.Range(2, (int)Math.Sqrt(n) - 1)
            //                                                                                    .All(i => n % i > 0))
            //                                                      );
            //primeNumberTask.ContinueWith(antecedent => Console.WriteLine("The answer is " + antecedent.Result));
            //Console.WriteLine("Task running...");
            //Console.WriteLine("The answer is " + primeNumberTask.Result);

            Console.ReadLine();
        }
    }
}
