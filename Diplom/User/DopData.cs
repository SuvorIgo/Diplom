using Diplom.Properties;
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
    public partial class DopData : Form
    {
        public string ImageTransport { get; set; }
        public string ModelTransport { get; set; }
        public string BrandTransport { get; set; }
        public string LoadCapacityTransport { get; set; }
        public string FIODriver { get; set; }
        public string NameProduct { get; set; }
        public string DepartureAddress { get; set; }

        public DopData()
        {
            InitializeComponent();
        }

        private void DopData_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources._5516_МАЗ_20000;

            label1.Text = ModelTransport;
            label3.Text = BrandTransport;
            label5.Text = LoadCapacityTransport;
            label7.Text = FIODriver;
            label9.Text = NameProduct;
            label11.Text = DepartureAddress;

            label1.Visible = true;
            label3.Visible = true;
            label5.Visible = true;
            label7.Visible = true;
            label9.Visible = true;
            label11.Visible = true;
        }
    }
}
