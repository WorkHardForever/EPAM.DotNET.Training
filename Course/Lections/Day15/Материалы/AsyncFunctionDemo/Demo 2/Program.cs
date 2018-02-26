using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Demo_2
{
    class Program
    {
        static void SyncVersion()
        {
            Stopwatch sw = Stopwatch.StartNew();
            const string url1 = "http://rsdn.ru";
            const string url2 = "http://gotdotnet.ru";
            const string url3 = "http://blogs.msdn.com";
            var webRequest1 = WebRequest.Create(url1);
            var webResponse1 = webRequest1.GetResponse();
            Console.WriteLine("{0} : {1}, elapsed {2}ms", url1,
                webResponse1.ContentLength, sw.ElapsedMilliseconds);

            var webRequest2 = WebRequest.Create(url2);
            var webResponse2 = webRequest2.GetResponse();
            Console.WriteLine("{0} : {1}, elapsed {2}ms", url2,
                webResponse2.ContentLength, sw.ElapsedMilliseconds);

            var webRequest3 = WebRequest.Create(url3);
            var webResponse3 = webRequest3.GetResponse();
            Console.WriteLine("{0} : {1}, elapsed {2}ms", url3,
                webResponse3.ContentLength, sw.ElapsedMilliseconds);
        }

        static void Main(string[] args)
        {
            SyncVersion();
        }
    }
}
