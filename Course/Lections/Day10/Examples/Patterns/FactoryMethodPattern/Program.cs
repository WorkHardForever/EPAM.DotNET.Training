using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//public enum StorageFormat { Txt, Rtf }
 
//public IDocStorage CreateStorage(StorageFormat format)
//{
//    switch (format) {
//        case StorageFormat.Txt:
//            return new TxtDocStorage();
 
//        case StorageFormat.Rtf:
//            return new RtfDocStorage();
 
//        default:
//            throw new ArgumentException("An invalid format: " + format.ToString());
//    }
//}


#region Interface method or abstract method
//Абстрактный метод или метод из интерфейса
//Данный подход обязывает потомка определить свои реализации 
//Фабричного метода и порождаемого им класса.

namespace FactoryMethodPattern
{
    public class Document { }
    public interface IDocumentStorage
    {
        void Save(string name, Document document);
        Document Load(string name);
    }
    public abstract class DocumentManager
    {
        private string _name;
        public abstract IDocumentStorage CreateStorage();

        public bool Save(Document document)
        {
            if (!this.SaveDialog())
            {
                return false;
            }
            // using Factory method to create a new document storage
            IDocumentStorage storage = this.CreateStorage();

            storage.Save(this._name, document);

            return true;
        }

        public bool SaveDialog()
        {
            throw new NotImplementedException();
        }
    }
    public class TxtDocumentManager : DocumentManager
    {
        private class TxtDocStorage : IDocumentStorage
        {
            public void Save(string name, Document document)
            {
                throw new NotImplementedException();
            }

            public Document Load(string name)
            {
                throw new NotImplementedException();
            }
        }

        public override IDocumentStorage CreateStorage() { return new TxtDocStorage(); }
    }
    public class RtfDocumentManager : DocumentManager
    {
        private class RtfDocStorage : IDocumentStorage
        {
            public void Save(string name, Document document)
            {
                throw new NotImplementedException();
            }

            public Document Load(string name)
            {
                throw new NotImplementedException();
            }
        }

        public override IDocumentStorage CreateStorage() { return new RtfDocStorage(); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var document = new Document();
            // Save a document as txt file using "Save" dialog
            DocumentManager docManager = new TxtDocumentManager();
            docManager.Save(document);
            // Or use the IDocStorage interface to save a document
            IDocumentStorage storage = docManager.CreateStorage();
            storage.Save("path", document);
        }
    }
} 
#endregion