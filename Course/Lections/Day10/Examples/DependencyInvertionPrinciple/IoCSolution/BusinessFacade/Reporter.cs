using System;
using System.Collections.Generic;
using IoCSolution.Domain;
using IoCSolution.Utility;

namespace IoCSolution.BusinessFacade
{
    public class Reporter : IReporter
    {
        private readonly IReportBuilder _reportBuilder;
        private readonly IReportSender _reportSender;

        public Reporter()
            : this(ServiceLocator.Resolve<IReportBuilder>(), ServiceLocator.Resolve<IReportSender>())
        {
        }

        //конструктор отлично подойдет для модульного тестирования
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
