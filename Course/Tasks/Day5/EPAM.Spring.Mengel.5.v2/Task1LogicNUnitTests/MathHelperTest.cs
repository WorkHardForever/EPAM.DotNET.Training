using NUnit.Framework;
using System;
using Task1Logic;

namespace Task1LogicNUnitTests
{
    [TestFixture]
    public class MathHelperTest
    {
        [TestCase(arguments: new object[] { 117649.0, 6, 2.0, 1E-10 }, Result = 7.0)]
        [TestCase(arguments: new object[] { 1594323, 13, 2.0, 1E-10 }, Result = 3.0)]
        [TestCase(arguments: new object[] { 36.0, 2, 2.0, 1E-10 }, Result = 6.0)]
        [TestCase(arguments: new object[] { 10556001.0, 4, 2.0, 1E-10 }, Result = 57.0)]
        [TestCase(arguments: new object[] { -1, 10, 10, 1E-10 }, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(arguments: new object[] { 10, -1, 10, 1E-10 }, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(arguments: new object[] { 10, 10, -1, 1E-10 }, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(arguments: new object[] { 10, 10, 10, -1 }, ExpectedException = typeof(ArgumentOutOfRangeException))]
        public double Sqrt_Test(double a, int n, double startX, double delta) =>
            MathHelper.Sqrt(a, n, startX, delta);
    }
}
