using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace PLINQ_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Находим простые числа с помощью простого алгоритма.
            IEnumerable<int> numbers = Enumerable.Range(3, 100000 - 3);

            var parallelQuery =
              from n in numbers.AsParallel()
              where Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0)
              select n;

            int[] primes = parallelQuery.ToArray();
            foreach (var prime in primes)
            {
                Console.Write(prime + " ");
            }
           
        }
    }
}
