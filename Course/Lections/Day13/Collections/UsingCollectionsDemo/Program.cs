using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Collections;

namespace UsingCollectionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //SortedList представляет коллекцию пар ключ / значение,
            //которые отсортированы по ключу и доступны по ключу и по индексу.
            SortedList people = new SortedList();
            people.Add("Richard", new Person { Name = "Richard", Age = 32 });
            Person louisa = new Person()
            {
                Name = "Louisa",
                Age = 25
            };
            people.Add(louisa.Name, louisa);

            Person personFromCollection = (Person)people["Richard"];

            if (personFromCollection != null)
            {
                Console.WriteLine("Name: {0}, Age: {1}", personFromCollection.Name, personFromCollection.Age.ToString());
            }

            Console.ReadLine();
            //Структура DictionaryEntry оОпределяет пару словаря ключ / значение,
            //которые можно установить или извлечь

            foreach (DictionaryEntry entry in people)
            {
                Person person = (Person)entry.Value;
                Console.WriteLine("Name: {0}, Age: {1}", person.Name, person.Age.ToString());
            }

            SortedList people2 = new SortedList()
                                     {
                                         {"Lara", new Person {Name = "Lara", Age = 32}},
                                         {"Rechard", new Person {Name = "Rechard", Age = 35}}
                                     };
            Queue people3 = new Queue();
                                //{
                                //     {"Lara", new Person {Name = "Lara", Age = 32}},
                                //         {"Rechard", new Person {Name = "Rechard", Age = 35}}
                                //}

            Console.ReadLine();
        }
    }
}
