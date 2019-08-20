using System;
using System.IO;

namespace WebServerOOP
{
    public class Error
    {
        private static readonly string Error_Message_Directory = "/error/";
        public static HTTPResponse BadRequest()
        {
            String file = Environment.CurrentDirectory + Error_Message_Directory + "405.html";
            FileInfo fileInfo = new FileInfo(file);
            FileStream fileStream = fileInfo.OpenRead();
            BinaryReader binaryReader = new BinaryReader(fileStream);
            Byte[] data = new Byte[fileStream.Length];
            binaryReader.Read(data, 0, data.Length);
            fileStream.Close();
            return new HTTPResponse("405: Method Not allowed", "text/html", data);
        }

        internal static HTTPResponse PageNotFound()
        {
            String file = Environment.CurrentDirectory + Error_Message_Directory + "404.html";
            FileInfo fileInfo = new FileInfo(file);
            FileStream fileStream = fileInfo.OpenRead();
            BinaryReader binaryReader = new BinaryReader(fileStream);
            Byte[] data = new Byte[fileStream.Length];
            binaryReader.Read(data, 0, data.Length);
            fileStream.Close();
            return new HTTPResponse("404: Page Not Found", "text/html", data);
        }
    }
}