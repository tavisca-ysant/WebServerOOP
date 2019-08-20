using System;
using System.Collections.Generic;
using System.Text;

namespace WebServerOOP
{
    public class ServerConfiguration
    {

        private static List<(String, String, IFileSystem)> _webAppConfigurations = new List<(String, String, IFileSystem)>()
        {
            ("demo.com","/com/demo",new LocalFileSystem()),
            ("login-system.com","/com/login-system",FileSystemFactory.GetFileSystem("LocalFileSystem")),
            ("checkleapyear.com","/com/checkleapyear",FileSystemFactory.GetFileSystem("LocalFileSystem"))
        };
        
        public static List<(String, IFileSystem)> GetRootDirecotryAndFileSystem(String webAppName)
        {
            var webApp = _webAppConfigurations.Find(WebApp => WebApp.Item1 == webAppName);
            List<(String, IFileSystem)> _WebApp = new List<(String, IFileSystem)>()
            {
                (webApp.Item2, webApp.Item3)
            };
            return _WebApp;
        }
        

    }
}
