using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh11DelegatesLambdasEvents
{
    class Program
    {
        delegate void myDelegate();
        static void Main(string[] args)
        {
        }

        public int FindMax(int[] sourceArray)
        {
            int maxi = sourceArray[0];
            for(int i=0; i < sourceArray.Length; ++i)
            {
                if (maxi < sourceArray[i])
                    maxi = sourceArray[i];
            }
            return maxi;
        }
        public int FindMin(int[] sourceArray)
        {
            int mini = sourceArray[0];
            for(int i=0; i < sourceArray.Length; ++i)
            {
                if (mini > sourceArray[i])
                    mini = sourceArray[i];
            }
            return mini;
        }
        public int FindSum(int[] sourceArray)
        {
            int sum = 0;
            for (int i = 0; i < sourceArray.Length; ++i)
                sum += sourceArray[i];
            return sum;
        }

        public void SortByMaxi()
        {

        }
        public void SortByMini()
        {

        }
        public void SortBySum()
        {

        }

        public void BubbleSort(int[,] matrix, int[] sourceArray, string compCreterion)
        {
            int temp = sourceArray[0];
            for(int i=0; i < matrix.GetLength(0); ++i)
            {
                for(int j=0; j < matrix.GetLength(1); ++j)
                {
                    if(compCreterion.Equals("ByMaxi"))
                    {
                        SortByMaxi();
                    }
                }
            }
        }
    }
}
