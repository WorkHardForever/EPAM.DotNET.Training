using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SimpleFinalize
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("***** Fun with Finalizers *****\n");
            Debug.WriteLine("Hit the return key to shut down this app");
            Debug.WriteLine("and force the GC to invoke Finalize()");
            Debug.WriteLine("for finalizable objects created in this AppDomain.");
            // Нажмите клавишу <Enter>, чтобы завершить приложение 
            // и заставить сборщик мусора вызвать метод Finalize () 
            // для всех финализируемых объектов, которые 
            // были созданы в домене этого приложения. 
            var rw = new MyResourceWrapper();
        }
    }
}
