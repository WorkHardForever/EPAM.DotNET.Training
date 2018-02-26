using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using BLL;

//using static System.Console;
//using static BLL.SomeClass;
namespace ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(SomeClass.SomeMethod(name));
            
            Console.ReadKey();

            //Write("Enter user name:");
            //string userName = ReadLine();
            //Clear();
            //WriteLine(GreetingMethod(userName));

            //ReadKey();
            
        }
    }
}
