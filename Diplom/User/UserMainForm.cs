using Diplom.libs.db;
using Diplom.libs.db.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom.User
{
    public partial class UserMainForm : Form
    {
        private string ImageTransport { get; set; }
        private string ModelTransport { get; set; }
        private string BrandTransport { get; set; }
        private string LoadCapacityTransport { get; set; }
        private string FIODriver { get; set; }
        private string NameProduct { get; set; }
        private string DepartureAddress { get; set; }

        public bool IsAuthorization { get; set; }
        public int IdUser { get; set; }

        public UserMainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }

        private void UserMainForm_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            label1.Visible = false;
            button2.Visible = true;
            dataGridView1.Visible = false;

            using (var db = new ApplicationContextDB())
            {
                var candidate = db.Users.FirstOrDefault(p => p.UserId == IdUser);

                var candidateListOrders = db.Orders.Where(p => p.Users!.UserId == candidate.UserId).ToList();

                if (candidateListOrders.IsNullOrEmpty())
                {
                    panel1.Visible = true;
                    label1.Visible = true;
                    button2.Visible = true;
                }

                else
                {
                    dataGridView1.DataSource = candidateListOrders;
                    dataGridView1.Visible = true;
                    panel4.Visible = true;
                }

                var categories = db.Categories.FromSqlRaw("SELECT * FROM Categories").ToList();

                foreach (var category in categories)
                {
                    comboBox1.Items.Add(category.Name);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            comboBox2.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            if (comboBox1.SelectedItem != null)
            {
                var categoryName = comboBox1.SelectedItem.ToString();

                using (var db = new ApplicationContextDB())
                {
                    var products = db.Products.Where(p => p.Categories!.Name == categoryName).ToList();

                    foreach (var product in products)
                    { 
                        comboBox2.Items.Add(product.Name);
                    }
                }

                comboBox2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var tonnage = textBox1.Text.Trim();
            var nameCompany = textBox2.Text.Trim();
            var numberPhone = textBox3.Text.Trim();
            var address = textBox4.Text.Trim();
            var productName = comboBox2.SelectedItem.ToString();

            if (tonnage != String.Empty)
            {
                if (nameCompany != String.Empty)
                {
                    if (numberPhone != String.Empty)
                    {
                        if (address != String.Empty)
                        {
                            if (productName != String.Empty)
                            {
                                using (var db = new ApplicationContextDB())
                                {
                                    Users userFromOrder = db.Users.Where(p => p.UserId == IdUser).FirstOrDefault();
                                    Products productsFromOrder = db.Products.Where(p => p.Name == productName).FirstOrDefault();

                                    Orders order = new Orders
                                    { 
                                        Tonnage = Convert.ToInt32(tonnage),
                                        NameCompany = nameCompany,
                                        NumberPhone = numberPhone,
                                        PointReception = address,
                                        Progress = "На рассмотрении",
                                        Users = userFromOrder,
                                        Products = productsFromOrder
                                    };

                                    productsFromOrder.Orders.Add(order);

                                    db.Products.Update(productsFromOrder);

                                    db.Orders.Add(order);

                                    db.SaveChanges();

                                    var orders = db.Orders.Where(p => p.Users!.UserId == IdUser).ToList();

                                    dataGridView1.DataSource = orders;

                                    textBox1.Text = String.Empty;
                                    textBox2.Text = String.Empty;
                                    textBox3.Text = String.Empty;
                                    textBox4.Text = String.Empty;
                                    comboBox1.SelectedItem = String.Empty;
                                    comboBox2.SelectedItem = String.Empty;

                                    comboBox2.Enabled = false;

                                    panel4.Visible = true;
                                    panel2.Visible = false;
                                    panel1.Visible = false;

                                    dataGridView1.Visible = true;
                                }
                            }
                            else
                                MessageBox.Show("Выберите наименование продукта");
                        }
                        else
                            MessageBox.Show("Введите адрес поставки");
                    }
                    else
                        MessageBox.Show("Введите Ваш номер телефона");
                }
                else
                    MessageBox.Show("Введите наименование компании");
            }
            else
                MessageBox.Show("Введите объем поставки в тоннах");

            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var n = Convert.ToInt32(dataGridView1.CurrentRow.Index);

            var nameCompany = dataGridView1.Rows[n].Cells[1].Value.ToString();
            var address = dataGridView1.Rows[n].Cells[3].Value.ToString();

            using (var db = new ApplicationContextDB())
            {
                var order = db.Orders.Where(p => p.NameCompany == nameCompany && p.PointReception == address).FirstOrDefault();

                db.Orders.Remove(order);

                db.SaveChanges();

                var orders = db.Orders.Where(p => p.Users!.UserId == IdUser).ToList();

                dataGridView1.DataSource = orders;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (var db = new ApplicationContextDB())
            { 
                db.SaveChanges();

                MessageBox.Show("Данные сохранены");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var n = Convert.ToInt32(dataGridView1.CurrentRow.Index);

            var tonnage = dataGridView1.Rows[n].Cells[0].Value.ToString();
            var nameCompany = dataGridView1.Rows[n].Cells[1].Value.ToString();
            var address = dataGridView1.Rows[n].Cells[3].Value.ToString();
            var numberPhone = dataGridView1.Rows[n].Cells[2].Value.ToString();

            using (var db = new ApplicationContextDB())
            {
                var currentOrder = db.Orders.Where(p => p.NameCompany == nameCompany &&
                                                   p.PointReception == address &&
                                                   p.NumberPhone == numberPhone &&
                                                   p.Tonnage == Convert.ToInt32(tonnage)).FirstOrDefault();

                label11.Text = currentOrder.Progress;

                var currentTransportation = db.Transportations.Where(p => p.Orders.OrderId == currentOrder.OrderId).FirstOrDefault();

                if (currentTransportation.DepartureDate == null && currentTransportation.ArrivalDate == null && currentTransportation.Cost == null)
                {
                    label22.Text = currentTransportation.Comment.ToString();

                    label22.MaximumSize = new Size(200, 0);

                    label22.Visible = true;

                    label16.Visible = false;
                    label17.Visible = false;
                    label18.Visible = false;
                    label19.Visible = false;

                    label14.Visible = false;
                    label10.Visible = false;
                    label13.Visible = false;
                    label15.Visible = false;
                }
                else
                {
                    label22.Visible = false;

                    label16.MaximumSize = new Size(90, 0);

                    label16.Visible = true;

                    label17.MaximumSize = new Size(90, 0);

                    label17.Visible = true;

                    label18.Visible = true;
                    label19.Visible = true;

                    label14.Visible = true;
                    label10.Visible = true;
                    label13.Visible = true;
                    label15.Visible = true;

                    label16.Text = currentTransportation.DepartureDate.Value.ToString("f");
                    label17.Text = currentTransportation.ArrivalDate.Value.ToString("f");
                    label18.Text = address;
                    label19.Text = currentTransportation.Cost.ToString() + " ₽";

                    label18.MaximumSize = new Size(146, 0);

                    var currentTransport = db.Transports.FromSqlRaw("SELECT t.* FROM Transports as t JOIN TransportsDrivers as td ON " +
                        $"t.transport_id = td.transport_id JOIN Transportations as tr ON " +
                        $"td.transportsDriver_id = tr.transportsDriver_id WHERE tr.transportation_id = {currentTransportation.TransportationId}").FirstOrDefault();

                    var currentDriver = db.Drivers.FromSqlRaw("SELECT d.* FROM Drivers as d JOIN TransportsDrivers as td ON " +
                        $"d.driver_id = td.driver_id JOIN Transports as t ON " +
                        $"td.transport_id = t.transport_id WHERE td.transport_id = {currentTransport.TransportId}").FirstOrDefault();

                    var currentProduct = db.Products.FromSqlRaw("SELECT p.* FROM Products as p JOIN Orders as o ON " +
                        $"p.product_id = o.product_id WHERE o.order_id = {currentOrder.OrderId}").FirstOrDefault();

                    var currentStorages = db.Storages.FromSqlRaw("SELECT s.* FROM Storages as s JOIN ProductsStorages as ps ON " +
                        $"s.storage_id = ps.storage_id WHERE ps.product_id = {currentProduct.ProductId}").FirstOrDefault();

                    ImageTransport = currentTransport.Photo;
                    ModelTransport = currentTransport.Name;
                    BrandTransport = currentTransport.Brand;
                    LoadCapacityTransport = (currentTransport.LoadCapacity / 1000).ToString() + " тонн";
                    FIODriver = currentDriver.Surname + " " + currentDriver.Name + " " + currentDriver.Patronymic;
                    NameProduct = currentProduct.Name;
                    DepartureAddress = currentStorages.Location;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var dopData = new DopData();

            dopData.ImageTransport = ImageTransport;
            dopData.ModelTransport = ModelTransport;
            dopData.BrandTransport = BrandTransport;
            dopData.LoadCapacityTransport = LoadCapacityTransport;
            dopData.FIODriver = FIODriver;
            dopData.NameProduct = NameProduct;
            dopData.DepartureAddress = DepartureAddress;

            dopData.ShowDialog();
        }
    }
}
