using _03_ModelData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03_ModelData.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product()
            {
                ProductId = 1,
                Name = "Шариковая ручка",
                Description = "Синяя шариковая ручка с колпачком и прозрачным корпусом.",
                Price = 3m,
                Category = "Канцтовары"
            });
            products.Add(new Product()
            {
                ProductId = 2,
                Name = "Мобильный телефон",
                Description = "Мобильный телефон с фотокамерой.",
                Price = 250m,
                Category = "Техника"
            });
            // Возвращаем представление из директории Views/Products/Index.cshtml
            // Параметр передающийся в метод View() является моделью, 
            //которая будет доступна только на чтение в представлении Index
            return View(products);
        }




        public ActionResult Index1()
        {
           Product product = new Product();

            return View(product);
        
        }
     
    }
}
