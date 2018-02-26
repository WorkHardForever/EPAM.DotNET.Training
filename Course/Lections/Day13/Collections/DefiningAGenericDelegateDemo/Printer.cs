using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningAGenericTypeDemo
{
    public delegate bool DocumentAddingToQueueDelegate<DocumentType>(DocumentType document);

    class Printer<DocumentType> where DocumentType : IPrintable
    {
        Queue<DocumentType> printQueue = new Queue<DocumentType>();

        public void AddDocumentToQueue(DocumentType document)
        {
            bool print = OnDocumentAddingToQueue(document);
            if (print)
            {
                printQueue.Enqueue(document);
            }
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
                OnDocumentPrinted(this, new DocumentPrintedEventArgs<DocumentType>(document));
            }
        }

        public event DocumentAddingToQueueDelegate<DocumentType> DocumentAddingToQueue = null;

        protected bool OnDocumentAddingToQueue(DocumentType document)
        {
            if (DocumentAddingToQueue != null)
            {
                return DocumentAddingToQueue(document);
            }
            else
            {
                return true;
            }
        }

        public event Action<Printer<DocumentType>, DocumentPrintedEventArgs<DocumentType>> DocumentPrinted = null;

        protected void OnDocumentPrinted(Printer<DocumentType> printer, DocumentPrintedEventArgs<DocumentType> e)
        {
            if (DocumentPrinted != null)
            {
                DocumentPrinted(printer, e);
            }
        }

    }

    class DocumentPrintedEventArgs<DocumentType> : EventArgs
    {
        public DocumentType Document { get; private set; }

        public DocumentPrintedEventArgs(DocumentType document)
        {
            Document = document;
        }
    }
}
