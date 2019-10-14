using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh04BasicCoding
{
    class Task3
    {
        public bool isEqual(double a, double b)
        {
            const double epsilon = 1e-5;
            return Math.Abs(a - b) < epsilon;
        }
        public int FindingElementIndexBetweenEqualSums(double[] sourceArray)
        {
            if (sourceArray.Length == 0)
                return -1;

            double leftSum;
            double rightSum;

            int pivot = -1;
            int index = 0;

            while(index <= sourceArray.Length)
            {
                leftSum = 0;
                rightSum = 0;
                for(int i=0; i < index; ++i)
                {
                    leftSum += sourceArray[i];
                }
                for(int i=index+1; i<sourceArray.Length; ++i)
                {
                    rightSum += sourceArray[i];
                }
                if(isEqual(leftSum, rightSum))
                    return index;
                index++;
            }

            return pivot;
        }
    }
}
