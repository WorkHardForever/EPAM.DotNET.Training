using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jQueryApplication.Controllers
{
    public class HomeController : Controller
    {
        Dictionary<string, string> articles = new Dictionary<string, string>();

        string article1 = "ARTICLE1 Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.";
        string article2 = "ARTICLE2 Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel. Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.";

        public HomeController()
        {
            articles.Add("1", article1);
            articles.Add("2", article2);
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetArticle(string id)
        {
            if (!string.IsNullOrEmpty(id) && articles.ContainsKey(id))
            {
                return Content(articles[id]);
            }
            return new EmptyResult();
        }
    }
}
