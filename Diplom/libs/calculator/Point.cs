using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Diplom.libs.calculator
{
    static class Point
    {
        public static double[] GetPointsArrayFromCity(string city)
        {
            string response = new StreamReader(WebRequest.Create($"https://geocode-maps.yandex.ru/1.x/?apikey=0c517217-773c-4be4-b617-95f1203e066b&geocode={city}&format=json&results=1").GetResponse().GetResponseStream()).ReadToEnd();

            dynamic json = JsonConvert.DeserializeObject(response);

            string[] points = (json.response.GeoObjectCollection.featureMember[0].GeoObject.Point.pos).ToString().Split(' ');

            List<double> result = new List<double>();

            foreach(var item in points)
            {
                result.Add(Convert.ToDouble(item.Replace('.', ',')));
            }

            return result.ToArray();
        }
    }
}
