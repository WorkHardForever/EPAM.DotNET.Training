using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Паттерн Декоратор динамически наделяет объект новыми возможностями и является гибкой 
//альтернативой классическому наледованию в области расширения функциональности

//Декоратор имеет тот же базовы тип, что и декорируемый объект
//Объект можно завенуть в один или несколько декораторов
//Декоратор добавляет свое поведение до и (или) после делегирования операций
//декорируемому объекту, выполняющему остальную работу
//Объект может быть декориован динамически и с произвольным количестом декораторов

namespace Decorator
{
    // Decorator (Wrapper) Pattern 
    // Shows two decorators and the output of various
    // combinations of the decorators on the basic component

    public interface IComponent
    {
        string Operation();
    }

    public class Component : IComponent
    {
        public string Operation()
        {
            return "I am walking ";
        }
    }

    public class DecoratorA : IComponent
    {
        IComponent component;

        public DecoratorA(IComponent c)
        {
            component = c;
        }

        public string Operation()
        {
            string s = component.Operation();
            s += "and listening to Classic FM ";
            return s;
        }
    }

    public class DecoratorB : IComponent
    {
        IComponent component;
        public string addedState = "past the Coffee Shop ";

        public DecoratorB(IComponent c)
        {
            component = c;
        }

        public string Operation()
        {
            string s = component.Operation();
            s += "to University ";
            return s;
        }

        public string AddedBehavior()
        {
            return "and I bought a cappuccino ";
        }
    }

    public class Client
    {
        public static void Display(string s, IComponent c)
        {
            Console.WriteLine(s + c.Operation());
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Decorator Pattern\n");

            IComponent component = new Component();
            Client.Display("1. Basic component: ", component);
            IComponent component1 = new DecoratorA(component);
            Client.Display("2. A-decorated : ", component1);
            Client.Display("3. B-decorated : ", new DecoratorB(component));
            Client.Display("4. B-A-decorated : ", new DecoratorB(new DecoratorA(component)));
            // Explicit DecoratorB
            var b = new DecoratorB(new Component());
            Client.Display("5. A-B-decorated : ", new DecoratorA(b));
            // Invoking its added state and added behavior
            Console.WriteLine("\t\t\t" + b.addedState + b.AddedBehavior());
            Console.ReadLine();
        }
    }
}
