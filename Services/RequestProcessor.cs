using BlazingPostMan.Data.Enums;
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

        public async Task<HttpResponseMessage> ProcessRequest(string url, RequestType requestType, string content = "")
        {
            return requestType switch
            {
                RequestType.POST => await _httpClient.PostAsync(url, new StringContent(content)),
                RequestType.GET => await _httpClient.GetAsync(url),
                RequestType.PUT => await _httpClient.PutAsync(url, new StringContent(content)),
                RequestType.DELETE => await _httpClient.DeleteAsync(url),
                _ => null,
            };
        }
    }
}
