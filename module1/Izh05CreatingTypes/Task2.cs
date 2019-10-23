using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh05CreatingTypes
{
    class Task2
    {
        private void swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
        private void swap(int[][] arr, int i, int j, int k)
        {
            int temp = arr[i][k];
            arr[i][k] = arr[j][k];
            arr[j][k] = temp;
        }
        public int[][] sortBySum(int[][] sourceArray, int n)
        {
            int[] arr = new int[n];
            int sum;

            for(int i=0; i < n; ++i)
            {
                sum = 0;
                for(int j=0; j < n; ++j)
                {
                    sum += sourceArray[i][j];
                }
                arr[i] = sum;
            }
            //BubbleSort for 2dArray
            for(int i=0; i < n; ++i)
            {
                for(int j=i+1; j < n; ++j)
                {
                    if(arr[i] > arr[j])
                    {
                        swap(arr, i, j);

                        for (int k = 0; k < n; ++k)
                        {
                            swap(sourceArray, i, j ,k);
                        }
                    }
                }
            }
            return sourceArray;
        }
        public int[][] sortByMaxi(int[][] sourceArray, int n)
        {
            int[] arr = new int[n];

            int maxi;

            for(int i=0; i < n; ++i)
            {
                maxi = sourceArray[i][0];
                for (int j=0; j < n; ++j)
                {
                    if(sourceArray[i][j] > maxi)
                    {
                        maxi = sourceArray[i][j];
                    }
                }
                arr[i] = maxi;
            }
            //BubbleSort for 2dArray
            for(int i=0; i < n; ++i)
            {
                for(int j=i+1; j < n; ++j)
                {
                    if(arr[i] > arr[j])
                    {
                        swap(arr, i, j);
                        for(int k=0; k < n; ++k)
                        {
                            swap(sourceArray, i, j, k);
                        }
                    }
                }
            }
            return sourceArray;
        }

        public int[][] sortByMini(int[][] sourceArray, int n)
        {
            int[] arr = new int[n];

            int mini;

            for (int i = 0; i < n; ++i)
            {
                mini = sourceArray[i][0];
                for (int j = 0; j < n; ++j)
                {
                    if (sourceArray[i][j] < mini)
                    {
                        mini = sourceArray[i][j];
                    }
                }
                arr[i] = mini;
            }
            //BubbleSort for 2dArray
            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    if (arr[i] > arr[j])
                    {
                        swap(arr, i, j);
                        for (int k = 0; k < n; ++k)
                        {
                            swap(sourceArray, i, j, k);
                        }
                    }
                }
            }
            return sourceArray;
        }

    }
}
