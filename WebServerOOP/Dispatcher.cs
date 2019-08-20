using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WebServerOOP
{
    public class Dispatcher
    {
        private Socket _clientSocket;
        private static String AppName = "";
        private ApiHandler _apiHandler;
        public Dispatcher(Socket clientSocket)
        {
            _clientSocket = clientSocket;
        }

        public void HandleRequest()
        {
            NetworkStream networkStream = new NetworkStream(_clientSocket);
            StreamReader streamReader = new StreamReader(networkStream);

            String Message = "";
            while(streamReader.Peek() != -1)
            {
                Message += streamReader.ReadLine() + "\n";
            }

            Debug.WriteLine("Request: \n" + Message);
            HTTPRequest hTTPRequest = HTTpRequestParser.GetHTTPRequest(Message);
            
            HTTPResponse hTTPResponse = GenerateResponse(hTTPRequest);
            hTTPResponse.Post(networkStream);
        }


        public HTTPResponse GenerateResponse(HTTPRequest hTTPRequest)
        {
            if (hTTPRequest == null) return Error.BadRequest();
            if(hTTPRequest.Type == "GET")
            {
                var URL = hTTPRequest.URL;
                

                
               var AppAndURL = Utility.SeperateAppNameAndURL(URL);
                if(AppName == "")
                {
                    if(AppAndURL[0].Contains(".com"))
                        AppName = AppAndURL[0];
                }
                Console.WriteLine($"App name is {AppName}");
                if (AppName == "checkleapyear.com")
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\ysant\source\repos\MyWebApi\MyWebApi\bin\Debug");
                    if (directoryInfo.Exists) Console.WriteLine("Hello");
                    ProcessStartInfo info = new ProcessStartInfo(@"C:\Users\ysant\source\repos\MyWebApi\MyWebApi\bin\Debug\MyWebApi.exe");
                    Process.Start(info);
                    Environment.Exit(0);
                }
                var actualURL = AppAndURL[1];
                
                var WebAppAndFileSystem = ServerConfiguration.GetRootDirecotryAndFileSystem(AppName);

                var FileSystem = WebAppAndFileSystem[0].Item2;
                if (FileSystem == null)
                    return Error.PageNotFound();
                var rootDirectory = Environment.CurrentDirectory +  WebAppAndFileSystem[0].Item1;
                
                IHttpHandler httpHandler = new StaticFileHandler(FileSystem);
                Byte[] Data = null;
                try
                {
                    Data = httpHandler.HandleStaticFiles(rootDirectory, actualURL);
                }
                catch (Exception)
                {
                    return Error.BadRequest();
                }
                return HTTPResponseParser.CreateHTTPResponse(Data, URL);
            }
            return Error.BadRequest();
        }

        public  void Start()
        {

            HandleRequest();
        }



    }
}
