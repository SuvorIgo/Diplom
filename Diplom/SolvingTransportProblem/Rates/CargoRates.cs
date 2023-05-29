using Diplom.libs.calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.SolvingTransportProblem.Rates
{
    public static class CargoRates
    {
        public static int GetFullSumOfCargo(int kilogramm)
        {
            int sum = 0;

            switch (kilogramm)
            {
                case < 10:
                    sum += Convert.ToInt32(Convert.ToDouble(kilogramm) * 30.30);
                    break;

                case < 100:
                    sum += Convert.ToInt32(Convert.ToDouble(kilogramm) * 20.20);
                    break;

                case < 1000:
                    sum += Convert.ToInt32(Convert.ToDouble(kilogramm) * 15.15);
                    break;

                case < 5000:
                    sum += Convert.ToInt32(Convert.ToDouble(kilogramm) * 10.10);
                    break;

                case < 10000:
                    sum += Convert.ToInt32(Convert.ToDouble(kilogramm) * 5.50);
                    break;

                default:
                    sum += kilogramm;
                    break;
            }

            return sum;
        }

        public static double GetSumOfCargo(int tonnage)
        {
            double sum = 0;

            var kg = tonnage * 1000;

            switch (kg)
            {
                case <= 10:
                    sum += 30.30;
                    break;

                case <= 100:
                    sum += 20.20;
                    break;

                case <= 1000:
                    sum += 15.15;
                    break;

                case <= 5000:
                    sum += 10.10;
                    break;

                case < 10000:
                    sum += 5.50;
                    break;

                case >= 10000:
                    sum += 3.30;
                    break;

                default:
                    sum += tonnage;
                    break;
            }

            return sum;
        }
    }
}
