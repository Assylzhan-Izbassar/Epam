using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh12GenericsAndCollections.BST
{
    public class Node<T> where T : IComparable
    {
        public T Key { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T item)
        {
            Key = item;
            Left = Right = null;
        }

        public override string ToString()
        {
            return "Key is equal to " + Key;
        }

        public int CompareTo(T other)
        {
            return other.CompareTo(Key);
        }
    }
}
