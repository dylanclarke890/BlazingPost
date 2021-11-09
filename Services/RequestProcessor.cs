using BlazingPostMan.Data.Enums;
using BlazingPostMan.Data.Helpers;
using BlazingPostMan.Data.Models;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
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
                RequestType.POST => await PostAsync(url, request.RequestBody),
                RequestType.GET => await GetAsync(url, request.RequestBody),
                RequestType.PUT => await PutAsync(url, request.RequestBody),
                RequestType.DELETE => await DeleteAsync(url, request.RequestBody),
                _ => null,
            };
        }

        private async Task<HttpResponseMessage> PostAsync(string url, Body body)
        {
            HttpRequestMessage httpRequest = new(HttpMethod.Post, url);
            httpRequest.Content = GetContent(body);

            if (body.BodyType == BodyType.File)
            {
                httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            }

            return await _httpClient.SendAsync(httpRequest);
        }

        private async Task<HttpResponseMessage> GetAsync(string url, Body body)
        {
            HttpRequestMessage httpRequest = new(HttpMethod.Get, url);
            httpRequest.Content = GetContent(body);

            return await _httpClient.SendAsync(httpRequest);
        }

        private async Task<HttpResponseMessage> PutAsync(string url, Body body)
        {
            HttpRequestMessage httpRequest = new(HttpMethod.Put, url);
            httpRequest.Content = GetContent(body);

            return await _httpClient.SendAsync(httpRequest);
        }

        private async Task<HttpResponseMessage> DeleteAsync(string url, Body body)
        {
            HttpRequestMessage httpRequest = new(HttpMethod.Delete, url);
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
                
                return body.FileContent.Count > 1 ? new MultipartContent() : GetStreamContent(body.FileContent.First());
            }

            return default;
        }
        
        private static StreamContent GetStreamContent(IBrowserFile file)
        {
            var memoryStream = new MemoryStream();
            file.OpenReadStream().CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            return new StreamContent(memoryStream);
        }
    }
}
