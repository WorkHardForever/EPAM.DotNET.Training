using System;

namespace Task1Logic
{
    public class ChangedElementEventArgs : EventArgs
    {
        #region Public Fields

        public int I { get; private set; }
        public int J { get; private set; }


        #endregion

        #region Constructor

        public ChangedElementEventArgs(int i, int j)
        {
            I = i;
            J = j;
        }

        #endregion
    }
}
