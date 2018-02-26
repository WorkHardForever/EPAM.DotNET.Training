using System;
using Ninject;//InjectProperty
using Ninject.Activation;//IProvider,Provider
using Ninject.Modules;//NinjectModule

//http://lunarfrog.com/blog/2009/12/01/dependency-injection-ninject-di-net/
namespace SimpleExampleNinject
{
    #region Problem
    //public class Engine
    //{
    //    public double GetSize()
    //    {
    //        return 2.5; // in liters
    //    }
    //}

    //public class Car
    //{
    //    private readonly Engine engine;

    //    public Car()
    //    {
    //        engine = new Engine();
    //    }

    //    public void GetDescription()
    //    {
    //        Console.WriteLine("Engine size: {0}", engine.GetSize());
    //    }
    //}

    //public class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Car car = new Car();
    //        car.GetDescription();
    //    }
    //} 
    #endregion

    #region DIP Solution

    //public interface IEngine
    //{
    //    double GetSize();
    //}

    //public class Engine : IEngine
    //{
    //    public double GetSize()
    //    {
    //        return 2.5; // in liters
    //    }
    //}

    //public class Car
    //{
    //    private readonly IEngine engine;

    //    public Car(IEngine engine)
    //    {
    //        this.engine = engine;
    //    }

    //    public void GetDescription()
    //    {
    //        Console.WriteLine("Engine size: {0}", engine.GetSize());
    //    }
    //}

    //public class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        #region Плюс
    //        //Получившееся в результате решение легче расширяемо, 
    //        //более тестируемо и является примером реализации паттерна 
    //        //Dependency Injection (внедрение зависимости) – зависимость 
    //        //машина-двигатель конфигурируется не внутри класса, 
    //        //а двигатель, созданный вне класса, внедряется в него. 
    //        #endregion
    //        IEngine engine = new Engine();//!!!
    //        #region Минус
    //        //Минус такого решения – потерялась простота создания нового 
    //        //экземпляра класса Car. Если в программе достаточно 
    //        //много подобных зависимостей, их все придется создавать вручную 
    //        //снова и снова. Поэтому, мы пойдем дальше и посмотрим, как
    //        //можно облегчить жизнь используя Ninject, фреймворк для 
    //        //автоматического внедрения зависимостей. 
    //        #endregion
    //        var car = new Car(engine);
    //        car.GetDescription();
    //    }
    //}

    #endregion

    #region Ninject Solution

    //public interface IEngine
    //{
    //    double GetSize();
    //}

    //public class Engine : IEngine
    //{
    //    public double GetSize()
    //    {
    //        return 2.5; // in liters
    //    }
    //}

    //public class Car
    //{
    //    private readonly IEngine engine;

    //    public Car(IEngine engine)
    //    {
    //        this.engine = engine;
    //    }

    //    public void GetDescription()
    //    {
    //        Console.WriteLine("Engine size: {0}", engine.GetSize());
    //    }
    //}

    //public class ModuleConfig : NinjectModule
    //{
    //    #region Overrides of NinjectModule

    //    public override void Load()
    //    {
    //        this.Bind<IEngine>().To<Engine>();
    //        this.Bind<Car>().ToSelf();
    //    }

    //    #endregion
    //}

    //public class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        IKernel kernel = new StandardKernel(new ModuleConfig());
    //        var car = kernel.Get<Car>();
    //        car.GetDescription();
    //        Console.ReadKey();
    //    }
    //}

    #endregion

    #region Injection Patterns in Ninject
    //http://dotnetslackers.com/articles/csharp/Get-Started-with-Ninject-2-0-in-C-sharp-Programming.aspx#s1-introduction
    interface IWeapon
    {
        void Hit(string target);//hit - удар
    }

    class Sword : IWeapon//sword - меч
    {
        public void Hit(string target)
        {
            Console.WriteLine("Killed {0} using Sword", target);
        }
    }

    class Gun : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine("Killed {0} using Gun", target);
        }
    }

    class Soldier
    {
        #region Property injection in action

        [Inject]
        public IWeapon Weapon { get; set; }

        public void Attack(string target)
        {
            Weapon.Hit(target);
        }

        #endregion

        #region Constructor injection in action

        //private IWeapon weapon;

        ////[Inject]
        //public Soldier(IWeapon weapon)
        //{
        //    this.weapon = weapon;
        //}

        //public void Attack(string target)
        //{
        //    weapon.Hit(target);
        //}

        #endregion

        #region Method injection in action

        //private IWeapon weapon;

        //[Inject]
        //public void Arm(IWeapon weapon)
        //{
        //    this.weapon = weapon;
        //} 

        //public void Attack(string target)
        //{
        //    weapon.Hit(target);
        //}

        #endregion
    }

    public class SwordProvider<T> : Provider<T>
    {
        public T Value { get; private set; }
        public SwordProvider(T value)
        {
            Value = value;
        }
        protected override T CreateInstance(IContext context)
        {
            // do some sort of complex custom initialization
            return Value;
        }
    }

    class WarriorModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWeapon>().To<Sword>();
            Bind<Soldier>().ToSelf();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //IKernel kernel = new StandardKernel(new WarriorModule());
            //Soldier warrior = kernel.Get<Soldier>();
            //warrior.Attack("the foemen");

            //IKernel kernel = new StandardKernel();
            //kernel.Bind<IWeapon>().To<Gun>();
            //Soldier warrior = kernel.Get<Soldier>();
            //warrior.Attack("the foemen");
            ////unbind test
            //kernel.Unbind<IWeapon>();
            //kernel.Bind<IWeapon>().To<Sword>();
            //Soldier warrior2 = kernel.Get<Soldier>();
            //warrior2.Attack("the foemen");

            #region Bind to Provider
            //IKernel kernel = new StandardKernel();
            //kernel.Bind<IWeapon>().ToProvider(new SwordProvider<Sword>(new Sword()));
            //Soldier warrior = kernel.Get<Soldier>();
            //warrior.Attack("the foemen"); 
            #endregion

            #region Factory Methods  
            //delegate lighter then provider
            IKernel kernel = new StandardKernel();
            kernel.Bind<IWeapon>().ToMethod(context => new Gun());
            Soldier warrior = kernel.Get<Soldier>();
            warrior.Attack("the foemen");

            kernel.Unbind<IWeapon>();
            kernel.Bind<IWeapon>().ToMethod(context => new Sword());
            kernel.Get<Soldier>().Attack("the foemen");
            Console.ReadKey(); 
            #endregion
        }
    }

    #endregion

    #region Contextual Binding

    //public interface ILogger
    //{
    //    void Write(string message);
    //}

    //public class FlatFileLogger : ILogger
    //{
    //    public void Write(string message)
    //    {
    //        Console.WriteLine(String.Format("Message:{0}", message));
    //        Console.WriteLine("Target:FlatFile");
    //    }
    //}

    //public class DatabaseLogger : ILogger
    //{
    //    public void Write(string message)
    //    {
    //        Console.WriteLine(String.Format("Message:{0}", message));
    //        Console.WriteLine("Target:Database");
    //    }
    //}

    //interface ITester
    //{
    //    void Test();
    //}
    
    //class IocTester : ITester
    //{
    //    private ILogger _logger;

    //    public IocTester() { }//This parameterless constructor is required by 'Activator.CreateInstance'

    //    public IocTester(ILogger logger)
    //    {
    //        _logger = logger;
    //    }

    //    public void Test()
    //    {
    //        _logger.Write("John Says: Hello Ninject!");
    //    }
    //}
    
    //public class ToConstantServiceModule : NinjectModule
    //{
    //    private readonly Type testerType;

    //    public ToConstantServiceModule(Type TesterType)
    //    {
    //        testerType = TesterType;
    //    }

    //    public override void Load()
    //    {
    //        Bind<ILogger>().To<FlatFileLogger>();
    //        var testertype = Activator.CreateInstance(testerType) as ITester;
    //        Bind<ITester>().ToConstant(testertype);
    //    }
    //}

    //public class SingletonServiceModule : NinjectModule
    //{
    //    public override void Load()
    //    {
    //        Bind<IocTester>().ToSelf().InSingletonScope();
    //    }
    //}

    //public class WithConstructorArgumentServiceModule : NinjectModule
    //{
    //    public override void Load()
    //    {
    //        Bind<ILogger>().To<FlatFileLogger>();
    //        Bind<ITester>().To<IocTester>().WithConstructorArgument("logger", new FlatFileLogger());
    //    }
    //}

    //class ContextualBindingDemo
    //{
    //    static void Main(string[] args)
    //    {
    //        IKernel kernel = new StandardKernel(new WithConstructorArgumentServiceModule());
    //        IocTester tester = kernel.Get<IocTester>();
    //        tester.Test();
    //        Console.WriteLine("continues..");
    //        Console.Read();
    //    }
    //}

    #endregion
}
