using Microsoft.AspNetCore.Mvc;

namespace Lambda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { 
                message = "Backend connected successfully!", 
                timestamp = DateTime.Now,
                port = "5188"
            });
        }

        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok(new { 
                status = "healthy", 
                service = "Lambda API",
                port = "5188",
                timestamp = DateTime.Now 
            });
        }
    }
}