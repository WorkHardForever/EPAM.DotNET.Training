
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace BackgroundWorkerDemo
{
    class Program
    {
        static BackgroundWorker _bw = new BackgroundWorker();

        static void Main()
        {
            _bw.DoWork += bw_DoWork;
            _bw.RunWorkerCompleted += (sender, args) => Console.WriteLine("Complied");
            _bw.RunWorkerAsync("Message to worker");
            Thread.Sleep(5000);
            //Console.ReadLine();

        }

        static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // This is called on the worker thread
            Console.WriteLine(e.Argument);        // writes "Message to worker"
            Thread.Sleep(2000);
            // Perform time-consuming task...
        }
    }
}
