using System;
using IoCSolution.Domain;

namespace IoCSolution.BusinessFacade
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
            Console.WriteLine("Create '{0}' by means of SMS", report.Name);
        }

        #endregion
    }
}
