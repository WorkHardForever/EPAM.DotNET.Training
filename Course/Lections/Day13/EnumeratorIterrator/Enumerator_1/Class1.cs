using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerator_1
{
    public class CustomCollection<T> : IEnumerable<T>
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

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_container).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

