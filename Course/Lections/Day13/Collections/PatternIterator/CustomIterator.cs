using System;
using System.Collections.Generic;

namespace PatternIterator
{
    public class CustomIterator<T> : IEnumerator<T>
    {
        private readonly CustomContainer<T> _collection;
        private int _currentIndex;

        public CustomIterator(CustomContainer<T> collection)
        {
            this._currentIndex = -1;
            this._collection = collection;
        }

        public T Current
        {
            get
            {
                if (_currentIndex == -1 || _currentIndex == _collection.Count)
                {
                    throw new InvalidOperationException();
                }
                return _collection[_currentIndex];
            }
        }

        public void Reset()
        {
            _currentIndex = -1;
        }

        public bool MoveNext()
        {
            return ++_currentIndex < _collection.Count;
        }

        // InvalidOperationException - при изменении коллекции!

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        object System.Collections.IEnumerator.Current
        {
            get { throw new NotImplementedException(); }
        }
    }
}
