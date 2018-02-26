using System;
using System.Collections;
using System.Collections.Generic;

namespace DoubleEndedQueue
{
    class DoubleEndedQueue<T> : IList<T>
    {
        /// <summary>
        /// List object stores items that are added to the collection
        /// </summary>
        private List<T> items;

        /// <summary>
        /// Constructor
        /// </summary>
        public DoubleEndedQueue()
        {
            items = new List<T>();
        }

        /// <summary>
        /// Enqueuing item to start of queue
        /// </summary>
        /// <param name="item"></param>
        public void EnqueueItemAtStart(T item)
        {
            //TODO
            throw new NotImplementedException(); 
        }

        /// <summary>
        /// Dequeuing item from start of queue
        /// </summary>
        /// <returns></returns>
        public T DeQueueItemFromStart()
        {
            //TODO
            throw new NotImplementedException(); 
        }

        /// <summary>
        /// Enqueuing item to end of queue
        /// </summary>
        /// <param name="item"></param>
        public void EnqueueItemAtEnd(T item)
        {
            //TODO
            throw new NotImplementedException(); 
        }

        /// <summary>
        /// Dequeuing item from end of queue
        /// </summary>
        /// <returns></returns>
        public T DeQueueItemFromEnd()
        {
            //TODO
            throw new NotImplementedException(); 
        }

        #region ICollection<T> Members
        /// <summary>
        /// Adding an item to queue
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            items.Add(item);
        }

        /// <summary>
        /// Removing all items from queue
        /// </summary>
        public void Clear()
        {
            items.Clear();
        }

        /// <summary>
        /// Return of a bool object according to whether the queue contains a particular item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        /// <summary>
        /// Copies the entire contents of queue to an array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removing the specified item from queue and returns a bool object 
        /// to indicate whether the item was removed successfully
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            return items.Remove(item);
        }

        /// <summary>
        /// Read-only property that returns the number of items in the queue
        /// </summary>
        public int Count
        {
            get { return items.Count; }
        }

        /// <summary>
        /// Read-only property that returns whether the queue is read-only
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion

        #region IEnumerable<T> Members
        /// <summary>
        /// Define a GetEnumerator method, which returns an IEnumerator object
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IEnumerable Members
        /// <summary>
        /// Define IEnumerable.GetEnumerator method (nongeneric version of the GetEnumerator method)
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            //throw new NotImplementedException();
            return GetEnumerator();
        }
        #endregion

        #region IList<T> Members
        /// <summary>
        /// Returns the index of the first occurrence of an item in the queue
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(T item)
        {
            return items.IndexOf(item);
        }

        /// <summary>
        /// Adding an item to the queue at aspecified index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
        {
            items.Insert(index, item);
        }

        /// <summary>
        /// Removing an item from the queue at the specified index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }

        /// <summary>
        /// Indexerthat enables read/write access to items in the queue, based on the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }
        #endregion
    }
}
