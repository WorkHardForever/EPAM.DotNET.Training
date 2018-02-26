using System;

namespace Task1Logic
{
    public class DiagonalMatrix<T> : SymmetricMatrix<T>
        where T : IComparable<T>
    {
        #region Public Field

        public override T[][] MatrixValues
        {
            get { return base.MatrixValues; }
            protected set
            {
                try
                {
                    base.MatrixValues = value;
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException($"{nameof(value)} values not diagonal.");
                }
            }
        }

        #endregion

        #region Constructor

        public DiagonalMatrix(T[][] matrixValues)
            : base(matrixValues)
        { }

        #endregion

        #region Public Method

        public override void SetElement(int i, int j, T value)
        {
            if (value.Equals(default(T)))
                base.SetElement(i, j, value);
            else if (i == j)
            {
                MatrixValues[i][i] = value;
                OnChangedElement(i, i);
            }
            else
                throw new ArgumentException("Current args can't be used in diagonal matrix.");
        }

        #endregion

        #region Protected Method

        protected override bool IsCorrectMatrix(T[][] matrixValues)
        {
            for (int i = 0; i < matrixValues.Length; i++)
                for (int j = 0; j < matrixValues[i].Length; j++)
                    if (i != j && matrixValues[i][j].CompareTo(default(T)) != 0)
                        return false;
            return true;
        }

        #endregion
    }
}
