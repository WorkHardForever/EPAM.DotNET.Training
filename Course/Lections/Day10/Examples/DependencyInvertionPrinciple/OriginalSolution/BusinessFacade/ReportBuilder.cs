using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OriginalSolution.BusinessFacade
{
    public class ReportBuilder
    {
        public ReportBuilder()
        {
            Debug.WriteLine("Create ReportBuilder");
        }

        public IList<Report> CreateReports()
        {
            return new List<Report>
                       {
                           new Report { Name = "Report 1" },
                           new Report { Name = "Report 2" }
                       };
        }
    }
}
