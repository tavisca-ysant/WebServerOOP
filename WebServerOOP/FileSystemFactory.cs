using System;
using System.Collections.Generic;
using System.Text;

namespace WebServerOOP
{
    public class FileSystemFactory
    {
        public static IFileSystem GetFileSystem(String fileSystemType)
        {
            switch (fileSystemType)
            {
                case "LocalFileSystem": return new LocalFileSystem();
                default: throw new InvalidFileSystemException();
            }
        }
    }
}
