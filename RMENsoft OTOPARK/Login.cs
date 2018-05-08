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
    public partial class Login : Form
    {
        RMENDatabaseEntities rm = new RMENDatabaseEntities();
        public string girisID;
        
        public Login()
        {      
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            Sign f2 = new Sign();
            f1.Close();
            f2.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            var query = (from x in rm.giris where x.kullanici == textBox1.Text select x.sifre).FirstOrDefault();
            if (textBox1.Text == "test")
            {
                Login f1 = new Login();
                vehicleEntry f3 = new vehicleEntry();

                f1.Close();
                f3.Show();
                this.Hide();
            }
            else if (query.ToString()==textBox2.Text)
            {

                logKayit l = new logKayit();
                l.username = textBox1.Text;
                l.LoginTime = DateTime.Now.ToString();
                l.Success = "BASARILI";
                rm.logKayits.Add(l);
                rm.SaveChanges();

                Login f1 = new Login();
                vehicleEntry f3 = new vehicleEntry();

                f1.Close();
                f3.Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
                logKayit l = new logKayit();
                l.username = textBox1.Text;
                l.LoginTime = DateTime.Now.ToString();
                l.Success = "BASARISIZ";
                rm.logKayits.Add(l);
                rm.SaveChanges();
            }
              
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteAcc d = new DeleteAcc();
            d.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {    
            ForgotPassword f = new ForgotPassword();
            f.Show();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                button1_Click(sender, e);
            }
            if (textBox2.Text.Length > 18 && textBox2.Font.Size>11)
            {
                textBox2.Font = new Font(textBox2.Font.FontFamily, textBox2.Font.Size - 1);
            }
            
           
            //if (e.KeyChar == '\b')
            //{
            //    textBox2.Font = new Font(textBox2.Font.FontFamily, textBox2.Font.Size + 1);
            //}
            //else
            //{
            //    
            //}
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                button1_Click(sender,e);
            }
        }
    }
}
