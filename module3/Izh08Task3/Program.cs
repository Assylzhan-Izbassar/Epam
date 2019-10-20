using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh08Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial zero = new Polynomial(0, 0);

            Polynomial p1 = new Polynomial(4, 3);
            Polynomial p2 = new Polynomial(3, 2);
            Polynomial p3 = new Polynomial(1, 0);
            Polynomial p4 = new Polynomial(2, 1);
            Polynomial p = p1.Add(p2).Add(p3).Add(p4);   // 4x^3 + 3x^2 + 1

            Polynomial q1 = new Polynomial(3, 2);
            Polynomial q2 = new Polynomial(5, 0);

            Polynomial q = q1.Add(q2);                     // 3x^2 + 5


            Polynomial r = p.Add(q);
            Polynomial u = p.SubTr(p);

            Console.WriteLine("zero(x) = " + zero);
            Console.WriteLine("p(x) = " + p);
            Console.WriteLine("q(x) = " + q);
            Console.WriteLine("p(x) + q(x) = " + r);
            Console.WriteLine("p(x) - p(x) = " + u);
            Console.WriteLine("0 - p(x) = " + zero.SubTr(p));
            Console.WriteLine("p(3) = " + p.Evaluate(3));
            Console.WriteLine("p'(x) = " + p.Differentiate());
            Console.WriteLine("p''(x) = " + p.Differentiate().Differentiate());
        }
    }
}
