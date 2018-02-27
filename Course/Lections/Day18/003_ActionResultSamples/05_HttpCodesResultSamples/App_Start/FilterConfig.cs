using System.Web;
using System.Web.Mvc;

namespace _05_HttpCodesResultSamples
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}