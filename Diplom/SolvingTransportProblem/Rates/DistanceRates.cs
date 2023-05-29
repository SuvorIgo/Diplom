using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.SolvingTransportProblem.Rates
{
    public static class DistanceRates
    {
       public static int GetFullSumOfPoints(int distance)
        {
            int sum = 0;

            switch (distance)
            {
                case < 100:
                    sum += Convert.ToInt32(Convert.ToDouble(distance) * 1.10);
                    break;

                case < 200:
                    sum += Convert.ToInt32(Convert.ToDouble(distance) * 2.20);
                    break;

                case < 500:
                    sum += Convert.ToInt32(Convert.ToDouble(distance) * 3.30);
                    break;

                case > 500:
                    sum += Convert.ToInt32(Convert.ToDouble(distance) * 4.40);
                    break;

                default:
                    sum += distance;
                    break;
            }

            return sum;
       }

        public static double GetSumOfPoints(int distance)
        {
            double sum = 0;

            switch (distance)
            {
                case < 100:
                    sum += 1.10;
                    break;

                case < 200:
                    sum += 2.20;
                    break;

                case < 500:
                    sum += 3.30;
                    break;

                case > 500:
                    sum += 4.40;
                    break;

                default:
                    sum += distance;
                    break;
            }

            return sum;
        }
    }
}
