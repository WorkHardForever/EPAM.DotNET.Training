using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace _002_SimpleAjaxApplication.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string Customer { get; set; }
        public int Quantity { get; set; }
    }

    class OrdersDatabase
    {
        public static IEnumerable<Order> Orders
        {
            get
            {
                Thread.Sleep(2000);

                List<Order> list = new List<Order>();
                list.Add(new Order() { Id = 1, Product = "Product 1", Customer = "Ivanov", Quantity = 1 });
                list.Add(new Order() { Id = 2, Product = "Product 2", Customer = "Petrov", Quantity = 10 });
                list.Add(new Order() { Id = 3, Product = "Product 2", Customer = "Fedorov", Quantity = 12 });
                list.Add(new Order() { Id = 4, Product = "Product 3", Customer = "Fedorov", Quantity = 6 });
                list.Add(new Order() { Id = 5, Product = "Product 1", Customer = "Petrov", Quantity = 7 });
                list.Add(new Order() { Id = 6, Product = "Product 4", Customer = "Ivanov", Quantity = 11 });
                list.Add(new Order() { Id = 7, Product = "Product 2", Customer = "Petrov", Quantity = 10 });
                list.Add(new Order() { Id = 8, Product = "Product 5", Customer = "Petrov", Quantity = 2 });
                list.Add(new Order() { Id = 9, Product = "Product 1", Customer = "Ivanov", Quantity = 11 });
                list.Add(new Order() { Id = 10, Product = "Product 5", Customer = "Fedorov", Quantity = 3 });
                list.Add(new Order() { Id = 11, Product = "Product 2", Customer = "Petrov", Quantity = 3 });
                list.Add(new Order() { Id = 12, Product = "Product 1", Customer = "Ivanov", Quantity = 3 });
                list.Add(new Order() { Id = 13, Product = "Product 4", Customer = "Petrov", Quantity = 7 });
                return list;
            }
        }

    }
}