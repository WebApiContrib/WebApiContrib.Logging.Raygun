using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;

namespace WebApiContrib.Logging.Raygun
{
    public class WebApiRaygunRequestMessage
    {
        public WebApiRaygunRequestMessage(HttpRequestMessage request)
        {
            HostName = request.RequestUri.Host;
            Url = request.RequestUri.AbsolutePath;
            HttpMethod = request.Method.ToString();
            Headers = new Dictionary<string, string>();

            foreach (var header in request.Headers)
            {
                Headers.Add(header.Key, string.Join(",", header.Value));
            }
            IPAddress = request.GetClientIpAddress();

            if (request.Content.Headers.ContentLength.HasValue && request.Content.Headers.ContentLength.Value > 0)
            {

                foreach (var header in request.Content.Headers)
                {
                    Headers.Add(header.Key, string.Join(",", header.Value));
                }

                try
                {
                    RawData = request.Content.ReadAsStringAsync().Result;
                }
                catch (Exception)
                {
                }
            }
        }

        public string HostName { get; set; }

        public string Url { get; set; }

        public string HttpMethod { get; set; }

        public string RawData { get; set; }

        public IDictionary Headers { get; set; }

        public string IPAddress { get; set; }

    }
}