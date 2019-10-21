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
        static int[,] arr = new int[,] { { 2, 3, 5 }, { 5, 5, 8 }, { 4, 5, 5 } };
        static int[,] ans = new int[,] { { 2, 3, 5 }, { 4, 5, 5 }, { 5, 5, 8 } };
        [TestCase(arr, ExpectedResult = ans)]
        /*Severity	Code	
        Description	Project	File Line Suppression State	Suppression State
        Error CS0182	An attribute argument must be a constant expression,
        typeof expression or array creation expression of an attribute parameter type	
        Izh08Task1	
        */
        public int[,] TestSortByMini(int[,] sourceArray)
        {
            //Arrange
            Matrix matrix = new Matrix(sourceArray.Length);
            //Add
            matrix.SetMatrix(sourceArray);
            //Assert
            return matrix.sortByMini();
        }
        public int[,] TestSortByMaxi(int[,] sourceArray)
        {
            //Arrange
            Matrix matrix = new Matrix(sourceArray.Length);
            //Add
            matrix.SetMatrix(sourceArray);
            //Assert
            return matrix.sortByMaxi();
        }
        public int[,] TestSortBySum(int[,] sourceArray)
        {
            //Arrange
            Matrix matrix = new Matrix(sourceArray.Length);
            //Add
            matrix.SetMatrix(sourceArray);
            //Assert
            return matrix.sortBySum();
        }
    }
}
