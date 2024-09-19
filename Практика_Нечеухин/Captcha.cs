using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace Практика_Нечеухин
{
    public partial class Captcha : Form
    {
        public Captcha()
        {
            InitializeComponent();
        }
        bool LastPress = false;
        // private TimeSpan sessionDuration = TimeSpan.FromMinutes(3);
        private TimeSpan sessionDuration = TimeSpan.FromSeconds(5);
        private DateTime startTime;
        private int ClickBtn = 0;
        private string text = String.Empty;
        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();

            //Создадим изображение
            Bitmap result = new Bitmap(Width, Height);

            //Вычислим позицию текста
            int Xpos = rnd.Next(0, Width - 50);
            int Ypos = rnd.Next(15, Height - 15);

            //Добавим различные цвета
            Brush[] colors = { Brushes.Black,
                     Brushes.Red,
                     Brushes.RoyalBlue,
                     Brushes.Green };

            //Укажем где рисовать
            Graphics g = Graphics.FromImage((System.Drawing.Image)result);

            //Пусть фон картинки будет серым
            g.Clear(Color.Gray);

            //Сгенерируем текст
            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                text += ALF[rnd.Next(ALF.Length)];

            //Нарисуем сгенирируемый текст
            g.DrawString(text,
                         new Font("Arial", 15),
                         colors[rnd.Next(colors.Length)],
                         new PointF(Xpos, Ypos));

            //Добавим немного помех
            /////Линии из углов
            g.DrawLine(Pens.Black,
                       new Point(0, 0),
                       new Point(Width - 1, Height - 1));
            g.DrawLine(Pens.Black,
                       new Point(0, Height - 1),
                       new Point(Width - 1, 0));
            ////Белые точки
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.White);

            return result;
        }

        private void Captcha_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClickBtn++;
            if (textBox1.Text == this.text)
            {
                MessageBox.Show("Верно!");
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Ошибка!");
                pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
            }
            if (ClickBtn==2)
            {
                startTime = DateTime.Now;
                timer1.Start();
                button1.Enabled = false;
                button2.Enabled = false;
            }
            if (LastPress == true)
            {
                MessageBox.Show("Вход в программу заблокирован");
                button1.Enabled = false;
                button2.Enabled = false;
                textBox1.Enabled = false;
                // System.Windows.Forms.Application.Restart();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var remainingTime = sessionDuration - (DateTime.Now - startTime);
            if ((DateTime.Now - startTime) >= sessionDuration)
            {
                timer1.Stop();
                MessageBox.Show("Время истекло!");
                button1.Enabled = true;
                button2.Enabled = true;
                LastPress = true;
            }
            else
            {
                TimerLabel.Text = $"Оставшееся время: {remainingTime.Minutes} минут {remainingTime.Seconds} секунд";
            }
        }
    }
}
