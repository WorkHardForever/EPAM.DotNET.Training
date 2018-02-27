using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_HtmlHelperMethods.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Days = new string[] { "Monday", "Tuesday", "Wednesday" };
            ViewBag.Fruits = new string[] { "Mango", "Banana", "Apple" };

            return View();
        }

    }
}
