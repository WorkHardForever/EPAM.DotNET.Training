using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04_FileResultSamples.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DownloadFile()
        {
            string filename = Server.MapPath("/Content/File.pdf");//полный путь к файлу
            string contentType = "application/pdf"; //тип файла который мы будем отдавать пользователю 
                                                    //MIME Type image/png  image/jpg
            string downloadName = "PDF File";
            // Если имя файла для скачивания не указано и если 
            // браузер поддерживает тип файла, файл откроется в самом браузере.
            return File(filename, contentType, downloadName);
        }

        public ActionResult DownloadBytes()
        {
            string filename = Server.MapPath("/Content/File.pdf");
            string contentType = "application/pdf";

            byte[] data = System.IO.File.ReadAllBytes(filename);

            return File(data, contentType);
        }

        public ActionResult DownloadStream()
        {
            string filename = Server.MapPath("/Content/File.pdf");
            string contentType = "application/pdf";

            FileStream stream = System.IO.File.OpenRead(filename);

            return File(stream, contentType);
        }
    }
}
