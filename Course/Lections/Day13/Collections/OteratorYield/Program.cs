using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

using CustomDictionary = System.Collections.Generic.Dictionary<int,string>;

namespace OteratorYield
{
    class Program
    {
        public static IEnumerator<int> GetNumbers()
        {
            string padding = "\t\t";
            Debug.WriteLine(padding + "Первая строка метода GetNumbers()"); // 1
            Debug.WriteLine(padding + "Сразу перед yield return 7"); // 2
            yield return 7;  // 3
            Debug.WriteLine(padding + "Сразу после yield return 7"); // 4
            Debug.WriteLine(padding + "Сразу перед yield return 42"); // 5 
            yield return 42;  // 6
            Debug.WriteLine(padding + "Сразу после yield return 42");  //7
        }

        public static IEnumerable<int> GetNumbersDemo()
        {
            try
            {
                yield return 7; // 1
                // 2: обработка первого элемента внешним кодом
                yield return 42; // 3
                // 4: обработка второго элемента внешним кодом
            }
            //catch ()//no!
            //{
                
            //}
            finally
            {
                Debug.WriteLine("Внутри блока finally метода GetNumbers");
            }
        }
        
        public static IEnumerable<string> ReadFile(string filename)
        {
            using (TextReader reader = File.OpenText(filename))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                    throw new IOException();
                }

            }
        }

        public static void Main()
        {
            Debug.WriteLine("Вызываем GetNumbers()");
            IEnumerator<int> enumerator = GetNumbers();
            Debug.WriteLine("Вызываем MoveNext()...");
            // Прежде чем обратиться к первому элементу коллекции нужно вызвать метод MoveNext
            bool more = enumerator.MoveNext();
            Debug.WriteLine("Result={0}; Current={1}", more, enumerator.Current);
            Debug.WriteLine("Снова вызываем MoveNext()...");
            more = enumerator.MoveNext();
            Debug.WriteLine("Result={0}; Current={1}", more, enumerator.Current);
            Debug.WriteLine("Снова вызываем MoveNext()...");
            more = enumerator.MoveNext();
            Debug.WriteLine("Result={0} (stopping)", more);
            //================================================
            IEnumerable<int> enumeratorDemo = GetNumbersDemo();
            foreach (var i in enumeratorDemo)
            {
                Debug.WriteLine(i);
            }
            //================================================
            try
            {
                foreach (var s in ReadFile("text.txt"))
                {
                    // Обрабатываем очередную строку, при этом при обработке может возникнуть исключение
                    Debug.WriteLine(s);
                }
            }
            catch
            {
                Debug.WriteLine("Блокировка файла была снята");
            }

            foreach (var s in ReadFile("text.txt"))
                Debug.WriteLine(s);
        }
    }
}
