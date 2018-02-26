using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new Thread(Go).Start();
            }
            //try/catch здесь  бесполезны, и NullReferenceException во вновь созданном 
            //потоке обработано не будет, потому, что поток имеет свой независимый путь исполнения. 
            //Решение состоит в добавлении обработки исключений непосредственно в метод потока
            catch (Exception ex)
            {
                // Сюда мы никогда не попадем!
                Console.WriteLine("Исключение!");
            }
           
        }

        static void Go()
        {
            try
            {
                throw new NullReferenceException();      // это исключение будет поймано ниже
            }
            catch (Exception ex)
            {
                //Логирование исключения и/или сигнал другим потокам
            }
            //throw new NullReferenceException();
        }
    }
}
