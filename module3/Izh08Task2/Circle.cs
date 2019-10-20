using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module3
{
    class Circle : Shape
    {
        private int radius;
        public Circle() { }
        public Circle(int radius)
        {
            this.radius = radius;
        }
        public override double CalculateArea()
        {
            area = Math.PI * radius * radius;
            return area;
        }
        public void SetRadius(int radius)
        {
            this.radius = radius;
        }
    }
}
