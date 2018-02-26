using NUnit.Framework;
using System;
using System.Collections.Generic;
using Task1Logic;
using Task1Tests.BinarySearchTreeTestAddons;

namespace Task1Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        public IEnumerable<TestCaseData> GetPreorderData
        {
            get
            {
                yield return new TestCaseData(
                    new BinarySearchTree<int>(new int[] { 5, 2, 8, 1, 3, 4, 7, 9, 6 }))
                    .Returns(new int[] { 5, 2, 1, 3, 4, 8, 7, 6, 9 });
            }
        }
        [Test, TestCaseSource(nameof(GetPreorderData))]
        public IEnumerable<int> GetPreorder_Test(BinarySearchTree<int> tree)
        {
            return tree.GetPreorder();
        }

        public IEnumerable<TestCaseData> GetInorderData
        {
            get
            {
                yield return new TestCaseData(
                    new BinarySearchTree<int>(new int[] { 5, 2, 8, 1, 3, 4, 7, 9, 6 }))
                    .Returns(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            }
        }
        [Test, TestCaseSource(nameof(GetInorderData))]
        public IEnumerable<int> GetInorder_Test(BinarySearchTree<int> tree)
        {
            return tree.GetInorder();
        }

        public IEnumerable<TestCaseData> GetPostorderData
        {
            get
            {
                yield return new TestCaseData(
                    new BinarySearchTree<int>(new int[] { 5, 2, 8, 1, 3, 4, 7, 9, 6 }))
                    .Returns(new int[] { 1, 4, 3, 2, 6, 7, 9, 8, 5 });
            }
        }
        [Test, TestCaseSource(nameof(GetPostorderData))]
        public IEnumerable<int> GetPostorder_Test(BinarySearchTree<int> tree)
        {
            return tree.GetPostorder();
        }

        public IEnumerable<TestCaseData> GetPreorderIntData
        {
            get
            {
                yield return new TestCaseData(
                    new BinarySearchTree<int>(new int[] { 5, 2, 8, 1 }, new IntComparer()))
                    .Returns(new int[] { 5, 2 });
            }
        }
        [Test, TestCaseSource(nameof(GetPreorderIntData))]
        public IEnumerable<int> InnerIntComparerToBinarySearchTree_Test(BinarySearchTree<int> tree)
        {
            return tree.GetPreorder();
        }

        public IEnumerable<TestCaseData> GetPreorderStringData
        {
            get
            {
                yield return new TestCaseData(
                    new BinarySearchTree<string>(new string[] { "e", "d", "g", "a", "r" },
                    new BinarySearchTreeTestAddons.StringComparer()))
                    .Returns(new string[] { "e", "d", "a", "g", "r" });
            }
        }
        [Test, TestCaseSource(nameof(GetPreorderStringData))]
        public IEnumerable<string> InnerStringComparerToBinarySearchTree_Test(BinarySearchTree<string> tree)
        {
            return tree.GetPreorder();
        }

        [TestCase(ExpectedException = typeof(ArgumentException))]
        public void InnerPointToBinarySearchTree_Test()
        {
            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(
                new Point[] { new Point(1, 2), new Point(3, 4), new Point(5, 6) });
        }
    }
}
