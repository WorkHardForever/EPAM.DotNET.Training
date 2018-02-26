using OriginalSolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OriginalSolution.BusinessFacade;

namespace ReporterTest
{
    /// <summary>
    ///This is a test class for ReporterTest and is intended
    ///to contain all ReporterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ReporterTest
    {
        /// <summary>
        ///A test for SendReports
        ///</summary>
        [TestMethod()]
        public void SendReportsTest()
        {
            var target = new Reporter(); // TODO: Initialize to an appropriate value
            target.SendReports();
            // // ???
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
