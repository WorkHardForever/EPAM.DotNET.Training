using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_ControllerSample.Controllers
{
    // Базовый класс Controller наследует тип ControllerBase, который реализует метод Execute().
    // Также тип Controller обеспечивает связь с системой представлений.
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Message = "Hello from HomeController";
            return View("MyView");
        }

    }
}
