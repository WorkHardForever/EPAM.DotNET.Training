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

            ReferenceGuide guide1 = new ReferenceGuide("Desktop Support Guide");
            ReferenceGuide guide2 = new ReferenceGuide("Laptop Support Guide");
            ReferenceGuide guide3 = new ReferenceGuide("Server Support Guide");

            Report project1 = new Report("IT Upgrade Report");
            Report project2 = new Report("Customer Project Report");
            Report project3 = new Report("Office Relocation Report");

            Printer<ReferenceGuide> referenceGuidePrinter = new Printer<ReferenceGuide>();

            referenceGuidePrinter.DocumentAddingToQueue += new DocumentAddingToQueueDelegate<ReferenceGuide>(referenceGuidePrinter_DocumentAddingToQueue);

            referenceGuidePrinter.AddDocumentToQueue(guide1);
            referenceGuidePrinter.AddDocumentToQueue(guide2);
            referenceGuidePrinter.AddDocumentToQueue(guide3);

            referenceGuidePrinter.PrintDocuments();

            Console.ReadLine();

            Printer<Report> reportPrinter = new Printer<Report>();
            reportPrinter.AddDocumentToQueue(project1);
            reportPrinter.AddDocumentToQueue(project2);
            reportPrinter.AddDocumentToQueue(project3);

            reportPrinter.DocumentPrinted += new Action<Printer<Report>, DocumentPrintedEventArgs<Report>>(reportPrinter_DocumentPrinted);

            reportPrinter.PrintDocuments();

            Console.ReadLine();
        }

        static bool referenceGuidePrinter_DocumentAddingToQueue(ReferenceGuide document)
        {
            System.Windows.Forms.DialogResult result = 
                System.Windows.Forms.MessageBox.Show(String.Format("Reference Guide Title: {0} \nProceeed?", document.Title), "Reference Guide Printing", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Information);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void reportPrinter_DocumentPrinted(Printer<Report> arg1, DocumentPrintedEventArgs<Report> arg2)
        {
            System.Windows.Forms.MessageBox.Show(arg2.Document.Title, 
                "Report Printed", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }
    }
}
