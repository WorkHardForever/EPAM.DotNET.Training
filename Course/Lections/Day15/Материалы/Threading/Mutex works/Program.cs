using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Mutex_works
{
    class Program
    {
        static void Main(string[] args)
        {
            var mut = new Mutex(false, "MutexForFile");
            var writer = new Process {StartInfo = {FileName = "FileWriter.exe"}};
            var reader = new Process {StartInfo = {FileName = "FileReader.exe"}};
            writer.Start();
            reader.Start();
            Console.WriteLine("++++++");
            writer.WaitForExit();
            Console.WriteLine("8749672984757984");
            reader.WaitForExit();
            Console.WriteLine("-----------------");
            mut.Close();
            Console.ReadKey();
        }
    }
}
