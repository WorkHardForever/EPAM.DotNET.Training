using CustomValidationAttribute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomValidationAttribute.Controllers
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
            if (ModelState.IsValid)
            {
                return View("Success");
            }

            return View();
        }

    }
}
