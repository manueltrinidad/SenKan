using System.Collections.Generic;

namespace SenKan
{
    public class Ship
    {
        public bool IsUp { get; set; }
        public List<ShipCoordinate> Coordinates { get; set; }

        public Ship(int xStart, int yStart, int xEnd, int yEnd)
        {
            var coordinates = new List<ShipCoordinate>();
            int length;
            // If the ship is horizontal or vertical
            if (xStart == xEnd)
            {
                if (yEnd < yStart)
                {
                    var yTemp = yStart;
                    yStart = yEnd;
                    yEnd = yTemp;
                }

                length = yEnd - yStart + 1;

                var yBuffer = yStart;
                for (var i = 0; i < length; i++)
                {
                    var coordinate = new ShipCoordinate(xStart, yBuffer);
                    coordinates.Add(coordinate);
                    yBuffer++;
                }
            }
            else
            {
                if (xEnd < xStart)
                {
                    var xTemp = xStart;
                    xStart = xEnd;
                    xEnd = xTemp;
                }

                length = xEnd - xStart + 1;

                var xBuffer = xStart;
                for (var i = 0; i < length; i++)
                {
                    var coordinate = new ShipCoordinate(xBuffer, yStart);
                    coordinates.Add(coordinate);
                    xBuffer++;
                }
            }
            Coordinates = coordinates;
            IsUp = true;
        }
    }
}