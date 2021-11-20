using BlazingPostMan.Data.Enums;
using BlazingPostMan.Generics;
using System.Collections.Generic;

namespace BlazingPostMan.Data.Models
{
    public class Request : ICloneable<Request>
    {
        public Request()
        {
            UrlParameters = new();
            Headers = new();
            AuthData = new();
            RequestBody = new();
        }

        public Request(string url, RequestType requestType, 
            Dictionary<string, string> urlParams,  Dictionary<string, string> headers, 
            Body body, AuthorisationData authorizationData)
        {
            Url = url;
            RequestType = requestType;
            UrlParameters = urlParams;
            Headers = headers;
            RequestBody = body;
            AuthData = authorizationData;
        }

        public string Url { get; set; }

        public RequestType RequestType { get; set; }

        public Dictionary<string, string> UrlParameters { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public AuthorisationData AuthData { get; set; }

        public Body RequestBody { get; set; }

        public Request Clone()
        {
            var obj = new Request
            {
                Url = Url,
                RequestType = RequestType,
                UrlParameters = UrlParameters,
                Headers = Headers,
                RequestBody = RequestBody,
                AuthData = AuthData
            };
            return obj;
        }
    }
}
