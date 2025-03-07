﻿using election_api.Model;

namespace election_api.Service
{
    public class ScoreboardService
    {
        private Scoreboard scoreboard = new Scoreboard();

        public ScoreboardService() { }

        internal void AddResult(ConstituencyResult cr)
        {
            if (cr.partyResults == null)
            {
                throw new Exception("Party results are null");
            }

            scoreboard.sum++;

            string winningParty = GetWinningParty(cr.partyResults);
            if (scoreboard.results.TryGetValue(winningParty, out ScoreboardResult? sr))
            {
                if (sr == null)
                {
                    throw new Exception("Scoreboard result is null");
                }
                sr.seats++;
            }
            else
            {
                scoreboard.results.Add(winningParty, new ScoreboardResult { seats = 1 });
            }
        }

        internal Scoreboard GetScoreboard()
        {
            scoreboard.winner = GetOverallWinner();
            return scoreboard;
        }

        private string GetOverallWinner()
        {
            string winningParty = "";
            int winningSeats = 0;
            foreach (KeyValuePair<string, ScoreboardResult> kvp in scoreboard.results)
            {
                if (kvp.Value.seats > winningSeats)
                {
                    winningSeats = kvp.Value.seats;
                    winningParty = kvp.Key;
                }
            }

            if (winningSeats >= 325)
            {
                return winningParty;
            }
            else
            {
                return "noone";
            }
        }

        private string GetWinningParty(List<PartyResult> partyResults)
        {
            string winningParty = "";
            int winningVotes = 0;

            foreach (PartyResult pr in partyResults)
            {
                if (pr.votes > winningVotes)
                {
                    winningVotes = pr.votes;
                    winningParty = pr.party;
                }
            }

            return winningParty;
        }
    }
}
