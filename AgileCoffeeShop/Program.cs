using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace AgileCoffeeShop
{
    class Program
    {
        #region Members
        private static User user;
        private static string urlFilePath;
        private static List<CoffeeShop> coffeeShops;
        private static Dictionary<string, double> distancesDictionary;
        #endregion
  
        private static void ReadDataFromUrlFile(string urlFilePath)
        {
            WebClient client = new WebClient();
            try
            {
                Stream stream = client.OpenRead(urlFilePath);
                StreamReader reader = new StreamReader(stream);
                string line = string.Empty;

                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    string[] splitLine = line.Split(',');
                    CoffeeShop coffeeShop = new CoffeeShop();
                    coffeeShop.Name = splitLine[0];
                    ValidateCoordinate(splitLine[1]);
                    coffeeShop.Coordinate.YCoordinate = Convert.ToDouble(splitLine[1]);
                    ValidateCoordinate(splitLine[2]);
                    coffeeShop.Coordinate.XCoordinate = Convert.ToDouble(splitLine[2]);
                    coffeeShops.Add(coffeeShop);
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine("Invalid URL." + exception.Message + "Program will exit.\n Press any key to continue...");
                Console.ReadKey();
            }
        }

        public static void ValidateCoordinate (string coordinate)
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
            }
        }
        private static void ValidateUrl(string url) 
        {
            bool result = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if(result==true)
            {
                if(!url.Contains("raw.githubusercontent.com"))
                {
                    result = false;
                }
            }
            if(result==false)
            {
                Console.WriteLine("Invalid URL. Program will exit.\n Press any key to continue...");
                Console.ReadKey();
            }
        }
        private static void Init()
        {
            user = new User();
            urlFilePath = string.Empty;
            coffeeShops = new List<CoffeeShop>();
            distancesDictionary = new Dictionary<string, double>();
        }
        public static double CalculateDistance(Coordinate A, Coordinate B)
        {
            var distance = Math.Round(Math.Sqrt(Math.Pow((A.XCoordinate - B.XCoordinate), 2) + Math.Pow((A.YCoordinate - B.YCoordinate), 2)), 4);
            return distance;
        }
        private static void CreateDistancesDictionary()
        {
            foreach (CoffeeShop coffeeShop in coffeeShops)
            {
                var distance = CalculateDistance(user.Coordinate, coffeeShop.Coordinate);
                distancesDictionary.Add(coffeeShop.Name, distance);                
            }
            distancesDictionary = distancesDictionary.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        private static void DisplayTheClosestCoffeeShops()
        {
            int counter = 0;

            foreach (KeyValuePair<string, double> kvp in distancesDictionary)
            {
                if (counter < 3)
                {
                    Console.WriteLine(kvp.Key + "," + kvp.Value);                 
                    counter++;
                }
            }
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Init();
            ValidateCoordinate(args[0]);
            user.Coordinate.XCoordinate = Convert.ToDouble(args[0]);
            ValidateCoordinate(args[1]);
            user.Coordinate.YCoordinate = Convert.ToDouble(args[1]);
            ValidateUrl(args[2]);
            urlFilePath = args[2];
            ReadDataFromUrlFile(urlFilePath);
            CreateDistancesDictionary();
            DisplayTheClosestCoffeeShops();

        }
    }
}
