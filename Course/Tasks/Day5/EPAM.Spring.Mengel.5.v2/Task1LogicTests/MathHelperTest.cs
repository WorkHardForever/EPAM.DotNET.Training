using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1Logic;

namespace Task1LogicTests
{
    [TestClass]
    public class MathHelperTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Sqrt_Negative_A()
        {
            MathHelper.Sqrt(-1, 10, 10, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Sqrt_Negative_n()
        {
            MathHelper.Sqrt(10, -1, 10, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Sqrt_Negative_x()
        {
            MathHelper.Sqrt(10, 10, -1, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Sqrt_Negative_delta()
        {
            MathHelper.Sqrt(10, 10, 10, -1);
        }
        
        [TestMethod]
        public void Sqrt_BigDouble_a()
        {
            var a = 117649.0;
            var n = 6;
            var startX = 2.0;
            var delta = 1E-10;
            var expected = 7.0;

            Assert.AreEqual(expected, MathHelper.Sqrt(a, n, startX, delta));
        }

        [TestMethod]
        public void Sqrt_BigDouble_a_and_n()
        {
            var a = 1594323.0;
            var n = 13;
            var startX = 2.0;
            var delta = 1E-10;
            var expected = 3.0;

            Assert.AreEqual(expected, MathHelper.Sqrt(a, n, startX, delta));
        }
    }
}
