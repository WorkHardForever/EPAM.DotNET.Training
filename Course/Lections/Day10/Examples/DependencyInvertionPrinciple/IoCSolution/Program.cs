using IoCSolution.BusinessFacade;
using IoCSolution.Domain;
using IoCSolution.Utility;

namespace IoCSolution
{
    public static class Program
    {
        static void Main(string[] args)
        {
            #region 1
            // Инициализируем (регистрируем) связи
            // Конфигурирование связей отделено от их использования
            ServiceLocator.RegisterService<IReportBuilder>(typeof(ReportBuilder));
            ServiceLocator.RegisterService<IReportSender>(typeof(SmsReportSender));

            var reporter = new Reporter();
            reporter.SendReports();

            //или 

            ServiceLocator.RegisterService<IReportBuilder>(typeof(ReportBuilder));
            ServiceLocator.RegisterService<IReportSender>(typeof(EmailReportSender));

            reporter = new Reporter();
            reporter.SendReports();

            #endregion

            #region 2
            ServiceLocator.RegisterService<IReportBuilder>(typeof(ReportBuilder));
            ServiceLocator.RegisterService<IReportSender>(typeof(SmsReportSender));
            ServiceLocator.RegisterService<IReporter>(typeof(Reporter));

            // Вызываем "сохраненную" ссылку на нужную реализацию
            var reporter1 = ReporterFactory.Create();
            reporter1.SendReports();

            //или

            ServiceLocator.RegisterService<IReportSender>(typeof(EmailReportSender));
            reporter1 = ServiceLocator.Resolve<IReporter>();

            reporter1.SendReports();  
            #endregion
        }
    }
}
