using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo_3
{
    class Program
    {
        //асинхронный метод
        static async Task AsyncVersion()
        {
            Stopwatch sw = Stopwatch.StartNew();
            string url1 = "http://rsdn.ru";
            //string url2 = "http://gotdotnet.ru";
            string url3 = "http://blogs.msdn.com";

            var webRequest1 = WebRequest.Create(url1);
            Debug.WriteLine($"Before webRequest1.GetResponseAsync(). Thread Id: { Thread.CurrentThread.ManagedThreadId}");
            Debug.WriteLine($"Is Thread ThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
            //асинхронная операция
            var webResponse1 = await webRequest1.GetResponseAsync();
            Debug.WriteLine($"{url1} : {webResponse1.ContentLength}," +
                              $" elapsed {sw.ElapsedMilliseconds}ms. " +
                              $" Thread Id: {Thread.CurrentThread.ManagedThreadId}" +
                              $" Is Thread Pool Thread: {Thread.CurrentThread.IsThreadPoolThread}");

            //var webRequest2 = WebRequest.Create(url2);
            //Debug.WriteLine("Before webRequest2.GetResponseAsync(). Thread Id: {0}",
            //    Thread.CurrentThread.ManagedThreadId);
            ////асинхронная операция
            //var webResponse2 = await webRequest2.GetResponseAsync();
            //Debug.WriteLine($"{url2} : {webResponse2.ContentLength}," +
            //                  $" elapsed {sw.ElapsedMilliseconds}ms. " +
            //                  $" Thread Id: {Thread.CurrentThread.ManagedThreadId}" +
            //                  $" Is Thread Pool Thread {Thread.CurrentThread.IsThreadPoolThread}");

            var webRequest3 = WebRequest.Create(url3);
            Debug.WriteLine("Before webRequest3.GetResponseAsync(). Thread Id: {0}",
                Thread.CurrentThread.ManagedThreadId);
            //асинхронная операция
            var webResponse3 = await webRequest3.GetResponseAsync();
            Debug.WriteLine($"{url3} : {webResponse3.ContentLength}," +
                              $" elapsed {sw.ElapsedMilliseconds}ms. " +
                              $" Thread Id: {Thread.CurrentThread.ManagedThreadId}" +
                              $" Is Thread Pool Thread {Thread.CurrentThread.IsThreadPoolThread}");
        }
        //вызфвающий метод
        static void Main(string[] args)
        {
            try
            {
                Debug.WriteLine("Main thread id: {0}", Thread.CurrentThread.ManagedThreadId);
                var task = AsyncVersion();
                task.Wait();
                Debug.WriteLine("Right after AsyncVersion() method call");
                Debug.WriteLine("Asyncronous task finished!");

            }
            catch (AggregateException e)
            {
                //Все исключения в TPL пробрасываются обернутые в AggregateException
                Console.WriteLine("AggregateException: {0}", e.InnerException.Message);
            }
            
            //Console.ReadLine();
        }
    }
}
