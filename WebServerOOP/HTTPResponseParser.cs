using System;
using System.Diagnostics;

namespace WebServerOOP
{
    internal class HTTPResponseParser
    {
        public static HTTPResponse CreateHTTPResponse(byte[] data, string uRL)
        {
            if(data == null)
            {
                return Error.PageNotFound();
            }
            var MimeType = "";
            var FileName = uRL.Substring(uRL.LastIndexOf('/')+1);
           
            if (FileName.Contains(".com"))
                MimeType = MIMEAssistant.GetMIMEType("index.html");
             else
                MimeType = MIMEAssistant.GetMIMEType(FileName);
            
            return new HTTPResponse("200: OK", MimeType, data);
        }
    }
}