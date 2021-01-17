using System.Collections.Generic;

namespace SenKan
{
    public class Ruleset
    {
        public Board Board { get; set; }
        public List<ShipRuleset> ShipRulesets { get; set; }
        
        public Ruleset(Board board, List<ShipRuleset> shipRulesets)
        {
            Board = board;
            ShipRulesets = shipRulesets;
        }
    }
}