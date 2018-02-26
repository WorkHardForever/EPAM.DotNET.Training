using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _14
{
    class Program
    {
        static List<string> list = new List<string>();

        static void Main(string[] args)
        {
            new Thread(AddItems).Start();
            new Thread(AddItems).Start();
        }

        static void AddItems()
        {
            for (int i = 0; i < 50; i++)
                lock (list)
                    list.Add("Item " + i);

            string[] items;

            lock (list)
                items = list.ToArray();


            lock (list)
            {
                int i = 1;
                foreach (string s in items)
                {
                    Console.WriteLine(i + " " + s);
                    i++;
                }
                
            }          
        }
    }
}
