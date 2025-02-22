using election_api.Model;
using election_api.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace election_api.Controller
{
    [ApiController]
    [Route("/")]
    public class ResultsController : ControllerBase
    {
        static ResultsControllerService _service = new ResultsControllerService();

        [HttpGet("result/{id}")]
        public ConstituencyResult GetResult(int id)
        {
            return _service.GetResult(id);
        }

        [HttpPost("result")]
        public void NewResult([FromBody] ConstituencyResult result)
        {
            _service.NewResult(result);
        }

        [HttpGet("scoreboard")]
        public Scoreboard GetScoreboard()
        {
            return _service.GetScoreboard();
        }
    }
}
