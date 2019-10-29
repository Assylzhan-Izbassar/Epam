using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh11DelegatesLambdasEvents.Task2
{
    class Task2
    {
        private int[,] Matrix;

        private int Width { get; set; }

        private int Height { get; set; }

        public Task2() { }

        public Task2(int Width, int Height)
        {
            Matrix = new int[this.Width = Width, this.Height = Height];
        }

        public int GetWidth()
        {
            return this.Width;
        }
        public int GetHeight()
        {
            return this.Height;
        }
    }
}
