using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace _02_ContentResultSamples.Controllers
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
            // Content - создает ActionResult представляющий строковой 
            //контент отправляющийся в ответ пользователю.

            // первый параметр - текстовые данные, которые необходимо отправить.
            // второй параметр - MIME тип возвращаемых данных, по умолчанию text/html.
            // третий параметр - кодировка.
            return Content("Hello World", "text/plain", Encoding.UTF8);
        }

        public ActionResult Action2()
        {
            // Отправка пустого ответа.
            return new EmptyResult();
        }

    }
}
