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
            var name = dataGridView1.CurrentCell.Value.ToString();

            using (var db = new ApplicationContextDB())
            {
                var transportId = db.Transports.Where(p => p.Name == name).FirstOrDefault().TransportId;

                var driversId = db.TransportsDrivers.Where(p => p.Transports!.TransportId == transportId).ToList();

                List<Drivers> drivers = new List<Drivers>();

                for (int i = 0; i < drivers.Count; i++)
                {
                    drivers.Add(db.Drivers.Where(p => p.DriverId == driversId[i].Transports!.TransportId).FirstOrDefault());
                }

                dataGridView2.DataSource = drivers;

            }
        }
    }
}
