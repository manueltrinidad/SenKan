using System;
using System.Collections.Generic;

namespace SenKan
{
    public class Match
    {
        public bool IsGoing { get; set; }
        public string Winner { get; set; }
        public int CurrentTurnIndex { get; set; }
        public List<Player> Players { get; set; }
        public List<Turn> TurnHistory { get; set; }
        public Ruleset Ruleset { get; set; }

        public Match(List<Player> players, Ruleset ruleset)
        {
            var rnd = new Random();
            Players = players;
            Ruleset = ruleset;
            IsGoing = true;
            Winner = null;
            CurrentTurnIndex = rnd.Next(0, players.Count);
            TurnHistory = new List<Turn>();
        }
    }
}