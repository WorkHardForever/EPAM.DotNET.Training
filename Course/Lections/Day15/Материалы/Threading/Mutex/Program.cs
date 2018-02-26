using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Mutex
{
    class Program
    {
        static void Main(string[] args)
        {
            var writer = new Process {StartInfo = {FileName = "FileWriter.exe"}};
            var reader = new Process {StartInfo = {FileName = "FileReader.exe"}};
            writer.Start();
            reader.Start();
            writer.WaitForExit();//Дает компоненту Process команду ожидать неопределенно долго 
            reader.WaitForExit();//до завершения связанного процесса
            Console.ReadKey();
        }
    }
}
