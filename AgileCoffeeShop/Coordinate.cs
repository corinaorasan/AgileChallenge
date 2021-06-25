using System;

namespace AgileCoffeeShop
{
    public class Coordinate
    {
        public double XCoordinate
        {
            get; private set;
        }

        public double YCoordinate
        {
            get; private set;
        }    

        public Coordinate (double xCoordinate, double yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }
    }
}
