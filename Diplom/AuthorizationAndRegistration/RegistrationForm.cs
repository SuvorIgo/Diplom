using Diplom.libs.crypt;
using Diplom.libs.db;
using Diplom.libs.db.entities;
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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;

            checkBox1.Checked = false;

            checkBox2.Checked = false;

            button1.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (!checkBox1.Checked) button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text.Trim();
            var surname = textBox2.Text.Trim();
            var login = textBox3.Text.Trim();
            var password = textBox4.Text.Trim();
            var passwordRepeat = textBox5.Text.Trim();

            if (name != String.Empty)
            {
                if (surname != String.Empty)
                {
                    if (login != String.Empty)
                    {
                        if (password != String.Empty)
                        {
                            if (passwordRepeat != String.Empty)
                            {
                                if (password == passwordRepeat)
                                {
                                    password = CryptMD5.GetHash(password);

                                    using (var db = new ApplicationContextDB())
                                    {
                                        var candidate = db.Users.Where(p => p.Login == login);

                                        if (!candidate.IsNullOrEmpty())
                                        {
                                            MessageBox.Show("Пользователь с таким логином уже существует");
                                            return;
                                        }

                                        Users user;

                                        if (checkBox2.Checked == true)
                                        {
                                            user = new Users { Name = name, Surname = surname, Email = login, Login = login, Password = password, IsManager = true };
                                        }
                                        else
                                        {
                                            user = new Users { Name = name, Surname = surname, Email = login, Login = login, Password = password };
                                        }

                                        db.Users.Add(user);
                                        db.SaveChanges();

                                        var authForm = new AuthorizationForm() { Owner = new MainForm() };
                                        authForm.ShowDialog();
                                        this.Close();
                                    }

                                }
                                else
                                    MessageBox.Show("Пароли не совпадают");
                            }
                            else
                                MessageBox.Show("Повторите пароль");
                        }
                        else
                            MessageBox.Show("Введите пароль");
                    }
                    else
                        MessageBox.Show("Введите email");
                }
                else
                    MessageBox.Show("Введите фамилию");
            }
            else
                MessageBox.Show("Введите имя");
        }

    }
}
