using Microsoft.AspNetCore.Mvc;

namespace QuizGenie.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "¡Hola desde QuizGenie API!" });
        }
    }
}
