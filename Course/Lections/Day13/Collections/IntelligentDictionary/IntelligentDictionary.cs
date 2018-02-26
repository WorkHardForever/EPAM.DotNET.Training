using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntelligentDictionary
{
    class IntelligentDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        Dictionary<TKey, TValue> items;

        public IntelligentDictionary()
        {
            items = new Dictionary<TKey, TValue>();
        }

        /// <summary>
        /// Add a key/value pair to the dictionary
        /// Detect a key clash, and generate a new random key if necessary
        /// Return the key that is used
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public TKey AddItem(TKey key, TValue value)
        {
            //TODO
            throw new NotImplementedException();
        }
        
        #region Implementation of IEnumerable<out KeyValuePair<TKey,TValue>>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Implementation of ICollection<KeyValuePair<TKey,TValue>>
        // Define an overload of the Add method to implement the
        // ICollection<T> interface. Use the KeyValuePair<TKey, TValue>
        // generic type as the type parameter.
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            // Call the Add method that was already defined by using the
            // properties of the item parameter as the parameters for the
            // Add method.
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            items.Clear();
        }

        // Define an overload of the Contains method to implement the
        // ICollection<T> interface. Use the KeyValuePair<TKey, TValue>
        // generic type as the type parameter.
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return items.Contains(item);
        }

        // Define a CopyTo method that copies the items in the
        // collection to an array that is passed as a parameter. The array
        // has one dimension and stores instances of the
        // KeyValuePair<TKey, TValue> type, not instances of the TKey or TValue types.
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<TKey, TValue>>)items).CopyTo(array, arrayIndex);
        }

        // Define a Count property that returns the number of items in the collection.
        public int Count
        {
            get { return items.Count; }
        }

        // Define an IsReadOnly property that returns a bool value
        // to indicate whether the collection is read-only.
        public bool IsReadOnly
        {
            get { return false; }
        }

        // Add a Remove method that removes an item from the collection,
        // based on the KeyValuePair<TKey, TValue> object that is
        // passed as a parameter.
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return items.Remove(item.Key);
        }
        #endregion

        #region Implementation of IDictionary<TKey,TValue>
        // Define an Add method that adds a new item with the specified
        // key and value to the collection.
        public void Add(TKey key, TValue value)
        {
            items.Add(key, value);
        }

        // Define a ContainsKey method that returns a bool object
        // if the collection contains a particular key.
        public bool ContainsKey(TKey key)
        {
            return items.ContainsKey(key);
        }

        // Define a Keys property that returns a collection of keys
        // that are stored in the collection.
        public ICollection<TKey> Keys
        {
            get { return items.Keys; }
        }

        // Define a Remove method that removes an item with the specified
        // key from the collection and returns a bool value that indicates
        // whether the method succeeded.
        public bool Remove(TKey key)
        {
            return items.Remove(key);
        }

        // Define a TryGetValue method that returns a bool value to
        // indicate whether the method was successful, and if it was, sets
        // the value of the output parameter to the value that corresponds
        // to the specified key.
        public bool TryGetValue(TKey key, out TValue value)
        {
            return items.TryGetValue(key, out value);
        }

        // Define a Values property that returns an ICollection object
        // of the values that are stored in the collection.
        public ICollection<TValue> Values
        {
            get { return items.Values; }
        }

        // Define an indexer that reads/writes the value for an item in
        // the collection, based on the key specified.
        public TValue this[TKey key]
        {
            get
            {
                return items[key];
            }
            set
            {
                items[key] = value;
            }
        }
        #endregion

        #region Implementation of IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
