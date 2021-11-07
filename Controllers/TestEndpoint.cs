using Microsoft.AspNetCore.Mvc;

namespace BlazingPostMan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestEndpointController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("test");
        }
    }
}
