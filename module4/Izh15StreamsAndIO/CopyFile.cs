using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh15StreamsAndIO
{
    class CopyFile
    {
        private int sizeOfFileInBytes = 0;
        public CopyFile()
        {
        }

        /// <summary>
        /// This method copy data of file byte by byte using System.IO.FileStream.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="newPath"></param>
        /// <returns>It is returns the count of bytes that was copied.</returns>
        public int CopyWithFileStreamByteByByte(string filePath, string newPath)
        {
            //Reading data of file.
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] arr = new byte[fileStream.Length];
                //Read the data.
                fileStream.Read(arr, 0, arr.Length);

                int count = 0;

                using (FileStream fs = new FileStream(newPath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    //Writing the data byte by byte.
                    while (count < arr.Length)
                    {
                        fs.WriteByte(arr[count++]);
                    }
                }
                sizeOfFileInBytes = arr.Length;
            }
            return sizeOfFileInBytes;
        }

        /// <summary>
        /// This method is copy data into one file to another byte by byte using System.IO.MemoryStream.
        /// </summary>
        /// <param name="currFilePath"></param>
        /// <param name="newFilePath"></param>
        /// <returns>The method is returns how many bytes stored into a data of file.</returns>
        public int CopyWithMemoryStreamByteByByte(string currFilePath, string newFilePath)
        {
            string data = "";
            //Reading data from the file with StreamReader.
            using (StreamReader sr = new StreamReader(currFilePath))
            {
                data = sr.ReadToEnd();
            }
            //Converting string data into bytes.
            byte[] bytes = Encoding.Default.GetBytes(data);

            //Creating MemoryStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                int count = 0;
                //Writing data into array bytes with MemoryStream byte by byte
                while (count < bytes.Length)
                {
                    memoryStream.WriteByte(bytes[count++]);
                }
                //Writing data into memoryStream to a new file using FileStream.
                using (FileStream fileStream = new FileStream(newFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    memoryStream.WriteTo(fileStream);
                }
            }
            return bytes.Length;
        }

        /// <summary>
        /// This method copy data from one file to another using System.IO.FileStream.
        /// </summary>
        /// <param name="currFilePath"></param>
        /// <param name="newFilePath"></param>
        /// <returns>The length of copied file in bytes.</returns>
        public int CopyWithFileStream(string currFilePath, string newFilePath)
        {
            //Reading the file
            using (FileStream fs = new FileStream(currFilePath, FileMode.Open, FileAccess.Read))
            {
                //storage for bytes of the data.
                byte[] bytes = new byte[fs.Length];
                //Reading the data
                fs.Read(bytes, 0, bytes.Length);

                //Writing data to another file.
                using (FileStream fileStream = new FileStream(newFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fileStream.Write(bytes, 0, bytes.Length);
                }
                sizeOfFileInBytes = bytes.Length;
            }
            return sizeOfFileInBytes;
        }

        /// <summary>
        /// This method is copy file using System.IO.BufferedStream.
        /// </summary>
        /// <param name="currFilePath"></param>
        /// <param name="newFilePath"></param>
        /// <returns>The size of data in file in bytes.</returns>
        public int CopyWithBufferedStream(string currFilePath, string newFilePath)
        {
            using (FileStream fs = new FileStream(currFilePath, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[fs.Length];
                //Reading from the file.
                fs.Read(bytes, 0, bytes.Length);
                using(FileStream fileStream = new FileStream(newFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    //Writing to another file with a new path.
                    using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                    {
                        bufferedStream.Write(bytes, 0, bytes.Length);
                    }
                }
                sizeOfFileInBytes = bytes.Length;
            }
            return sizeOfFileInBytes;
        }

        /// <summary>
        /// This method is copy a data from one file to another using System.IO.MemoryStream.
        /// </summary>
        /// <param name="currPathName"></param>
        /// <param name="newPathName"></param>
        /// <returns>A size of data in bytes.</returns>
        public int CopyWithMemoryStream(string currPathName, string newPathName)
        {
            using (StreamReader sr = new StreamReader(currPathName))
            {
                //Reading a data from the file.
                string temp = sr.ReadToEnd();
                //Converting the data into bytes.
                byte[] bytes = Encoding.Default.GetBytes(temp);
                
                using(MemoryStream ms = new MemoryStream())
                {
                    //Writing the data to MemoryStream store.
                    ms.Write(bytes, 0, bytes.Length);

                    using (FileStream fs = new FileStream(newPathName, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        //Writing the data to new file.
                        ms.WriteTo(fs);
                    }
                }
                sizeOfFileInBytes = bytes.Length;
            }
            return sizeOfFileInBytes;
        }

        /// <summary>
        /// This method copy the text into file line by line to another file.
        /// </summary>
        /// <param name="currPathName"></param>
        /// <param name="newPathName"></param>
        /// <returns>A size of bytes into file.</returns>
        public int CopyTextLineByLine(string currPathName, string newPathName)
        {
            using(StreamReader sr = new StreamReader(currPathName))
            {
                string data = null;
                StringBuilder stringBuilder = new StringBuilder();
                //Reading the text line by line.
                while(!sr.EndOfStream)
                {
                    string temp = sr.ReadLine();
                    if(sr.EndOfStream)
                    {
                        stringBuilder.Append(temp);
                    }
                    else
                    {
                        stringBuilder.AppendLine(temp);
                    }
                }
                data = stringBuilder.ToString();

                using(FileStream fs = new FileStream(newPathName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] bytes = Encoding.Default.GetBytes(data);
                    //Writing the data of file to new file.
                    fs.Write(bytes, 0, bytes.Length);

                    sizeOfFileInBytes = bytes.Length;
                }
            }
            return sizeOfFileInBytes;
        }
        
        /// <summary>
        /// This method is checked a data of two files.
        /// </summary>
        /// <param name="pathOfFirstFile"></param>
        /// <param name="pathOfSecondFile"></param>
        /// <returns>True or false.</returns>
        public bool EqualsOfTwoFiles(string pathOfFirstFile, string pathOfSecondFile)
        {
            string first,second = null;

            using(StreamReader sr = new StreamReader(pathOfFirstFile))
            {
                //Reading text from the first file.
                first = sr.ReadToEnd();
            }
            using(StreamReader sr = new StreamReader(pathOfSecondFile))
            {
                //Reading text from the second file.
                second = sr.ReadToEnd();
            }

            return first.Equals(second);
        }
    }
}
