using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module3
{
    class Rectangle : Shape
    {
        protected int a, b;
        protected int perimeter;
        public Rectangle() { }

        public Rectangle(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public override double CalculateArea()
        {
            area = a * b;
            return area;
        }
        public int CalculatePerimeter()
        {
            perimeter = 2 * (a + b);
            return perimeter;
        }
        public void SetSide(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public int GetPerimeter()
        {
            return perimeter;
        }
    }
}
