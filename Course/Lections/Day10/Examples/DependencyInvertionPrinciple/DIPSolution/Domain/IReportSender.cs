using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIPSolution.Domain
{
    public interface IReportSender
    {
        void Send(Report report);
    }
}
