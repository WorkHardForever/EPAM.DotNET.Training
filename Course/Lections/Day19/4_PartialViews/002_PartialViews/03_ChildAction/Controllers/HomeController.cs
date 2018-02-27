using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03_ChildAction.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly] // метод может быть запущен только как дочернее действие
        public string CurrentDate()
        {
            return DateTime.Now.ToShortDateString();
        }

    }
}
