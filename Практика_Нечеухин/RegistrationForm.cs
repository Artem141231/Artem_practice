using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практика_Нечеухин
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string fio = textBoxFIO.Text;
            string login = textBoxLogin.Text;
            string phone = textBoxPhone.Text;
            string password = textBoxPassword.Text;
            string passwordRepeat = textBoxPasswordRepeat.Text;

            if (string.IsNullOrEmpty(fio) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordRepeat))
            {
                MessageBox.Show("Заполните все поля.");
                return;
            }

            if (password != passwordRepeat)
            {
                MessageBox.Show("Пароли не совпадают.");
                return;
            }

            DB db = new DB();
            SqlCommand command = new SqlCommand("INSERT INTO Users (fio, phone, login, password, typeID) " +
                                                "VALUES (@fio, @phone, @login, @password, @typeID)", db.getConnection());

            command.Parameters.Add("@fio", SqlDbType.VarChar).Value = fio;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = password; 
            command.Parameters.Add("@typeID", SqlDbType.Int).Value = 4;
            db.OpenConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Регистрация прошла успешно!");
            }
            else
            {
                MessageBox.Show("Ошибка при регистрации. Попробуйте еще раз.");
            }
            db.CloseConnection();
        }

        private void labelAuthorization_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
