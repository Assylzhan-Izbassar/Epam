using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh12GenericsAndCollections.BST
{
    public class BinarySearchTree
    {
        public Node Root { get; private set; }

        public BinarySearchTree()
        {
            Root = null;
        }

        public void Insert(int key)
        {
            Root = InsertRecursive(Root, key);
        }

        private Node InsertRecursive(Node root, int key)
        {
            if(root == null)
            {
                root = new Node(key);
                return root;
            }

            if(key < root.Key)
            {
                root.Left = InsertRecursive(root.Left, key);
            }
            if(key > root.Key)
            {
                root.Right = InsertRecursive(root.Right, key);
            }

            return root;
        }

        public void Inorder()
        {
            InorderRecursive(Root);
        }

        private void InorderRecursive(Node root)
        {
            if(root != null)
            {
                InorderRecursive(root.Left);
                Console.Write(root.Key + " ");
                InorderRecursive(root.Right);
            }
        }
    }
}
