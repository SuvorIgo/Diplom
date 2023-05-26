using Diplom.libs.db;
using Diplom.SolvingTransportProblem;
using Microsoft.EntityFrameworkCore;
using System;
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

            var categories = db.Categories.FromSqlRaw("SELECT * FROM Categories").ToList();

            comboBox1.DataSource = categories;

            var products = db.Products.FromSqlRaw("SELECT * FROM Products").ToList();

            comboBox2.DataSource = products;
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
            var list = Solving.Element.Result();

            panel2.Visible = true;
            panel3.Visible = true;

            //dataGridView2 = Solving.Element.Result();
           

            dataGridView2.ColumnCount = 3;
            dataGridView2.RowCount = 3;

            dataGridView2.Columns[0].Name = "B1";
            dataGridView2.Columns[1].Name = "B2";

            dataGridView2.Rows[0].Cells[0].Value = list[0];
            dataGridView2.Rows[0].Cells[1].Value = list[1];
            dataGridView2.Rows[0].Cells[2].Value = list[2];

            dataGridView2.Rows[1].Cells[0].Value = list[3];
            dataGridView2.Rows[1].Cells[1].Value = list[4];
            dataGridView2.Rows[1].Cells[2].Value = list[5];

            dataGridView2.Rows[2].Cells[0].Value = list[6];
            dataGridView2.Rows[2].Cells[1].Value = list[7];

            dataGridView2.Update();

            var listTwo = Solving.Element.ResultSum();

            dataGridView3.ColumnCount = 2;
            dataGridView3.RowCount = 2;

            dataGridView3.Rows[0].Cells[0].Value = listTwo[0];
            dataGridView3.Rows[0].Cells[1].Value = listTwo[1];
            dataGridView3.Rows[1].Cells[0].Value = listTwo[2];
            dataGridView3.Rows[1].Cells[1].Value = listTwo[3];

            dataGridView3.Columns[0].Name = "B1";
            dataGridView3.Columns[1].Name = "B2";

            textBox1.Text += $"{listTwo[4]} ₽\r\n";
            textBox1.Text += $"{listTwo[5]} ₽\r\n";
            textBox1.Text += $"{listTwo[6]} ₽\r\n";
        }
    }
}
