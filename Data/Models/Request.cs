using BlazingPostMan.Data.Enums;
using System.Collections.Generic;

namespace BlazingPostMan.Data.Models
{
    public class Request
    {
        public Request(string url, RequestType requestType, Dictionary<string, string> urlParams, Dictionary<string, string> headers, Body body)
        {
            Url = url;
            RequestType = requestType;
            UrlParameters = urlParams;
            Headers = headers;
            RequestBody = body;
        }

        public string Url { get; set; }

        public RequestType RequestType { get; set; }

        public Dictionary<string, string> UrlParameters { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public Body RequestBody { get; set; }
    }
}
