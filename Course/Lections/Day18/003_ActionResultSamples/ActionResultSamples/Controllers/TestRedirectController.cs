using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionResultSamples.Controllers
{
    public class TestRedirectController : Controller
    {
        //
        // GET: /TestRedirect/

        public ActionResult Index(string id)
        {
            ViewBag.Message = id;
            return View();
        }

    }
}
