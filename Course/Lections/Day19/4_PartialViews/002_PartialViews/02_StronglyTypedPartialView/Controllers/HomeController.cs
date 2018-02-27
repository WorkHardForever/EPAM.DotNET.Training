using _02_StronglyTypedPartialView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_StronglyTypedPartialView.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product()
            {
                Id = 1,
                Name = "Item 1",
                Price = 10
            });
            products.Add(new Product()
            {
                Id = 2,
                Name = "Item 2",
                Price = 5
            });
            products.Add(new Product()
            {
                Id = 3,
                Name = "Item 3",
                Price = 50
            });

            return View(products);
        }
    }
}
