using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh04BasicCoding
{
    class Task2
    {
        int maxIndex = 0; int index = 0;
        public int MaxElementFinding(int[] sourceArray)
        {
            if (sourceArray == null)//if our array is empty, then we return -1;
                return -1;
            else if (index == sourceArray.Length)//if our index come to the array size, then we return element
            {
                return sourceArray[maxIndex];
            }
            else if (sourceArray[index] > sourceArray[maxIndex])//if we have more element than we had then our maxi index will be new index
            {
                maxIndex = index;
            }
            index++;

            return MaxElementFinding(sourceArray);//recursive call
        }
    }
}
