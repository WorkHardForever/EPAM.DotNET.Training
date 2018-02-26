using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class HeaderData { }
    public class MenuItems { }
    public class PostData { }
    public class FooterData { }
    public class Page
    {
        internal void AddHeader(HeaderData header)
        {
            throw new NotImplementedException();
        }

        internal void SetMenuItems(MenuItems menuItems)
        {
            throw new NotImplementedException();
        }

        internal void AddPost(PostData post)
        {
            throw new NotImplementedException();
        }

        internal void AddFooter(FooterData footer)
        {
            throw new NotImplementedException();
        }
    }
    public class PageImageList
    {
        internal void AddImageUrl(string imageUrl)
        {
            throw new NotImplementedException();
        }
    }
    public interface IPageBuilder
    {
        void BuildHeader(HeaderData header);
        void BuildMenu(MenuItems menuItems);
        void BuildPost(PostData post);
        void BuildFooter(FooterData footer);
    }
    public class PageDirector
    {
        private readonly IPageBuilder _builder;

        public PageDirector(IPageBuilder builder)
        {
            this._builder = builder;
        }

        public void BuildPage(int pageId)
        {
            this._builder.BuildHeader(this.GetHeader(pageId));
            this._builder.BuildMenu(this.GetMenuItems(pageId));

            foreach (PostData post in this.GetPosts(pageId))
            {
                this._builder.BuildPost(post);
            }

            this._builder.BuildFooter(this.GetFooter(pageId));
        }

        private HeaderData GetHeader(int pageId) { /*TODO*/ throw new NotImplementedException(); }
        private MenuItems GetMenuItems(int pageId) { /*TODO*/ throw new NotImplementedException(); }
        private IEnumerable<PostData> GetPosts(int pageId) { /*TODO*/ throw new NotImplementedException(); }
        private FooterData GetFooter(int pageId) { /*TODO*/ throw new NotImplementedException(); }
    }
    //создать объект Page, который содержит HTML код для выбранной страницы
    public class PageBuilder : IPageBuilder
    {
        private readonly Page _page = new Page();

        public void BuildHeader(HeaderData header) { this._page.AddHeader(header); }

        public void BuildMenu(MenuItems menuItems) { this._page.SetMenuItems(menuItems); }

        public void BuildPost(PostData post) { this._page.AddPost(post); }

        public void BuildFooter(FooterData footer) { this._page.AddFooter(footer); }

        public Page GetResult() { return this._page; }
    }
    //создать версию страницы для печати
    public class PrintPageBuilder : IPageBuilder
    {
        private readonly Page _page = new Page();
        private PostData PreparePostToPrinter(PostData post) { /* TODO */ throw new NotImplementedException(); }

        public void BuildHeader(HeaderData header) { }

        public void BuildMenu(MenuItems menuItems) { }

        public void BuildPost(PostData post)
        {
            PostData postToPrint = this.PreparePostToPrinter(post);
            this._page.AddPost(postToPrint);
        }

        public void BuildFooter(FooterData footer) { }

        public Page GetResult() { return this._page; }
    }
    //получить объект PostImageList, содержащий список изображений в публикациях на выбранной странице
    public class PageImageListBuilder : IPageBuilder
    {
        private readonly PageImageList _imageList = new PageImageList();

        private IEnumerable PostImages(PostData post) { /* TODO */ throw new NotImplementedException();}

        public void BuildHeader(HeaderData header) { }
        public void BuildMenu(MenuItems menuItems) { }
        public void BuildFooter(FooterData footer) { }

        public void BuildPost(PostData post)
        {
            foreach (string imageUrl in this.PostImages(post))
            {
                this._imageList.AddImageUrl(imageUrl);
            }
        }

        public PageImageList GetResult() { return this._imageList; }
    }
    class Program
    {
        public void PostPage(int pageId)
        {
            var pageBuilder = new PageBuilder();//PrintPageBuilder or PageImageListBuilder
            var pageDirector = new PageDirector(pageBuilder);

            pageDirector.BuildPage(pageId);

            Page page = pageBuilder.GetResult();

            //TODO with page
        }
        static void Main(string[] args)
        {
        }
    }
}
//Такой подход можно часто встретить, когда из готового набора данных надо
//создавать различные варианты. Например, из XML надо создавать объекты, содержащие 
//его HTML, RTF или TXT представления. В этом случае Распорядитель будет отвечать
//за получение данных из XML, а Строители за преобразование в нужный формат и 
//создание объектов