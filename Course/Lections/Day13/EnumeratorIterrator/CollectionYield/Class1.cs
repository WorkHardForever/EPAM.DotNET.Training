using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionYield
{
    public class CustomContainer<T> : IEnumerable<T>
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

        

      

        #region GetEnumerator
        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < _container.Length; i++)
                yield return _container[i];
        }
        #endregion

        #region Generator
        
        public IEnumerable<T> Reverse
        {
            get
            {
                for (var i = _container.Length - 1; i >= 0; i--)
                    yield return _container[i];
            }
        }
        #endregion

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
