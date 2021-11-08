using BlazingPostMan.Data.Enums;
using System.Collections.Generic;

namespace BlazingPostMan.Data.Models
{
    public class Request
    {
        public Request(string url, RequestType requestType, Dictionary<string, string> urlParams, Body body)
        {
            Url = url;
            RequestType = requestType;
            UrlParameters = urlParams;
            RequestBody = body;
        }

        public string Url { get; set; }

        public RequestType RequestType { get; set; }

        public Dictionary<string, string> UrlParameters { get; set; }

        public Body RequestBody { get; set; }
    }
}
