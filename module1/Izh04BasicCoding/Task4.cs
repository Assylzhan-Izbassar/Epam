using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh04BasicCoding
{
    class Task4
    {
        public string StringConcatenation(string firstStr, string secondStr)
        {
            string result = firstStr;

            for(int i=0; i < secondStr.Length; ++i)
            {
                if (!firstStr.Contains(secondStr[i]))
                    result += secondStr[i];
            }

            return result;
        }
    }
}
