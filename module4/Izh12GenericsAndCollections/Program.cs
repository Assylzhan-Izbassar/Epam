using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Izh12GenericsAndCollections.BST;

namespace Izh12GenericsAndCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();

            Random random = new Random();

            for (int i = 0; i < 6; ++i)
            {
                bst.Insert(random.Next(1, 20));
            }
            bst.Inorder();
        }
    }
}
