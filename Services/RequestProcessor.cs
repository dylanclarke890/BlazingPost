using BlazingPostMan.Data.Enums;
using BlazingPostMan.Data.Helpers;
using BlazingPostMan.Data.Models;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BlazingPostMan.Services
{
    public class RequestProcessor : IRequestProcessor
    {
        private readonly HttpClient _httpClient;

        public RequestProcessor()
        {
            _httpClient = new();
        }

        public async Task<HttpResponseMessage> ProcessRequest(Request request)
        {
            string url = UrlHelper.GetUrl(request.Url, request.UrlParameters);
            return request.RequestType switch
            {
                RequestType.POST => await SendAsync(url, request.RequestBody, HttpMethod.Post),
                RequestType.GET => await SendAsync(url, request.RequestBody, HttpMethod.Get),
                RequestType.PUT => await SendAsync(url, request.RequestBody, HttpMethod.Put),
                RequestType.DELETE => await SendAsync(url, request.RequestBody, HttpMethod.Delete),
                _ => null,
            };
        }

        private async Task<HttpResponseMessage> SendAsync(string url, Body body, HttpMethod httpMethod)
        {
            HttpRequestMessage httpRequest = new(httpMethod, url);
            httpRequest.Content = GetContent(body);

            return await _httpClient.SendAsync(httpRequest);
        }

        private static HttpContent GetContent(Body body)
        {
            body ??= new() 
            { 
                StringContent = "",
                BodyType = BodyType.String
            };

            if (body.BodyType is BodyType.String or BodyType.None)
            {
                return new StringContent(JsonConvert.SerializeObject(body.StringContent), Encoding.UTF8, "application/json");
            }
            else if (body.BodyType is BodyType.File)
            {
                if (body.FileContent is null)
                {
                    return null;
                }
                
                return GetStreamContent(body.FileContent);
            }

            return default;
        }
        
        private static MultipartFormDataContent GetStreamContent(List<IBrowserFile> files)
        {
            var content = new MultipartFormDataContent();
            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");

            foreach (var file in files)
            {
                if (file is not null)
                {
                    var ms = file.OpenReadStream();
                    content.Add(new StreamContent(ms, Convert.ToInt32(file.Size)), file.Name, file.Name);
                }
            }

            return content;
        }
    }
}
