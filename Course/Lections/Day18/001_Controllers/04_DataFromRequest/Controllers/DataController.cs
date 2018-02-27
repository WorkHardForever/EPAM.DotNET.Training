using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04_DataFromRequest.Controllers
{
    public class DataController : Controller
    {
        //
        // GET: /Data/

        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Data/DataInformation/

        public ActionResult PostInformation()
        {
            // Чтение данных, которые передаются с помощью POST запроса.
            ViewBag.Message = Request.Form["message"];
            return View("Index");
        }

        //
        // GET: /Data/RouteInformation/

        public ActionResult RouteInformation()
        {
            // Чтение данных, которые передаются с помощью GET запроса, как данные в маршруте.
            ViewBag.Message = RouteData.Values["id"];
            return View("Index");
        }

        //
        // GET: /Data/QueryInformation/

        public ActionResult QueryInformation()
        {
            // Чтение данных, которые передаются в адресной строке.
            ViewBag.Message = Request.QueryString["message"];
            return View("Index");
        }

    }
}
