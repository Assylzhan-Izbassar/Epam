using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh08Task3
{
    class Polynomial
    {
        private int[] coefficients;
        private int degree;

        public Polynomial() { }
        public Polynomial(int a, int n)
        {
            if(n < 0)
            {
                throw new ArgumentException("Exponent cannot be nagative: " + n);
            }
            coefficients = new int[n + 1];
            coefficients[n] = a;
            Reduce();
        }
        private void Reduce()
        {
            degree = -1;
            for(int i = coefficients.Length - 1; i >= 0; --i)
            {
                if(coefficients[i] != 0)
                {
                    degree = i;
                    return;
                }
            }
        }
        public int Degree()
        {
            return degree;
        }

        public Polynomial Add(Polynomial p)
        {
            Polynomial poly = new Polynomial(0, Math.Max(this.degree, p.degree));

            for (int i = 0; i <= this.degree; ++i)
                poly.coefficients[i] += this.coefficients[i];
            for (int i = 0; i <= p.degree; ++i)
                poly.coefficients[i] += p.coefficients[i];
            poly.Reduce();

            return poly;
        }
        public Polynomial SubTr(Polynomial p)
        {
            Polynomial poly = new Polynomial(0, Math.Max(this.degree, p.degree));

            for (int i = 0; i <= this.degree; ++i)
                poly.coefficients[i] += this.coefficients[i];
            for (int i = 0; i <= p.degree; ++i)
                poly.coefficients[i] -= p.coefficients[i];
            poly.Reduce();

            return poly;
        }

        public Polynomial Multiply(Polynomial p)
        {
            Polynomial poly = new Polynomial(0, this.degree + p.degree);
            for (int i = 0; i <= this.degree; i++)
                for (int j = 0; j <= p.degree; j++)
                    poly.coefficients[i + j] += (this.coefficients[i] * p.coefficients[j]);
            poly.Reduce();

            return poly;
        }

        public Polynomial Differentiate()
        {
            if (degree == 0) return new Polynomial(0, 0);
            Polynomial poly = new Polynomial(0, degree - 1);
            poly.degree = degree - 1;
            for (int i = 0; i < degree; i++)
                poly.coefficients[i] = (i + 1) * coefficients[i + 1];
            return poly;
        }

        public int Evaluate(int x)
        {
            int p = 0;
            for (int i = degree; i >= 0; i--)
                p = coefficients[i] + (x * p);
            return p;
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (obj.GetType() != this.GetType() || obj == null) return false;
            Polynomial poly = (Polynomial)obj;
            if (this.degree != poly.degree) return false;
            for(int i= this.degree; i >= 0; --i)
            {
                if (this.coefficients[i] != poly.coefficients[i]) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return 5 * degree ^ 4;
        }

        public override string ToString()
        {
            if (degree == -1) return "0";
            else if (degree == 0) return "" + coefficients[0];
            else if(degree == 1) return coefficients[1] + "x + " +coefficients[0];
            string s = coefficients[degree] + "x^" + degree;

            for(int i=degree-1; i >= 0; --i)
            {
                if (coefficients[i] == 0) continue;
                else if (coefficients[i] > 0) s += " + " + coefficients[i];
                else if (coefficients[i] < 0) s += " - " + (-coefficients[i]);

                if (i == 1) s += "x";
                else if (i > 1) s += "x^" + i;
            }
            return s;
        }
    }
}


