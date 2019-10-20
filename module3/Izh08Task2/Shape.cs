using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module3
{
    abstract class Shape
    {
        protected double area;
        public abstract double CalculateArea();
        public double GetArea()
        {
            return area;
        }
    }
}
