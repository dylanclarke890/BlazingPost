using BlazingPostMan.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BlazingPostMan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestEndpointController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] string content)
        {
            if (!StringContentRequest())
            {
                if (Request.Form.Files.Any())
                {
                    content += $", {Request.Form.Files.Count} Files";
                }
            }

            return OkWithBody(content, RequestType.POST);
        }

        private bool StringContentRequest()
        {
            return Request.ContentType == "application/json; charset=utf-8";
        }

        [HttpGet]
        public IActionResult Get([FromBody] string content)
        {
            return OkWithBody(content, RequestType.GET);
        }

        [HttpPut]
        public IActionResult Put([FromBody] string content)
        {
            return OkWithBody(content, RequestType.PUT);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] string content)
        {
            return OkWithBody(content, RequestType.DELETE);
        }

        private IActionResult OkWithBody(string content, RequestType requestType)
        {
            string contentToReturn = $"testing {requestType}";

            if (!string.IsNullOrEmpty(content))
            {
                contentToReturn += $", Body: {content}";
            }

            return Ok(contentToReturn);
        }
    }
}
