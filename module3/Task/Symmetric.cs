using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Symmetric : SquareMatrix
    {
        public Symmetric()
        {
        }
        public Symmetric(int n)
        {
            arr = new int[n, n];
            size = n;
        }
        public void setMatrix(int[,] sourceArray)
        {
            if(isSymmetricMatrix(sourceArray))
            {
                SetMatrix(sourceArray);
            }
        }

        public bool checkSymmetric(int[,] sourceArray)
        {
            bool res = isSymmetricMatrix(sourceArray);
            return res;
        }
    }
}
