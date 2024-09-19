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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Практика_Нечеухин
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void eyes_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String LoginUser = textBoxLogin.Text;
            String PasswordUser = textBoxPassword.Text;
            String FioUser;
            bool IsSuccessful;

            DB db = new DB();

            DataTable table = new DataTable();
            
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE login = @login AND password = @password ", db.getConnection());

            command.Parameters.AddWithValue("@login", LoginUser); //Используем параметры чтобы не могли взламывать базу
            command.Parameters.AddWithValue("@password", PasswordUser);

            

            adapter.SelectCommand = command;
            adapter.Fill(table ); 
            if (table.Rows.Count>0 )
            {
                int typeID = Convert.ToInt32(table.Rows[0]["typeID"]);
                if (typeID == 4)
                {
                    FioUser = table.Rows[0]["fio"].ToString();
                    int UserID = Convert.ToInt32(table.Rows[0]["UserID"]);
                    MessageBox.Show("Добро пожаловать " + FioUser);
                    IsSuccessful = true;
                    this.Hide();
                    UserForm userForm = new UserForm(UserID);
                    userForm.Show();
                }
                 else if (typeID == 3)
                {
                    FioUser = table.Rows[0]["fio"].ToString();
                    int UserID = Convert.ToInt32(table.Rows[0]["UserID"]);
                    MessageBox.Show("Добро пожаловать " + FioUser);
                    IsSuccessful = true;
                    OperatorForm operatorForm = new OperatorForm();
                    operatorForm.Show();
                    this.Hide();
                }
                else if (typeID == 2)
                {
                    FioUser = table.Rows[0]["fio"].ToString();
                    int UserID = Convert.ToInt32(table.Rows[0]["UserID"]);
                    MessageBox.Show("Добро пожаловать " + FioUser);
                    IsSuccessful = true;
                    MasterForm masterForm = new MasterForm(UserID);
                    masterForm.Show();
                    this.Hide();
                }
                else if (typeID == 1)
                {
                    FioUser = table.Rows[0]["fio"].ToString();
                    int UserID = Convert.ToInt32(table.Rows[0]["UserID"]);
                    MessageBox.Show("Добро пожаловать " + FioUser);
                    IsSuccessful = true;
                    ManagerForm managerForm = new ManagerForm();
                    managerForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("У нас техническая неполадка. Извините, что приносим неудобства");
                    IsSuccessful = false;
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
                IsSuccessful = false;
                this.Hide();
                Captcha captcha = new Captcha();
                captcha.Show();
            }

            db.OpenConnection();
            SqlCommand commandHistory = new SqlCommand("INSERT INTO LoginHistory(time, login, IsSuccessful) VALUES(@time, @login, @IsSuccessful)", db.getConnection());
            commandHistory.Parameters.Add("@login", SqlDbType.VarChar).Value = textBoxLogin.Text;
            commandHistory.Parameters.Add("@time", SqlDbType.DateTime).Value = DateTime.Now;
            commandHistory.Parameters.Add("@IsSuccessful", SqlDbType.VarChar).Value = IsSuccessful ? "yes" : "no";
            commandHistory.ExecuteNonQuery();
        }

       

        private void labelRegistration_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
        }
    }
}
