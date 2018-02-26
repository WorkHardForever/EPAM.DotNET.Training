
//Консольное приложение, которое занимается рассылкой отчетов
using System.Diagnostics;
using OriginalSolution.BusinessFacade;

namespace OriginalSolution
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Главный объект в бизнес-логике – Reporter.
            var reporter = new Reporter();
            reporter.SendReports();
        }
    }
}
