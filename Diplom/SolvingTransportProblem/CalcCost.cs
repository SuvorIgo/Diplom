using Diplom.libs.calculator;
using Diplom.SolvingTransportProblem.Rates;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.SolvingTransportProblem
{
    public static class CalcCost
    {
        public static int Sum { get; set; }

        public static void CalcSumOfDistance(string addressA, string addressB)
        {
            var arrayPointsA = libs.calculator.Point.GetPointsArrayFromCity(addressA);
            var arrayPointsB = libs.calculator.Point.GetPointsArrayFromCity(addressB);

            int distance = Distance.GetDistanceBetweenTwoCities(arrayPointsA, arrayPointsB);

            int sumOfDistance = DistanceRates.GetFullSumOfPoints(distance);

            int sumOfCargo = DistanceRates.GetFullSumOfPoints(distance);
        }
    }
}
