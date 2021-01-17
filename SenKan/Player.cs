using System.Collections.Generic;

namespace SenKan
{
    public class Player
    { 
        public int GameId { get; set; }
        public List<Ship> Ships { get; set; }
        public string Name { get; set; }

        public Player(int gameId, List<Ship> ships, string name)
        {
            GameId = gameId;
            Ships = ships;
            Name = name;

        }
    }
}