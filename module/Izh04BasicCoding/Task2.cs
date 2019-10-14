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
            if (sourceArray == null)
                return 0;
            else if (index == sourceArray.Length)
            {
                return sourceArray[maxIndex];
            }
            else if (sourceArray[index] > sourceArray[maxIndex])
            {
                maxIndex = index;
            }
            index++;

            return MaxElementFinding(sourceArray);
        }
    }
}
