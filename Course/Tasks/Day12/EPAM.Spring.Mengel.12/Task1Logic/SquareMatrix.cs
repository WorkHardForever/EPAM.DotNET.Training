using System;

namespace Task1Logic
{
    public class SquareMatrix<T> : Matrix<T>
        where T : IComparable<T>
    {
        #region Public Field

        public override T[][] MatrixValues
        {
            get { return _matrixValues; }
            protected set
            {
                if (value.Length != value[value.Length - 1].Length)
                    throw new ArgumentException($"{nameof(value)} values create not square matrix.");

                _matrixValues = value;
            }
        }

        #endregion

        #region Private Field

        private T[][] _matrixValues;

        #endregion

        #region Public Property

        public int Size { get { return MatrixValues.Length; } }

        #endregion

        #region Constructor

        public SquareMatrix(T[][] matrixValues)
            : base(matrixValues)
        {
            if (matrixValues == null)
                throw new ArgumentNullException(nameof(matrixValues));

            if (Size != matrixValues.Length)
                throw new ArgumentException($"{nameof(matrixValues)} has not equal size as current matrix");
        }

        #endregion

        #region Public Method

        public override void SetElement(int i, int j, T value)
        {
            MatrixValues[i][j] = value;
            base.SetElement(i, j, value);
        }

        #endregion
    }
}
