using Diplom.libs.db;
using Diplom.libs.db.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.SolvingTransportProblem
{
    public class Solving
    {
        public struct Element
        {
            public int Delivery { get; set; }
            public double Value { get; set; }
            public static int FindMinElement(int a, int b)
            {
                if (a > b) return b;
                if (a == b) { return a; }
                else return a;
            }

            public static int SetCountA(List<Storages> storages)
            {
                return storages.Count;
            }

            public static int[] SetArrayA(List<Storages> storages)
            {
                var a = new int[storages.Count];

                using (var db = new ApplicationContextDB())
                {
                    for (var i = 0; i < storages.Count; i++)
                    {
                        a[i] = Convert.ToInt32(db.ProductsStorages.Where(p => p.Storages!.StorageId == storages[i].StorageId).FirstOrDefault().Volume);
                    }

                    return a;
                }
            }

            public static int SetCountB(List<Orders> orders)
            {
                return orders.Count;
            }

            public static int[] SetArrayB(List<Orders> orders)
            {
                var b = new int[orders.Count];

                using (var db = new ApplicationContextDB())
                {
                    for (var i = 0; i < orders.Count; i++)
                    {
                        b[i] = orders[i].Tonnage;
                    }

                    return b;
                }
            }

            public static List<double> Result(int[] a, int[] b, double[] rates)
            {
                string returnString = String.Empty;
                var returnArray = new List<double>(){};

                int i = 0;
                int j = 0;

                int n = a.Length;

                int m = b.Length;


                Element[,] C = new Element[n, m];

                //for (var k = 0; k < rates.Length; k++)
                //{
                int countIter = 0;
                for (var s = 0; s < rates.Length / 2; s++)
                    {
                        for (var p = 0; p < rates.Length / 2; p++)
                        {
                            C[s, p].Value = rates[countIter];
                            countIter++;
                        }
                    }
                //}

                //i = j = 0;

                // действуем по алгоритму 
                // идём с северо-западного элемента 
                // если a[i] = 0 i++
                // если b[j] = 0 j++
                //  если a[i],b[j] = 0 то i++,j++;
                // доходим до последнего i , j

                //Оператор while выполняет оператор или блок операторов, пока определенное выражение не примет значение false.
                while (i < n && j < m)
                {
                    try
                    {
                        if (a[i] == 0) { i++; }
                        if (b[j] == 0) { j++; }
                        if (a[i] == 0 && b[j] == 0) { i++; j++; }
                        C[i, j].Delivery = Element.FindMinElement(a[i], b[j]);
                        a[i] -= C[i, j].Delivery;
                        b[j] -= C[i, j].Delivery;
                    }
                    catch { }
                }

                //считаем функцию
                double ResultFunction = 0;
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        ResultFunction += (C[i, j].Value * C[i, j].Delivery);
                        if (C[i, j].Delivery != 0)
                        {
                            returnString += $"B{j + 1} - {(C[i, j].Value * 1000 * C[i, j].Delivery)}";
                            returnArray.Add(C[i, j].Value * 1000 * C[i, j].Delivery);
                        }
                        else
                            continue;
                    }
                }
                returnString += $"\nРезультат = {ResultFunction}";
                i = 0;
                j = 0;
                int[] u = new int[n];
                int[] v = new int[m];

                return returnArray;
            }
        }
    }
}
