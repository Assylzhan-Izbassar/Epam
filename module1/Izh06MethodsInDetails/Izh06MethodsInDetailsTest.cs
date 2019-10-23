using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh06MethodsInDetails
{
    [TestFixture]
    class Izh06MethodsInDetailsTest
    {
        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        public string CheckIEEE_754(double number)
        {
            throw new NotImplementedException();
        }

        [TestCase(new int[] { 75,15}, ExpectedResult = 15)]
        [TestCase(new int[] { 16,12,24}, ExpectedResult = 4)]
        [TestCase(new int[] { 9,81,3,54 }, ExpectedResult = 3)]
        public int CheckGCD(int[] numbers, int length)
        {
            throw new NotImplementedException();
        }

        /*public bool CheckNull()
        {

        }*/
    }
}
