using System;
using System.Collections.Generic;
using DIPSolution.Domain;

namespace DIPSolution.BusinessFacade
{
    public class ReportBuilder : IReportBuilder
    {
        public ReportBuilder()
        {
            Console.WriteLine("Create ReportBuilder");
        }

        #region IReportBuilder Members

        public IList<Report> CreateReports()
        {
            return new List<Report>
                       {
                           new Report {Name = "Report 1"},
                           new Report {Name = "Report 2"}
                       };
        }

        #endregion
    }
}
