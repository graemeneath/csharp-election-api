using election_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace election_api.Service
{
    public class ResultsControllerService
    {
        ResultService _resultService;

        public ResultsControllerService()
        {
            _resultService = new ResultService();
        }

        public ConstituencyResult GetResult(int id)
        {
            return _resultService.GetResult(id);
        }

        public void NewResult(ConstituencyResult result)
        {
            _resultService.NewResult(result);
        }

        public void Reset()
        {
            _resultService.Reset();
        }

        public Scoreboard GetScoreboard()
        {
            ScoreboardService scoreboardService = new ScoreboardService();
            
            _resultService.GetAll().ToList().ForEach(result =>
            {
                scoreboardService.AddResult(result.Value);
            });

            return scoreboardService.GetScoreboard();
        }
    }
}
