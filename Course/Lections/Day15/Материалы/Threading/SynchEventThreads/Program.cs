using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace SynchEventThreads
{
    class Program
    {
        static AutoResetEvent exit = null;

        static void Copy()
        {
            FileStream reader = new FileStream(@"C:\Users\kravchuk\Desktop\1.txt", FileMode.Open);
            FileStream writer = new FileStream(@"C:\Users\kravchuk\Desktop\2.txt", FileMode.Create);
            byte[] buffer = new byte[1024 * 1024];
            // Цикл, пока не кончится файл или пока пользователь не нажмет кнопку на клавиатуре
            while (!exit.WaitOne(500) && reader.Position < reader.Length)
            {
                int readedBytesCount = reader.Read(buffer, 0, buffer.Length);
                writer.Write(buffer, 0, readedBytesCount);
                Console.Write(".");
            }
            writer.Close();
            if (reader.Position < reader.Length)
            {
                Console.WriteLine();
                Console.WriteLine("Отмена копирования");
                File.Delete(@"C:\Users\kravchuk\Desktop\2.txt");
            }
            else
            {
                Console.WriteLine("Копирование завершено");
            }
            reader.Close();
        }

        static void Main(string[] args)
        {
            exit = new AutoResetEvent(false);
            var longOperatioin = new Thread(Copy);
            longOperatioin.Start();
            Console.WriteLine("Идет копирование файла. Нажатие любой клавиши прервет операцию.");
            Console.ReadKey();
            exit.Set();
            Console.ReadKey();
        }
    }
}
