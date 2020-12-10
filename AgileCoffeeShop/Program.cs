using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace AgileCoffeeShop
{
    class Program
    {
        private static User user;
        private static string urlFilePath;
        private static List<CoffeeShop> coffeeShops;
        private static Dictionary<string, double> distancesDictionary;
        private const int XMAX = 180;
        private const int YMAX = 90;
       
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
                    ValidateCoordinate(splitLine[1], YMAX);
                    ValidateCoordinate(splitLine[2], XMAX);
                    CoffeeShop coffeeShop = new CoffeeShop(splitLine[0], new Coordinate(Convert.ToDouble(splitLine[2]), Convert.ToDouble(splitLine[1])));
                    coffeeShops.Add(coffeeShop);
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine("Invalid URL." + exception.Message + "Program will exit.\n Press any key to continue...");
                Console.ReadKey();
            }
        }

        public static void ValidateCoordinate (string coordinate, int limitValue)
        {
            double temp = 0;
            try
            {
                temp = Convert.ToDouble(coordinate);
                if(!(temp>=-limitValue && temp <= limitValue))
                {
                    if (limitValue == XMAX)
                    {
                        Console.WriteLine("Invalid value for x coordinate. Program will exit.\nPress any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Invalid value for y coordinate. Program will exit.\nPress any key to continue...");
                        Console.ReadKey();
                    }
                }
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
            if(result)
            {
                if(!url.Contains("raw.githubusercontent.com"))
                {
                    result = false;
                }
            }
            if(!result)
            {
                Console.WriteLine("Invalid URL. Program will exit.\n Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static void Init()
        {
            urlFilePath = string.Empty;
            coffeeShops = new List<CoffeeShop>();
            distancesDictionary = new Dictionary<string, double>();
        }

        public static double CalculateDistance(Coordinate A, Coordinate B)
        {
            var x2 = (Math.Pow((A.XCoordinate - B.XCoordinate), 2));
            var y2 = (Math.Pow((A.YCoordinate - B.YCoordinate), 2));
            var distance = Math.Round(Math.Sqrt(x2 + y2), 4);
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
            const int SHOPS_TO_DISPLAY = 3;

            foreach (KeyValuePair<string, double> kvp in distancesDictionary)
            {
                if (counter < SHOPS_TO_DISPLAY)
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
            ValidateCoordinate(args[0], XMAX);
            ValidateCoordinate(args[1], YMAX);
            user = new User(new Coordinate(Convert.ToDouble(args[0]), Convert.ToDouble(args[1])));
            ValidateUrl(args[2]);
            urlFilePath = args[2];
            ReadDataFromUrlFile(urlFilePath);
            CreateDistancesDictionary();
            DisplayTheClosestCoffeeShops();
        }
    }
}
