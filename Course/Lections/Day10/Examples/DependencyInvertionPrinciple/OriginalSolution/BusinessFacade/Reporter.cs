using System.Collections.Generic;

namespace OriginalSolution.BusinessFacade
{
    public class Reporter
    {
        public void SendReports()
        {
            //Reporter просит ReportBuilder создать список отчетов
            var reportBuilder = new ReportBuilder();//SRP DIP (параметры в конструкторе?)
            IList<Report> reports = reportBuilder.CreateReports();

            if (reports.Count == 0)
                throw new NoReportsException();
            //потом один за другим отсылает их с помощью объекта EmailReportSender
            var reportSender = new EmailReportSender();//SRP OCP (Email<->SMS?) DIP
            foreach (Report report in reports)
            {
                reportSender.Send(report);
            }
        }
        //Что будет, если клиенту программы нужно будет отсылать сообщения через SMS вместо e-mail?
        //А если кто-то захочет сделать свой ReportBuilder?
        //Функция SendReports, кроме своей прямой обязанности, слишком много знает и умеет:
        //знает, что именно ReportBuilder будет создавать отчеты
        //знает, что все отчеты надо отсылать через email с помощью EmailReportSender
        //умеет создавать объект ReportBuilder
        //умеет создавать объект EmailReportSender
        //нарушается принцип единственности ответственности!
        //нарушается принцип открытости/закрытости!
        //нарушение принципа инверсии зависимостей!
    }
}
