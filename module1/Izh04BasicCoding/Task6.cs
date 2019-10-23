using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh04BasicCoding
{
    class Task6
    {
        public int[] FilterDigit(int[] sourceArray, int digit)
        {
            bool[] result = new bool[sourceArray.Length];
            int newLenght = 0;
            int temp;

            for (int i = 0; i < sourceArray.Length; ++i)
            {
                temp = Math.Abs(sourceArray[i]);

                while (temp != 0)
                {
                    if (Math.Abs(temp) % 10 == digit)
                    {
                        result[i] = true;
                        newLenght++;
                        break;
                    }
                    else
                    {
                        temp = temp / 10;
                    }
                }
            }

            int[] newSourceArray = new int[newLenght];
            int index = 0;

            for (int i = 0; i < result.Length; ++i)
            {
                if (result[i] == true)
                {
                    newSourceArray[index] = sourceArray[i];
                    index++;
                }
            }

            return newSourceArray;
        }
    }
}
