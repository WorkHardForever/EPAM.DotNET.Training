using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_TempData.Controllers
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
            // TempData удобно использовать, если необходимо сохранить данные между двумя запросами
            // Объект TempData похож на Session, но после прочтения значения из TempData оно помечается на удаление
            // и удаляется после обработки запроса.
            TempData["info"] = "Test";

            return View();
        }

        public ActionResult Action2()
        {
            // При чтении значения по ключу info, после завершения обработки запроса, запись в TempData будет удалена.
           // string info = TempData["info"] as string;
            // Получение значения из TempData не помечая его на удаление.
            string info = TempData["info"] as string; //TempData.Peek("info") as string;
            return View((object)info);
        }

        public ActionResult Action3()
        {
            // Объекта по ключу info не существует.
            string info = TempData["info"] as string;
            return View((object)info);
        }
    }
}
