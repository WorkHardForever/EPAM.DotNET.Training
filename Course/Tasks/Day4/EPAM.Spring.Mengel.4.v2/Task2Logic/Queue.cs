using System;
using System.Collections;
using System.Collections.Generic;

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
        /// Count elements of queue
        /// </summary>
        private int _size;

        /// <summary>
        /// Factor for resizing array
        /// </summary>
        private int _growFactor;

        #endregion

        #region Constructor

        /// <summary>
        /// Generate initial values
        /// </summary>
        /// <param name="capacity">Length of cyclin array</param>
        /// <param name="growFactor">Factor for resizing array</param>
        public Queue(int capacity = 10, int growFactor = 2)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException($"Requare {nameof(capacity)} more than zero");
            }

            if (growFactor < 1 || growFactor > 10)
            {
                throw new ArgumentOutOfRangeException($"Requare {nameof(growFactor)} between 1 to 10");
            }

            _array = new T[capacity];
            _growFactor = growFactor;
            StartValues();
        }

        #endregion

        #region Property

        /// <summary>
        /// Array length
        /// </summary>
        public int Count { get { return _size; } }

        #endregion

        #region Public Methods

        /// <summary>
        /// Enqueue <paramref name="obj"></paramref> to queue/>
        /// </summary>
        /// <param name="obj">Element for enqueuing to tail</param>
        public void Enqueue(T obj)
        {
            if (!HasTailDistanceToHead())
                SetNewArrayCapacity(Count * _growFactor);

            PutElementToTail(obj);
        }

        /// <summary>
        /// Dequeue from queue
        /// </summary>
        /// <returns>Head element</returns>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException($"{nameof(Count)} should be more than zero");
            }

            return TakeElementFromHead();
        }

        /// <summary>
        /// Give head element without removing
        /// </summary>
        /// <returns>Head element of queue</returns>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return _array[_head];
        }

        /// <summary>
        /// Delete all elements in queue
        /// </summary>
        public void Clear()
        {
            if (_head > _tail)
            {
                Array.Clear(_array, 0, _tail);
                Array.Clear(_array, _head, _array.Length - 1);
            }
            else
            {
                Array.Clear(_array, _head, _size);
            }

            StartValues();
        }

        /// <summary>
        /// Get item for foreach
        /// </summary>
        /// <returns>Yield item</returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (Count == 0)
            {
                yield break;
            }

            if (_head < _tail)
            {
                for (int i = _head; i <= _tail; i++)
                    yield return _array[i];
            }
            else
            {
                for (int i = _head; i < _size; i++)
                    yield return _array[i];
                for (int i = 0; i <= _tail; i++)
                    yield return _array[i];
            }
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
            _tail = -1;
            _size = 0;
        }

        /// <summary>
        /// Get know if array need resize for more elements
        /// </summary>
        /// <returns>False if need to resize</returns>
        private bool HasTailDistanceToHead()
        {
            if (_tail != -1 &&
                ((_tail > _head && _tail - _head == _array.Length - 1) ||
                (_tail < _head && _head - _tail == 1) ||
                (_tail == _head && _array.Length == 1)))
                return false;
            return true;
        }

        /// <summary>
        /// Extend array to bigger by capacity parameter
        /// </summary>
        /// <param name="capacity">New size for array</param>
        private void SetNewArrayCapacity(int capacity)
        {
            var newArray = new T[capacity];

            if (_head <= _tail)
            {
                Array.Copy(_array, _head, newArray, 0, Count);
            }
            else
            {
                Array.Copy(_array, _head, newArray, 0, _array.Length - _head);
                Array.Copy(_array, 0, newArray, _array.Length - _head, _tail + 1);
                _head = 0;
                _tail = _array.Length - 1;
            }

            _array = newArray;
        }

        /// <summary>
        /// Put <paramref name="obj"/> element to queue
        /// </summary>
        /// <param name="obj">Some new element</param>
        private void PutElementToTail(T obj)
        {
            _tail = (_tail + 1) % _array.Length;
            _array[_tail] = obj;
            _size++;
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
            _size--;

            if (Count == 0)
            {
                _tail = -1;
                _head = 0;
            }

            return result;
        }

        #endregion
    }
}
