using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.libs.calculator
{
    static class Distance
    {
        public static int GetDistanceBetweenTwoCities(double[] cityDeparture, double[] cityArrival)
        {
            //L = R * Math.acos(Math.sin(lat1) * Math.sin(lat2) + Math.cos(lat1) * Math.cos(lat2) * Math.cos(long1 - long2));

            var distance = 6371 * Math.Acos(Math.Sin(cityDeparture[0] * Math.PI / 180) * Math.Sin(cityArrival[0] * Math.PI / 180) +
                    Math.Cos(cityDeparture[0] * Math.PI / 180) * Math.Cos(cityArrival[0] * Math.PI / 180) * 
                    Math.Cos(cityDeparture[1] * Math.PI / 180 - cityArrival[1] * Math.PI / 180));

            return (int)(distance - distance * 0.1);
        }
    }
}
