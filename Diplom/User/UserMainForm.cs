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
        public bool IsAuthorization { get; set; }
        public int IdUser { get; set; }

        public UserMainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void UserMainForm_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
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
                }

                var categories = db.Categories.FromSqlRaw("SELECT * FROM Categories").ToList();

                comboBox1.DataSource = categories;

                var products = db.Products.FromSqlRaw("SELECT * FROM Products").ToList();

                comboBox2.DataSource = products;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
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
            var selectItemName = comboBox1.SelectedItem.ToString();

            using (var db = new ApplicationContextDB())
            {
                var products = db.Products.Where(p => p.Categories!.Name == selectItemName).ToList();

                comboBox2.DataSource = products;
                comboBox2.Update();
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
                                    var userFromOrder = db.Users.Where(p => p.Users!.UserId == IdUser);
                                    var productsFromOrder = db.Products.Where(p => p.Name == productName);

                                    Orders order = new Orders
                                    {
                                        OrderId = db.Orders.OrderByDescending(p => p.OrderId).FirstOrDefault().OrderId + 1,
                                        Tonnage = Convert.ToInt32(tonnage),
                                        NameCompany = nameCompany,
                                        NumberPhone = numberPhone,
                                        PointReception = address,
                                        Progress = "На рассмотрении",
                                        Users = userFromOrder,
                                        Products = productsFromOrder
                                    };

                                    db.Orders.Add(order);

                                    db.SaveChanges();

                                    dataGridView1.Update();
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
    }
}
