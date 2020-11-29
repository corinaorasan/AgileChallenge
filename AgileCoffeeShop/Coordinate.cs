using System;

namespace AgileCoffeeShop
{
    public class Coordinate
    {
        #region Members
        private double _xCoordinate;
        private double _yCoordinate;
        #endregion

        public double XCoordinate
        {
            get
            {
                return _xCoordinate;
            }
            set
            {
                if(value >=-180 && value <= 180)
                {
                    _xCoordinate = value;
                }
                else
                {
                    Console.WriteLine("Invalid value for x coordinate. Program will exit.\nPress any key to continue...");
                    Console.ReadKey();
                    Environment.Exit(-1);
                }
            }
        }

        public double YCoordinate
        {
            get
            {
                return _yCoordinate;
            }
            set
            {
                if (value >= -90 && value <= 90)
                {
                    _yCoordinate = value;
                }
                else
                {
                    Console.WriteLine("Invalid value for y coordinate. Program will exit.\n Press any key to continue...");
                    Console.ReadKey();
                    Environment.Exit(-1);
                } 
            }
        }    

        public Coordinate ()
        {
            XCoordinate = 0;
            YCoordinate = 0;
        }
    }
}
