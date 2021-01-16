using System.Collections.Generic;

namespace SenKan
{
    public class Ruleset
    {
        public int Id { get; set; }
        public Board Board { get; set; }
        public List<ShipRuleset> ShipRulesets { get; set; }
        
        public Ruleset(int id, Board board, List<ShipRuleset> shipRulesets)
        {
            Id = id;
            Board = board;
            ShipRulesets = shipRulesets;
        }
    }
}