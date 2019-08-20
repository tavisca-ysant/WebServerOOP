using System;
using Microsoft.Owin.Hosting;

namespace WebServerOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting server on port 8080");
            HTTPServer hTTPServer = new HTTPServer(8080);
            hTTPServer.Start();
            //string domain = "http://localhost/";
            //using (Microsoft.Owin.Hosting.WebApp.Start(url: domain))
            //{
            //    Console.WriteLine("Service hosted");
            //    System.Threading.Thread.Sleep(-1);
            //}
        }
    }
}
