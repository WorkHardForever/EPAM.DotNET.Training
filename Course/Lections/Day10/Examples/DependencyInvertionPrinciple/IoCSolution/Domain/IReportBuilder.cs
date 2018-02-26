using System.Collections.Generic;

namespace IoCSolution.Domain
{
    public interface IReportBuilder
    {
        IList<Report> CreateReports();
    }
}
