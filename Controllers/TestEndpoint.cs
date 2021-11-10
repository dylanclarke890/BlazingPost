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
            string content = "";
            if (!StringContentRequest())
            {
                if (Request.Form.Files.Any())
                {
                    content += $"{Request.Form.Files.Count} Files";
                }
            }

            return await OkWithBody(content, RequestType.POST);
        }

        private bool StringContentRequest()
        {
            return Request.ContentType == "application/json; charset=utf-8";
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromBody] string content)
        {
            return await OkWithBody(content, RequestType.GET);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] string content)
        {
            return await OkWithBody(content, RequestType.PUT);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] string content)
        {
            return await OkWithBody(content, RequestType.DELETE);
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

        private static bool IsNullOrEmptyRequestBody(string content)
        {
            return content == "\"\"" || content == "\"null\"";
        }
    }
}
