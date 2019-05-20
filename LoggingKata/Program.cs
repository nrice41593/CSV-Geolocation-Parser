using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            if (lines.Length == 0)
            {
                logger.LogError("no lines found");
            }
            else if (lines.Length == 1)
            {
                logger.LogError("only 1 line found");
            }

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;

            GeoCoordinate corA = new GeoCoordinate();
            GeoCoordinate corB = new GeoCoordinate();
            double longestDistance = 0;

            foreach (var locA in locations)
            {
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                foreach (var locB in locations)
                {
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;
                    
                    if (corA.GetDistanceTo(corB) > longestDistance)
                    {
                        longestDistance = corA.GetDistanceTo(corB);
                        tacoBell1 = locA;
                        tacoBell2 = locB;
                    }

                }

            }
            Console.WriteLine($"{tacoBell1.Name} {tacoBell2.Name}");
        }
    }
}