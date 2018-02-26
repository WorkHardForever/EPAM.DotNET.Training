using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace AutoResetEvent3
{
    class Program
    {
        static int value = 0;

        static AutoResetEvent five = null;
        static AutoResetEvent zero = null;

        static void Inc()
        {
            // Перед запуском ждем, чтобы нам сообщили,
            // что в переменной 0
            zero.WaitOne();
            for (int i = 0; i <= 10; i++)
            {
                if (value == 5)
                {
                    // Сообщаем, что достигли 5
                    five.Set();
                    // Ждем ноля
                    zero.WaitOne();
                }
                value = value + 1;
                Debug.WriteLine(value);
            }
        }

        static void Dec()
        {
            // Перед запуском ждем, чтобы нам сообщили,
            // что в переменной 5
            five.WaitOne();
            for (int i = 0; i < 10; i++)
            {
                if (value == 0)
                {
                    // Сообщаем, что достигли 0
                    zero.Set();
                    // Ждем 5
                    five.WaitOne();
                }
                value = value - 1;
                Debug.WriteLine(value);
            }
        }

        static void Main(string[] args)
        {
            var inc = new Thread(Inc);
            var dec = new Thread(Dec);
            five = new AutoResetEvent(false); // Событие не активно
            zero = new AutoResetEvent(true); // т.к. в value ноль, поднимаем событие
            inc.Start();
            dec.Start();
            inc.Join(5000);
            dec.Join(5000);
            Debug.WriteLine("The value at the end of:{0}", value);
            //Console.ReadKey();
        }
    }
}
