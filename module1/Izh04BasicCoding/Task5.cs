using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh04BasicCoding
{
    class Task5
    {
        int sizeOfNumber = 0;
        static void swap(char[] ar, int i, int j)
        {
            char temp = ar[i];
            ar[i] = ar[j];
            ar[j] = temp;
        }
        public char[] ConvertToArray(int number)
        {
            int temp = number;
            while(temp != 0)
            {
                temp /= 10;
                sizeOfNumber++;
            }

            char[] num = new char[sizeOfNumber];
            int i = 1;
            while(number != 0)
            {
                num[sizeOfNumber - i] = (char)(number % 10 + 48);
                number /= 10;
                i++;
            }
            return num;
        }
        public int FindNextBiggerNumber(int number)
        {
            char[] num = ConvertToArray(number);

            int i, j;
            for(i = sizeOfNumber-1; i > 0; --i)
            {
                if(num[i] > num[i-1])
                {
                    break;
                }
            }
            /*if our number is monotone decrease, then it is impossible to convert next 
            greater number than we have, with number's digit*/
            if(i == 0)
            {
                return -1;
            }

            int x = num[i - 1];
            int sm = i;

            for(j=i+1; j < sizeOfNumber; ++j)
            {
                if(num[j] > x && num[j] < num[sm])
                {
                    sm = j;
                }
            }

            swap(num, i - 1, sm);

            for(int t = i; t < sizeOfNumber; ++t)
            {
                for(int l = t+1; l < sizeOfNumber; ++l)
                {
                    if(num[t] > num[l])
                    {
                        swap(num, t, l);
                    }
                }
            }

            string resultStr = "";

            for(int t=0; t < num.Length; ++t)
            {
                resultStr += num[t];
            }
            int resultNum = 0;

            try
            {
                resultNum = int.Parse(resultStr);
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            return resultNum;
        }

    }
}
