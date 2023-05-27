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
            comboBox2.Items.Clear();

            using (var db = new ApplicationContextDB())
            {
                var products = db.Products.Where(p => p.Categories!.Name == selectItemName).ToList();

                foreach (var product in products)
                {
                    comboBox2.Items.Add(product.Name);
                }

                comboBox2.Update();
            }

            /*var products = db.Products.FromSqlRaw("SELECT Products.* FROM Products, " +
                    "Categories WHERE Products.category_id = Categories.category_id " +
                    "WHERE category_id = (SELECT name FROM Categories WHERE name = " + comboBox1.SelectedItem.ToString() + ")").Distinct().ToList();

            foreach (var product in products)
            {
                comboBox2.Items.Add(product.Name);
            }*/
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
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            var row = dataGridView1.CurrentCell.Value.ToString();

            dataGridView1.Rows.RemoveAt(rowIndex);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (var db = new ApplicationContextDB())
            { 
                db.SaveChanges();

                MessageBox.Show("Данные сохранены");
            }
        }
    }
}
