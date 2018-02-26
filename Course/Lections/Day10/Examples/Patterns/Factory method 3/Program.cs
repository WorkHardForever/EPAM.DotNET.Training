using System;
using System.Collections;

//Фабричный метод применяется для создания объектов с определенным интерфейсом, 
//реализации которого предоставляются потомками

namespace Factory_method_3
{
    //определяется интерфейс порождаемых объектов IPage
    interface IPage { }

    class SkillsPage : IPage { }
    class EducationPage : IPage { }
    class ExperiencePage : IPage { }
    class IntroductionPage : IPage { }
    class ResultsPage : IPage { }
    class ConclusionPage : IPage { }
    class SummaryPage : IPage { }
    class BibliographyPage : IPage { }

    abstract class Document
    {
        private readonly ArrayList _pages = new ArrayList();

        protected Document()
        {
            CreatePages();
        }

        public ArrayList Pages
        {
            get { return _pages; }
        }

        //базовый класс описывает метод public IProduct FabricMethod() для их создания
        public abstract void CreatePages();//фабичный метод
    }

    internal class Resume : Document
    {
        public override void CreatePages()
        {
            Pages.Add(new SkillsPage());
            Pages.Add(new EducationPage());
            Pages.Add(new ExperiencePage());
        }
    }

    internal class Report : Document
    {
        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ResultsPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());
        }
    }

    internal class Program
    {
        public static void Main()
        {
            var documents = new Document[2];
            documents[0] = new Resume();
            documents[1] = new Report();

            foreach (Document document in documents)
            {
                Console.WriteLine("\n{0}--", document.GetType().Name);
                foreach (IPage page in document.Pages)
                {
                    Console.WriteLine(" {0}", page.GetType().Name);
                }
            }
            Console.ReadKey();
        }
    }
}
