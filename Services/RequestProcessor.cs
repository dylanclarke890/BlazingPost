using BlazingPostMan.Data.Enums;
using BlazingPostMan.Data.Helpers;
using BlazingPostMan.Data.Models;
using System.Net.Http;
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
                RequestType.POST => await _httpClient.PostAsync(url, new StringContent(request.RequestBody?.StringContent)),
                RequestType.GET => await _httpClient.GetAsync(url),
                RequestType.PUT => await _httpClient.PutAsync(url, new StringContent(request.RequestBody?.StringContent)),
                RequestType.DELETE => await _httpClient.DeleteAsync(url),
                _ => null,
            };
        }
    }
}
