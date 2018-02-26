using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task3Logic
{
    /// <summary>
    /// Math set using ISet
    /// </summary>
    /// <typeparam name="T">Some unknown user type</typeparam>
    public class Set<T> : ISet<T>
    {
        #region Field

        private List<T> _set;

        #endregion

        #region Constructors

        /// <summary>
        /// Simple ctor
        /// </summary>
        public Set()
        {
            _set = new List<T>();
        }

        /// <summary>
        /// Get set by collection
        /// </summary>
        /// <param name="collection"></param>
        public Set(IEnumerable<T> collection)
        {
            AddRange(collection);
        }

        #endregion

        #region Properies

        /// <summary>
        /// Count of set
        /// </summary>
        public int Count { get { return _set.Count; } }

        /// <summary>
        /// Just implementation of interface
        /// </summary>
        public bool IsReadOnly { get { return false; } }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add some item to set
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Add(T item)
        {
            if (Contains(item))
                return false;

            _set.Add(item);
            return true;
        }

        /// <summary>
        /// Remove item from set
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item) =>
            _set.Remove(item);

        /// <summary>
        /// Check consist this item in set
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item) =>
            _set.Contains(item);

        /// <summary>
        /// Union operation
        /// </summary>
        /// <param name="other"></param>
        public void UnionWith(IEnumerable<T> other)
        {
            foreach (var item in other)
                if (!Contains(item))
                    Add(item);
        }

        /// <summary>
        /// Intersect operation
        /// </summary>
        /// <param name="other"></param>
        public void IntersectWith(IEnumerable<T> other)
        {
            foreach (var item in other)
                if (!_set.Contains(item))
                    Remove(item);
        }

        /// <summary>
        /// Except operation
        /// </summary>
        /// <param name="other"></param>
        public void ExceptWith(IEnumerable<T> other)
        {
            foreach (var item in other)
                if (_set.Contains(item))
                    Remove(item);
        }

        /// <summary>
        /// Symmetric Except operation
        /// </summary>
        /// <param name="other"></param>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            var newSet = new Set<T>(_set);
            IntersectWith(other);

            var temp = _set;
            _set = newSet._set;
            newSet._set = temp;

            UnionWith(other);
            ExceptWith(newSet);
        }

        /// <summary>
        /// Is subset set with other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (Count == 0)
                return true;

            foreach (var item in _set)
                if (!other.Contains(item))
                    return false;

            return true;
        }

        /// <summary>
        /// Is superset set with other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (Count < other.ToList().Count)
                return false;

            var set = other.ToList();
            foreach (var item in set)
                if (!Contains(item))
                    return false;

            return true;
        }

        /// <summary>
        /// Is proper superset set with other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            var otherCount = other.ToList().Count;
            if (Count == 0 || otherCount == 0)
                return true;

            if (Count <= otherCount)
                return false;

            int exist = 0, notExist = 0;
            foreach (var item in _set)
                if (other.Contains(item))
                    exist++;
                else
                    notExist++;

            return exist != 0 && notExist != 0;
        }

        /// <summary>
        /// Is proper subset with other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            if (Count == 0 || other.ToList().Count == 0)
                return true;

            foreach (var item in _set)
                if (other.Contains(item))
                    continue;
                else
                    return false;

            var otherList = other.ToList();
            foreach (var item in otherList)
                if (Contains(item))
                    continue;
                else
                    return true;

            return false;
        }

        /// <summary>
        /// Overlaps set with other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Overlaps(IEnumerable<T> other)
        {
            var otherList = other.ToList();
            if (otherList.Count > Count)
            {
                foreach (var item in otherList)
                    if (Contains(item))
                        return true;
                return false;
            }
            else
            {
                foreach (var item in _set)
                    if (other.Contains(item))
                        return true;
            }

            return false;
        }

        /// <summary>
        /// Set equals set with other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool SetEquals(IEnumerable<T> other)
        {
            var otherList = other.ToList();
            foreach (var item in otherList)
                if (!Contains(item))
                    return false;

            foreach (var item in _set)
                if (!other.Contains(item))
                    return false;

            return true;
        }

        /// <summary>
        /// Clear set
        /// </summary>
        public void Clear() =>
            _set.Clear();

        /// <summary>
        /// CopyTo array by index
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < array.Length; i++)
                _set[i + arrayIndex] = array[i];
        }

        /// <summary>
        /// Foreach machine
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _set.GetEnumerator();
        }

        #endregion

        #region Private Method

        private void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Add(item);
        }

        #endregion

        #region Interface methods

        bool ISet<T>.Add(T item) =>
            Add(item);

        void ICollection<T>.Add(T item) =>
            Add(item);

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();

        #endregion
    }
}
