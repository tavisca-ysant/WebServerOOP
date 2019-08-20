using System;
using System.Collections.Generic;
using System.Text;

namespace WebServerOOP
{
    public interface IHttpHandler
    {
        Byte[] HandleStaticFiles(String RootDirectory, String URL);
        Byte[] GetFileData();

        Byte[] HandleFileDirectory();
    }
}
