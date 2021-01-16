namespace SenKan
{
    public class ShipCoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsHit { get; set; }

        public ShipCoordinate(int x, int y)
        {
            X = x;
            Y = y;
            IsHit = false;
        }
    }
}