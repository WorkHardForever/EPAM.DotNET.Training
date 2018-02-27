using System.Web;
using System.Web.Optimization;

namespace _08_Bundling
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Создание бандла ~/bundles/jquery в который войдут файлы jquery-* 
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                        .Include("~/Scripts/jquery-{version}.js")
                        .Include("~/Scripts/jquery.validate.js"));

            // Создание бандла ~/bundles/modernizr для библиотеки modernizr
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // Создание бандла для стилей
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
        }
    }
}