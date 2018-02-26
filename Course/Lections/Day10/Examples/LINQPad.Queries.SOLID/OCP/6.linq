<Query Kind="Program" />

abstract class Importer
{
    public abstract void ImportData();
}
 
//Принцип единственного выбора: всякий раз, 
//когда система программного обеспечения должна 
//поддерживать множество альтернатив, их полный 
//список должен быть известен только одному модулю системы.

static class ImporterFactory
{
    public static Importer Create(string fileName)
    {
        //...
 
        var extension = Path.GetExtension(fileName);
        switch (extension)
        {
            case "json":
                return new JsonImporter();
            case "xls":
            case "xlsx":
                return new XlsImporter();
            default:
                throw new InvalidOperationException(
                  "Extension is not supported");
        }
    }
}