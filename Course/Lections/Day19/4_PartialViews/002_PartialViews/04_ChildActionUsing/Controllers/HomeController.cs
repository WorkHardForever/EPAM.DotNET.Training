using _04_ChildActionUsing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04_ChildActionUsing.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult ShowTable(int numberOfRows = 5)
        {
            IEnumerable<Product> products = ProductCollection.All.Take(numberOfRows);
            return PartialView("_Table", products);
        }

    }
}
