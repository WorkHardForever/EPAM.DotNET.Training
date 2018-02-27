using _02_ListElements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_ListElements.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            List<Product> products = new List<Product>() 
            {
                new Product() { Id = 1, Name ="Product #1"},
                new Product() { Id = 2, Name ="Product #2"},
                new Product() { Id = 3, Name ="Product #3"},
                new Product() { Id = 4, Name ="Product #4"}
            };

            ViewBag.Products = new SelectList(products, "Id", "Name", 2);

            return View();
        }

        [HttpPost]
        public ActionResult Index(string Products)
        {
            return View("Selected", (object)Products);
        }

    }
}
