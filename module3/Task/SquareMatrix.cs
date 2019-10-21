using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class SquareMatrix
    {
        protected int[,] arr;
        protected int size;

        public SquareMatrix(int n)
        {
            arr = new int[n, n];
            size = n;
        }
        protected bool isDiagonalMatrix(int[,] sourceArray)
        {
            int n = sourceArray.Length;
            for(int i=0; i < n/2; ++i)
            {
                for(int j=0; j < n/2; ++j)
                {
                    if(sourceArray[i,j] != sourceArray[n-i-1,n-j-1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        protected bool isSymmetricMatrix(int[,] sourceArray)
        {
            int n = sourceArray.Length;
            for (int i = 0; i < n / 2; ++i)
            {
                for (int j = 0; j < n / 2; ++j)
                {
                    if (sourceArray[i, j] != sourceArray[n - i - 1, n - j - 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /*public int[][] AddMatrices(int[,] A, int[,] B)
        {
            int[,] C = new int[,]
        }*/
    }
}
