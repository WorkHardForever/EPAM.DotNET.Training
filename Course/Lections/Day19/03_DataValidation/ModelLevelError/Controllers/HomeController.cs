using ModelLevelError.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ModelLevelError.Controllers
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
        public ActionResult Index(AccountModel model)
        {
            if (string.IsNullOrEmpty(model.Login))
            {
                ModelState.AddModelError("Login", "Введите логин");
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("Password", "Введите пароль");
            }
            if (string.Compare(model.Password, model.PasswordConfirm) != 0)
            {
                ModelState.AddModelError("PasswordConfirm", "Пароли не совпадают");
            }
            if (model.Email != null && !new Regex(@"\b[a-z0-9._]+@[a-z0-9.-]+\.[a-z]{2,4}\b").IsMatch(model.Email))
            {
                ModelState.AddModelError("Email", "Email не правильный");
            }

            if (model.Login == model.Password)
            {
                // Добавление ошибки уровня модели.
                ModelState.AddModelError("", "Пароль не может совпадать с логином");
            }

            if (ModelState.IsValid)
            {
                // произвести сохранение модели
                return View("Success");
            }
            else
            {
                return View();
            }
        }

    }
}
