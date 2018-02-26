using System.Collections.Generic;
using DIPSolution.Domain;

namespace DIPSolution.BusinessFacade
{
    public class Reporter : IReporter
    {
        private readonly IReportBuilder reportBuilder;
        private readonly IReportSender reportSender;

        public Reporter(IReportBuilder reportBuilder, IReportSender reportSender)
        {
            this.reportBuilder = reportBuilder;
            this.reportSender = reportSender;
        }

        public void SendReports()
        {
            IList<Report> reports = reportBuilder.CreateReports();

            if (reports.Count == 0)
                throw new NoReportsException();

            foreach (Report report in reports)
            {
                reportSender.Send(report);
            }
        }
    }
}
