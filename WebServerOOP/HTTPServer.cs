using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WebServerOOP
{
    public class HTTPServer
    {
        public  static readonly string Version = "HTTP/1.1";
        public  static readonly object Name = "C# Http Server";
        private Socket _serverSocket;
        private IPAddress _ipAddress = Dns.GetHostEntry("localhost").AddressList[1];
        private IPEndPoint _ipEndPoint;
        private bool ServerIsRunning = false;
        public HTTPServer(int port)
        {
            _serverSocket = new Socket(_ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _ipEndPoint = new IPEndPoint(_ipAddress, port);
            
        }

        public void Start()
        {
            Thread listeningThread = new Thread(new ThreadStart(StartListening));
            listeningThread.Start();
        }

        private void StartListening()
        {
            ServerIsRunning = true;
            _serverSocket.Bind(_ipEndPoint);
            _serverSocket.Listen(10);
            while (ServerIsRunning)
            {
                Console.WriteLine("Waiting for connection");
                Socket _clientSocket = _serverSocket.Accept();
                Dispatcher dispatcher = new Dispatcher(_clientSocket);
                dispatcher.Start();
                _clientSocket.Close();
            }
            ServerIsRunning = false;
            _serverSocket.Disconnect(true);
            
        }
    }
}
