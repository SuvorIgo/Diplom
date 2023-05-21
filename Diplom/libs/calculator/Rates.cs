using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.libs.calculator
{
    static class Rates
    {
        private static double GetSum(int kilometrazh)
        {
            double sumOfCargo = 10.10 * 5000;

            double sumOfDistance = 0;

            switch (kilometrazh) 
            {
                case < 100:
                    sumOfDistance += 1.10 * kilometrazh;
                    break;

                case < 200:
                    sumOfDistance += 2.20 * kilometrazh;
                    break;

                case < 500:
                    sumOfDistance += 3.30 * kilometrazh;
                    break;

                case > 500:
                    sumOfDistance += 4.40 * kilometrazh;
                    break;

                default:
                    sumOfDistance += kilometrazh;
                    break;
            }

            return sumOfCargo + sumOfDistance;
        }

        public static double GetSumOfDistanceAndCargo(int kilometrazh)
        {
            return GetSum(kilometrazh);
        }
    }
}
