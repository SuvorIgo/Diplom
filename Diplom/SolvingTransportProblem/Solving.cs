using Diplom.libs.db;
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
            public int Value { get; set; }
            public static int FindMinElement(int a, int b)
            {
                if (a > b) return b;
                if (a == b) { return a; }
                else return a;
            }

            public static int SetCountA()
            {
                using (var db = new ApplicationContextDB())
                {
                    return db.Storages.Count();
                }
            }

            public static int[] SetArrayA(int n)
            {
                var a = new int[n];

                using (var db = new ApplicationContextDB())
                {
                    var products = db.Products.FromSqlRaw("Select * From Products").ToList();

                    for (var i = 0; i < products.Count; i++)
                    {
                        a[i] = products[i].Volume;
                    }

                    return a;
                }
            }

            public static int SetCountB()
            {
                using (var db = new ApplicationContextDB())
                {
                    return db.Orders.Count();
                }
            }

            public static int[] SetArrayB(int m)
            {
                var b = new int[m];

                using (var db = new ApplicationContextDB())
                {
                    var orders = db.Orders.FromSqlRaw("Select * From Orders").ToList();

                    for (var i = 0; i < orders.Count; i++)
                    {
                        b[i] = orders[i].Tonnage;
                    }

                    return b;
                }
            }

            public static List<string> Result()
            {
                string returnString = String.Empty;
                var returnArray = new List<string>(){};

                int i = 0;
                int j = 0;
                int n;

                n = SetCountA();

                int m = SetCountB();


                Element[,] C = new Element[n, m];

                var a = SetArrayA(n);

                var b = SetArrayB(m);

                C[0, 0].Value = 2383;
                C[0, 1].Value = 1112;

                for (int l = 0; l < n; l++)
                {
                    returnArray.Add(C[0, l].Value.ToString());
                }

                returnArray.Add(a[0].ToString());

                C[1, 0].Value = 4500;
                C[1, 1].Value = 2410;

                for (int l = 0; l < n; l++)
                {
                    returnArray.Add(C[1, l].Value.ToString());
                }

                returnArray.Add(a[1].ToString());

                for (int l = 0; l < b.Length; l++)
                {
                    returnArray.Add(b[l].ToString());
                }

                /*Console.WriteLine("Введите C[i][j]");
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        Console.Write("a[{0},{1}] = ", i, j);
                        C[i, j].Value = Convert.ToInt32(Console.ReadLine());
                    }
                }*/

                i = j = 0;

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

                //выводим массив на экран
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        if (C[i, j].Delivery != 0)
                        {
                            returnString += $"({C[i, j].Delivery})";
                        }
                        else
                            returnString += "====";
                    }
                    Console.WriteLine();
                }

                //считаем функцию
                int ResultFunction = 0;
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        ResultFunction += (C[i, j].Value * C[i, j].Delivery);
                        if (C[i, j].Delivery != 0)
                            returnString += $"B{j + 1} - {(C[i, j].Value * C[i, j].Delivery)}";
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

            public static List<string> ResultSum()
            {
                string returnString = String.Empty;
                var returnArray = new List<string>() { };

                int i = 0;
                int j = 0;
                int n;

                n = SetCountA();

                int m = SetCountB();


                Element[,] C = new Element[n, m];

                var a = SetArrayA(n);

                var b = SetArrayB(m);

                C[0, 0].Value = 2383;
                C[0, 1].Value = 1112;
                C[1, 0].Value = 4500;
                C[1, 1].Value = 2410;

                /*Console.WriteLine("Введите C[i][j]");
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        Console.Write("a[{0},{1}] = ", i, j);
                        C[i, j].Value = Convert.ToInt32(Console.ReadLine());
                    }
                }*/

                i = j = 0;

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

                //выводим массив на экран
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        if (C[i, j].Delivery != 0)
                        {
                            returnString += $"({C[i, j].Delivery})";
                            returnArray.Add(C[i, j].Delivery.ToString());
                        }
                        else
                        {
                            returnString += "====";
                            returnArray.Add(0.ToString());
                        }
                            
                       
                    }
                }

                //считаем функцию
                int ResultFunction = 0;
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        ResultFunction += (C[i, j].Value * C[i, j].Delivery);
                        if (C[i, j].Delivery != 0)
                            returnArray.Add($"B{j + 1} - {(C[i, j].Value * C[i, j].Delivery)}");
                        else
                            continue;
                    }
                }
                returnArray.Add($"\nРезультат = {ResultFunction}");
                i = 0;
                j = 0;
                int[] u = new int[n];
                int[] v = new int[m];

                return returnArray;
            }
        }
    }
}
