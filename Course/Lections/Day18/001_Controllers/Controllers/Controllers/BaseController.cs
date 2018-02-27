using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controllers.Controllers
{
    public class BaseController:IController
    {
        public void Execute(System.Web.Routing.RequestContext requestContext)
        {
            requestContext.HttpContext.Response.Write("<h1>Welcome from IController implemnt!</h1>");

            string controller = (string)requestContext.RouteData.Values["controller"];
            string action = (string)requestContext.RouteData.Values["action"];

            requestContext.HttpContext.Response.Write(string.Format("Controller: {0}, Action: {1}", controller, action));
        }
    }
}