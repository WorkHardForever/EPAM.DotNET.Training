namespace Task1Logic
{
    /// <summary>
    /// Node for tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTreeNode<T>
    {
        #region Properties

        /// <summary>
        /// Some data
        /// </summary>
        public T Value { get; set; }
        /// <summary>
        /// Left node
        /// </summary>
        public BinaryTreeNode<T> Left { get; set; }
        /// <summary>
        /// Right node
        /// </summary>
        public BinaryTreeNode<T> Right { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Simple ctor
        /// </summary>
        /// <param name="value"></param>
        public BinaryTreeNode(T value)
            : this(value, null, null)
        { }

        /// <summary>
        /// Simple ctor
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public BinaryTreeNode(T value, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        #endregion
    }
}
