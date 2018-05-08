using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMENsoft_OTOPARK
{
    public partial class SignVerify : Form
    {
        RMENDatabaseEntities rm = new RMENDatabaseEntities();
        Sign f2 = new Sign();
        Login f1 = new Login();
        public int verify;
        public string username, password, email;
        public SignVerify()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(textBox1.Text) == verify)
            {
                giri g = new giri();
                g.kullanici = username;
                g.sifre = password;
                g.eposta = email;
                rm.giris.Add(g);
                rm.SaveChanges();
                MessageBox.Show("Başarıyla kayıt oldunuz!");

                f2.Close();
                this.Close();
                f1.Show();
            }
            else
                MessageBox.Show("Doğrulama kodu yanlış. Tekrar deneyiniz!");
        }
    }
}
