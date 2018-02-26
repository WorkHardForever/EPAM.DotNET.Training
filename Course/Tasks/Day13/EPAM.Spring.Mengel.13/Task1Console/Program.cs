using Task1Logic;
using System.Collections.Generic;
using static System.Console;

namespace Task1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Task1Logic.Queue<string>(new string[] { "-2", "-1", "0" });
            queue.Enqueue("1");
            WriteLine("** Dequeue: " + queue.Dequeue().ToString());
            queue.Enqueue("2");
            WriteLine("** Dequeue: " + queue.Dequeue().ToString());
            queue.Enqueue("3");
            queue.Enqueue("4");
            WriteLine("** Dequeue: " + queue.Dequeue().ToString());
            queue.Enqueue("5");
            queue.Enqueue("6");
            queue.Enqueue("7");
            WriteLine("** Dequeue: " + queue.Dequeue().ToString());
            queue.Enqueue("8");
            queue.Enqueue("9");
            queue.Enqueue("10");
            queue.Enqueue("11");
            queue.Enqueue("12");
            WriteLine("Peek: " + queue.Peek().ToString());
            WriteLine("** Dequeue: " + queue.Dequeue().ToString());
            WriteLine("Peek: " + queue.Peek().ToString());
            WriteLine("-- Count: " + queue.Count.ToString());
            queue.Enqueue("13");
            queue.Enqueue("14");
            queue.Enqueue("15");
            queue.Enqueue("16");
            WriteLine("-- Count: " + queue.Count.ToString());
            WriteLine("** Dequeue: " + queue.Dequeue().ToString());
            WriteLine("** Dequeue: " + queue.Dequeue().ToString());
            WriteLine("** Dequeue: " + queue.Dequeue().ToString());
            WriteLine("** Dequeue: " + queue.Dequeue().ToString());
            WriteLine("** Dequeue: " + queue.Dequeue().ToString());
            WriteLine("-- Count: " + queue.Count.ToString());
            WriteLine("Peek: " + queue.Peek().ToString());
            WriteLine("Peek: " + queue.Peek().ToString());
            WriteLine("Peek: " + queue.Peek().ToString());
            WriteLine("-- Count: " + queue.Count.ToString());
            queue.Clear();
            queue.Enqueue("17");
            queue.Enqueue("18");
            queue.Enqueue("19");
            queue.Enqueue("20");
            queue.Enqueue("21");
            WriteLine("-- Count: " + queue.Count.ToString());

            foreach (var item in queue)
            {
                WriteLine(item);
            }

            ReadKey();
        }
    }
}
