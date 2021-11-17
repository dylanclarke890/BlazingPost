using BlazingPostMan.Data.Enums;
using BlazingPostMan.Services.StrBuilder;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPostMan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestEndpointController : ControllerBase
    {
        private readonly IStringBuilderService _sbService;

        public TestEndpointController(IStringBuilderService stringBuilderService)
        {
            _sbService = stringBuilderService;
        }

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
        private async Task<IActionResult> ProcessRequest(RequestType requestType)
        {
            _sbService.Add($"Testing {requestType}. ");

            if (!StringContentRequest() && Request.ContentType != null)
            {
                if (Request.Form.Files.Any())
                {
                    _sbService.Add($"{Request.Form.Files.Count} Files. ");
                }
            }

            _sbService.Add($"With Headers: ");

            foreach (var header in Request.Headers)
            {
                _sbService.Add($"{header.Key}: {header.Value}, ");
            }

            return await OkWithBody();
        }
        private bool StringContentRequest()
        {
            return Request.ContentType == "application/json; charset=utf-8";
        }

        private async Task<IActionResult> OkWithBody()
        {
            if (Request.Body != null)
            {
                var bodyContent = JsonConvert.DeserializeObject<string>(await new StreamReader(Request.Body).ReadToEndAsync());
                bodyContent ??= "None";
                _sbService.Add($"Body: {bodyContent} ");
            }

            return Ok(_sbService.Get());
        }
    }
}
