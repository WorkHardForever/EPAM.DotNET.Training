using System;
using System.Collections.Generic;

namespace Factory_method_2
{
    //определение интерфейса объектов, создаваемых фабричным методом
    interface IProduct
    {
        decimal PurchasePrice { get; set; }

        decimal Price { get; set; }

        string Description { get; set; }
    }

    class Computer : IProduct
    {
        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal PurchasePrice { get; set; }

        public Computer() : this(null) { }

        public Computer(string description) : this(description, 0) { }

        public Computer(string description, decimal purchasePrice) : this(description, purchasePrice, 0) { }

        public Computer(string description, decimal purchasePrice, decimal price)
        {
            this.Description = description;
            this.PurchasePrice = purchasePrice;
            this.Price = price;
        }

        public override string ToString()
        {
            return string.Format("Object {0}\n" +
                     "Description: {1}\n" +
                     "Purchase Price: {2}\n" +
                     "Price: {3}\n",
                     this.GetType().Name,
                     this.Description,
                     this.PurchasePrice,
                     this.Price);
        }
    }

    class CDPlayer : IProduct
    {
        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal PurchasePrice { get; set; }

        public CDPlayer() : this(null) { }

        public CDPlayer(string description) : this(description, 0) { }

        public CDPlayer(string description, decimal purchasePrice) : this(description, purchasePrice, 0) { }

        public CDPlayer(string description, decimal purchasePrice, decimal price)
        {
            this.Description = description;
            this.PurchasePrice = purchasePrice;
            this.Price = price;
        }

        public override string ToString()
        {
            return string.Format("Object {0}\n" +
                     "Description: {1}\n" +
                     "Purchase Price: {2}\n" +
                     "Price: {3}\n",
                     this.GetType().Name,
                     this.Description,
                     this.PurchasePrice,
                     this.Price);
        }
    }

    abstract class Creator
    {
        //методы для всех видов конструкторов класса Computer
        public abstract IProduct FactoryMethod();

        public abstract IProduct FactoryMethod(string description);

        public abstract IProduct FactoryMethod(string description, decimal purchasePrice);

        public abstract IProduct FactoryMethod(string description, decimal purchasePrice, decimal price);
    }

    class ComputerCreator : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new Computer();
        }

        public override IProduct FactoryMethod(string description)
        {
            return new Computer(description);
        }

        public override IProduct FactoryMethod(string description, decimal purchasePrice)
        {
            return new Computer(description, purchasePrice);
        }

        public override IProduct FactoryMethod(string description, decimal purchasePrice, decimal price)
        {
            return new Computer(description, purchasePrice, price);
        }
    }

    class CDPlayerCreator : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new CDPlayer();
        }

        public override IProduct FactoryMethod(string description)
        {
            return new CDPlayer(description);
        }

        public override IProduct FactoryMethod(string description, decimal purchasePrice)
        {
            return new CDPlayer(description, purchasePrice);
        }

        public override IProduct FactoryMethod(string description, decimal purchasePrice, decimal price)
        {
            return new CDPlayer(description, purchasePrice, price);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var productList = new List<IProduct>();

            Creator[]  creators = { new ComputerCreator(), new CDPlayerCreator() };

            productList.Add(creators[0].FactoryMethod("Notebook", 600, 800));
            productList.Add(creators[1].FactoryMethod("audio,mp3,mp4", 250, 360));

            foreach (IProduct product in productList)
            {
                Console.WriteLine(product.ToString());
            }

            Console.ReadKey();
        }
    }
}
