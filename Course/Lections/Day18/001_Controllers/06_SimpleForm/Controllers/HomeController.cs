using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _06_SimpleForm.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost] // метод будет вызываться только при POST запросах
        public ActionResult Index(int x, int y)
        {
            ViewBag.Result = x + y;

            return View();
        }

    }
}
