using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh12GenericsAndCollections.BST
{
    public class BinarySearchTree<T> where T: IComparable
    {
        public Node<T> Root { get; private set; }
        public int Count { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public BinarySearchTree()
        {
            Root = null;
            Count = 0;
        }

        /// <summary>
        /// This method is delete an element in BST.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="key"></param>
        public void Delete(Node<T> node, T key)
        {
            Root = DeleteRecursive(node, key);
        }

        /// <summary>
        /// Inorder traversal to BST. Starting with left most child, then go to right most child.
        /// </summary>
        public void Inorder()
        {
            InorderRecursive(Root);
        }

        /// <summary>
        /// This method insert the object into binary structure
        /// </summary>
        /// <param name="key"></param>
        public void Insert(T key)
        {
            Root = InsertRecursive(Root, key);
        }

        /// <summary>
        /// This method for searching element into the BST.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Node<T> Search(Node<T> node, T key)
        {
            if (node == null || node.CompareTo(key) == 0)
            {
                return node;
            }
            if (node.CompareTo(key)>=0)
            {
                return Search(node.Left, key);
            }
            return Search(node.Right, key);
        }

        private Node<T> InsertRecursive(Node<T> root, T key)
        {
            if (root == null)
            {
                root = new Node<T>(key);
                Count++;
                return root;
            }

            if (root.CompareTo(key) > 0) 
            {
                root.Left = InsertRecursive(root.Left, key);
            }
            if (root.CompareTo(key) < 0)
            {
                root.Right = InsertRecursive(root.Right, key);
            }
            return root;
        }

        private void InorderRecursive(Node<T> root)
        {
            if (root != null)
            {
                InorderRecursive(root.Left);
                Console.Write(root.Key + " ");
                InorderRecursive(root.Right);
            }
        }
      
        private Node<T> DeleteRecursive(Node<T> node, T key)
        {
            if(node == null)
            {
                return node;
            }
            if(node.CompareTo(key) == 0)
            {
                Count--;
                if (node.Right == null && node.Left == null)
                {
                    return null;
                }
                if(node.Right == null && node.Left != null)
                {
                    Node<T> temp = node.Left;
                    return temp;
                }
                if(node.Right != null && node.Left == null)
                {
                    Node<T> temp = node.Right;
                    return temp;
                }
                node.Key = RightMost(node.Left);
                node.Left = DeleteRecursive(node.Left, node.Key);
                return node;
            }
            if(node.CompareTo(key) > 0)
            {
                node.Left = DeleteRecursive(node.Left, key);
                return node;
            }
            if(node.CompareTo(key) < 0)
            {
                node.Right = DeleteRecursive(node.Right, key);
                return node;
            }
            return node;
        }

        private T RightMost(Node<T> node)
        {
            while(node.Right != null)
            {
                node = node.Right;
            }
            return node.Key;
        }
    }
}
