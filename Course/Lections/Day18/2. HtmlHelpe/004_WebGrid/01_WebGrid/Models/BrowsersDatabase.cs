using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01_WebGrid.Models
{
    public static class BrowsersDatabase
    {
        private static List<BrowserInfo> _browsers = null;

        public static List<BrowserInfo> Browsers
        {
            get
            {
                if (_browsers == null)
                {
                    _browsers = new List<BrowserInfo>();
                    BrowserInfo info;

                    info = new BrowserInfo();
                    info.ID = 1;
                    info.Name = "Google Chrome";
                    info.ImagePath = "/Content/Images/chrome.png";
                    info.Url = "http://www.google.ru/chrome";
                    _browsers.Add(info);

                    info = new BrowserInfo();
                    info.ID = 2;
                    info.Name = "Microsoft Internet Explorer";
                    info.ImagePath = "/Content/Images/internet_explorer.png";
                    info.Url = "http://windows.microsoft.com/ru-RU/internet-explorer/products/ie/home";
                    _browsers.Add(info);

                    info = new BrowserInfo();
                    info.ID = 3;
                    info.Name = "Mozilla Firefox";
                    info.ImagePath = "/Content/Images/mozilla.png";
                    info.Url = "http://www.mozilla.org/en-US/firefox/new/";
                    _browsers.Add(info);

                    info = new BrowserInfo();
                    info.ID = 4;
                    info.Name = "Opera";
                    info.ImagePath = "/Content/Images/opera.png";
                    info.Url = "http://www.opera.com/download/";
                    _browsers.Add(info);

                    info = new BrowserInfo();
                    info.ID = 5;
                    info.Name = "Safari";
                    info.ImagePath = "/Content/Images/safari.png";
                    info.Url = "http://www.apple.com/safari/download/";
                    _browsers.Add(info);
                }
                return _browsers;
            }
        }
    }

    public class BrowserInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Url { get; set; }
    }
}