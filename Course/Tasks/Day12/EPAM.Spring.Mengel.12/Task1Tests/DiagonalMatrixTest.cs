using System;
using NUnit.Framework;
using Task1Logic;
using System.Collections.Generic;

namespace Task1Tests
{
    [TestFixture]
    public class DiagonalMatrixTest
    {
        public IEnumerable<TestCaseData> Ctor_Args
        {
            get
            {
                yield return new TestCaseData(new object[] {
                    new int[][] {
                        new int[] { 1, 0, 0 },
                        new int[] { 0, 5, 0 },
                        new int[] { 0, 0, 9 }
                    }
                });
                yield return new TestCaseData(new object[] {
                    new int[][] {
                        new int[] { 0, 0, 0 },
                        new int[] { 0, 0, 0 },
                        new int[] { 0, 0, 0 }
                    }
                });
            }
        }

        [Test, TestCaseSource(nameof(Ctor_Args))]
        public void Constructors_Test(int[][] values)
        {
            new DiagonalMatrix<int>(values);
        }

        public IEnumerable<TestCaseData> Ctor_Exceptions_Args
        {
            get
            {
                yield return new TestCaseData(new object[] {
                    new int[][] {
                        new int[] { 1, 2, 3 },
                        new int[] { 4, 5, 6 },
                        new int[] { 7, 8, 9 }
                    }
                });
                yield return new TestCaseData(new object[] {
                    new int[][] {
                        new int[] { 10, 10, 10 },
                        new int[] { 10, 10, 10 },
                        new int[] { 10, 10, 10 }
                    }
                });
            }
        }

        [Test, TestCaseSource(nameof(Ctor_Exceptions_Args))]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructors_Exceptions_Test(int[][] values)
        {
            new DiagonalMatrix<int>(values);
        }

        [TestCase(arg1: 2, arg2: 2, arg3: 15)]
        [TestCase(arg1: 0, arg2: 2, arg3: 145, ExpectedException = typeof(ArgumentException))]
        [TestCase(arg1: 1, arg2: 0, arg3: 462, ExpectedException = typeof(ArgumentException))]
        public void SetElement_Test(int i, int j, int value)
        {
            var matrix = new int[][] {
                new int[] { 10, 0, 0 },
                new int[] { 0, 10, 0 },
                new int[] { 0, 0, 10 }
            };

            var diagonal = new DiagonalMatrix<int>(matrix);
            diagonal.SetElement(i, j, value);

            Assert.AreEqual(value, diagonal.MatrixValues[i][j]);
        }
    }
}
