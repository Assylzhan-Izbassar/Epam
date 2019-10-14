using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh05CreatingTypes
{
    class Task1
    {
        public double NthRoot(int A, int n, double epsilon)
        {
            Random rand = new Random();

            double xPre = rand.Next(10);

            double delX = 2147483647;

            double xC = 0.0;

            while (delX > epsilon)
            {
                //newton's method 
                xC = ((n - 1.0) * xPre +
                (double)A / Math.Pow(xPre, n - 1)) / (double)n;
                delX = Math.Abs(xC - xPre);
                xPre = xC;
            }
            return xC;
        }
    }
}
