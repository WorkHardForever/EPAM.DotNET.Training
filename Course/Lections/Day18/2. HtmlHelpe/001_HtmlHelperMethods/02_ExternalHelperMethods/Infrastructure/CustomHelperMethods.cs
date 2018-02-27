using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_ExternalHelperMethods.Infrastructure
{
    public static class CustomHelperMethods
    {
        // Для того чтобы использовать данный вспомогательный метод, 
        //необходимо импортировать пространство имен _02_ExternalHelperMethods.Infrastructure.
        // В данном проекте, пространство имен импортировано с помощью файла Views/web.config
        public static MvcHtmlString UnorderedList(this HtmlHelper html, IEnumerable<string> items)
        {
            // TagBuilder - класс для создания HTML элементов.
            TagBuilder tag = new TagBuilder("ul");
            foreach (var item in items)
            {
                TagBuilder liTag = new TagBuilder("li");
                liTag.SetInnerText(item);
                tag.InnerHtml += liTag.ToString();
            }

            // MvcHtmlString - представляет HTML кодированную строку, которая не должна кодироваться повторно.
            // Необходимо самостоятельно позаботится о кодировании тех данных, с которыми связан риск XSS атаки
            return new MvcHtmlString(tag.ToString());
        }
    }
}



