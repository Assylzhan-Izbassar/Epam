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

        public SquareMatrix()
        {
        }
        public SquareMatrix(int n)
        {
            arr = new int[n, n];
            size = n;
        }
        protected bool IsDiagonalMatrix(int[,] sourceArray)
        {
            int n = sourceArray.GetLength(0);
            for(int i=0; i < n/2; ++i)
            {
                for(int j=0; j < n/2; ++j)
                {
                    if(sourceArray[i,j] != sourceArray[n-i-1,n-j-1])
                    {
                        return false;
                    }
                    if (sourceArray[i,n-i-1] != sourceArray[n-i-1,i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        protected bool IsSymmetricMatrix(int[,] sourceArray)
        {

            int[,] transpose = new int[sourceArray.GetLength(0), sourceArray.GetLength(1)];
            int row = transpose.GetLength(0);
            int column = transpose.GetLength(1);

            for(int i=0; i < row; ++i)
            {
                for(int j=0; j < column; ++j)
                {
                    transpose[j, i] = sourceArray[i, j];
                }
            }

            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < column; ++j)
                {
                    if (transpose[i, j] != sourceArray[i, j])
                        return false;
                }
            }
            return true;
        }

        public int[,] AddMatrices(int[,] A, int[,] B)
        {
            int[,] C = new int[A.GetLength(0), B.GetLength(0)];

            for(int i=0; i < C.GetLength(0); ++i)
            {
                for(int j=0; j < C.GetLength(1); ++j)
                {
                    C[i, j] = A[i, j] + B[i, j];
                }
            }

            return C;
        }
        public void SetElement(int x, int i, int j)
        {
            arr[i, j] = x;
        }

        public virtual void SetMatrix(int[,] sourceArray)
        {
            arr = new int[sourceArray.GetLength(0), sourceArray.GetLength(1)];

            for(int i=0; i < arr.GetLength(0); ++i)
            {
                for(int j=0; j < arr.GetLength(1); ++j)
                {
                    arr[i, j] = sourceArray[i, j];
                }
            }
        }
    }
}
