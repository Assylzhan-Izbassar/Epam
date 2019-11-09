using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh15StreamsAndIO
{
    class Program
    {
        static void Main(string[] args)
        {
            CopyFile file = new CopyFile();
            string filePath = @"C:\Users\Brother\Desktop\UnicodeTest.txt";
            string pathOfNewFile = @"C:\Users\Brother\Desktop\newFile.txt";
            //Console.WriteLine(file.CopyWithFileStream(filePath, pathOfNewFile));
            //Console.WriteLine(file.CopyWithMemoryStream(filePath, pathOfNewFile));
        }
    }
}
