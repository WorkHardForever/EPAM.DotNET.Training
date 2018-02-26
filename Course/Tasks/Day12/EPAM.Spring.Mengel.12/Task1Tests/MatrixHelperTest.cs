using NUnit.Framework;
using System;
using System.Collections.Generic;
using Task1Logic;

namespace Task1Tests
{
    [TestFixture]
    public class MatrixHelperTest
    {
        public IEnumerable<TestCaseData> Sum_Args
        {
            get
            {
                yield return new TestCaseData(
                new SquareMatrix<int>(
                    new int[][] {
                        new int[] { 1, 0, 0 },
                        new int[] { 0, 5, 0 },
                        new int[] { 0, 0, 9 }
                    }
                ),
                new SquareMatrix<int>(
                    new int[][] {
                        new int[] { 1, 0, 0 },
                        new int[] { 0, 5, 0 },
                        new int[] { 0, 0, 9 }
                    }
                )).Returns(new SquareMatrix<int>(
                    new int[][] {
                        new int[] { 2, 0, 0 },
                        new int[] { 0, 10, 0 },
                        new int[] { 0, 0, 18 }
                    }
                ));
                yield return new TestCaseData(
                new SymmetricMatrix<int>(
                    new int[][] {
                        new int[] { 10, 10, 10 },
                        new int[] { 10, 10, 10 },
                        new int[] { 10, 10, 10 }
                    }
                ),
                new DiagonalMatrix<int>(
                    new int[][] {
                        new int[] { 10, 0, 0 },
                        new int[] { 0, 10, 0 },
                        new int[] { 0, 0, 10 }
                    }
                )).Returns(new SquareMatrix<int>(
                    new int[][] {
                        new int[] { 20, 10, 10 },
                        new int[] { 10, 20, 10 },
                        new int[] { 10, 10, 20 }
                    }
                ));
            }
        }

        //[Test, TestCaseSource(nameof(Sum_Args))]
        //public SquareMatrix<int> Sum_Test(SquareMatrix<int> matrix, SquareMatrix<int> other)
        //{
        //    return matrix.Sum(other);
        //}
    }
}
