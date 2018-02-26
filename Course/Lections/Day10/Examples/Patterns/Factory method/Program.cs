using System;

//Фабричный метод (Factory Method)
//Синонимы: Виртуальный конструктор (Virtual Constructor)
//Определяет интерфейс для создания объектов, при этом выбранный класс инстанцируется подклассами,
//то есть оставляет подклассам решение о том, какой класс инстанцировать. Фабричный метод позволяет 
//классу делегировать инстанцирование подклассам. Фабричные методы избавляют проектировщика встраивать
//в код зависящие от приложения классы.
//
//Порождает один объект с определенным интерфейсом.
//Метод класса, который переопределяется потомками.
//Скрывает реализацию объекта.

#region Абстрактный метод или метод из интерфейса
//Данный подход обязывает потомка определить свои реализации
//Фабричного метода и порождаемого им класса.

namespace Factory_method
{
    public interface IProduct
    {
        string Brend();
    }

    public class ProductA : IProduct
    {
        public String Brend()
        {
            return "D&G";
        }
    }

    public class ProductB : IProduct
    {
        public String Brend()
        {
            return "Casio";
        }
    }

    public class ProductC : IProduct
    {
        public String Brend()
        {
            return "Seiko";
        }
    }

    public abstract class Creator
    {
        public abstract IProduct FactoryMethod();
    }

    public class CreatorProductA : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ProductA();
        }
    }

    public class CreatorProductB : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ProductB();
        }
    }

    public class CreatorProductC : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ProductC();
        }
    }

    class Program
    {
        private static void Main(string[] args)
        {
            int b = int.Parse(Console.ReadLine());
            Creator creator;
            switch (b)
            {
                case 1:
                    creator = new CreatorProductA();
                    break;
                case 2:
                    creator = new CreatorProductB();
                    break;
                case 3: 
                    creator= new CreatorProductC();
                    break;
                default:
                    creator = new CreatorProductA();
                    break;
            }
            //var creator = new Creator[] { new CreatorProductA(), new CreatorProductB(), new CreatorProductC() };
            //foreach (var temp in creator)
            //{
            //    Watch(temp);
            //}
            Watch(creator);
            Console.ReadKey();
        }

        static void Watch(Creator creator)
        {
            IProduct product = creator.FactoryMethod();
            Console.WriteLine(product.Brend());
        }
    }
} 
#endregion

#region Частный случай Фабричного метода
//Входной параметр используется для определения, какую реализацию интерфейса требуется создать

//namespace FactoryPattern
//{
//    internal interface IProduct
//    {
//        string ShipFrom(int month);
//    }

//    internal class ProductA : IProduct
//    {
//        public string ShipFrom(int month)
//        {
//            return "from South Africa";
//        }
//    }

//    internal class ProductB : IProduct
//    {
//        public string ShipFrom(int month)
//        {
//            return "from Spain";
//        }
//    }

//    internal class DefaultProduct : IProduct
//    {
//        public String ShipFrom(int month)
//        {
//            return "not available";
//        }
//    }

//    internal class Creator
//    {
//        public static IProduct FactoryMethod(int month)
//        {
//            if (month >= 4 && month <= 11)
//                return new ProductA();
//            if (month == 1 || month == 2 || month == 12)
//                return new ProductB();
//            return new DefaultProduct();
//        }
//    }

//    internal class Program
//    {
//        private static void Main(string[] args)
//        {
//            for (int i = 1; i <= 12; i++)
//            {
//                var product = Creator.FactoryMethod(i);
//                Console.WriteLine("Avocados " + product.ShipFrom(i));
//            }

//            Console.ReadKey();
//        }
//    }
//}
#endregion