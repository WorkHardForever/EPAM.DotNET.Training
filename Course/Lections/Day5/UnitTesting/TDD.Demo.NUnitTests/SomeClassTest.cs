using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TDD.Demo;
namespace TDD.Demo.NUnitTests
{
    public class SomeClassTest
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, Result = 15)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, -15 }, Result = 0)]
        [TestCase(null, ExpectedException = typeof(ArgumentNullException))]
        [TestCase(new int[] {1, int.MaxValue}, ExpectedException = typeof(OverflowException))]
        public static int SomeMethod_Test( int[] a)
        {
            return TDD.Demo.SomeClass.SomeMethod(a);
        }

        public IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5 }).Returns(15);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, -15} ).Returns(0);
                yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(new int[] { 1, int.MaxValue }).Throws(typeof(OverflowException));
            }
        }
        [Test, TestCaseSource("TestData")]
        public static int SomeMethod_Test_Yeild(int[] a)
        {
            return TDD.Demo.SomeClass.SomeMethod(a);
        }
    }
}
