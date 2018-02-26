#region Abstract Factory Description
//Предоставление интерфейса для создания семейств связанных между собой или
//зависимых друг от друга объектов без указания их конкретных классов

//Реализуется путем создания абстрактного класса или интерфейса Factory,
//предоставляющего собой интерфейс для создания абстрактных объектов продуктов

//Назначение - Требуется организовать работу с семействами или наборами объектов для определенных
//объектов-клиентов (или отдельных случаев)

//Задача - Необходимо создать экземпляры объектов, принадлежащих заданному семейству

//Способ решения - Координация процесса создания семейств объектов. Предусматривается выделение
//реализации правила создания тех или иных семейств объектов из объекта"клиента, который в
//дальнейшем будет использовать созданные объекты, в отдельный объект

//Участники - Класс AbstractFactory (или интерфейс IFactory) определяет интерфейс для создания 
//каждого из объектов заданного семейства. Как правило, каждое семейство создается с помощью
//собственного конкретного уникального класса ConcreteFactory

//Следствия - Шаблон отделяет правила, какие объекты нужно использовать, от правил, как эти объекты
//следует использовать

//Реализация - Определяется абстрактный класс, описывающий, какие объекты должны быть созданы. Затем
//реализуется по одному конкретному классу для каждого семейства объектов
#endregion

using System;

#region Using intrfaces

namespace Abstract_factory
{
    interface IContinentFactory
    {
        IHerbivore CreateHerbivore();
        
        ICarnivore CreateCarnivore();
    }

    //На основании абстрактного класса или интерфейса строятся один или несколько
    //конкретных классов фабрик, создающих конкретные объекты-продукты
    class AfricaFactory : IContinentFactory
    {
        public IHerbivore CreateHerbivore()
        {
            return new Wildebeest();
        }

        public ICarnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    class AmericaFactory : IContinentFactory
    {
        public IHerbivore CreateHerbivore()
        {
            return new Bison();
        }

        public ICarnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }

    interface IHerbivore { }

    interface ICarnivore
    {
        string Eat(IHerbivore herbivore);
    }

    internal class Wildebeest : IHerbivore { }

    internal class Lion : ICarnivore
    {
        public string Eat(IHerbivore herbivore)
        {
            return String.Format("{0} eats {1}", GetType().Name, herbivore.GetType().Name);
        }
    }

    internal class Bison : IHerbivore { }

    internal class Wolf : ICarnivore
    {
        public string Eat(IHerbivore herbivore)
        {

            return String.Format("{0} eats {1}", GetType().Name, herbivore.GetType().Name);
        }
    }

    //Клиентский код использует в работе только интерфейсы. 
    //Реализации Абстрактной фабрики и порождаемых ею объектов скрыты. 
    //Такой подход уменьшает зависимости между объектами и повышает гибкость, 
    //за счет возможности изменения реализаци
    internal class AnimalWorld
    {
        private readonly ICarnivore carnivore;
        private readonly IHerbivore herbivore;

        public AnimalWorld(IContinentFactory factory)
        {
            carnivore = factory.CreateCarnivore();
            herbivore = factory.CreateHerbivore();
        }

        public string RunFoodChain()
        {
            return carnivore.Eat(herbivore);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Шаблон проектирования, позволяющий изменять поведение системы, 
            //варьируя создаваемые объекты, сохраняя при этом интерфейсы
            IContinentFactory africa = new AfricaFactory();
            var world = new AnimalWorld(africa);
            Console.WriteLine(world.RunFoodChain());

            IContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            Console.WriteLine(world.RunFoodChain());

            Console.ReadKey();
        }
    }
}
#endregion

#region Using abstract classes
//namespace Abstract_factory
//{
//    internal abstract class ContinentFactory
//    {
//        public abstract Herbivore CreateHerbivore();
//        public abstract Carnivore CreateCarnivore();
//    }

//    internal class AfricaFactory : ContinentFactory
//    {
//        public override Herbivore CreateHerbivore()
//        {
//            return new Wildebeest();
//        }

//        public override Carnivore CreateCarnivore()
//        {
//            return new Lion();
//        }
//    }

//    internal class AmericaFactory : ContinentFactory
//    {
//        public override Herbivore CreateHerbivore()
//        {
//            return new Bison();
//        }

//        public override Carnivore CreateCarnivore()
//        {
//            return new Wolf();
//        }
//    }

//    internal abstract class Herbivore { }

//    internal abstract class Carnivore
//    {
//        public abstract void Eat(Herbivore herbivore);
//    }

//    internal class Wildebeest : Herbivore { }

//    internal class Lion : Carnivore
//    {
//        public override void Eat(Herbivore herbivore)
//        {
//            string eatString = String.Format("{0} eats {1}", GetType().Name, herbivore.GetType().Name);
//            Console.WriteLine(eatString);
//        }
//    }

//    internal class Bison : Herbivore { }

//    internal class Wolf : Carnivore
//    {
//        public override void Eat(Herbivore herbivore)
//        {

//            string eatString = String.Format("{0} eats {1}", GetType().Name, herbivore.GetType().Name);
//            Console.WriteLine(eatString);
//        }
//    }

//    internal class AnimalWorld
//    {
//        private Carnivore carnivore;
//        private Herbivore herbivore;

//        public AnimalWorld(ContinentFactory factory)
//        {
//            carnivore = factory.CreateCarnivore();
//            herbivore = factory.CreateHerbivore();
//        }

//        public void RunFoodChain()
//        {
//            carnivore.Eat(herbivore);
//        }
//    }

//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            ContinentFactory africa = new AfricaFactory();
//            AnimalWorld world = new AnimalWorld(africa);
//            world.RunFoodChain();

//            ContinentFactory america = new AmericaFactory();
//            world = new AnimalWorld(america);
//            world.RunFoodChain();

//            Console.Read();
//        }
//    }
//} 
#endregion

