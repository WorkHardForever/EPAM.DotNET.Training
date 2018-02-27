using JsonResultApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JsonResultApplication.Controllers
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
        public ActionResult Index(string id)
        {
            // id - имя клиента, заказы которого необходимо выводить на странице.
            return View("Index", (object)id);
        }

        public ActionResult OrdersData(string id)
        {
            var data = OrdersDatabase.Orders;
            if (!string.IsNullOrEmpty(id) && id != "All")
            {
                // выполняем выборку по свойству Customer если значение id не пустое и не равное "All"
                data = data.Where(e => e.Customer == id);
            }
            return PartialView(data);
        }

        public ActionResult JsonOrdersData(string id) 
        {
            var data = OrdersDatabase.Orders;
            if (!string.IsNullOrEmpty(id) && id != "All")
            {
                data = data.Where(e => e.Customer == id);
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
