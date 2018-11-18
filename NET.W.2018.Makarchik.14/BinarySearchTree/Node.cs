using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySearchTree
{
    /// <summary>
    /// Tree node
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    public class Node<T>
    {
        #region Properties

        /// <summary>
        /// Store data
        /// </summary>
        public T Data { set; get; }

        /// <summary>
        /// Left node
        /// </summary>
        public Node<T> LeftNode { set; get; }

        /// <summary>
        /// Right node
        /// </summary>
        public Node<T> RightNode { set; get; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class
        /// </summary>
        public Node(T data)
        {
            Data = data;
            LeftNode = RightNode = null;
        }
    }
}
