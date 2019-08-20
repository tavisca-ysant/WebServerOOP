using System;
using System.Diagnostics;
using System.IO;

namespace WebServerOOP
{
    public class LocalFileSystem : IFileSystem
    {
        private static String _physicalPath;

        public string PhysicalPath
        {
            get => _physicalPath;
        }

        public void ResolveVirtualPath(String rootDirectory, String fileName)
        {
            _physicalPath = rootDirectory + fileName;
        }

        public bool TryGetFile(out FileInfo fileInfo)
        {
            fileInfo = new FileInfo(_physicalPath);
            return fileInfo.Exists && IsFile(fileInfo);
            
        }

        private bool IsFile(FileInfo fileInfo)
        {
            return fileInfo.Extension.Contains('.');
        }

        public Byte[] GetFileStream(FileInfo fileInfo)
        {

            return FileReader.GetFileStream(fileInfo);
        }

        public Byte[] HandleDirectory(FileInfo fileInfo)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(fileInfo + "/");
            
            if (!directoryInfo.Exists)
                throw new DirectoryNotFoundException();
            FileInfo[] fileInfoArray = directoryInfo.GetFiles();
            foreach(var file in fileInfoArray)
            {
                String fileName = file.Name;

                if (fileName.Contains("default.html") || fileName.Contains("default.htm")
                    || fileName.Contains("index.html") || fileName.Contains("index.htm")
                    || fileName.Contains("index.php"))
                    return GetFileStream(file);

            }
            return null;
        }
    }
}