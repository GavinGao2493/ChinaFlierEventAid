using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVersion
{
    internal class HaversineDistance
    {
        private const double EarthRadius = 6371; // Earth radius in kilometers
        public static double CalcDistance(double lat1, double lon1, double lat2, double lon2)
        {
            // Convert latitude and longitude from degrees to radians
            lat1 = ConvertDegreesToRadians(lat1);
            lon1 = ConvertDegreesToRadians(lon1);
            lat2 = ConvertDegreesToRadians(lat2);
            lon2 = ConvertDegreesToRadians(lon2);

            // Calculate the differences
            double dLat = lat2 - lat1;
            double dLon = lon2 - lon1;

            // Haversine formula
            double a = Math.Pow(Math.Sin(dLat / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dLon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // Calculate the distance
            double distance = EarthRadius * c;

            return distance;
        }
        private static double ConvertDegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}
