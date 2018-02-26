using System;
using System.Collections;
using System.Collections.Generic;
using Task1Logic.Exeptions;

namespace Task1Logic
{
    /// <summary>
    /// Simple custom queue using cyclic array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        #region Fields

        /// <summary>
        /// Default empty array
        /// </summary>
        private static readonly T[] _emptyArray = new T[0];

        /// <summary>
        /// Cyclic auto-resizing array
        /// </summary>
        private T[] _array;

        /// <summary>
        /// Head of queue
        /// </summary>
        private int _head;

        /// <summary>
        /// Tail of queue
        /// </summary>
        private int _tail;

        /// <summary>
        /// Factor for resizing array (please, use property GrowFactor)
        /// </summary>
        private int _growFactor;

        /// <summary>
        /// Version should be for Class-Enumerator
        /// </summary>
        private int _version;

        #endregion

        #region Constructor

        /// <summary>
        /// Create empty queue
        /// </summary>
        public Queue()
        {
            _array = _emptyArray;
            GrowFactor = 2;
        }

        /// <summary>
        /// Generate queue by collection
        /// </summary>
        /// <param name="collection">Some enumerable</param>
        public Queue(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new NullReferenceException(nameof(collection));

            _array = new T[4];
            Count = 0;
            GrowFactor = 2;
            _version = 0;

            foreach (T obj in collection)
                Enqueue(obj);
        }

        /// <summary>
        /// Generate initial values
        /// </summary>
        /// <param name="capacity">Length of cyclin array</param>
        /// <param name="growFactor">Factor for resizing array</param>
        public Queue(int capacity = 10, int growFactor = 2)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException($"Requare {nameof(capacity)} more than zero");

            _array = new T[capacity];
            GrowFactor = growFactor;
            StartValues();
        }

        #endregion

        #region Property

        /// <summary>
        /// Count elements of queue
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Factor for resizing array
        /// </summary>
        public int GrowFactor
        {
            get { return _growFactor; }
            set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentOutOfRangeException($"Requare {nameof(value)} between 1 to 10");
                }

                _growFactor = value;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Enqueue <paramref name="item"></paramref> to queue/>
        /// </summary>
        /// <param name="item">Element for enqueuing to tail</param>
        public void Enqueue(T item)
        {
            if (Count == _array.Length)
                SetCapacity(Count * GrowFactor + 4);

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

            return _array[_head];
        }

        /// <summary>
        /// Delete all elements in queue
        /// </summary>
        public void Clear()
        {
            if (_head < _tail)
            {
                Array.Clear(_array, _head, Count);
            }
            else
            {
                Array.Clear(_array, _head, _array.Length - _head);
                Array.Clear(_array, 0, _tail);
            }

            _version++;
            StartValues();
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
        /// Initialize values
        /// </summary>
        private void StartValues()
        {
            _head = 0;
            _tail = 0;
            Count = 0;
        }

        /// <summary>
        /// Extend array to bigger by capacity parameter
        /// </summary>
        /// <param name="capacity">New size for array</param>
        private void SetCapacity(int capacity)
        {
            var newArray = new T[capacity];

            if (Count > 0)
            {
                if (_head < _tail)
                {
                    Array.Copy(_array, _head, newArray, 0, Count);
                }
                else
                {
                    Array.Copy(_array, _head, newArray, 0, _array.Length - _head);
                    Array.Copy(_array, 0, newArray, _array.Length - _head, _tail);
                }
            }

            _version++;
            _head = 0;
            _tail = Count == capacity ? 0 : Count;
            _array = newArray;
        }

        /// <summary>
        /// Put <paramref name="item"/> element to queue
        /// </summary>
        /// <param name="item">Some new element</param>
        private void PutElementToTail(T item)
        {
            _array[_tail] = item;
            _tail = (_tail + 1) % _array.Length;
            Count++;
        }

        /// <summary>
        /// Get and delete head element from queue
        /// </summary>
        /// <returns>Current head element</returns>
        private T TakeElementFromHead()
        {
            var result = _array[_head];
            _array[_head] = default(T);
            _head = (_head + 1) % _array.Length;
            Count--;

            return result;
        }

        private T GetElement(int i)
        {
            return _array[(_head + i) % _array.Length];
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
            private T _currentElement;

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
                _currentElement = default(T);
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

                    return _currentElement;
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
                _currentElement = default(T);
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

                _currentIndex++;

                if (_currentIndex == _queue.Count)
                {
                    Dispose();
                    return false;
                }

                _currentElement = _queue.GetElement(_currentIndex);
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
                _currentElement = default(T);
            }

            #endregion
        }

        #endregion
    }
}
