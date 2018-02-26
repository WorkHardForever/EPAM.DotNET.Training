namespace Task2Logic
{
    /// <summary>
    /// Node of 1-linked list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Some data
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        /// Next element
        /// </summary>
        public Node<T> Next { get; set; }

        /// <summary>
        /// Simple ctor
        /// </summary>
        /// <param name="data"></param>
        public Node(T data)
        {
            Data = data;
        }
    }
}
