﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace election_api.Model
{
    public class Scoreboard
    {
        public string winner { get; set; }
        public int sum { get; set; }
        public Dictionary<string, ScoreboardResult> results { get; set; }

        public Scoreboard()
        {
            winner = "noone";
            results = new Dictionary<string, ScoreboardResult>();
        }
    }
}
