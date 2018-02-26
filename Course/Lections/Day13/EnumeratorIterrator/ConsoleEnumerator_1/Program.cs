using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumerator_1;
using System.Diagnostics;
 
namespace ConsoleEnumerator_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new CustomCollection<string>(new[]
                {
                    "one", "two", "three", "four"
                });


            Debug.WriteLine("foreach C#:");
            foreach (var temp in collection)
            {
                Debug.WriteLine(temp);
            }

        }
    }
}
