using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
    /// <summary>
    /// Class that describes generic collection Binary Search Tree
    /// </summary>
    /// <typeparam name="T">Generic type of tree node values</typeparam>
    public class BinarySearchTree<T> : IEnumerable where T : IComparable
    {
        private int count;
        private Node<T> head;

        /// <summary>
        /// Property for getting number of tree nodes
        /// </summary>
        public int Count => count;

        #region Public methods

        /// <summary>
        /// Method for adding a new node in collection
        /// </summary>
        /// <param name="value">Value of a new node</param>
        public void Add(T value)
        {
            if (head == null)
            {
                head = new Node<T>(value);
            }
            else
            {
                AddTo(head, value);
            }

            count++;
        }

        /// <summary>
        /// Determines whether given value is storaged in tree
        /// </summary>
        /// <param name="value">Given value</param>
        /// <returns>True if value is contained. Otherwise, false</returns>
        public bool Contains(T value)
        {
            return FindWithParent(value, out Node<T> parent) != null;
        }

        /// <summary>
        /// Deletes first node with given value
        /// </summary>
        /// <param name="value">Given value</param>
        /// <returns>True if value was contained in tree and was removed successfully. Otherwise, false</returns>
        public bool Remove(T value)
        {
            Node<T> current, parent;

            current = FindWithParent(value, out parent);

            if (current == null)
            {
                return false;
            }

            count--;

            if (current.Right == null)
            {
                if (parent == null)
                {
                    head = current.Left;
                }
                else
                {
                    int result = parent.Value.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (parent == null)
                {
                    head = current.Right;
                }
                else
                {
                    int result = parent.Value.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                Node<T> leftmost = current.Right.Left;
                Node<T> leftmostParent = current.Right;
                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                leftmostParent.Left = leftmost.Right;
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;
                if (parent == null)
                {
                    head = leftmost;
                }
                else
                {
                    int result = parent.Value.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = leftmost;
                    }
                    else if (result < 0)
                    {
                        parent.Right = leftmost;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Bypasses a tree in the prefix order.
        /// </summary>
        /// <returns>Sequence of tree nodes values</returns>
        public IEnumerable<T> PreOrder() => PreOrder(head);

        /// <summary>
        /// Bypasses a tree in the postfix order.
        /// </summary>
        /// <returns>Sequence of tree nodes values</returns>
        public IEnumerable<T> PostOrder() => PostOrder(head);

        /// <summary>
        /// Bypasses a tree in the infix order.
        /// </summary>
        /// <returns>Sequence of tree nodes values</returns>
        public IEnumerable<T> InOrder() => InOrder(head);

        /// <summary>
        /// Returns an iterator to traverse the tree in an infix order
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            yield return InOrder();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Removes all nodes from tree
        /// </summary>
        public void Clear()
        {
            head = null;
            count = 0;
        }

        #endregion

        #region Private Methods

        private void AddTo(Node<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(value);
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        private Node<T> FindWithParent(T value, out Node<T> parent)
        {
            Node<T> current = head;
            parent = null;
            while (current != null)
            {
                int result = current.Value.CompareTo(value);

                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private IEnumerable<T> PreOrder(Node<T> node)
        {
            yield return node.Value;

            if (node.Left != null)
            {
                foreach (var n in PreOrder(node.Left))
                {
                    yield return n;
                }
            }

            if (node.Right != null)
            {
                foreach (var n in PreOrder(node.Right))
                {
                    yield return n;
                }
            }
        }

        private IEnumerable<T> PostOrder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var n in PostOrder(node.Left))
                {
                    yield return n;
                }
            }

            if (node.Right != null)
            {
                foreach (var n in PostOrder(node.Right))
                {
                    yield return n;
                }
            }

            yield return node.Value;
        }

        private IEnumerable<T> InOrder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var n in InOrder(node.Left))
                {
                    yield return n;
                }
            }

            yield return node.Value;

            if (node.Right != null)
            {
                foreach (var n in InOrder(node.Right))
                {
                    yield return n;
                }
            }
        }

        #endregion
    }
}