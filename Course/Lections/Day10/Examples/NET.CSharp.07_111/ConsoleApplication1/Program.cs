using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("method main works");
                FunctionA(); 
           
        }

        #region Function A

        static void FunctionA()
        {
           
                Console.WriteLine("method A (FormatDataForDisplay) works");
                FunctionB();
   
        }
        #endregion

        #region Function B
        static void FunctionB()
        {
                Console.WriteLine("method B (ProcessData) works");
                FunctionC();
         }
        #endregion

        #region Function C
        static void FunctionC()
        {

            Console.WriteLine("method C (GetFile) works");
            File.Open("text.txt", FileMode.Open);
        }
        #endregion
    }
}
