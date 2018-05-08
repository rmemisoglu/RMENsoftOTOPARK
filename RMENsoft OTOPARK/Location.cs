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

namespace RMENsoft_OTOPARK
{
    public partial class Location : Form
    {
        public vehicleEntry frm3;
        public int maxID;
        public Location()
        {
            InitializeComponent();
        }
        public SqlConnection bag = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = 'C:\\Users\\USER\\Documents\\Visual Studio 2017\\Projects\\RMENsoft OTOPARK\\RMENsoft OTOPARK\\bin\\Debug\\RMENDatabase.mdf'; Integrated Security = True");
        public SqlCommand kmt = new SqlCommand();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        RMENDatabaseEntities rm = new RMENDatabaseEntities();

        private void Form4_Load(object sender, EventArgs e)
        {
            frm3.plakayaz();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            frm3.Show();
            this.Hide();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Çıkmak istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "SELECT MAX(ID) FROM logKayit";
                maxID = Convert.ToInt32(kmt.ExecuteScalar());
                kmt.CommandText = "UPDATE logKayit SET LogoutTime='" + DateTime.Now + "' WHERE ID=" + maxID + "";
                kmt.ExecuteNonQuery();
                bag.Close();
                Application.Exit();
            }
            else
            {

            }
        }

        private void getInfo(string konum)
        {
            Konum k = (from x in rm.Konums where x.konum1 == konum select x).FirstOrDefault();
            Tarih t = (from x in rm.Tarihs where x.a_plaka == k.a_plaka select x).FirstOrDefault();
            Arac a = (from x in rm.Aracs where x.Plaka == k.a_plaka select x).FirstOrDefault();
            Musteri m = (from x in rm.Musteris where x.Id == a.m_id select x).FirstOrDefault();

            MessageBox.Show(m.Adı + "\n" + m.Soyadı + "\n" + m.Telefon + "\n" + a.Model + "\n" + a.Renk + "\n" + t.GirisSaati);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (button1.BackColor == Color.Red)
            {
                getInfo("A1");
            }
            if (button1.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "A1";
                frm3.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.Red)
            {
                getInfo("A2");
            }
            if (button2.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "A2";
                frm3.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.Red)
            {
                getInfo("A3");
            }
            if (button3.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "A3";
                frm3.Show();
                this.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.Red)
            {
                getInfo("A4");
            }
            if (button4.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "A4";
                frm3.Show();
                this.Hide();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.Red)
            {
                getInfo("A5");
            }
            if (button5.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "A5";
                frm3.Show();
                this.Hide();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.Red)
            {
                getInfo("B1");
            }
            if (button6.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "B1";
                frm3.Show();
                this.Hide();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == Color.Red)
            {
                getInfo("B2");
            }

            if (button7.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "B2";
                frm3.Show();
                this.Hide();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.BackColor == Color.Red)
            {
                getInfo("B3");
            }
            if (button8.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "B3";
                frm3.Show();
                this.Hide();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.BackColor == Color.Red)
            {
                getInfo("B4");
            }
            if (button9.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "B4";
                frm3.Show();
                this.Hide();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.BackColor == Color.Red)
            {
                getInfo("B5");
            }
            if (button10.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "B5";
                frm3.Show();
                this.Hide();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.BackColor == Color.Red)
            {
                getInfo("C1");
            }
            if (button11.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "C1";
                frm3.Show();
                this.Hide();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.BackColor == Color.Red)
            {
                getInfo("C2");
            }
            if (button12.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "C2";
                frm3.Show();
                this.Hide();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (button13.BackColor == Color.Red)
            {
                getInfo("C3");
            }
            if (button13.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "C3";
                frm3.Show();
                this.Hide();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (button14.BackColor == Color.Red)
            {
                getInfo("C4");
            }
            if (button14.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "C4";
                frm3.Show();
                this.Hide();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (button15.BackColor == Color.Red)
            {
                getInfo("C5");
            }
            if (button15.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "C5";
                frm3.Show();
                this.Hide();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (button16.BackColor == Color.Red)
            {
                getInfo("D1");
            }
            if (button16.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "D1";
                frm3.Show();
                this.Hide();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (button17.BackColor == Color.Red)
            {
                getInfo("D2");
            }
            if (button17.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "D2";
                frm3.Show();
                this.Hide();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (button18.BackColor == Color.Red)
            {
                getInfo("D3");
            }
            if (button18.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "D3";
                frm3.Show();
                this.Hide();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (button19.BackColor == Color.Red)
            {
                getInfo("D4");
            }
            if (button19.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "D4";
                frm3.Show();
                this.Hide();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (button20.BackColor == Color.Red)
            {
                getInfo("D5");
            }
            if (button20.BackColor == Color.FromArgb(0, 192, 0))
            {
                frm3.comboBox1.SelectedItem = "D5";
                frm3.Show();
                this.Hide();
            }
        }
    }
}
