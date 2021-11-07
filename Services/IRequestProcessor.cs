using System.Net.Http;
using System.Threading.Tasks;

namespace BlazingPostMan.Services
{
    public interface IRequestProcessor
    {
        Task<HttpResponseMessage> ProcessRequest(string url);
    }
}