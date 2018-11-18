using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySearchTree
{
    /// <summary>
    /// Binary search tree realization
    /// </summary>
    public class BinarySearchTree<T>
    {
        #region Fields

        /// <summary>
        /// Tree elements count
        /// </summary>
        private int _count;
        
        /// <summary>
        /// Tree root
        /// </summary>
        private Node<T> _root;

        /// <summary>
        /// Tree comparer
        /// </summary>
        private IComparer<T> _comparer;

        #endregion        

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree"/> class
        /// </summary>
        public BinarySearchTree(IComparer<T> comparer, IEnumerable<T> elements = null)
        {
            _comparer = comparer;

            if (elements != null)
            {
                foreach (T item in elements)
                {
                    Add(item);
                }
            }
        }

        #region Properties

        /// <summary>
        /// Get tree elements count
        /// </summary>
        public int Count => _count;

        #endregion

        #region Methods

        /// <summary>
        /// Add element to tree
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            if (_root == null)
            {
                _root = new Node<T>(data);
                _count++;                
            }
            else
            {
                Node<T> treeWalker;
                treeWalker = _root;

                while (treeWalker != null)
                {
                    if (_comparer.Compare(data, treeWalker.Data) > 0)
                    {
                        if (treeWalker.RightNode == null)
                        {
                            treeWalker.RightNode = new Node<T>(data);
                            return;
                        }
                        else
                        {
                            treeWalker = treeWalker.RightNode;
                        }
                    }
                    else
                    {
                        if (treeWalker.LeftNode == null)
                        {
                            treeWalker.LeftNode = new Node<T>(data);
                            return;
                        }
                        else
                        {
                            treeWalker = treeWalker.LeftNode;
                        }
                    }
                }
                
                _count++;
            }
        }

        /// <summary>
        /// Direct tree bypass
        /// </summary>
        /// <returns>Sequence of bypasses elements</returns>
        public IEnumerable<T> DirectBypass()
        {
            return DirectBypass(_root);
        }

        /// <summary>
        /// Symmetrical tree bypass
        /// </summary>
        /// <returns>Sequence of bypasses elements</returns>
        public IEnumerable<T> SymmetricalBypass()
        {
            return SymmetricalBypass(_root);
        }

        /// <summary>
        /// Reverse tree bypass
        /// </summary>
        /// <returns>Sequence of bypasses elements</returns>
        public IEnumerable<T> ReverseBypass()
        {
            return ReverseBypass(_root);
        }

        /// <summary>
        /// Direct bypass
        /// </summary>
        /// <param name="node">Current node</param>
        /// <returns>Tree values in direct order</returns>
        private IEnumerable<T> DirectBypass(Node<T> node)
        {
            yield return node.Data;

            if (node.LeftNode != null)
            {
                foreach (var value in DirectBypass(node.LeftNode))
                {
                    yield return value;
                }
            }

            if (node.RightNode != null)
            {
                foreach (var value in DirectBypass(node.RightNode))
                {
                    yield return value;
                }
            }
        }

        /// <summary>
        /// Symmetrical bypass
        /// </summary>
        /// <param name="node">Current node</param>
        /// <returns>Tree values in symmetrical order</returns>
        private IEnumerable<T> SymmetricalBypass(Node<T> node)
        {
            if (node.LeftNode != null)
            {
                foreach (var value in SymmetricalBypass(node.LeftNode))
                {
                    yield return value;
                }
            }

            yield return node.Data;

            if (node.RightNode != null)
            {
                foreach (var value in SymmetricalBypass(node.RightNode))
                {
                    yield return value;
                }
            }
        }

        /// <summary>
        /// Reverse bypass
        /// </summary>
        /// <param name="node">Current node</param>
        /// <returns>Tree values in reverse order</returns>
        private IEnumerable<T> ReverseBypass(Node<T> node)
        {
            if (node.LeftNode != null)
            {
                foreach (var value in ReverseBypass(node.LeftNode))
                {
                    yield return value;
                }
            }

            if (node.RightNode != null)
            {
                foreach (var value in ReverseBypass(node.RightNode))
                {
                    yield return value;
                }
            }

            yield return node.Data;
        }
        #endregion
    }
}
