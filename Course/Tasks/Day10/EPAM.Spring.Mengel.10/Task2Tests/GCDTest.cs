using NUnit.Framework;
using Task2Logic;

namespace Task2LogicNUnitTests
{
    [TestFixture]
    public class GCDTest
    {
        [TestCase(arg1: 1071, arg2: 462, Result = 21)]
        [TestCase(arg1: -2048, arg2: -19, Result = 1)]
        [TestCase(arg1: 0, arg2: 730, Result = 730)]
        public double GetGcdByEuclideanAlgorithm_Test(int value1, int value2) =>
            GCD.GetGcdByEuclideanAlgorithm(value1, value2);

        [TestCase(arg1: 1071, arg2: 462, arg3: 1, Result = 1)]
        [TestCase(arg1: -2048, arg2: -19, arg3: 1, Result = 1)]
        [TestCase(arg1: 2, arg2: 730, arg3: 10, Result = 2)]
        public double GetGcdByEuclideanAlgorithm_Test(int value1, int value2, int value3) =>
            GCD.GetGcdByEuclideanAlgorithm(value1, value2, value3);

        [TestCase(arg1: 1071, arg2: 462, Result = 21)]
        [TestCase(arg1: -2048, arg2: -19, Result = 1)]
        [TestCase(arg1: 0, arg2: 730, Result = 730)]
        public double GetGcdByStainAlgorithm_Test(int value1, int value2) =>
            GCD.GetGcdByStainAlgorithm(value1, value2);

        [TestCase(arg1: 1071, arg2: 462, arg3: 1, Result = 1)]
        [TestCase(arg1: -2048, arg2: -19, arg3: 1, Result = 1)]
        [TestCase(arg1: 2, arg2: 730, arg3: 10, Result = 2)]
        public double GetGcdByStainAlgorithm_Test(int value1, int value2, int value3) =>
            GCD.GetGcdByStainAlgorithm(value1, value2, value3);
    }
}
