using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCompletionSourceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var tcs = new TaskCompletionSource<int>();
            new Thread(() => { Thread.Sleep(5000); tcs.SetResult(42); }).Start();
            Task<int> task = tcs.Task; // Our "slave" task.
            Console.WriteLine(task.Result); // 42
        }
    }
}
