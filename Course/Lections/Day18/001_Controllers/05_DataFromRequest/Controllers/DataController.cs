using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _05_DataFromRequest.Controllers
{
    public class DataController : Controller
    {
        //
        // GET: /Data/

        public ActionResult Index()
        {
            return View();
        }

        // Платформа предоставит значения для параметров, проверив соответствующие объекты контекста,
        // включая Request.Form, RouteData.Values, Request.QueryString

        //
        // POST: /Data/PostInformation

        public ActionResult PostInformation(string message)
        {
            //ViewBag.Message = Request.Form["message"];
            ViewBag.Message = message;
            return View("Index");
        }

        //
        // GET: /Data/RouteInformation

        public ActionResult RouteInformation(string id)
        {
            //ViewBag.Message = RouteData.Values["id"];
            ViewBag.Message = id;
            return View("Index");
        }

        //
        // GET: /Data/QueryInformation

        public ActionResult QueryInformation(string message)
        {
            //ViewBag.Message = Request.QueryString["message"];
            ViewBag.Message = message;
            return View("Index");
        }

    }
}
