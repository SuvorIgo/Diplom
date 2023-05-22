using Diplom.libs.crypt;
using Diplom.libs.db;
using Diplom.libs.db.entities;
using Diplom.Properties;
using Diplom.User;
using Diplom.Manager;
using Diplom.Admin;
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
                        {
                            var isAuthorization = true;

                            foreach (Users user in candidate)
                            {
                                if (!CryptMD5.EqualsHashes(user.Password, CryptMD5.GetHash(password)))
                                {
                                    MessageBox.Show("Пароль или логин не верны");
                                    break;
                                }

                                if (user.IsManager == false && user.IsAdmin == false)
                                {
                                    var userForm = new UserMainForm();
                                    this.Close();
                                    userForm.Show();
                                    userForm.IsAuthorization = isAuthorization;
                                    this.Owner.Hide();
                                    break;
                                }
                                
                                if (user.IsManager == true && user.IsAdmin == false)
                                {
                                    var managerForm = new ManagerMainForm();
                                    this.Close();
                                    managerForm.Show();
                                    managerForm.IsAuthorization = isAuthorization;
                                    this.Owner.Hide();
                                    break;
                                }
                                
                                if (user.IsManager == false && user.IsAdmin == true)
                                {
                                    var adminForm = new AdminMainForm();
                                    this.Close();
                                    adminForm.Show();
                                    adminForm.IsAuthorization = isAuthorization;
                                    this.Owner.Hide();
                                    break;
                                }
                            }
                        }
                        else
                            MessageBox.Show("Пользователя с таким логином не существует");
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
