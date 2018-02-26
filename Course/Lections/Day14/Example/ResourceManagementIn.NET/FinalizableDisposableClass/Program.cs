using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FinalizableDisposableClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("***** Dispose() / Destructor Combo Platter *****");

            // Вызов метода Dispose () вручную; метод финализации 
            //в таком случае вызываться не будет. 
            MyResourceWrapper rw = new MyResourceWrapper();
            rw.Dispose();

            // Пропуск вызова метода Dispose () ; в таком случае будет 
            // вызываться метод финализации и выдаваться звуковой сигнал. 
            MyResourceWrapper rw2 = new MyResourceWrapper();
        }

    }
}
