using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningAGenericTypeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Запись в журнал событий об ошибках, произошедших при публикации SOAP 
            //с поддержкой COM-интерфейсов в COM + приложений.
            Report project1 = new Report("IT Upgrade Report");
            Report project2 = new Report("Customer Project Report");
            Report project3 = new Report("Office Relocation Report");

            ReferenceGuide guide1 = new ReferenceGuide("Desktop Support Guide");
            ReferenceGuide guide2 = new ReferenceGuide("Laptop Support Guide");
            ReferenceGuide guide3 = new ReferenceGuide("Server Support Guide");

            Printer<Report> reportPrinter = new Printer<Report>();
            reportPrinter.AddDocumentToQueue(project1);
            reportPrinter.AddDocumentToQueue(project2);
            reportPrinter.AddDocumentToQueue(project3);

            reportPrinter.PrintDocuments();

            Console.ReadLine();

            Printer<ReferenceGuide> referenceGuidePrinter = new Printer<ReferenceGuide>();
            referenceGuidePrinter.AddDocumentToQueue(guide1);
            referenceGuidePrinter.AddDocumentToQueue(guide2);
            referenceGuidePrinter.AddDocumentToQueue(guide3);

            referenceGuidePrinter.PrintDocuments();

            Console.ReadLine();

        }
    }
}
