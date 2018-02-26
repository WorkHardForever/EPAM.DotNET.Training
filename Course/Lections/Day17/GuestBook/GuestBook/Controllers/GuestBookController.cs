using GuestBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuestBook.Controllers
{
    public class GuestBookController : Controller
    {
        //
        // GET: /GuestBook/
        private GuestBookContext ctx = new GuestBookContext();
        public ActionResult Index()
        {
            //var query = ctx.Entries.OrderBy(it => it.DateAdd).Take(20).ToList();
            ViewBag.Entries = ctx.Entries.OrderByDescending(it => it.DateAdd).Take(4).ToList();
            return View();
        }
        

     //   [HttpGet]
        public ActionResult Create()
        {            
            return View();
        }
      //  [HttpPost]
         public ActionResult Create(GuestBookEntity guestBook)
        {
            guestBook.DateAdd = DateTime.Now;

            ctx.Entries.Add(guestBook);

            ctx.SaveChanges();
           
            return View();
        }

        
        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
            base.Dispose(disposing);
        }

        [NonAction]
        public DateTime Foo()
        {
            return DateTime.Now;
        }
    }
}



 //GuestBookContext ctx = new GuestBookContext();

 //           GuestBookContext ctx = new GuestBookContext();
 //           var query = ctx.Entries.OrderBy(it => it.DateAdd).Take(20).ToList();
 //           ctx.Entries.Add(new GuestBookEntity{Id = 1, Name= "Ivan", Message= "Hello", DateAdd=DateTime.UtcNow });
