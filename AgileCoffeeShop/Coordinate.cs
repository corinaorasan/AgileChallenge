using System;

namespace AgileCoffeeShop
{
    public class Coordinate
    {
        private double _xCoordinate;
        private double _yCoordinate;
        public double XCoordinate
        {
            get; set;
        }

        public double YCoordinate
        {
            get; set;
        }    

        public Coordinate ()
        {
            XCoordinate = 0;
            YCoordinate = 0;
        }
    }
}
