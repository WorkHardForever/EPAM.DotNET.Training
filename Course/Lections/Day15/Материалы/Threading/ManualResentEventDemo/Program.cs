using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ManualResentEventDemo
{
    class MyThread
    {
        public Thread Thrd;
        ManualResetEvent mre;

        public MyThread(string name, ManualResetEvent evt)
        {
            Thrd = new Thread(this.Run) {Name = name};
            mre = evt;
            Thrd.Start();
        }

        void Run()
        {
            Console.WriteLine("Inside thread " + Thrd.Name);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(Thrd.Name);
                Thread.Sleep(500);
            }

            Console.WriteLine(Thrd.Name + " is completed!");

            // Уведомление о событии
            mre.Set();
        }
    }

    class Program
    {
        #region 1
        static EventWaitHandle re = null;

        static void Worker()
        {
            re.WaitOne();
            Console.WriteLine("Thread {0} received event ", Thread.CurrentThread.Name);
        }

        static void Main(string[] args)
        {
            //re = new AutoResetEvent(false);
            re = new ManualResetEvent(false);
            Thread threadA = new Thread(Worker) { Name = "A" };
            Thread threadB = new Thread(Worker) { Name = "B" };
            Thread threadC = new Thread(Worker) { Name = "C" };
            threadA.Start();
            threadB.Start();
            threadC.Start();
            Console.WriteLine("Threads start");
            Thread.Sleep(5000);
            re.Set();
            re.Close();
        } 
        #endregion

        #region 2
        //static void Main()
        //{
        //    var evtObj = new ManualResetEvent(false);

        //    MyThread mt1 = new MyThread("Событийный поток 1", evtObj);

        //    Console.WriteLine("Основной поток ожидает событие");

        //    evtObj.WaitOne();

        //    Console.WriteLine("Основной поток получил уведомление о событии от первого потока");

        //    evtObj.Reset();

        //    mt1 = new MyThread("Событийный поток 2", evtObj);

        //    evtObj.WaitOne();

        //    Console.WriteLine("Основной поток получил уведомление о событии от второго потока");
        //    Console.ReadLine();
        //}
        #endregion
    }
}
