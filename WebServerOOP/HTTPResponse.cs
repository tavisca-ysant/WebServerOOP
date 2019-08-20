using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace WebServerOOP
{
    public class HTTPResponse
    {
        private Byte[] _data = null;
        private String _status;
        private String _mime;

        public HTTPResponse(String status, String mime, Byte[] data)
        {
            _status = status;
            _data = data;
            _mime = mime;
        }

        public  void Post(NetworkStream networkStream)
        {
            StreamWriter streamWriter = new StreamWriter(networkStream);
            streamWriter.WriteLine(String.Format("{0} {1}\r\nServer: {2}\r\nContent-Type: {3}\r\nAccept-Ranges: bytes\r\nContent-Length: {4}\r\n"
                                                 , HTTPServer.Version, _status, HTTPServer.Name, _mime, _data.Length));
            streamWriter.Flush();
            networkStream.Write(_data, 0, _data.Length);
        }
    }


}
