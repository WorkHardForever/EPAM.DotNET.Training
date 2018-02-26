using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace _16
{
    class BasicWaitHandle
    {
        //var auto = new AutoResetEvent (false);
        //var auto = new EventWaitHandle (false, EventResetMode.AutoReset);
        //Конструктор EventWaitHandle также может использоваться для создания объекта ManualResetEvent
        //(если задать в качестве параметра EventResetMode.Manual)
        static EventWaitHandle _waitHandle = new AutoResetEvent(false);//true -> _waitHandle.Set();

        static void Main()
        {
            new Thread(Waiter).Start();
            Thread.Sleep(5000);                  // Pause for a second...
            _waitHandle.Set();                    // Wake up the Waiter.
        }

        static void Waiter()
        {
            Debug.WriteLine("Waiting...");
            _waitHandle.WaitOne();                // Wait for notification // _waitHandle.WaitOne(1000);
            Debug.WriteLine("Notified");
        }
    }
}
