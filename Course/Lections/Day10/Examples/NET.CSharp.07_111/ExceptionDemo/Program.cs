using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NestedTryBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Outer try block.
                //...
                try
                {
                    //throw new FileNotFoundException();// Nested try block
                    //throw  new DivideByZeroException();
                    throw new ArgumentOutOfRangeException();
                }
                catch (FileNotFoundException ex)
                {
                    // Catch block for nested try block
                    Console.WriteLine(ex.Message);   //не удалось найти указанный файл
                }
                //...
                // Outer try block continued
                finally
                {

                }
            }
            catch (DivideByZeroException ex)
            {
                // Catch block, can access DivideByZeroException exception in ex.
                Console.WriteLine(ex.Message);    // попытка деления на нуль.
            }
            catch (Exception ex)
            {
                // Catch block, can access exception in ex.
                Console.WriteLine(ex.Message);
                //Заданный аргумент находит вне диапазона допустимых значений.
            }
            finally
            {

            }
            Console.Read();

        }
    }
}