using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _8
{
    //Допустим, что в рассматриваемом примере мы захотим более явно 
    //различать вывод каждого из потоков, например, по регистру символов. 
    //Можно добиться этого, передавая соответствующий флаг в метод Go(), 
    //но в этом случае нельзя использовать делегат ThreadStart, так он не 
    //принимает аргументов. .NET Framework определяет другую 
    //версию делегата – ParameterizedThreadStart, которая может принимать один аргумент
    //public delegate void ParameterizedThreadStart(object obj);
    class ThreadTest 
    {
        static void Main(string[] args)
        {
            var t = new Thread(Go);
            //Thread t = new Thread(new ParameterizedThreadStart(Go));
            t.Start(true);             // == Go(true) 
            Go(false);
            
            //Удобство состоит в том, что нужный метод (в данном случае WriteText) 
            //можно вызвать с любым количеством аргументов и безо всякого приведения типов.
            var t1 = new Thread(() => WriteText("Hello"));
            t1.Start();
            //Однако нужно принять во внимание особенность семантики анонимных методов,
            //связанную с внешней переменной, которая становится очевидной в следующем примере 
            string text = "Before";
            var t2 = new Thread(() => WriteText(text));//замыкание!!!
            text = "After";
            t2.Start();
            Task task1 = Task.Factory.StartNew(() => Console.Write("antecedant.."));
            Task task2 = task1.ContinueWith(ant => Console.Write("..continuation"));
            Console.ReadKey();
        }

        static void WriteText(string text)
        {
            Console.WriteLine(text);
        }

        static void Go(object upperCase)
        {
            var upper = (bool)upperCase;
            Console.WriteLine(upper ? "HELLO!" : "hello!");
        }
    }
}
