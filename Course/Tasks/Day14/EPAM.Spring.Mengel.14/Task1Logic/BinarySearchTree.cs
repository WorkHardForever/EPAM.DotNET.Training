using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task1Logic
{
    /// <summary>
    /// Simple implementation of binary search tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        #region Fields

        private BinaryTreeNode<T> _root;

        private Comparison<T> _comparer;

        #endregion

        #region Constructors

        /// <summary>
        /// Create empty tree
        /// </summary>
        public BinarySearchTree()
        {
            SetDefaultComparer();
        }

        /// <summary>
        /// Gets start tree comparer
        /// </summary>
        /// <param name="comparer"></param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            if (comparer == null)
                SetDefaultComparer();
            else
                _comparer = (t1, t2) => comparer.Compare(t1, t2);
        }

        /// <summary>
        /// Gets start tree comparer
        /// </summary>
        /// <param name="comparer"></param>
        public BinarySearchTree(Comparison<T> comparer)
        {
            if (comparer == null)
                SetDefaultComparer();
            else
                _comparer = comparer;
        }

        /// <summary>
        /// Gets start tree items
        /// </summary>
        /// <param name="items"></param>
        public BinarySearchTree(IEnumerable<T> items)
        {
            SetDefaultComparer();
            ItemsInit(items);
        }

        /// <summary>
        /// Gets start tree items and comparer
        /// </summary>
        /// <param name="items"></param>
        /// <param name="_comparer"></param>
        public BinarySearchTree(IEnumerable<T> items, IComparer<T> _comparer)
            : this(_comparer)
        {
            ItemsInit(items);
        }

        /// <summary>
        /// Gets start tree items and comparer
        /// </summary>
        /// <param name="items"></param>
        /// <param name="_comparer"></param>
        public BinarySearchTree(IEnumerable<T> items, Comparison<T> _comparer)
            : this(_comparer)
        {
            ItemsInit(items);
        }

        #endregion

        #region Property

        /// <summary>
        /// Size of this tree
        /// </summary>
        public int Count { get; private set; } = 0;

        #endregion

        #region Public Methods

        /// <summary>
        /// Add new node by data of type T
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (EqualityComparer<T>.Default.Equals(item, default(T)))
                throw new ArgumentNullException(nameof(item));

            AddNode(item);
            Count++;
        }

        /// <summary>
        /// Get finding node result
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            if (EqualityComparer<T>.Default.Equals(item, default(T)))
                throw new ArgumentNullException(nameof(item));

            return FindNodeByValue(item) != null;
        }

        #region Traversals

        /// <summary>
        /// Preorder traversals
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetPreorder()
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(_root);

            while (stack.Count != 0)
            {
                var current = stack.Pop();
                if (current != null)
                {
                    stack.Push(current.Right);
                    stack.Push(current.Left);
                    yield return current.Value;
                }
            }
        }

        /// <summary>
        /// Inoreder traversals
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetInorder()
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            var current = _root;

            while (true)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                if (stack.Count == 0)
                    break;

                current = stack.Pop();
                yield return current.Value;
                current = current.Right;
            }
        }

        /// <summary>
        /// Postorder traversals
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetPostorder()
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T> current = _root, parent = null;

            while (true)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                if (stack.Count == 0)
                    break;

                current = stack.Peek();

                if (current.Right != null && current.Right != parent)
                    current = current.Right;
                else
                {
                    yield return current.Value;
                    parent = current;
                    current = null;
                    stack.Pop();
                }
            }
        }

        #endregion

        /// <summary>
        /// IEnumerable implementation
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() =>
            GetInorder().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();

        #endregion

        #region Private Methods

        private void AddNode(T item)
        {
            BinaryTreeNode<T> nodeCurrent = _root, nodeParent = null;
            int comparison;
            while (nodeCurrent != null)
            {
                comparison = _comparer(item, nodeCurrent.Value);
                if (comparison == 0)
                    return;

                nodeParent = nodeCurrent;
                if (comparison > 0)
                    nodeCurrent = nodeCurrent.Right;
                else
                    nodeCurrent = nodeCurrent.Left;
            }

            if (nodeParent == null)
                _root = new BinaryTreeNode<T>(item);
            else
            {
                comparison = _comparer(item, nodeParent.Value);
                if (comparison > 0)
                    nodeParent.Right = new BinaryTreeNode<T>(item);
                else
                    nodeParent.Left = new BinaryTreeNode<T>(item);
            }
        }

        private BinaryTreeNode<T> FindNodeByValue(T item)
        {
            BinaryTreeNode<T> current = _root;
            int comparison;
            while (current != null)
            {
                comparison = _comparer(item, current.Value);

                if (comparison == 0)
                    return current;
                if (comparison > 0)
                    current = current.Right;
                else
                    current = current.Left;
            }
            return null;
        }

        private void SetDefaultComparer()
        {
            if (!typeof(T).GetInterfaces().Contains(typeof(IComparable<T>)))
                throw new ArgumentException($"{typeof(T)} hasn't implement IComparable.");

            _comparer = (t1, t2) => (t1 as IComparable<T>).CompareTo(t2);
        }

        private void ItemsInit(IEnumerable<T> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            foreach (var item in items)
                Add(item);
        }

        #endregion
    }
}
