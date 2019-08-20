using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebServerOOP
{
    public class FileReader
    {
        public static Byte[] GetFileStream(FileInfo fileInfo)
        {

            FileStream fileStream = fileInfo.OpenRead();
            BinaryReader binaryReader = new BinaryReader(fileStream);
            Byte[] data = new Byte[fileStream.Length];
            binaryReader.Read(data, 0, data.Length);
            fileStream.Close();
            return data;
        }
    }
}
