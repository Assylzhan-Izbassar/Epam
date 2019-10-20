using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module3
{
    class Square : Rectangle
    {
        public Square(){}
        public Square(int a)
        {
            this.a = a;
            b = a;
        }
        public override double CalculateArea()
        {
            area = a * b;
            return area;
        }
        public int GetSide()
        {
            return a;
        }
    }
}
