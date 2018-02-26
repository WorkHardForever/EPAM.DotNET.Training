using System;

namespace Task1Logic
{
    public abstract class Matrix<T>
        where T : IComparable<T>
    {
        #region Public Field

        public virtual T[][] MatrixValues { get; protected set; }

        #endregion

        #region Constructor

        public Matrix(T[][] matrixValues)
        {
            MatrixValues = matrixValues;
        }

        #endregion

        #region Indexer

        public T this[int i, int j] =>
            MatrixValues[i][j];

        #endregion

        #region Public Method

        public virtual void SetElement(int i, int j, T value)
        {
            MatrixValues[i][j] = value;
            OnChangedElement(i, j);
        }

        #endregion

        #region Protected Method

        protected void OnChangedElement(int i, int j) =>
            ChangedElement?.Invoke(this, new ChangedElementEventArgs(i, j));

        #endregion

        #region Event
        
        public event EventHandler<ChangedElementEventArgs> ChangedElement;

        #endregion
    }
}
