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
        public override void SetMatrix(int[,] sourceArray)
        {
            if(IsSymmetricMatrix(sourceArray))
            {
                base.SetMatrix(sourceArray);
            }
        }

        public bool CheckSymmetric(int[,] sourceArray)
        {
            bool res = IsSymmetricMatrix(sourceArray);
            return res;
        }
    }
}
