using Microsoft.AspNetCore.Mvc;

namespace BlazingPostMan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestEndpointController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post()
        {
            return Ok("testing post");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("testing get");
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok("testing put");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("testing delete");
        }
    }
}
