using System.Collections.Generic;

namespace IoCNinjectSolution.Domain
{
    public interface IReportBuilder
    {
        IList<Report> CreateReports();
    }
}
