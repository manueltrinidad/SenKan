using System.Collections.Generic;

namespace SenKan
{
    public class Player
    { 
        public int Id { get; set; }
        public List<Ship> Ships { get; set; }
        public string Name { get; set; }

        public Player(int id, List<Ship> ships, string name)
        {
            Id = id;
            Ships = ships;
            Name = name;

        }
    }
}