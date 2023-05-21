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

            button1.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (!checkBox1.Checked) button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var surname = textBox2.Text;
            var login = textBox3.Text;
            var password = textBox4.Text;
            var passwordRepeat = textBox5.Text;

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

                                    /*try
                                    {
                                        using (SqlConnection conn = DataBase.CreateConnect())
                                        {
                                            conn.Open();

                                            string getUserByLogin = $"SELECT * FROM Users WHERE login = '{login}'";

                                            SqlCommand commandGetUserByLogin = new SqlCommand(getUserByLogin, conn);

                                            var isTrueReg = commandGetUserByLogin.ExecuteNonQuery().ToString();

                                            if (true)
                                            {
                                                MessageBox.Show("Пользователь с таким email уже зарегистрирован");
                                                login = String.Empty;
                                            }
                                            else
                                            {
                                                string sqlCommand = $"INSERT INTO Users (name, surname, login, password) VALUES ('{name}', '{surname}', '{login}', '{password}')";

                                                SqlCommand commandReg = new SqlCommand(sqlCommand, conn);

                                                Console.WriteLine(commandReg.ExecuteNonQuery());

                                                this.Close();
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.Write(ex);
                                    }*/

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
