using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;

namespace MvcPL.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService service;
        
        public UserController(IUserService service)
        {
            this.service = service;
        }

        [ActionName("Index")]
        public ActionResult GetAllUsers()
        {
            return View(service.GetAllUserEntities().Select(user => user.ToMvcUser()));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel userViewModel)
        {
            service.CreateUser(userViewModel.ToBllUser());
            return RedirectToAction("Index");
        }

        //GET-запрос к методу Delete несет потенциальную уязвимость!
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            UserEntity user = service.GetUserEntity(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user.ToMvcUser());
        }
        
        //Post/Redirect/Get (PRG) — модель поведения веб-приложений, используемая
        //разработчиками для защиты от повторной отправки данных веб-форм
        //(Double Submit Problem)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(UserEntity user)
        {
            service.DeleteUser(user);
            return RedirectToAction("Index");
        }

        //etc.
    }
}