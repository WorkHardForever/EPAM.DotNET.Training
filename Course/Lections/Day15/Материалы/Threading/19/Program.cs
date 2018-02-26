using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

//AutoResetEvent используется для сигнализации рабочему потоку, 
//который приостанавливается, только если ему больше нечего исполнять 
//(очередь пуста). Для очереди используется Queue<>, доступ к ней защищен
//блокировкой для обеспечения потоковой безопасности. Рабочий поток завершается, 
//если встречает null-задачу

namespace _19
{
    class ProducerConsumerQueue : IDisposable
    {
        private readonly EventWaitHandle _hendel = new AutoResetEvent(false);
        private readonly Thread _worker;
        private readonly object _locker = new object();
        private readonly Queue<string> _tasks;

        public ProducerConsumerQueue()
        {
            _tasks = new Queue<string>();
            _worker = new Thread(Work);
            _worker.Start();
        }

        public void EnqueueTask(string task)
        {
            lock (_locker)
                _tasks.Enqueue(task);

            _hendel.Set();
        }

        public void Dispose()
        {
            EnqueueTask(null);      // Сигнал Потребителю на завершение
            _worker.Join();          // Ожидание завершения Потребителя
            _hendel.Close();             // Освобождение ресурсов
        }

        void Work()
        {
            while (true)
            {
                string task = null;// текущая задача из очереди

                lock (_locker)
                {
                    if (_tasks.Count > 0)
                    {
                        task = _tasks.Dequeue();
                        if (task == null)
                            return;
                    }
                }

                if (task != null)
                {
                    Console.WriteLine("Task works: " + task);
                    Thread.Sleep(1000); // симуляция работы...
                }
                else
                    _hendel.WaitOne();       // Больше задач нет, ждем сигнала...
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var q = new ProducerConsumerQueue())
            {
                q.EnqueueTask("Hi!");

                for (int i = 0; i < 10; i++)
                    q.EnqueueTask("Message " + i);

                q.EnqueueTask("By!");
            }
            // Выход из using приводит к вызову Dispose, который ставит
            // в очередь null-задачу и ожидает, пока Потребитель не завершится.
        }
    }
}
