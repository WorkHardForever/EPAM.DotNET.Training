using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionResultSamples.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GoTo1()
        {
            // Переход со статус кодом 302 - временное перенаправление.
            // Использование метода из базового класса Controller
            return Redirect("http://msdn.com");
        }

        public ActionResult GoTo2()
        {
            // Переход со статус кодом 302 - временное перенаправление.
            // Использование экземпляра класса RedirectResult
            return new RedirectResult("http://msdn.com");
        }

        public ActionResult GoTo3()
        {
            // Переход со статус кодом 301 - постоянное перенаправление.
            return RedirectPermanent("http://msdn.com");
            // Второй вариант постоянного перенаправления.
            //return new RedirectResult("http://msdn.com", true);
        }

        public ActionResult GoTo4()
        {
            return RedirectToRoute(new { 
                controller = "TestRedirect",
                action = "Index",
                id = "Hello from RedirectToRoute"
            });
        }

        public ActionResult GoTo5()
        {
            return RedirectToAction("Index", "TestRedirect", 
                new { id = "Hello from RedirectToAction" });
        }
    }
}
