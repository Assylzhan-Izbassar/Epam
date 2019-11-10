using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    class Sum
    {
        private bool result { get; set; }
        private int resultSum = 0;
        public Sum()
        {
            result = false;
        }

        /// <summary>
        /// This asunc method is calculate a sum of the n numbers.
        /// </summary>
        /// <param name="n"></param>
        public async void CalcSum(int n)
        {
            int sum = 0;

            if (n >= 0)
            {
                for (int i = 0; i <= n; ++i)
                {
                    Console.SetCursorPosition(0, 0);
                    sum += i;
                    await Task.Delay(100);
                    Console.Write(sum.ToString());
                }
                resultSum = sum;
                result = true;
            }
            else
            {
                for (int i = n; i <= 0; ++i)
                {
                    sum += i;
                    await Task.Delay(100);
                    Console.Write(sum.ToString());
                }
                resultSum = sum;
            }
            Console.WriteLine();
        }
        public bool GetResult()
        {
            return this.result;
        }
        public int GetResultSum()
        {
            return this.resultSum;
        }
    }
}
