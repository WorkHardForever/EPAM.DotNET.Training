using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WaitPulse
{
    class TickTock
    {
        private object lockOn = new object();

        public void Tick(bool running)
        {
            lock (lockOn)
            {
                if (!running)
                {
                    // Остановить часы
                    Monitor.Pulse(lockOn);
                    return;
                }

                Console.Write("Tick ");
                // Разрешить выполнение метода Tock()
                Monitor.Pulse(lockOn);

                // Ожидать завершение Tock()
                Monitor.Wait(lockOn);
            }
        }

        public void Tock(bool running)
        {
            lock (lockOn)
            {
                if (!running)
                {
                    Monitor.Pulse(lockOn);
                    return;
                }

                Console.WriteLine("Tock");
                Monitor.Pulse(lockOn);
                Monitor.Wait(lockOn);
            }
        }
    }

    class MyThread
    {
        public Thread thread;
        private TickTock _tickTockObj;

        // Новый поток
        public MyThread(string name, TickTock tt)
        {
            thread = new Thread(this.Run);
            _tickTockObj = tt;
            thread.Name = name;
            thread.Start();
        }

        void Run()
        {
            if (thread.Name == "Tick")
            {
                for (int i = 0; i < 5; i++)
                {
                    _tickTockObj.Tick(true);
                    Thread.Sleep(1000);
                }

                _tickTockObj.Tick(false);
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    _tickTockObj.Tock(true);
                    Thread.Sleep(1000);
                }
                _tickTockObj.Tock(false);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var tickTock = new TickTock();

            var mt1 = new MyThread("Tick", tickTock);
            var mt2 = new MyThread("Tock", tickTock);

            mt1.thread.Join();
            mt2.thread.Join();

            Console.WriteLine("Clock is stopped");
            Console.ReadLine();
        }
    }
}

