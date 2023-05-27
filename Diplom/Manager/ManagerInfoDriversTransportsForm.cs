using Diplom.libs.db;
using Diplom.libs.db.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom.Manager
{
    public partial class ManagerInfoDriversTransportsForm : Form
    {
        public ManagerInfoDriversTransportsForm()
        {
            InitializeComponent();
        }

        private void ManagerInfoDriversTransportsForm_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;

            using (var db = new ApplicationContextDB())
            {
                var transports = db.Transports.FromSqlRaw("SELECT * FROM Transports").ToList();

                dataGridView1.DataSource = transports;

                var drivers = db.Drivers.FromSqlRaw("SELECT * FROM Drivers").ToList();

                dataGridView2.DataSource = drivers;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select File";
            openFileDialog.InitialDirectory = @"C:\Diplom\images";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                button2.Text = "Изображение выбрано";
            }
            else
                return;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var nameModel = textBox1.Text.Trim();
            var nameBrend = textBox2.Text.Trim();
            int? yearProd = dateTimePicker1.Value.Year;
            var capacity = comboBox1.SelectedItem.ToString().Split(' ')[0];

            if (nameModel != String.Empty)
            {
                if (nameBrend != String.Empty)
                {
                    if (yearProd != null)
                    {
                        if (capacity != String.Empty)
                        {
                            using (var db = new ApplicationContextDB())
                            {
                                var transport = new Transports { Name = nameModel, Brand = nameBrend, YearProd = (int)yearProd, LoadCapacity = Convert.ToInt32(capacity) * 1000 };

                                db.Transports.Add(transport);
                                db.SaveChanges();

                                var transports = db.Transports.FromSqlRaw("SELECT * FROM Transports").ToList();

                                dataGridView1.DataSource = transports;

                                panel1.Visible = false;
                            }
                        }
                        else
                            MessageBox.Show("Выберите грузоподъемность машины");
                    }
                    else
                        MessageBox.Show("Выберите год производства");
                }
                else
                    MessageBox.Show("Введите наименование производителя");
            }
            else
                MessageBox.Show("Введите наименование модели транспорта");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;

            for (int i = 1; i < 101; i++)
            {
                comboBox2.Items.Add(i);
            }

            using (var db = new ApplicationContextDB())
            {
                var transports = db.Transports.FromSqlRaw("SELECT * FROM Transports").ToList();

                foreach (var transport in transports)
                {
                    comboBox3.Items.Add($"{transport.Name} {transport.Brand} - {transport.LoadCapacity}");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
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

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            using (var db = new ApplicationContextDB())
            {
                db.SaveChanges();

                MessageBox.Show("Данные сохранены");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var n = Convert.ToInt32(dataGridView1.CurrentRow.Selected);

            var nameModel = dataGridView1.Rows[n].Cells[0].Value.ToString();
            var nameBrend = dataGridView1.Rows[n].Cells[1].Value.ToString();
            var capacity = dataGridView1.Rows[n].Cells[2].Value.ToString();

            using (var db = new ApplicationContextDB())
            {
                var transport = db.Transports.Where(p => p.Name == nameModel &&
                                                         p.Brand == nameBrend &&
                                                         p.LoadCapacity == Convert.ToInt32(capacity)).FirstOrDefault();

                db.Transports.Remove(transport);

                db.SaveChanges();

                var transports = db.Transports.FromSqlRaw("SELECT * FROM Transports").ToList();

                dataGridView1.DataSource = transports;
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            var n = Convert.ToInt32(dataGridView2.CurrentRow.Selected);

            var name = dataGridView2.Rows[n].Cells[0].Value.ToString();
            var surname = dataGridView2.Rows[n].Cells[1].Value.ToString();
            var patronymic = dataGridView2.Rows[n].Cells[2].Value.ToString();

            using (var db = new ApplicationContextDB())
            {
                var driver = db.Drivers.Where(p => p.Name == name &&
                                                   p.Surname == surname &&
                                                   p.Patronymic == patronymic).
                                                   FirstOrDefault();

                db.Drivers.Remove(driver);

                db.SaveChanges();

                var drivers = db.Drivers.FromSqlRaw("SELECT * FROM Drivers").ToList();

                dataGridView2.DataSource = drivers;
            }
        }
    }
}
