using Diplom.libs.crypt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom.AuthorizationAndRegistration
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var password = CryptMD5.GetHash(textBox2.Text);

            if (login != null)
            {
                if (password != null)
                {
                    this.Close();
                }
                else
                    MessageBox.Show("Введите пароль");
            }
            else
                MessageBox.Show("Введите логин");
        }
    }
}
