using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    [TestFixture]
    class MatrixTest
    {
        [TestCase]
        public void TestSymmetric()
        {
            int[,] arr = new int[,] { { 2, 3, 5 },
                                      { 3, 5, 8 }, 
                                      { 5, 8, 5 } };
            bool result = true;
            Symmetric symmetric = new Symmetric(3);
            bool check = symmetric.CheckSymmetric(arr);
            Assert.AreEqual(check, result);
        }

        [TestCase]
        public void TestDiagonal()
        {
            int[,] arr = new int[,] { { 5, 3, 5 },
                                      { 3, 5, 8 },
                                      { 3, 8, 5 } };
            bool result = false;
            DiagonalMatrix dm = new DiagonalMatrix(3);
            bool check = dm.CheckDiagonal(arr);
            Assert.AreEqual(check, result);
        }

        [TestCase]
        public void CheckAdd()
        {
            int[,] arr = new int[,] { { 2, 3, 5 },
                                      { 3, 5, 8 },
                                      { 5, 8, 5 } };

            int[,] arr2 = new int[,] { { 5, 3, 5 },
                                       { 3, 5, 8 },
                                       { 3, 8, 5 } };

            int[,] ans = new int[,]  { { 7, 6, 10 },
                                       { 6, 10, 16 },
                                       { 8, 16, 10 } };

            SquareMatrix square = new SquareMatrix(3);

            int[,] newMatrix = square.AddMatrices(arr, arr2);

            Assert.AreEqual(newMatrix, ans);
        }
    }
}
