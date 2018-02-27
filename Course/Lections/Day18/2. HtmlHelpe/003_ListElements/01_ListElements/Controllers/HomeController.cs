using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_ListElements.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string list1, string[] list2)
        {
            ViewBag.Selected1 = list1;

            string result = string.Empty;
            foreach (var item in list2)
            {
                result += item + ", ";
            }
            ViewBag.Selected2 = result.TrimEnd(',', ' ');

            return View();
        }

    }
}
