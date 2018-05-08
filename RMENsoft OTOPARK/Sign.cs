using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace RMENsoft_OTOPARK
{
    public partial class Sign : Form
    {
        RMENDatabaseEntities rm = new RMENDatabaseEntities();

        public Sign()
        {
            InitializeComponent();
        }
        public static string username;
        public static string password;
        public int dogrulama;

        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            password = textBox2.Text;
            string password2 = textBox3.Text;
            string email = textBox4.Text;

            if (username == "" || username.Length < 3)
            {
                MessageBox.Show("Kullanıcı adı 3 karakterden az olamaz veya boş bırakılamaz");
            }
            else if (password == "" || password2 == "" || password.Length < 5)
            {
                MessageBox.Show("Parola alanları boş bırakılamaz! (En az 5 karakter!)");
            }
            else if (password != password2)
            {
                MessageBox.Show("Parolalar Uyuşmuyor");
            }
            else if (email == "" || !email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("E-posta alanını boş bırakmayın veya düzgün bir e-posta adı giriniz");
            }

            else
            {
                Random x = new Random();
                string sayi = "";

                for (int i = 0; i < 6; i++)
                {
                    int a = x.Next(10);
                    sayi += a.ToString();

                }
                dogrulama = Convert.ToInt32(sayi);
                

                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;

                sc.Credentials = new NetworkCredential("rmensoft@gmail.com", "rmen123456789");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("rmensoft@gmail.com", "RMENsoft");
                mail.To.Add(textBox4.Text);
                mail.Subject = "Info";
                mail.IsBodyHtml = true;
                mail.Body = "Sayın " + textBox1.Text + ", RMENsoft OTOPARK v1.0.1 uygulamasına kaydınızı tamamlamak için aşağıda verilen doğrulama kodunu gerekli yere giriniz."+dogrulama + "\n\n" +
                    " RMENsoft mail Ekibi.";

                sc.Send(mail);

                SignVerify sv = new SignVerify();
                sv.verify = dogrulama;
                sv.username = textBox1.Text;
                sv.password = textBox2.Text;
                sv.email = textBox4.Text;
                sv.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sign f2 = new Sign();
            f2.Close();
            Login f1 = new Login();

            f1.Show();

            this.Hide();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.Text.Length > 18 && textBox2.Font.Size > 11)
            {
                textBox2.Font = new Font(textBox2.Font.FontFamily, textBox2.Font.Size - 1);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox3.Text.Length > 18 && textBox3.Font.Size > 11)
            {
                textBox3.Font = new Font(textBox4.Font.FontFamily, textBox3.Font.Size - 1);
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox4.Text.Length > 14 && textBox4.Font.Size > 10)
            {
                textBox4.Font = new Font(textBox4.Font.FontFamily, textBox4.Font.Size - 1);
            }
        }
    }
}
