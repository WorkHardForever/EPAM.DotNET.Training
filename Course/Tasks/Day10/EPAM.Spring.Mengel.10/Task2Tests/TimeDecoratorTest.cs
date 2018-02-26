using NUnit.Framework;
using Task2Logic;

namespace Task2LogicNUnitTests
{
    [TestFixture]
    public class TimeDecoratorTest
    {
        [TestCase(arg1: 1071, arg2: 462)]
        public void GetTimeOfMethodWork_Test(int value1, int value2)
        {
            long time;
            TimeDecorator.GetTimeOfMethodWork(out time, GCD.GetGcdByEuclideanAlgorithm, value1, value2);
            Assert.Greater(time, 0);
        }

        [TestCase(arg1: 1071, arg2: 462)]
        public void GetGcdByStainAlgorithm_Test(int value1, int value2)
        {
            long time;
            TimeDecorator.GetTimeOfMethodWork(out time, GCD.GetGcdByStainAlgorithm, value1, value2);
            Assert.Greater(time, 0);
        }
    }
}
