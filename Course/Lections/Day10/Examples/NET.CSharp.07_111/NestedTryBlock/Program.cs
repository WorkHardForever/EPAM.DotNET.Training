using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SEHExceptionHandling1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("method main works");
                FormatDataForDisplay();//Function A
            }
            catch (Exception /*DivideByZeroException*/ ex)
            {
                Console.WriteLine("method  main catch block");
                Console.WriteLine($"Main take ex:\n\n{ex}\n\n");
            }
            finally
            {
                Console.WriteLine("method  main finally block");
            }
        }

        #region Function A

        static void FormatDataForDisplay()
        {
            try
            {
                Console.WriteLine("method A (FormatDataForDisplay) works");
                ProcessData();// Function B
            }
            catch (Exception /*DivideByZeroException*/ ex)
            {
                Console.WriteLine("method A (FormatDataForDisplay) catch block");
                throw /*ex*/;
            }
            finally
            {
                Console.WriteLine("method A (FormatDataForDisplay) finally block");
            }
        }
        #endregion

        #region Function B
        static void ProcessData()
        {
            try
            {
                Console.WriteLine("method B (ProcessData) works");
                GetFile();// Function C
            }
            catch (Exception /*DivideByZeroException*/ ex)
            {
                Console.WriteLine("method B (ProcessData) catch block");
                throw /*ex*/;
            }
            finally
            {
                Console.WriteLine("method B (ProcessData) finally block");
            }
        }
        #endregion

        #region Function C
        static void GetFile()
        {
            Console.WriteLine("method C (GetFile) works");
            File.Open("text.txt", FileMode.Open);
            //throw new IOException("Data File Data.txt was not found");
        }
        #endregion
    }
}
