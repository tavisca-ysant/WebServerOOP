using System;

namespace WebServerOOP
{
    public class WebApp
    {
        private String _rootDirectory;
        private IFileSystem _iFileSystem;
        private IHttpHandler _requestHandler;

        public WebApp(String rootDirectory, IFileSystem iFileSystem)
        {
            _rootDirectory = rootDirectory;
            _iFileSystem = iFileSystem;
        }

        public byte[] HandleRequest(String URL)
        {
            _requestHandler = new StaticFileHandler(_iFileSystem);
            return _requestHandler.HandleStaticFiles(_rootDirectory, URL);
        }
    }
}