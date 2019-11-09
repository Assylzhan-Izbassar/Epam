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
        public CopyFile()
        {
        }

        /// <summary>
        /// This method copy data of file using byte array and IO FileStream.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>It is returns the count of bytes that was copied.</returns>
        public int CopyWithFileStream(string filePath, string newPath)
        {
            string readingText = "";

            //Reading data of file.
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] arr = new byte[fileStream.Length];
                //Read the data.
                fileStream.Read(arr, 0, arr.Length);
                //Decoding bytes into string.
                readingText = Encoding.Default.GetString(arr);
            }

            byte[] bytes = null;
            using (FileStream fileStream = new FileStream(newPath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                //Converting string into bytes.
                bytes = Encoding.Default.GetBytes(readingText);
                //Writing the data into the new file.
                fileStream.Write(bytes, 0, bytes.Length);
            }
            return bytes.Length;
        }

        /// <summary>
        /// This method is copy data into one file to another using System.IO MemoryStream.
        /// </summary>
        /// <param name="currFilePath"></param>
        /// <param name="newFilePath"></param>
        /// <returns>The method is returns how many bytes stored into a data of file.</returns>
        public int CopyWithMemoryStream(string currFilePath, string newFilePath)
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
                //Writing data into array bytes to memoryStream.
                memoryStream.Write(bytes, 0, bytes.Length);
                //Writing data into memoryStream to a new file using FileStream.
                using (FileStream fileStream = new FileStream(newFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    memoryStream.WriteTo(fileStream);
                }
            }
            return bytes.Length;
        }
    }
}
