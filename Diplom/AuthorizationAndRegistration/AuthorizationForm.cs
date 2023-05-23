﻿using Diplom.libs.crypt;
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
            var login = textBox1.Text.Trim();
            var password = textBox2.Text.Trim();

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
                                if (CryptMD5.EqualsHashes(user.Password, CryptMD5.GetHash(password)) == false)
                                {
                                    MessageBox.Show("Пароль или логин не верны");
                                    break;
                                }

                                if (user.IsManager == false && user.IsAdmin == false)
                                {
                                    var userForm = new UserMainForm();
                                    userForm.IsAuthorization = isAuthorization;
                                    userForm.IdUser = user.UserId;
                                    this.Close();
                                    userForm.Show();
                                    this.Owner.Hide();
                                    break;
                                }
                                
                                if (user.IsManager == true && user.IsAdmin == false)
                                {
                                    var managerForm = new ManagerMainForm();
                                    managerForm.IsAuthorization = isAuthorization;
                                    managerForm.IdUser = user.UserId;
                                    this.Close();
                                    managerForm.Show();
                                    this.Owner.Hide();
                                    break;
                                }
                                
                                if (user.IsManager == false && user.IsAdmin == true)
                                {
                                    var adminForm = new AdminMainForm();
                                    adminForm.IsAuthorization = isAuthorization;
                                    this.Close();
                                    adminForm.Show();
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
