using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Sum sum = new Sum();

            sum.CalcSum(n);

            while(true)
            {
                if(sum.GetResult() == true)
                {
                    Console.WriteLine("Sum is complited:");
                    break;
                }
                else
                { 
                    try
                    {
                        n = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                    }
                    sum.CalcSum(n);
                }
            }
            Console.WriteLine(sum.GetResultSum());
        }
    }
}
