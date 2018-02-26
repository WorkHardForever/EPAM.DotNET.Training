using System;
using System.Diagnostics;

namespace OriginalSolution.BusinessFacade
{
    public class EmailReportSender
    {
        public EmailReportSender()
        {
            Debug.WriteLine("Create EmailReportSender");
        }

        public string SmtpServer { get; set; }

        public void Send(Report report)
        {
            if (!string.IsNullOrEmpty(SmtpServer))
            {
                Debug.WriteLine("Send '{0}' to '{1}' by means of email", report.Name, SmtpServer);
            }
            else
            {
                Debug.WriteLine("Send '{0}' by means of email", report.Name);
            }
        }
    }
}
