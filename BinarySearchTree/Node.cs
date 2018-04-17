using System;

namespace BinarySearchTree
{
    /// <summary>
    /// Class that describes nodes of Binary Search Tree
    /// </summary>
    /// <typeparam name="T">System or user type</typeparam>
    public class Node<T> : INodeComparer<Node<T>> where T : IComparable   
    {
        /// <summary>
        /// Constructor for node with given value
        /// </summary>
        /// <param name="value">Given value</param>
        public Node(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Reference on left node
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// Reference on right node
        /// </summary>
        public Node<T> Right { get; set; }

        /// <summary>
        /// Value of tree node
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Compares tree nodes by custom comparator
        /// </summary>
        /// <param name="other">Other node to compare with</param>
        /// <returns>Result of order comparation as soon as generic type T implements <see cref="IComparable"/> interface</returns>
        public int Compare(Node<T> other) => Value.CompareTo(other.Value);
    }
}
