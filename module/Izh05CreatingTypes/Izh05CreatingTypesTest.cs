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

        [TestCase]/*Я ни смог сделать тесткейс для двумерного массива: оно выдает ошибку CS0182*/
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
    }
}
