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
    public partial class vehicleExit : Form
    {
        public vehicleEntry frm3;
        public int maxID;
        public vehicleExit()
        {
            InitializeComponent();
        }
        public SqlConnection bag = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = 'C:\\Users\\USER\\Documents\\Visual Studio 2017\\Projects\\RMENsoft OTOPARK\\RMENsoft OTOPARK\\bin\\Debug\\RMENDatabase.mdf'; Integrated Security = True");
        public SqlCommand kmt = new SqlCommand();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        public DataSet dtst = new DataSet();
        RMENDatabaseEntities rm = new RMENDatabaseEntities();


        public double ucretHesapla(int gun, int saat, int dk)
        {
            double ucret = 0;
            if (gun==0 && saat==0 && dk < 30)
            {
                ucret = 0;
            }
            else if (gun > 0)
            {
                ucret = gun * 48;
            }
            else
            {
                ucret = ((gun * 1440) + (saat * 60) + dk) * 0.1;
            }
            return ucret;
        }

        private void button7_Click(object sender, EventArgs e)
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
            
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            var t = (from x in rm.Tarihs where x.a_plaka == label5.Text select x.GirisSaati).FirstOrDefault();

            string[] giris = t.Split('.', ' ', ':');
            string[] cikis = dateTimePicker1.Value.ToString().Split('.', ' ', ':');

            int gun = Convert.ToInt32(cikis[0]) - Convert.ToInt32(giris[0]);
            int ay = Convert.ToInt32(cikis[1]) - Convert.ToInt32(giris[1]);
            int yil = Convert.ToInt32(cikis[2]) - Convert.ToInt32(giris[2]);
            int saat = Convert.ToInt32(cikis[3]) - Convert.ToInt32(giris[3]);
            int dk = Convert.ToInt32(cikis[4]) - Convert.ToInt32(giris[4]);

            if (gun < 0)
            {
                ay = ay - 1;
                gun = 30 + gun;
            }
            if (ay < 0)
            {
                yil = yil - 1;
                ay = 12 + ay;
            }
            if (saat < 0)
            {
                saat = 24 + saat;
                if (gun == 0)
                {
                    gun = 29;

                    if (ay == 0)
                    {
                        ay = 11;
                        yil = yil - 1;
                    }
                    else
                        ay = ay - 1;
                }
                else
                    gun = gun - 1;

            }
            if (dk < 0)
            {
                saat = saat - 1;
                dk = 60 + dk;
            }


            if (label1.Text != "" && label5.Text != "" && label9.Text != "")
            {
                DialogResult cevap;
                cevap = MessageBox.Show("Araç çıkışı yapmak istediğinize eminmisiniz? \n" + "\nGeçen süre " 
                    + gun + " gün " + saat + " saat " + dk + " dk \n" + "\nÜcret= "
                    + ucretHesapla(gun, saat, dk) + " TL", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    frm3.plakasil();
                    //frm3.bag.Open();

                    //MUSTERİ

                    Musteri m = (from x in rm.Musteris where x.TC == label1.Text select x).FirstOrDefault();
                    m.Aktif = 0;
                    rm.SaveChanges();
                    //gridUpdate();

                    RMENdata.bosRow bosRow = rmeNdata1.bos.NewbosRow();
                    bosRow.bosyerler = label9.Text;
                    rmeNdata1.bos.AddbosRow(bosRow);
                    bosTableAdapter.Update(bosRow);

                    dolu d = (from x in rm.dolus where x.doluyerler == label9.Text select x).FirstOrDefault();
                    rm.dolus.Remove(d);
                    rm.SaveChanges();

                    frm3.comboBox1.Items.Add(label9.Text);
                    frm3.comboBox1.Sorted = true;
                   
                    label1.Text = ""; label2.Text = ""; label3.Text = ""; label4.Text = ""; label5.Text = "";
                    label6.Text = ""; label7.Text = ""; label8.Text = ""; label9.Text = ""; label21.Text = "";
                   
                    frm3.plakasil();
                    gridUpdate();
                }
            }
            else
            {
                MessageBox.Show("Boş alanları doldurunuz !!!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frm3.Show();
            this.Hide();
            
            
        }
        private void gridUpdate()
        {
            
            var update = (from x in rm.Musteris where x.Aktif == 1 select x).ToList();
            dataGridView1.DataSource = update;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MusteribindingSource.MoveFirst();
            //int index = dataGridView1.CurrentRow.Index;
            //dataGridView1.Rows[index+1].Selected = true;   
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MusteribindingSource.MovePrevious();
            //    int index = dataGridView1.CurrentRow.Index;
            //    MessageBox.Show(index.ToString());
            //    dataGridView1.Rows[0].Selected = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //MusteribindingSource.MoveNext(); 
            //int index = dataGridView1.CurrentRow.Index;
            //dataGridView1.Rows[index + 1].Selected = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //MusteribindingSource.MoveLast();  
        }
        
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
                label1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                label2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                label3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                label4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            

            //ENTITY

            Musteri m = (from z in rm.Musteris where z.TC == label1.Text select z).FirstOrDefault();
            int id = m.Id;
            
            Arac a = (from x in rm.Aracs where x.m_id == id select x).FirstOrDefault();
            label5.Text = a.Plaka;
            label6.Text = a.Marka;
            label7.Text = a.Model;
            label8.Text = a.Renk;

            Konum k = (from x in rm.Konums where x.a_plaka == label5.Text select x).FirstOrDefault();
            label9.Text = k.konum1;

            Tarih t = (from x in rm.Tarihs where x.a_plaka == label5.Text select x).FirstOrDefault();
            label21.Text = t.GirisSaati;

            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "TC")
            {
                var filter = (from x in rm.Musteris where x.TC.Contains(textBox1.Text) && x.Aktif == 1 select x).ToList();
                dataGridView1.DataSource = filter;
            }
            else if(comboBox2.SelectedItem.ToString() == "Adı")
            {
                var filter = (from x in rm.Musteris where x.Adı.Contains(textBox1.Text) && x.Aktif == 1 select x).ToList();
                dataGridView1.DataSource = filter;
            }
            else if(comboBox2.SelectedItem.ToString() == "Soyadı")
            {
                var filter = (from x in rm.Musteris where x.Soyadı.Contains(textBox1.Text) && x.Aktif == 1 select x).ToList();
                dataGridView1.DataSource = filter;
            }
            else if (comboBox2.SelectedItem.ToString() == "Telefon")
            {
                var filter = (from x in rm.Musteris where x.Telefon.Contains(textBox1.Text) && x.Aktif == 1 select x).ToList();
                dataGridView1.DataSource = filter;
            }

            if (textBox1.Text == "")
            {
                gridUpdate();
            }
                     
        }

        private void vehicleExit_Activated(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'rmeNdata1.Tarih' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tarihTableAdapter.Fill(this.rmeNdata1.Tarih);
            // TODO: Bu kod satırı 'rmeNdata1.Konum' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.konumTableAdapter.Fill(this.rmeNdata1.Konum);
            // TODO: Bu kod satırı 'rmeNdata1.Musteri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.musteriTableAdapter.Fill(this.rmeNdata1.Musteri);
            // TODO: Bu kod satırı 'rmeNdata1.Arac' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.aracTableAdapter.Fill(this.rmeNdata1.Arac);

            gridUpdate();
            //frm3.combo2();
            dateTimePicker1.Value = DateTime.Now;
            comboBox2.SelectedIndex = 1;
        }

        private void vehicleExit_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'rmeNdata1.Tarih' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tarihTableAdapter.Fill(this.rmeNdata1.Tarih);
            // TODO: Bu kod satırı 'rmeNdata1.Konum' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.konumTableAdapter.Fill(this.rmeNdata1.Konum);
            // TODO: Bu kod satırı 'rmeNdata1.Musteri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.musteriTableAdapter.Fill(this.rmeNdata1.Musteri);
            // TODO: Bu kod satırı 'rmeNdata1.Arac' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.aracTableAdapter.Fill(this.rmeNdata1.Arac);

            gridUpdate();
            //frm3.combo2();
            dateTimePicker1.Value = DateTime.Now;
            comboBox2.SelectedIndex = 1;
        }
    }
}
