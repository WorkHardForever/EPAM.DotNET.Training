using System;

namespace Task1Logic
{
    public static class MatrixHelper
    {
        #region Public Method

        public static SquareMatrix<T> Sum<T>(this SquareMatrix<T> matrix, SquareMatrix<T> other)
            where T : IComparable<T>
        {
            CheckArguments(matrix, other);
            if (matrix.Size != other.Size)
                throw new InvalidOperationException("Different sizes of matrixes.");

            return GetSum(matrix, other);
        }

        #endregion

        #region Private Methods

        private static void CheckArguments<T>(Matrix<T> matrix, Matrix<T> other)
            where T : IComparable<T>
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            if (other == null)
                throw new ArgumentNullException(nameof(other));
        }

        private static T[][] GenerateClearArray<T>(SquareMatrix<T> matrix)
            where T : IComparable<T>
        {
            var newMatrixValues = new T[matrix.Size][];
            for (int i = 0; i < matrix.Size; i++)
                newMatrixValues[i] = new T[matrix.Size];

            return newMatrixValues;
        }

        private static SquareMatrix<T> GetSum<T>(SquareMatrix<T> matrix, SquareMatrix<T> other)
            where T : IComparable<T>
        {
            var newMatrixValues = GenerateClearArray(matrix);

            try
            {
                for (int i = 0; i < matrix.Size; i++)
                    for (int j = 0; j < matrix.Size; j++)
                        newMatrixValues[i][j] = (dynamic)matrix[i, j] + other[i, j];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new SquareMatrix<T>(newMatrixValues);
        }

        #endregion
    }
}
