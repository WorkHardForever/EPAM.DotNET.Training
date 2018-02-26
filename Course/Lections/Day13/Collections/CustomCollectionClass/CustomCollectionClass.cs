using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomCollectionClass
{
    class CustomCollectionClass<T> : IEnumerator<T>
    {
        // An array that stores data internally.
        readonly T[] _values = new T[10];

        public CustomCollectionClass() { }

        // An int object to hold the current position of the enumerator.
        int _pointer = -1;

        #region IEnumerator<T> Members
        // Define a Current property to return the current item.
        // You should include validation to ensure that the pointer is
        // currently valid.
        public T Current
        {
            get
            {
                // Check that the state is valid.
                if (_pointer != -1 )
                {
                    return _values[_pointer];
                }
                // Throw an exception if the current state is not valid.
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        #endregion

        #region IDisposable Members

        // Implement the IDisposable interface and associated methods.
        public void Dispose() { }

        #endregion

        #region IEnumerator Members

        // Define a Current property for the IEnumerable interface.
        // Return the Current property from the type-safe generic
        // IEnumerator<T> interface.
        object IEnumerator.Current
        {
            get { return (object)Current; }
        }

        // Define a MoveNext method that advances the enumerator to the
        // next item in the collection.
        public bool MoveNext()
        {
            // You should check that the enumerator will not pass the end
            //of the collection if you advance it.
            if (_pointer < (_values.Length - 1))
            {
                _pointer++;
                // Return true if the enumerator successfully advances.
                return true;
            }
            else
            {
                // Return false if the enumerator will pass the end of the
                // collection if you advance it.
                return false;
            }
        }

        // Define a Reset method that restores the enumerator to the
        // initial state, before the first item.
        public void Reset()
        {
            _pointer = -1;
        }

        #endregion
    }
}
