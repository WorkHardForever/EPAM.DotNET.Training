using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartialViews.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Homw/

        public ActionResult Index()
        {
            return View();
        }

    }
}
