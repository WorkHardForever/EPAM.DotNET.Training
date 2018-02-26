using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace InterlockedDemo
{
    class Atomicity
    {
        public static int x;
        static int y;
        static long z;

        public static void Test()
        {
            long myLocal;
            x = 3;             // Атомарная операция
            z = 3;             // Не атомарная (z – 64-битная переменная)
            myLocal = z;       // Не атомарная (z is 64 bits)
            y += x;            // Не атомарная (операции чтения и записи)
            x++;               // Не атомарная (операции чтения и записи)
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
