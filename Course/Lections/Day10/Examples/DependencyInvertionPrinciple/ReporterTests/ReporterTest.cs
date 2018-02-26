using System.Collections.Generic;
using DIPSolution;
using DIPSolution.BusinessFacade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DIPSolution.Domain;
using Moq;

namespace ReporterTests
{
    [TestClass()]
    public class ReporterTest
    {
        [TestMethod()]
        [ExpectedException(typeof(NoReportsException))]
        public void IfNotReportsThenThrowExceptionSendReportsTest()
        {
            var builder = new Mock<IReportBuilder>();
            builder.Setup(m => m.CreateReports()).Returns(new List<Report>());

            var sender = new Mock<IReportSender>();

            var reporter = new Reporter(builder.Object, sender.Object);

            reporter.SendReports();
        }
    }
}
