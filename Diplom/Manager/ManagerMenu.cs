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
    public partial class ManagerMenu : Form
    {
        public bool IsAuthorization { get; set; }
        public int IdUser { get; set; }

        public ManagerMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var manageFrom = new ManagerMainForm();
            manageFrom.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var mainMenu = new MainForm();
            mainMenu.Show();
            this.Close();
        }

        private void ManagerMenu_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var categoriesProductsForm = new ManagerInfoCategoriesProductsForm();
            categoriesProductsForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var driversTransportsForm = new ManagerInfoDriversTransportsForm();
            driversTransportsForm.Show();
            this.Close();
        }
    }
}
