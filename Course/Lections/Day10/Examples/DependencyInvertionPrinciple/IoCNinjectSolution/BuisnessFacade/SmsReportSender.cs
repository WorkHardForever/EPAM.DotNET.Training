using System;
using IoCNinjectSolution.Domain;

namespace IoCNinjectSolution.BuisnessFacade
{
    public class SmsReportSender : IReportSender
    {
        public SmsReportSender()
        {
            Console.WriteLine("Create SmtpReportSender");
        }

        #region IReportSender Members

        public void Send(Report report)
        {
            Console.WriteLine("Send '{0}' by means of SMS", report.Name);
        }

        #endregion
    }
}
