using Diplom.libs.db;
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
            label1.Visible = false;
            button2.Visible = false;
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
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
