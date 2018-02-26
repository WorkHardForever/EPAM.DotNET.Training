using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  QuickSort;
namespace QuickSortConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, -48, 90, 234, 12, -45, 6, 7, -12, 
                          -56, 34, 123, 456, -894, 5, -56 };

           Sort2.Sort(a);

            for (int i = 0; i <a.Length; i++)
            {
                Console.Write(a[i]);
                Console.Write(' ');
            }
           
            Console.ReadLine();

        }
    }
}
