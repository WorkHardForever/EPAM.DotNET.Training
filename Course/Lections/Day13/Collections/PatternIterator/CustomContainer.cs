using System;
using System.Collections;
using System.Collections.Generic;

namespace PatternIterator
{
    public class CustomContainer<T> //: IEnumerable<T>
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
        public CustomContainer(T[] array)
        {
            _container = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                _container[i] = array[i];
            }
        } 
        #endregion

        #region Inner class-iterator
        //public class CustomIterator
        //{
        //    private readonly CustomContainer<T> _collection;
        //    private int _currentIndex;

        //    public CustomIterator(CustomContainer<T> collection)
        //    {
        //        this._currentIndex = -1;
        //        this._collection = collection;
        //    }

        //    public T Current
        //    {
        //        get
        //        {
        //            if (_currentIndex == -1 || _currentIndex == _collection.Count)
        //            {
        //                throw new InvalidOperationException();
        //            }
        //            return _collection[_currentIndex];
        //        }
        //    }

        //    public void Reset()
        //    {
        //        _currentIndex = -1;
        //    }

        //    public bool MoveNext()
        //    {
        //        return ++_currentIndex < _collection.Count;
        //    }

        //    // InvalidOperationException - при изменении коллекции!
        //} 
        #endregion

        #region Pattern Iterator
        //public CustomIterator Iterator()
        //{
        //    return new CustomIterator(this);
        //} 
        #endregion

        #region GetEnumerator
        //public CustomIterator GetEnumerator()
        //{
        //    return new CustomIterator(this);
        //}

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < _container.Length; i++)
                yield return _container[i];
            //return ((IEnumerable<T>) _container).GetEnumerator();
        } 
        #endregion

        #region Generator
        //public IEnumerable<T> Reverse()
        //{
        //    for (var i = _container.Length - 1; i >= 0; i--)
        //        yield return _container[i];
        //}

        public IEnumerable<T> Reverse
        {
            get
            {
                for (var i = _container.Length - 1; i >= 0; i--)
                    yield return _container[i];
            }
        } 
        #endregion

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}

       
    }
}