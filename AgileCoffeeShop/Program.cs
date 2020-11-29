using System;

namespace AgileCoffeeShop
{
    class Program
    {
        #region Members
        private static User user;
        private static string urlFilePath;
        #endregion
        private static void ValidateCoordinate (string coordinate)
        {
            double temp = 0;
            try
            {
                temp = Convert.ToDouble(coordinate);
            }
            catch(Exception exception)
            {
                Console.WriteLine("Invalid coordinates." + exception.Message + "Program will exit.\nPress any key to continue...");
                Console.ReadKey();
                Environment.Exit(-1);
            }
        }
        private static void Init()
        {
            user = new User();
            urlFilePath = string.Empty;
        }

        static void Main(string[] args)
        {
            Init();
            ValidateCoordinate(args[0]);
            user.Coordinate.XCoordinate = Convert.ToDouble(args[0]);
            ValidateCoordinate(args[1]);
            user.Coordinate.YCoordinate = Convert.ToDouble(args[1]);

        }

    }
}
