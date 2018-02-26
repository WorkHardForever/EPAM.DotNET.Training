//В следующем примере кода демонстрируются несколько свойств и методов универсального класса List<T> строчного типа.

//С помощью конструктора по умолчанию создается список строк с емкостью по умолчанию. 
//Выводится значение свойства Capacity, а затем с помощью метода Add добавляется несколько элементов.
//Выводится список этих элементов, а затем снова выводится значение свойства Capacity и вместе
//с ним — значение свойства Count, показывающее, что емкость увеличивается по мере необходимости.

//С помощью метода Contains проверяется наличие некоторого элемента в списке, с помощью метода 
//Insert в середину списка вставляется новый элемент, после чего снова выводится содержимое списка.

//С помощью свойства по умолчанию Item (индексатор в C#) из списка извлекается элемент, с помощью
//метода Remove удаляется первый экземпляр дублированного элемента, добавленный ранее, и содержимое 
//списка выводится вновь. Метод Remove всегда удаляет первый обнаруженный им экземпляр.

//С помощью метода TrimExcess емкость уменьшается в соответствии с числом элементов, и
//выводятся значения свойств Capacity и Count. Если незадействованная емкость составляет 
//менее 10% от общей емкости, изменение размера списка не требуется.

//В заключение используется метод Clear для удаления всех элементов из списка, и выводятся
//значения свойств Capacity и Count.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleListGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> dinosaurs = new List<string>();

            Console.WriteLine("\nCapacity: {0}", dinosaurs.Capacity);

            dinosaurs.Add("Tyrannosaurus");
            dinosaurs.Add("Amargasaurus");
            dinosaurs.Add("Mamenchisaurus");
            dinosaurs.Add("Deinonychus");
            dinosaurs.Add("Compsognathus");

            Console.WriteLine();
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            Console.WriteLine("\nCapacity: {0}", dinosaurs.Capacity);
            Console.WriteLine("Count: {0}", dinosaurs.Count);

            Console.WriteLine("\nContains(\"Deinonychus\"): {0}",
                dinosaurs.Contains("Deinonychus"));

            Console.WriteLine("\nInsert(2, \"Compsognathus\")");
            dinosaurs.Insert(2, "Compsognathus");

            Console.WriteLine();
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            Console.WriteLine("\ndinosaurs[3]: {0}", dinosaurs[3]);

            Console.WriteLine("\nRemove(\"Compsognathus\")");
            dinosaurs.Remove("Compsognathus");

            Console.WriteLine();
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            dinosaurs.TrimExcess();
            Console.WriteLine("\nTrimExcess()");
            Console.WriteLine("Capacity: {0}", dinosaurs.Capacity);
            Console.WriteLine("Count: {0}", dinosaurs.Count);

            dinosaurs.Clear();
            Console.WriteLine("\nClear()");
            Console.WriteLine("Capacity: {0}", dinosaurs.Capacity);
            Console.WriteLine("Count: {0}", dinosaurs.Count);
            Console.ReadKey();
        }
    }
}