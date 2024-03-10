using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVersion
{
    public class CoordinationTransform
    {
        public static (double Lat, double Lng) FromEuroscopeToDouble(string lat, string lng)
        {
            if (lat.Length != 14 || lng.Length != 14)
                return (0, 0);
            double outputLat = 1, outputLng = 1;
            if (lat[0] == 'S')
                outputLat = -1;
            if (lng[0] == 'W')
                outputLng = -1;
            outputLat *= int.Parse(lat.Substring(1, 3)) + int.Parse(lat.Substring(5, 2)) / 60.0
                + int.Parse(lat.Substring(8, 2)) / 3600.0;
            outputLng *= int.Parse(lng.Substring(1, 3)) + int.Parse(lng.Substring(5, 2)) / 60.0
                + int.Parse(lng.Substring(8, 2)) / 3600.0;
            return (outputLat, outputLng);
        }
    }
}
