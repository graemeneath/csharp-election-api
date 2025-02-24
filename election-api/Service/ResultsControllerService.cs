using election_api.Model;

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
