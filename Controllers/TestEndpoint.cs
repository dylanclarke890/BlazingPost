using BlazingPostMan.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPostMan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestEndpointController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return await ProcessRequest(RequestType.POST);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ProcessRequest(RequestType.GET);
        }

        [HttpPut]
        public async Task<IActionResult> Put()
        {
            return await ProcessRequest(RequestType.PUT);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return await ProcessRequest(RequestType.DELETE);
        }

        private async Task<IActionResult> OkWithBody(string content, RequestType requestType)
        {
            string contentToReturn = $"testing {requestType}";
            var bodyContent = await new StreamReader(Request.Body).ReadToEndAsync();
            if (!IsNullOrEmptyRequestBody(bodyContent))
            {
                contentToReturn += $", Body: {bodyContent}";
            }

            return Ok($"{contentToReturn}, {content}");
        }

        private async Task<IActionResult> ProcessRequest(RequestType requestType)
        {
            string content = "";
            if (!StringContentRequest())
            {
                if (Request.Form.Files.Any())
                {
                    content += $"{Request.Form.Files.Count} Files";
                }
            }

            return await OkWithBody(content, requestType);
        }

        private bool StringContentRequest()
        {
            return Request.ContentType == "application/json; charset=utf-8";
        }

        private static bool IsNullOrEmptyRequestBody(string content)
        {
            return content == "\"\"" || content == "\"null\"";
        }
    }
}
