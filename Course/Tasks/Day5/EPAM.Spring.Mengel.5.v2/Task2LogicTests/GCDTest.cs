using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2Logic;

namespace Task2LogicTests
{
    [TestClass]
    public class GCDTest
    {
        [TestMethod]
        public void GetGcdByEuclideanAlgorithm_All_Positive_Numbers()
        {
            var value1 = 1071;
            var value2 = 462;
            var expected = 21;

            Assert.AreEqual(expected, GCD.GetGcdByEuclideanAlgorithm(value1, value2));
        }

        [TestMethod]
        public void GetGcdByEuclideanAlgorithm_One_Positive_Number()
        {
            var value1 = 0;
            var value2 = 730;
            var expected = 730;

            Assert.AreEqual(expected, GCD.GetGcdByEuclideanAlgorithm(value1, value2));
        }

        [TestMethod]
        public void GetGcdByEuclideanAlgorithm_All_Negative_Numbers()
        {
            var value1 = -2048;
            var value2 = -19;
            var expected = 1;

            Assert.AreEqual(expected, GCD.GetGcdByEuclideanAlgorithm(value1, value2));
        }

        [TestMethod]
        public void GetGcdByStainAlgorithm_All_Positive_Numbers()
        {
            var value1 = 1071;
            var value2 = 462;
            var expected = 21;

            Assert.AreEqual(expected, GCD.GetGcdByStainAlgorithm(value1, value2));
        }

        [TestMethod]
        public void GetGcdByStainAlgorithm_One_Positive_Number()
        {
            var value1 = 0;
            var value2 = 730;
            var expected = 730;

            Assert.AreEqual(expected, GCD.GetGcdByStainAlgorithm(value1, value2));
        }

        [TestMethod]
        public void GetGcdByStainAlgorithm_All_Negative_Numbers()
        {
            var value1 = -2048;
            var value2 = -19;
            var expected = 1;

            Assert.AreEqual(expected, GCD.GetGcdByStainAlgorithm(value1, value2));
        }
    }
}
