using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
//http://www.albahari.com/threading/part2.aspx#_CrossProcess_EventWaitHandle
namespace _17
{
    class TwoWaySignaling
    {
        static EventWaitHandle _ready = new AutoResetEvent(false);
        static EventWaitHandle _go = new AutoResetEvent(false);
        static readonly object _locker = new object();
        static string _message;

        static void Main()
        {
            new Thread(Work).Start();
            _ready.WaitOne();                  // Сначала ждем, когда рабочий поток будет готов
            lock (_locker) _message = "ooo";   // Назначаем задачу
            _go.Set();                         // Говорим рабочему потоку, что можно начинать

            _ready.WaitOne();
            lock (_locker) _message = "ahhh";  // Назначаем задачу
            _go.Set();
            _ready.WaitOne();
            lock (_locker) _message = null;    // Сообщаем о необходимости завершения рабочего потока
            _go.Set();
        }

        static void Work()
        {
            while (true)
            {
                _ready.Set();                          // Сообщаем о готовности
                _go.WaitOne();                         // Ожидаем сигнала начать...
                lock (_locker)
                {
                    if (_message == null) return;        // Элегантно завершаемся
                    Console.WriteLine(_message);
                }
            }
        }
    }
}
