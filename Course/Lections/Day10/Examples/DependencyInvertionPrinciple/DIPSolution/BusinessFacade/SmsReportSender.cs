using System;
using DIPSolution.Domain;

namespace DIPSolution.BusinessFacade
{
    public class SmsReportSender : IReportSender
    {
        public SmsReportSender()
        {
            Console.WriteLine("Create SmsReportSender");
        }

        #region IReportSender Members

        public void Send(Report report)
        {
            Console.WriteLine("Send '{0}' by means of SMS", report.Name);
        }

        #endregion
    }
}
