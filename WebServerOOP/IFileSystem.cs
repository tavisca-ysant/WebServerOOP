using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebServerOOP
{
    public interface IFileSystem
    {

        void ResolveVirtualPath(String rootDirectory, String fileName);

        Byte[] GetFileStream(FileInfo fileInfo);

        bool TryGetFile(out FileInfo fileInfo);

        Byte[] HandleDirectory(FileInfo fileInfo);
    }
}
