using Diplom.libs.calculator;
using Diplom.libs.db;
using Diplom.libs.db.entities;
using Diplom.SolvingTransportProblem;
using Diplom.SolvingTransportProblem.Rates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom.Manager
{
    public partial class ManagerMainForm : Form
    {
        public bool IsAuthorization { get; set; }
        public int IdUser { get; set; }

        public ManagerMainForm()
        {
            InitializeComponent();
        }

        private void ManagerMainForm_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;

            var products = db.Products.FromSqlRaw("SELECT * FROM Products").Distinct().ToList();

            foreach (var product in products)
            {
                comboBox1.Items.Add(product.Name);
            }

            var arrayStatus = new string[4] { "На рассмотрении", "В процессе", "Закрыта", "Отменено" };

            var i = 0;
            foreach (var status in arrayStatus)
            {
                comboBox2.Items.Add(arrayStatus[i]);
                i++;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private ApplicationContextDB db = new ApplicationContextDB();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.db.Orders.Load();

            this.ordersBindingSource.DataSource = db.Orders.Local.ToBindingList();
            
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.db?.Dispose();
            this.db = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var rowsData = dataGridView1.DataSource;

            var listOrders = new List<Orders>();

            foreach (var obj in (IEnumerable)rowsData)
            {
                Orders currentOrder = (Orders)obj;

                var pointOrder = currentOrder;

                listOrders.Add(pointOrder);
            }

            var nameCargo = comboBox1.SelectedItem.ToString();

            var listStorages = db.Storages.FromSqlRaw("SELECT s.* FROM Storages as s JOIN ProductsStorages as ps ON " +
                                                                "s.storage_id = ps.storage_id JOIN Products as p ON " + 
                                                                    $"ps.product_id = p.product_id WHERE p.name = '{nameCargo}'").ToList();

            /*var listDistanceRates = new List<double>();

            for (var i = 0; i < listOrders.Count; i++)
            {
                listDistanceRates.Add(DistanceRates.GetSumOfPoints(
                    Distance.GetDistanceBetweenTwoCities(
                        libs.calculator.Point.GetPointsArrayFromCity(listStorages[i].Location),
                        libs.calculator.Point.GetPointsArrayFromCity(listOrders[i].PointReception)
                        )
                    )
                );
            }*/

            int n = Solving.Element.SetCountA(listStorages);
            int m = Solving.Element.SetCountB(listOrders);

            var a = Solving.Element.SetArrayA(listStorages);
            var b = Solving.Element.SetArrayB(listOrders);

            List<double> rates = new List<double>();
            List<int> distancesList = new List<int>();

            //for (int i = 0; i < n * m; i++)
            //{
                for (var j = 0; j < listStorages.Count; j++)
                {
                    var currentStorage = listStorages[j];

                    for (var k = 0; k < listOrders.Count; k++)
                    {
                        double sum = 0d;

                        var currentOrder = listOrders[k];

                        var distance = Distance.GetDistanceBetweenTwoCities(
                            libs.calculator.Point.GetPointsArrayFromCity(currentStorage.Location),
                            libs.calculator.Point.GetPointsArrayFromCity(currentOrder.PointReception)
                        );

                        distancesList.Add(distance);

                        sum += DistanceRates.GetSumOfPoints(
                            distance
                        );

                        sum += CargoRates.GetSumOfCargo(currentOrder.Tonnage);

                        rates.Add(sum);

                        sum = 0d;
                    }
                }                
            //}

            var str = Solving.Element.Result(a, b, rates.ToArray());

            int i = 0;
            foreach (var order in listOrders)
            { 
                using (var db = new ApplicationContextDB())
                {
                    var idsProducts = db.Products.Where(p => p.Categories == db.Categories.Where(p => p.Name == "Скоропортящиеся").FirstOrDefault()).ToList();

                    if (idsProducts.Contains(db.Products.Where(p => p.Name == nameCargo).FirstOrDefault()))
                    {
                        if (distancesList[i] > 800)
                        {
                            order.Progress = "Отменено";
                            db.Orders.Update(order);

                            var skTransportation = new Transportations { Orders = db.Orders.Where(p => p.OrderId == order.OrderId).FirstOrDefault(), DepartureDate = null, Comment = "Извините, мы не можем доставить скоропортящуюся продукцию на данный адрес" };

                            db.Transportations.Add(skTransportation);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        order.Progress = "В процессе";
                        db.Orders.Update(order);

                        var transportation = new Transportations { Orders = db.Orders.Where(p => p.OrderId == order.OrderId).FirstOrDefault(), ArrivalDate = new DateTime(2023, 05, 31).Date, Cost = Convert.ToInt32(str[i]) };

                        db.Transportations.Add(transportation);
                        db.SaveChanges();
                    }
                }
                i++;
            }

            panel2.Visible = true;
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var nameProduct = comboBox1.SelectedItem.ToString();

            using (var db = new ApplicationContextDB())
            {
                List<Orders> currentOrders;

                if (nameProduct == String.Empty)
                    currentOrders = db.Orders.FromSqlRaw("SELECT * FROM Orders").ToList();
                else
                    currentOrders = db.Orders.Where(p => p.Products!.ProductId == (db.Products.Where(p => p.Name == nameProduct).FirstOrDefault().ProductId)).ToList();

                dataGridView1.Update();
                dataGridView1.DataSource = currentOrders;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var valueStatus = comboBox2.SelectedItem.ToString();

            using (var db = new ApplicationContextDB())
            {
                List<Orders> currentOrders;

                currentOrders = db.Orders.Where(p => p.Progress == valueStatus).ToList();

                dataGridView1.Update();
                dataGridView1.DataSource = currentOrders;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var managerMenu = new ManagerMenu();
            managerMenu.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }
    }
}
