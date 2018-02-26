using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuestBook.Controllers
{
    public class BaseController:IController
    {

        public void Execute(System.Web.Routing.RequestContext requestContext)
        {
            requestContext.HttpContext.Response.Write("<h1>Welcome from IController implemnt!</h1>");
           
            string controller = requestContext.RouteData.Values["controller"].ToString();
            string action = requestContext.RouteData.Values["action"].ToString();
           
            requestContext.HttpContext.Response.Write(string.Format(
                "controller:{0} action:{1}", controller, action));

            //var headers = requestContext.HttpContext.Request.Headers;
            //foreach (var h in headers)
            //{
            //    requestContext.HttpContext.Response.Write("</br> header:" + h);
            //}

            //var browser = requestContext.HttpContext.Request.Browser.Type;
            //requestContext.HttpContext.Response.Write("</br> browser:" + browser);
        }
    }
}