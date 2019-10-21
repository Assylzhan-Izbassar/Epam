using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh08Task1
{
    class Matrix
    {
        private int[,] arr;
        private int size;

        public Matrix(int n)
        {
            arr = new int[n,n];
            size = n;
        }
        private void Swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
        private void Swap(int[,] arr, int i, int j, int k)
        {
            int temp = arr[i,k];
            arr[i,k] = arr[j,k];
            arr[j,k] = temp;
        }
        private int FindMaxi(int[,] sourceArray, int currentMaxi, int i)
        {
            for (int j = 0; j < sourceArray.GetLength(1); ++j)
            {
                if (sourceArray[i,j] > currentMaxi)
                {
                    currentMaxi = sourceArray[i,j];
                }
            }
            return currentMaxi;
        }
        private int FindMini(int[,] sourceArray, int currentMini, int i)
        {
            for (int j = 0; j < sourceArray.GetLength(1); ++j)
            {
                if (sourceArray[i,j] < currentMini)
                {
                    currentMini = sourceArray[i,j];
                }
            }
            return currentMini;
        }
        private int FindSum(int[,] sourceArray, int sum, int i)
        {
            for (int j = 0; j < sourceArray.GetLength(1); ++j)
            {
                sum += sourceArray[i,j];
            }
            return sum;
        }

        public void BubbleSort(int[] sourceArray)
        {
            for (int i = 0; i < size; ++i)
            {
                for (int j = i + 1; j < size; ++j)
                {
                    if (sourceArray[i] > sourceArray[j])
                    {
                        Swap(sourceArray, i, j);
                        for (int k = 0; k < size; ++k)
                        {
                            Swap(arr, i, j, k);
                        }
                    }
                }
            }
        }
        public int[,] sortByMini()
        {
            int[] temp = new int[size];

            int mini;

            for (int i = 0; i < size; ++i)
            {
                mini = arr[i,0];
                mini = FindMini(arr, mini, i);
                temp[i] = mini;
            }
            //BubbleSort for 2dArray
            BubbleSort(temp);

            return arr;
        }
        public int[,] sortByMaxi()
        {
            int[] temp = new int[size];

            int maxi;

            for (int i = 0; i < size; ++i)
            {
                maxi = arr[i, 0];
                maxi = FindMaxi(arr, maxi, i);
                temp[i] = maxi;
            }
            //BubbleSort for 2dArray
            BubbleSort(temp);

            return arr;
        }
        public int[,] sortBySum()
        {
            int[] temp = new int[size];

            int sum;

            for (int i = 0; i < size; ++i)
            {
                sum = 0;
                sum = FindSum(arr, sum, i);
                temp[i] = sum;
            }
            //BubbleSort for 2dArray
            BubbleSort(temp);

            return arr;
        }
        public int[,] getMatrix()
        {
            return arr;
        }
        public void SetMatrix(int[,] sourceArray)
        {
            for(int i=0; i < sourceArray.GetLength(0); ++i)
            {
                for(int j=0; j < sourceArray.GetLength(1); ++j)
                {
                    arr[i, j] = sourceArray[i, j];
                }
            }
        }
    }
}
