namespace SenKan
{
    public class ShipRuleset
    {
        public int Id { get; set; }
        public int Length { get; set; }
        public int Amount { get; set; }

        public ShipRuleset(int id, int length, int amount)
        {
            Id = id;
            Length = length;
            Amount = amount;
        }
    }
}