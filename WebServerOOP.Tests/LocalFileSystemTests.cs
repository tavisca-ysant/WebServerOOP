using System;
using Xunit;
using WebServerOOP;
using System.IO;

namespace WebServerOOP.Tests
{
    public class LocalFileSystemTests
    {
        private IFileSystem _iFileSystem = FileSystemFactory.GetFileSystem("LocalFileSystem");
        [Fact]
        public void Get_correct_file_system_test()
        {
            Assert.IsType<LocalFileSystem>(_iFileSystem);
        }

        [Fact]
        public void Get_correct_physical_path()
        {
            string expectedPhysicalPath = @"C:\Users\ysant\source\repos\WebServer\WebServer\bin\Debug\netcoreapp2.2\root\web\index.html";
            LocalFileSystem localFileSystem = (LocalFileSystem)_iFileSystem;
            localFileSystem.ResolveVirtualPath(@"C:\Users\ysant\source\repos\WebServer\WebServer\bin\Debug\netcoreapp2.2\root\web\", "index.html");
            Assert.Equal(expectedPhysicalPath, localFileSystem.PhysicalPath);
        }

        [Fact]
        public void Get_Try_Get_File_Test()
        {
            FileInfo fileInfo;
            _iFileSystem.ResolveVirtualPath(@"C:\Users\ysant\source\repos\WebServer\WebServer\bin\Debug\netcoreapp2.2\root\web\", "index.html");
            Assert.True(_iFileSystem.TryGetFile(out fileInfo));
        }

        

    }
}
