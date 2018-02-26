using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DIPSolution.Domain;

namespace DIPSolution.BusinessFacade
{
    public class EmailReportSender : IReportSender
    {
        public EmailReportSender()
        {
            Console.WriteLine("Create EmailReportSender");
        }

        public string SmtpServer { get; set; }

        #region IReportSender Members

        public void Send(Report report)
        {
            if (!string.IsNullOrEmpty(SmtpServer))
            {
                Console.WriteLine("Send '{0}' to '{1}' by means of email", report.Name, SmtpServer);
            }
            else
            {
                Console.WriteLine("Send '{0}' by means of email", report.Name);
            }
        }

        #endregion
    }
}
