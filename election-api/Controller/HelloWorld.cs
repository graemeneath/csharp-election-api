using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
