using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCollection
{
    class BasicCollection<T>
    {
        private List<T> data = new List<T>();

        public void FillList(params T[] items)
        {
            foreach (var datum in items)
            {
                data.Add(datum);
            }  
        }

        public void Delete(T item)
        {
            data.Remove(item);
        }

        #region Implementation of IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var datum in data)
            {
                yield return datum;
            }
        }

        #endregion

        public IEnumerable<T> Reverse
        {
            get
            {
                for (int i = data.Count - 1; i >= 0; i--)
                {
                    yield return data[i];
                }
            }
        }
    }
}
