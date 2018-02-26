using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SimpleDispose
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("***** Fun with Dispose *****\n");

            // Создание высвобождаемого объекта и вызов метода 
            // Dispose () для освобождения любых внутренних ресурсов. 
            MyResourceWrapper rw = new MyResourceWrapper();
            rw.Dispose();

            if (rw is IDisposable)
                rw.Dispose();

            try
            {
                // Использование членов rw. 
            }
            finally
            {
                // Обеспечение вызова метод Dispose() в любом случае, 
                //в том числе при возникновении ошибки. 
                rw.Dispose();
            }

            // Use a comma-delimited list to declare multiple objects to dispose.
            using (MyResourceWrapper rw1 = new MyResourceWrapper(), rw2 = new MyResourceWrapper())
            {
                // Use rw and rw2 objects.
            }
        }
    }
}
