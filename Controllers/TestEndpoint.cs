﻿using BlazingPostMan.Data.Enums;
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
            string content = "";
            if (!StringContentRequest())
            {
                if (Request.Form.Files.Any())
                {
                    content += $"{Request.Form.Files.Count} Files";
                }
            }

            content += $"{Request.Headers.Count} Headers";

            foreach (var header in Request.Headers)
            {
                content += $"{header.Key}, {header.Value}";
            }

            return await OkWithBody(content, requestType);
        }
        private bool StringContentRequest()
        {
            return Request.ContentType == "application/json; charset=utf-8";
        }

        private async Task<IActionResult> OkWithBody(string content, RequestType requestType)
        {
            string contentToReturn = $"Testing {requestType}";
            var bodyContent = JsonConvert.DeserializeObject<string>(await new StreamReader(Request.Body).ReadToEndAsync());
            if (!string.IsNullOrEmpty(bodyContent))
            {
                contentToReturn += $"Body: {bodyContent}";
            }

            return Ok($"{contentToReturn} {content}");
        }
    }
}
