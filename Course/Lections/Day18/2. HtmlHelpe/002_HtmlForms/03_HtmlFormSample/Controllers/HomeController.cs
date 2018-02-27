using _03_HtmlFormSample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03_HtmlFormSample.Controllers
{
    public class HomeController : Controller
    {
        // Возвращает главную страницу со ссылкой на форму создания новой задачи
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        // Возвращает форму для создания новой задачи
        // GET: /Home/Create

        public ActionResult Create()
        {
            TaskModel model = new TaskModel();
            model.Name = "Unknown";
            model.StartDate = DateTime.Now.ToShortDateString();
            model.Completed = false;

            return View(model);
        }

        // Получает данные переданные через форму и создает задачу
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(TaskModel incomingData)
        {
            Debug.WriteLine("Name = " + incomingData.Name);
            Debug.WriteLine("StartDate = " + incomingData.StartDate);
            Debug.WriteLine("Completed = " + incomingData.Completed);

            return View("Success");
        }
    }
}
