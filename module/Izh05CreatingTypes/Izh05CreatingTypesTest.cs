using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh05CreatingTypes
{
    [TestFixture]
    class Izh05CreatingTypesTest
    {
        static int[] a1 = new int[] { 1, 2, 3 };
        static int[] a2 = new int[] { 2, 3, 4 };
        static int[] a3 = new int[] { 2, 4, 1 };

        [TestCase]/*Я ни смог сделать тесткейс для двумерного массива: оно выдает ошибку CS0182.
                    Но я проверил работаспособность кода при помощи Program.cs файла*/
        public int[][] CheckSortBySums(int[][] sourceArray, int n)
        {
            //Arrange
            Task2 task = new Task2();
            //Assert
            return task.sortBySum(new int[][] {
                new int[] {1,2,3},
                new int[] {2,3,4},
                new int[] {2,4,1}
            }, 3);//Add
        }

        [TestCase]
        public int[][] CheckSortByMaxi(int[][] sourceArray, int n)
        {
            //Arrange
            Task2 task = new Task2();
            //Assert
            return task.sortByMaxi(new int[][] {
                new int[] {1,2,3},
                new int[] {2,3,4},
                new int[] {2,4,1}
            }, 3);//Add
        }

        [TestCase]
        public int[][] CheckSortByMini(int[][] sourceArray, int n)
        {
            //Arrange
            Task2 task = new Task2();
            //Assert
            return task.sortByMini(new int[][] {
                new int[] {5,4,3},
                new int[] {7,2,5},
                new int[] {9,6,1}
            }, 3);//Add
        }

        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]

        public double CheckNthRoot(int A, int n, double epsilon)
        {
            Task1 task = new Task1();

            return task.NthRoot(A, n, epsilon);
        }
    }
}
