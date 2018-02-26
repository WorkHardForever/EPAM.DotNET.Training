using System;
using System.Collections;
using System.Collections.Generic;
using Task2Logic.Exeptions;

namespace Task2Logic
{
    /// <summary>
    /// Simple custom queue using cyclic array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        #region Fields

        /// <summary>
        /// Head of queue
        /// </summary>
        private Node<T> _head;

        /// <summary>
        /// Tail of queue
        /// </summary>
        private Node<T> _tail;

        /// <summary>
        /// Version should be for Class-Enumerator
        /// </summary>
        private int _version;

        #endregion

        #region Constructor

        /// <summary>
        /// Create empty queue
        /// </summary>
        public Queue() { }

        /// <summary>
        /// Generate queue by collection
        /// </summary>
        /// <param name="collection">Some enumerable</param>
        public Queue(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException();

            foreach (T obj in collection)
                Enqueue(obj);
        }

        #endregion

        #region Property

        /// <summary>
        /// Count elements of queue
        /// </summary>
        public int Count { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Enqueue <paramref name="item"></paramref> to queue/>
        /// </summary>
        /// <param name="item">Element for enqueuing to tail</param>
        public void Enqueue(T item)
        {
            _version++;
            PutElementToTail(item);
        }

        /// <summary>
        /// Dequeue from queue
        /// </summary>
        /// <returns>Head element</returns>
        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException($"{nameof(Count)} should be more than zero");

            _version++;
            return TakeElementFromHead();
        }

        /// <summary>
        /// Give head element without removing
        /// </summary>
        /// <returns>Head element of queue</returns>
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            return _head.Data;
        }

        /// <summary>
        /// Delete all elements in queue
        /// </summary>
        public void Clear()
        {
            _version++;

            _head = null;
            _tail = null;
            Count = 0;
        }

        /// <summary>
        /// Get item for foreach
        /// </summary>
        /// <returns>Yield item</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        /// <summary>
        /// Get item for foreach
        /// </summary>
        /// <returns>Yield item</returns>
        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();

        #endregion

        #region Private Methods

        /// <summary>
        /// Put <paramref name="item"/> element to queue
        /// </summary>
        /// <param name="item">Some new element</param>
        private void PutElementToTail(T item)
        {
            var previousNode = _tail;
            _tail = new Node<T>(item);

            if (Count == 0)
                _head = _tail;
            else
                previousNode.Next = _tail;

            Count++;
        }

        /// <summary>
        /// Get and delete head element from queue
        /// </summary>
        /// <returns>Current head element</returns>
        private T TakeElementFromHead()
        {
            var data = _head.Data;
            _head = _head.Next;
            Count--;

            return data;
        }

        #endregion

        #region Inner Class-iterator

        /// <summary>
        /// Class-iterator for Queue
        /// </summary>
        public struct Enumerator : IEnumerator<T>
        {
            #region Fields

            private Queue<T> _queue;
            private int _version;
            private int _currentIndex;
            private Node<T> _head;
            private Node<T> _currentElement;

            #endregion

            #region Constructor

            /// <summary>
            /// Clone queue to Enumerator queue
            /// </summary>
            /// <param name="queue"></param>
            public Enumerator(Queue<T> queue)
            {
                _queue = queue;
                _version = _queue._version;
                _currentIndex = -1;
                _head = queue._head;
                _currentElement = _head;
            }

            #endregion

            #region Property

            /// <summary>
            /// Get current element of Queue in foreach
            /// </summary>
            public T Current
            {
                get
                {
                    if (_currentIndex < 0)
                        throw new InvalidOperationException();

                    return _currentElement.Data;
                }
            }

            #endregion

            #region Public Methods

            /// <summary>
            /// IEnumerator implementation of dispose method
            /// </summary>
            public void Dispose()
            {
                _currentIndex = -2;
                _currentElement = _head;
            }

            /// <summary>
            /// IEnumerator implementation of MoveNext method for foreach
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                if (_version != _queue._version)
                    throw new VersionException();

                if (_currentIndex == -2)
                    return false;

                if (_currentElement.Next == null)
                {
                    Dispose();
                    return false;
                }

                if (_currentIndex != -1)
                    _currentElement = _currentElement.Next;

                _currentIndex++;
                return true;
            }

            #endregion

            #region Interface methods

            object IEnumerator.Current { get { return Current; } }

            void IEnumerator.Reset()
            {
                if (_version != _queue._version)
                    throw new VersionException();

                _currentIndex = -1;
                _currentElement = _head;
            }

            #endregion
        }

        #endregion
    }
}
