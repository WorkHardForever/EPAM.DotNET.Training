using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningAGenericTypeDemo
{
    class Printer<DocumentType> where DocumentType : IPrintable
    {
        Queue<DocumentType> printQueue = new Queue<DocumentType>();

        public void AddDocumentToQueue(DocumentType document)
        {
            printQueue.Enqueue(document);
        }

        public void PrintDocuments()
        {
            while (printQueue.Count > 0)
            {
                DocumentType document = printQueue.Dequeue();
                Console.WriteLine("PRINTING: {0}", document.Title.ToUpper());
                Console.WriteLine();
                Console.WriteLine(document.Print());
                Console.WriteLine();
                Console.WriteLine("PRINTED");
                Console.WriteLine();
            }
        }
    }
}
