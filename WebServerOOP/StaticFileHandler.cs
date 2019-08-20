using System;
using System.IO;

namespace WebServerOOP
{
    public class StaticFileHandler : IHttpHandler
    {
        //webApp => root Dir,
       
        private IFileSystem _iFileSystem;
        private FileInfo _fileInfo;
        public StaticFileHandler(IFileSystem iFileSystem)
        {
            _iFileSystem = iFileSystem;
        }

        public Byte[] HandleStaticFiles(String RootDirectory, String URL)
        {
            _iFileSystem.ResolveVirtualPath(RootDirectory, URL);
            if (_iFileSystem.TryGetFile(out _fileInfo))
                return GetFileData();
            return HandleFileDirectory();

        }

        public Byte[] HandleFileDirectory()
        {
            return _iFileSystem.HandleDirectory(_fileInfo);
        }

        public Byte[] GetFileData()
        {
            return _iFileSystem.GetFileStream(_fileInfo);
        }

    }
}
