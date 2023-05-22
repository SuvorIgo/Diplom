using Diplom.libs.crypt;
using Diplom.libs.db;
using Diplom.libs.db.entities;
using Diplom.Properties;
using Diplom.User;
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
                    using (ApplicationContextDB db = new ApplicationContextDB())
                    {
                        var candidate = db.Users.Where(p => p.Login == login);

                        if (!candidate.IsNullOrEmpty())
                            MessageBox.Show("Пользователь с таким логином уже был зарегистрирован");
                        else
                        {
                            var isAuthorization = true;

                            foreach (Users user in candidate)
                            {
                                if (user.IsManager == false && user.IsAdmin == false)
                                {
                                    var userForm = new UserMainForm();
                                    userForm.Show();
                                    this.Close();
                                }
                                else if (user.IsManager == true && user.IsAdmin == false)
                                {
                                    var managerForm = new ManagerMainFrom();
                                    managerForm.Show();
                                    this.Close();
                                }
                                else 
                                {
                                    var adminForm = new AdminMainForm();
                                    adminForm.Show();
                                    this.Close();
                                }
                            }


                        }
                    }
                }
                else
                    MessageBox.Show("Введите пароль");
            }
            else
                MessageBox.Show("Введите логин");
        }
    }
}
