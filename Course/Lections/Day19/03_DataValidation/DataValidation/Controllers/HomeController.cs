using DataValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataValidation.Controllers
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
        public ActionResult Index(AccountModel model)
        {
            // нет проверки данных модели!
            // нельзя продолжать работать с моделью так как в ней могут быть не допустимые значения.

            return View("Success");
        }

    }
}
