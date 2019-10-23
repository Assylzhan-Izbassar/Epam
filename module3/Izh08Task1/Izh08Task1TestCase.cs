using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh08Task1
{
    [TestFixture]
    class Izh08Task1TestCase
    {
        [TestCase]
        public void TestSortByMini()
        {
            int[,] arr = new int[,] { { 2, 3, 5 }, { 5, 5, 8 }, { 4, 5, 5 } };
            int[,] ans = new int[,] { { 2, 3, 5 }, { 4, 5, 5 }, { 5, 5, 8 } };
            Matrix matrix = new Matrix(3);

            matrix.SetMatrix(arr);

            matrix.SortByMini();

            Assert.AreEqual(matrix.getMatrix(), ans);
        }

        [TestCase]
        public void TestSortByMaxi()
        {
            int[,] arr = new int[,] { { 2, 3, 5 }, { 5, 5, 8 }, { 4, 6, 5 } };
            int[,] ans = new int[,] { { 2, 3, 5 }, { 4, 6, 5 }, { 5, 5, 8 } };
            Matrix matrix = new Matrix(3);

            matrix.SetMatrix(arr);

            matrix.SortByMaxi();

            Assert.AreEqual(matrix.getMatrix(), ans);
        }
        [TestCase]
        public void TestSortBySum()
        {
            int[,] arr = new int[,] { { 2, 3, 5 }, { 5, 5, 8 }, { 4, 6, 5 } };
            int[,] ans = new int[,] { { 2, 3, 5 }, { 4, 6, 5 }, { 5, 5, 8 } };
            Matrix matrix = new Matrix(3);

            matrix.SetMatrix(arr);

            matrix.SortBySum();

            Assert.AreEqual(matrix.getMatrix(), ans);
        }
    }
}
