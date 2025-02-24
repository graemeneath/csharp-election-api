using Microsoft.AspNetCore.Mvc;

namespace election_api.Controller
{
    [ApiController]
    [Route("/")]
    public class HelloController : ControllerBase
    {
        [HttpGet("hello")]
        public string Get()
        {
            return "Hello, World!";
        }
    }
}
