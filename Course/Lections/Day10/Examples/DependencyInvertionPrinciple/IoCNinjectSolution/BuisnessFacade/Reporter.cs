using System;
using System.Collections.Generic;
using IoCNinjectSolution.Domain;

namespace IoCNinjectSolution.BuisnessFacade
{
    public class Reporter : IReporter
    {
        private readonly IReportBuilder _reportBuilder;
        private readonly IReportSender _reportSender;

        public Reporter(IReportBuilder reportBuilder, IReportSender reportSender)
        {
            this._reportBuilder = reportBuilder;
            this._reportSender = reportSender;

            Console.WriteLine("Create Reporter");
        }

        #region IReporter Members

        public void SendReports()
        {
            IList<Report> reports = _reportBuilder.CreateReports();

            if (reports.Count == 0)
                throw new NoReportsException();

            foreach (Report report in reports)
            {
                _reportSender.Send(report);
            }
        }

        #endregion
    }
}
