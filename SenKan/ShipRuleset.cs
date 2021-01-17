namespace SenKan
{
    public class ShipRuleset
    {
        public int Length { get; set; }
        public int Amount { get; set; }

        public ShipRuleset(int length, int amount)
        {
            Length = length;
            Amount = amount;
        }
    }
}