using Diplom.libs.db;
using Diplom.libs.db.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom.Manager
{
    public partial class ManagerInfoCategoriesProductsForm : Form
    {
        public ManagerInfoCategoriesProductsForm()
        {
            InitializeComponent();
        }

        private void ManagerInfoCategoriesProductsForm_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;

            using (var db = new ApplicationContextDB())
            {
                var categories = db.Categories.FromSqlRaw("SELECT * FROM Categories").ToList();

                dataGridView1.DataSource = categories;

                var products = db.Products.FromSqlRaw("SELECT * FROM Products").ToList();

                dataGridView2.DataSource = products;

                foreach (var category in categories)
                {
                    comboBox1.Items.Add(category.Name);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nameCategory = textBox1.Text.Trim();

            if (nameCategory != String.Empty)
            {
                using (var db = new ApplicationContextDB())
                { 
                    var category = new Categories { Name = nameCategory };

                    db.Categories.Add(category);
                    db.SaveChanges();

                    var categories = db.Categories.FromSqlRaw("SELECT * FROM Categories").ToList();

                    dataGridView1.DataSource = categories;

                    textBox1.Text = String.Empty;

                    panel1.Visible = false;
                }
            }
            else
                MessageBox.Show("Введите наименование категории");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var nameCategory = comboBox1.SelectedItem.ToString();
            var nameProduct = textBox2.Text.Trim();

            if (nameCategory != String.Empty)
            {
                if (nameProduct != String.Empty)
                {
                    using (var db = new ApplicationContextDB())
                    { 
                        var product = new Products { Name = nameProduct, Categories = db.Categories.Where(p => p.Name == nameCategory).FirstOrDefault() };

                        db.Products.Add(product);
                        db.SaveChanges();

                        var products = db.Products.FromSqlRaw("SELECT * FROM Products").ToList();
                        dataGridView2.DataSource = products;

                        comboBox1.SelectedValue = String.Empty;
                        textBox2.Text = String.Empty;

                        panel2.Visible = false;
                    }
                }
                else
                    MessageBox.Show("Укажите наименование продукта");
            }
            else
                MessageBox.Show("Выберите категорию");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var nameCategory = dataGridView1.SelectedCells[0].Value.ToString();

            using (var db = new ApplicationContextDB())
            {
                var products = db.Products.Where(p => p.Categories!.Name == nameCategory).ToList();

                dataGridView2.DataSource = products;

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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            using (var db = new ApplicationContextDB())
            {
                db.SaveChanges();

                MessageBox.Show("Данные сохранены");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int n;

            if (dataGridView1.CurrentRow.Selected)
            {
                n = Convert.ToInt32(dataGridView1.CurrentRow.Selected);

                var name = dataGridView1.Rows[n].Cells[0].Value.ToString();

                using (var db = new ApplicationContextDB())
                {
                    var category = db.Categories.Where(p => p.Name == name).FirstOrDefault();

                    db.Categories.Remove(category);

                    db.SaveChanges();

                    var categories = db.Categories.FromSqlRaw("SELECT * FROM Categories").ToList();

                    dataGridView1.DataSource = categories;
                }
            }

            else
            {
                n = Convert.ToInt32(dataGridView2.CurrentRow.Selected);

                var name = dataGridView2.Rows[n].Cells[0].Value.ToString();

                using (var db = new ApplicationContextDB())
                {
                    var product = db.Products.Where(p => p.Name == name).FirstOrDefault();

                    db.Products.Remove(product);

                    db.SaveChanges();

                    var products = db.Products.FromSqlRaw("SELECT * FROM Products").ToList();

                    dataGridView2.DataSource = products;
                }
            }
        }
    }
}
