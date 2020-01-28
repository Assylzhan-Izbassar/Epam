using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh12GenericsAndCollections.BST
{
    public class Node
    {
        public int Key { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int item)
        {
            Key = item;
            Left = Right = null;
        }

    }
}
