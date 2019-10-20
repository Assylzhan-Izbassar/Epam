using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh08Task3
{
    [TestFixture]
    class PolynomialTest
    {
        [TestCase(new int[] { 4,3,3, 2, 1, 0, 2, 1}, ExpectedResult = "4x^3 + 3x^2 + 2x + 1")]
        public string TestAdd(int[] sourceArray)
        {
            Polynomial polynomial = new Polynomial(0,0);
            Polynomial temp = new Polynomial(0,0);

            for(int i=0; i < sourceArray.Length-1; i+=2)
            {
                temp = new Polynomial(sourceArray[i], sourceArray[i + 1]);
                polynomial = polynomial.Add(temp);
            }

            return polynomial.ToString();
        }
        [TestCase(new int[] { 3,4,5,3,5,2}, new int[] { 6,4,5,3,3,2}, ExpectedResult = "-3x^4 + 2x^2")]
        public string TestSubTr(int[] sourceArray, int[]sourceArray2)
        {
            Polynomial polynomial1 = new Polynomial(0, 0);
            Polynomial temp = new Polynomial(0, 0);

            Polynomial polynomial2 = new Polynomial(0, 0);

            for (int i = 0; i < sourceArray.Length - 1; i += 2)
            {
                temp = new Polynomial(sourceArray[i], sourceArray[i + 1]);
                polynomial1 = polynomial1.Add(temp);
            }

            for (int i = 0; i < sourceArray2.Length - 1; i += 2)
            {
                temp = new Polynomial(sourceArray2[i], sourceArray2[i + 1]);
                polynomial2 = polynomial2.Add(temp);
            }

            temp = polynomial1.SubTr(polynomial2);

            return temp.ToString();
        }
        [TestCase(new int[] { 5,4,-3,2,5,0}, ExpectedResult = "20x^3 - 6x")]
        [TestCase(new int[] { 4, 3, 3, 2, 43, 0 }, ExpectedResult = "12x^2 + 6x")]
        public string DiffTest(int[] sourceArray)
        {
            Polynomial polynomial = new Polynomial(0, 0);
            Polynomial temp = new Polynomial(0, 0);

            for (int i = 0; i < sourceArray.Length - 1; i += 2)
            {
                temp = new Polynomial(sourceArray[i], sourceArray[i + 1]);
                polynomial = polynomial.Add(temp);
            }

            polynomial = polynomial.Differentiate();

            return polynomial.ToString();
        }
        [TestCase(new int[] { 4,2,3,1,5,0}, 2, ExpectedResult = 27)]
        public int EvaluateTest(int[] sourceArray, int x)
        {
            Polynomial polynomial = new Polynomial(0, 0);
            Polynomial temp = new Polynomial(0, 0);

            for (int i = 0; i < sourceArray.Length - 1; i += 2)
            {
                temp = new Polynomial(sourceArray[i], sourceArray[i + 1]);
                polynomial = polynomial.Add(temp);
            }

            int k = polynomial.Evaluate(x);

            return k;
        }
    }
}


