using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;

namespace ConsoleUI_1
{
    class Program
    {
        //public delegate void F();
        static void Main(string[] args)
        {

            Car car = new Car();
            var library = new[]
            {
                new Book("Author 1","Title 1", car) { ID = 1, Publisher = "Publisher 1"},
                new Book("Author 2","Title 2", car) { ID = 2, Publisher = "Publisher 2"},
                new Book("Author 3","Title 3", car) { ID = 3, Publisher = "Publisher 3"},
            };

            foreach (var lib in library)
            {
                Debug.WriteLine(lib.ToString());
            }


            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            //Этот метод позволяет узнать, какие сборки .NET были загружены в данный домен 
            //приложения (двоичные файлы СОМ и С игнорируются)
            foreach (Assembly ass in assemblies)
            {
                Debug.WriteLine(ass.ToString());
            }

            var assembly = typeof(Program).Assembly;
            Debug.WriteLine(assembly.CodeBase);// полный путь где находиться запускаемая сборка
            Debug.WriteLine(assembly.FullName); //имя, версия, культура и ключ
            Debug.WriteLine(assembly.EntryPoint);//точка входа - это функция main
        }
    }
}
