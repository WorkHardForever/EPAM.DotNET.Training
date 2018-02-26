using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Demo;

namespace TDD.DemoTests
{
    [TestClass]
    public class SomeClassTest
    {
        [TestMethod]
        public void SameMethod_All_Positive_Numbers()
        {
            var a = new int[] { 1, 2, 3, 4, 5 };

            int expected = 15;

            int actual = SomeClass.SomeMethod(a);

            Assert.AreEqual(expected, actual);
            //Assert.AreEqual();
        }

        [TestMethod]
        public void SameMethod_Negative_Numbers_Exist()
        {
            var a = new int[] { 1, 2, 3, 4, 5, -15 };

            int expected = 0;

            int actual = SomeClass.SomeMethod(a);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SameMethod_Empty_Array()
        {
            var a = new int[] { };

            int expected = 0;

            int actual = SomeClass.SomeMethod(a);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SameMethod_Null_Reference()
        {
            int[] a = null;

            int expected = 0;

            int actual = SomeClass.SomeMethod(a);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void SameMethod_Overflow_Exception()
        {
            int[] a = { 1, int.MaxValue };
            int actual = SomeClass.SomeMethod(a);
        }
    }
}
