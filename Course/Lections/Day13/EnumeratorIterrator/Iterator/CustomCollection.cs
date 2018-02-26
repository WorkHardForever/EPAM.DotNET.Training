using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class CustomCollection<T>
    {

        #region Fields&Properties
        private readonly T[] _container;

        public int Count { get { return _container.Length; } }

        public T this[int index]
        {
            get { return _container[index]; }
            set { _container[index] = value; }
        }
        #endregion

        #region Constructors
        public CustomCollection(T[] array)
        {
            _container = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                _container[i] = array[i];
            }
        }
        #endregion

        #region Inner class-iterator

        public class CustomIterator
        {
            private readonly CustomCollection<T> _collection;
            private int _currentIndex;

            public CustomIterator(CustomCollection<T> collection)
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
        }
        #endregion

        #region Pattern Iterator
        public CustomIterator Iterator()
        {
            return new CustomIterator(this);
        }
        #endregion

        #region GetEnumerator
        public CustomIterator GetEnumerator()
        {
            return new CustomIterator(this);
        }

        #endregion

    }

}

