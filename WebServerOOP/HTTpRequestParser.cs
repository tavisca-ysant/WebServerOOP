using System;

namespace WebServerOOP
{
    internal class HTTpRequestParser
    {
        public static HTTPRequest GetHTTPRequest(String request)
        {
            if (String.IsNullOrEmpty(request))
                return null;
            String[] tokens = request.Split(' ', '\n');
            String type = tokens[0];
            String url = tokens[1];
            String host = tokens[4];
            Console.WriteLine("URL is " + url);
            String referer = "";
            for (int index = 0; index < tokens.Length; index++)
            {
                if (tokens[index] == "Referer:")
                {
                    referer = tokens[index + 1];
                    break;
                }
            }
            Console.WriteLine(String.Format("{0} {1} @ {2} \nReferer: {3}", type, url, host, referer));

            return new HTTPRequest(type, url, host, referer);
        }
    }
}