using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebServerOOP
{
    public class Utility
    {
        public static List<String> SeperateAppNameAndURL(string uRL)
        {
            var Output = new List<String>();
            
            var data = uRL.Split('/');
            int index = 0;
            var webAppName = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Contains(".com"))
                {
                    webAppName = data[i];
                    index = i;
                    break;
                }
            }
            var url = "";
            for (int j = index + 1; j < data.Length; j++)
            {
                url += "/";
                url += data[j];

            }
            if (url.Length != 0)
                url.Remove(url.Length - 1);
            Output.Add(webAppName);
            Output.Add(url);
            return Output;
        }
    }
}