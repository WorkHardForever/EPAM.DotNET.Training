using System;
using System.Threading;

#region ref
//http://www.rsdn.ru/article/dotnet/CSThreading1.xml 
#endregion

namespace _1
{
    //каждая последовательность символов 'X' и 'Y' соответствует кванту времени, выделенному потоку
    static class Program
    {
        //Программа на C# запускается как единственный поток, автоматически создаваемый CLR 
        //и операционной системой ("главный" поток), и становится многопоточной при помощи 
        //создания дополнительных потоков
        static void Main(string[] args)
        {
            var t = new Thread(WriteY);
            t.Start();                  // Выполнить WriteY в новом потоке
            for (int i = 0; i < 1000; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write("x"); // Печатать
            }

            Console.ReadKey();
        }

        static void WriteY()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write("y");     // Печатать 'y'
            }
        }
    }
}
