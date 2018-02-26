using NUnit.Framework;
using System.Collections;
using System.Linq;
using Task3Logic;
using Task3Logic.Comparators;

namespace Task3Testt
{
    [TestFixture]
    public class SortTest
    {
        [Test]
        [ExpectedException("System.ArgumentNullException")]
        public void TestNull()
        {
            int[][] ar = null;
            DelegateToInterfaceSort.SortBy(ar, new ComparatorBySum().Compare);
            DelegateToInterfaceSort.SortBy(ar, new ComparatorByMaxElement().Compare);

        }

        [Test]
        public void TestSum()
        {
            int[][] start = new[] { new[] { 1 }, null, null, new[] { -2, 7, 5 }, null, new[] { 40, 2 } };
            int[][] result = new[] { null, null, null, new[] { 1 }, new[] { -2, 7, 5 }, new[] { 40, 2 } };
            DelegateToInterfaceSort.SortBy(start, new ComparatorByMaxElement().Compare);
            IStructuralEquatable eq = start;
            Assert.AreEqual(eq.Equals(result, StructuralComparisons.StructuralEqualityComparer), true);
        }
    }
}
