namespace SenKan
{
    public class Turn
    {
        public int PlayerId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Turn(int playerId, int x, int y)
        {
            PlayerId = playerId;
            X = x;
            Y = y;
        }
    }
}