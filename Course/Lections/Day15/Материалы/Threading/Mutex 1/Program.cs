using System;
using System.IO;

namespace FileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            for (int i = 0; i < 100000; i++)
            {
                var sw = new StreamWriter("1.txt", true);
                sw.WriteLine(rnd.Next(100000));
                sw.Close();
            }  
        }
    }
}
