using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Sockets;
using System;
using System.Text;
using System.Net.Http;

namespace WebServerOOP
{
    internal class ApiHandler
    {
        private HTTPRequest _hTTPRequest;
        private string _message;
        private NetworkStream _networkStream;
        public ApiHandler(HTTPRequest hTTPRequest, string Message, NetworkStream networkStream)
        {
            _hTTPRequest = hTTPRequest;
            _message = Message;
            _networkStream = networkStream;
        }

        public void Handle()
        {
            var data = _message.Split(' ','\n');
            for(int i = 0; i < data.Length; i++)
            {
                Debug.WriteLine($"{i} : {data[i]} ");
            }
            HttpClient client = new HttpClient();
            var year = int.Parse(data[26]);
            var IsLeap = CheckForLeapYear(year);
            JObject responseJSON = JObject.Parse(@"{'IsLeap': '" + IsLeap + @"'}");
            byte[] buf = Encoding.UTF8.GetBytes(responseJSON.ToString());
            var httpResponse = new HTTPResponse("200: OK", "application/json", buf);
        }
        private bool CheckForLeapYear(int year)
        {
            return ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0);
        }
    }
}