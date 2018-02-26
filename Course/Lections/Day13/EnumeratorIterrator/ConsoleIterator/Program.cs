using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Iterator;
using System.Diagnostics;

namespace ConsoleIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new CustomCollection<string>(new[]
                {
                    "one", "two", "three", "four"
                });

            CustomCollection<string>.CustomIterator iterator = collection.Iterator();
            Debug.WriteLine("Pattern iterator:");
            while (iterator.MoveNext())
            {
                Debug.WriteLine(iterator.Current);
            }
            iterator.Reset();


            //массив изменился
            collection[0] = "zero";
            Debug.WriteLine("=================");
            iterator = collection.Iterator();
            Debug.WriteLine("Pattern iterator:");
            while (iterator.MoveNext())
            {
                Debug.WriteLine(iterator.Current);
            }
            iterator.Reset();

            //Debug.WriteLine("foreach C#:");
            //foreach (var temp in collection)
            //{
            //    Debug.WriteLine(temp);
            //}

        }
    }
}
