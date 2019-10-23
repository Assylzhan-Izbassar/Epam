using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class DiagonalMatrix:SquareMatrix
    {
        public DiagonalMatrix() { }

        public DiagonalMatrix(int n)
        {
            arr = new int[n,n];
            size = n;
        }
        public override void SetMatrix(int[,] sourceArray)
        {
            if (IsDiagonalMatrix(sourceArray))
            {
                base.SetMatrix(sourceArray);
            }
        }

        public bool CheckDiagonal(int[,] sourceArray)
        {
            bool res = IsDiagonalMatrix(sourceArray);
            return res;
        }
    }
}
