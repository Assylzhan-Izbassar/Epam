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
        public void setMatrix(int[,] sourceArray)
        {
            if (isDiagonalMatrix(sourceArray))
            {
                SetMatrix(sourceArray);
            }
        }

        public bool checkDiagonal(int[,] sourceArray)
        {
            bool res = isDiagonalMatrix(sourceArray);
            return res;
        }
    }
}
