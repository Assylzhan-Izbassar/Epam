using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module3
{
    class Triangle : Shape
    {
        private double a, b, c;
        private double perimeter;

        public Triangle() { }
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override double CalculateArea()
        {
            double p = (a + b + c) / 2;
            area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return area;
        }
        public double CalculatePerimeter()
        {
            perimeter = a + b + c;
            return perimeter;
        }
        public void SetSides(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public double GetPerimeter()
        {
            return perimeter;
        }
    }
}
