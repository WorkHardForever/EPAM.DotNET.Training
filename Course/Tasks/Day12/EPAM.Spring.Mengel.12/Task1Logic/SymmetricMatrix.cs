using System;

namespace Task1Logic
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
        where T : IComparable<T>
    {
        #region Public Field

        public override T[][] MatrixValues
        {
            get { return base.MatrixValues; }
            protected set
            {
                if (!this.IsCorrectMatrix(value))
                    throw new ArgumentException($"{nameof(value)} values not symmetric.");

                base.MatrixValues = value;
            }
        }

        #endregion

        #region Constructor

        public SymmetricMatrix(T[][] matrixValues)
            : base(matrixValues)
        { }

        #endregion

        #region Public Method

        public override void SetElement(int i, int j, T value)
        {
            if (i != j)
                MatrixValues[j][i] = value;

            base.SetElement(i, j, value);
        }

        #endregion

        #region Private Method

        protected virtual bool IsCorrectMatrix(T[][] matrixValues)
        {
            for (int i = 0; i < matrixValues.Length; i++)
                for (int j = 0; j < i; j++)
                    if (matrixValues[i][j].CompareTo(matrixValues[j][i]) != 0)
                        return false;
            return true;
        }

        #endregion
    }
}
