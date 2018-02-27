using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _05_HttpCodesResultSamples.Controllers
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
            // Возвращение статуса 404 NotFound
            return HttpNotFound();
        }

        public ActionResult Action2()
        {
            int result;
            try
            {
                int a = 10, b = 0;
                result = a / b;
            }
            catch (Exception)
            {
                // Возвращение статуса 500 Internal Server Error
                return new HttpStatusCodeResult(500, "Internal Server Error");
            }

            return Content(result.ToString());
        }
    }
}
