using System;
namespace WebServerOOP
{
    public class HTTPRequest
    {
        public String Type { get; set; }

        public String URL { get; set; }

        public String Host { get; set; }

        public String Referer { get; set; }

        public HTTPRequest(String type, String url, String host, String referer)
        {
            Type = type;
            URL = url;
            Host = host;
            Referer = referer;
        }

    }
}