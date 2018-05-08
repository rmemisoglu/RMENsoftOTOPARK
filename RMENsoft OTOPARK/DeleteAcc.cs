using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace RMENsoft_OTOPARK
{
    public partial class DeleteAcc : Form
    {
        RMENDatabaseEntities rm = new RMENDatabaseEntities();
        bool verify = false;
        public int dogrulama;

        public DeleteAcc()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var g = (from z in rm.giris where z.eposta == textBox4.Text select z.eposta).FirstOrDefault();

            if (g == null)
            {
                MessageBox.Show("E-posta yanlış tekrar deneyiniz");
            }
            else if (g != null)
            {

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
                Random x = new Random();
                string sayi = "";

                for (int i = 0; i < 6; i++)
                {
                    int a = x.Next(10);
                    sayi += a.ToString();

                }
                dogrulama = Convert.ToInt32(sayi);

                mail.Body = "Sayın user, RMENsoft OTOPARK v1.0.1 uygulaması hesabınızı silmek istediğiniz yönünde bildirim aldık.\n" +
                    "Hesabınızı silmek için aşağıda verdiğimiz kodu uygulama ekranında gerekli yere giriniz.\n\n" +
                    dogrulama + "\n\n" +
                    "RMENsoft mail Ekibi.";

                sc.Send(mail);
                button1.Enabled = true;
            }
        }

        private void DeleteAcc_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) == dogrulama)
            {
                giri g = (from x in rm.giris where x.eposta == textBox4.Text select x).FirstOrDefault();
                rm.giris.Remove(g);
                rm.SaveChanges();
                MessageBox.Show("Hesabınız başarıyla silinmiştir");
                this.Close();
            }
            else
                MessageBox.Show("Doğrulama kodu yanlış!");
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox4.Text.Length > 12 && textBox4.Font.Size > 9)
            {
                textBox4.Font = new Font(textBox4.Font.FontFamily, textBox4.Font.Size - 1);
            }
        }
    }
}
