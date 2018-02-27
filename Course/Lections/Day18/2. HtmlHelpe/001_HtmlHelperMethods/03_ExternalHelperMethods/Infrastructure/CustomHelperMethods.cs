using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03_ExternalHelperMethods.Infrastructure
{
    public static class CustomHelperMethods
    {
        public static MvcHtmlString ErrorMessage(this HtmlHelper helper, string message)
        {
            TagBuilder tag = new TagBuilder("p");
            tag.MergeAttribute("style", "color:red; padding:8px; border:1px solid red; border-radius:3px;");
            tag.SetInnerText(message);

            return new MvcHtmlString(tag.ToString());
        }
    }
}