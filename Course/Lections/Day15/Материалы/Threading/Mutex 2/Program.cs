using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            while (i < 100000)
            {
                if (File.Exists("1.txt"))
                {
                    var sr = new StreamReader("1.txt");
                    while (!sr.EndOfStream)
                    {
                        Console.WriteLine(sr.ReadLine());
                        i++;
                    }
                    sr.Close();
                    File.Delete("1.txt");
                }
            }
        }
    }
}
