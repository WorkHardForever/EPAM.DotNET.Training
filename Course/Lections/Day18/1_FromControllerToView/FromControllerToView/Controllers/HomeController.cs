using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FromControllerToView.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Action1()
        {
            DateTime date = DateTime.Now;

            // Передача данных в представление.
            return View(date);
        }

        public ActionResult Action2()
        {
            // Использование объекта ViewBag (это динамический тип данных).
            ViewBag.Date = DateTime.Now;
            return View();
        }

        public ActionResult Action3()
        {
            // Запись данных во ViewData для представления.
            ViewData["Date"] = DateTime.Now;
            return View();
        }

    }
}
