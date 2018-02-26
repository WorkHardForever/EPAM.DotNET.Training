using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DIPSolution.BusinessFacade;

namespace DIPSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            //new new new ...?
            var builder = new ReportBuilder();
            var senderSms= new SmsReportSender();
            var reporter = new Reporter(builder, senderSms);

            reporter.SendReports();

            var senderEmail = new EmailReportSender();
            var reporter2 = new Reporter(builder, senderEmail);

            reporter2.SendReports();
        }
    }
}
