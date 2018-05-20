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
using System.Globalization;
using System.Data.SqlClient;

namespace RMENsoft_OTOPARK
{
    public partial class vehicleEntry : Form
    {
        public Location frm4;
        public vehicleExit frm5;
        public Login frm1;
        private DateTimePicker timePicker;
        public int maxID = 0;
        public vehicleEntry()
        {
            InitializeComponent();
            frm4 = new Location();
            frm5 = new vehicleExit();
            frm1 = new Login(); 
            frm4.frm3 = this;
            frm5.frm3 = this;
        }

       
        public SqlConnection bag = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = 'C:\\Users\\USER\\Documents\\Visual Studio 2017\\Projects\\RMENsoft OTOPARK\\RMENsoft OTOPARK\\bin\\Debug\\RMENDatabase.mdf'; Integrated Security = True");
        public SqlCommand kmt = new SqlCommand();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        RMENDatabaseEntities rm = new RMENDatabaseEntities();

        public void combo()
        {
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select * from bos";
            SqlDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[1].ToString());
            }
            bag.Close();
            oku.Dispose();
            comboBox1.Sorted = true;
        }
        private int checkActive(string konum)
        {
            int act = 0;
            var k = (from x in rm.Konums where x.konum1 == konum select x.a_plaka).ToList();
            foreach (var item in k)
            {
                var a = (from x in rm.Aracs where x.Plaka == item select x.m_id).FirstOrDefault();
                act += (from x in rm.Musteris where x.Id == a select x.Aktif).FirstOrDefault();
            }
            return act;
        }
        public void plakayaz()
        {
            
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select * from Konum";
            SqlDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {

                switch (oku["konum"].ToString())
                {
                    case "A1":
                        {
                            if (checkActive("A1") == 1)
                            {
                                frm4.button1.Text = oku["a_plaka"].ToString();
                                frm4.button1.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "A2":
                        {
                            if (checkActive("A2") == 1)
                            {
                                frm4.button2.Text = oku["a_plaka"].ToString();
                                frm4.button2.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "A3":
                        {
                            if (checkActive("A3") == 1)
                            {
                                frm4.button3.Text = oku["a_plaka"].ToString();
                                frm4.button2.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "A4":
                        {
                            if (checkActive("A4") == 1)
                            {
                                frm4.button4.Text = oku["a_plaka"].ToString();
                                frm4.button4.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "A5":
                        {
                            if (checkActive("A5") == 1)
                            {
                                frm4.button5.Text = oku["a_plaka"].ToString();
                                frm4.button5.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "B1":
                        {
                            if (checkActive("B1") == 1)
                            {
                                frm4.button6.Text = oku["a_plaka"].ToString();
                                frm4.button6.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "B2":
                        {
                            if (checkActive("B2") == 1)
                            {
                                frm4.button7.Text = oku["a_plaka"].ToString();
                                frm4.button7.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "B3":
                        {
                            if (checkActive("B3") == 1)
                            {
                                frm4.button8.Text = oku["a_plaka"].ToString();
                                frm4.button8.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "B4":
                        {
                            if (checkActive("B4") == 1)
                            {
                                frm4.button9.Text = oku["a_plaka"].ToString();
                                frm4.button9.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "B5":
                        {
                            if (checkActive("B5") == 1)
                            {
                                frm4.button10.Text = oku["a_plaka"].ToString();
                                frm4.button10.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "C1":
                        {

                            if (checkActive("C1") == 1)
                            {
                                frm4.button11.Text = oku["a_plaka"].ToString();
                                frm4.button11.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "C2":
                        {
                            if (checkActive("C2") == 1)
                            {
                                frm4.button12.Text = oku["a_plaka"].ToString();
                                frm4.button12.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "C3":
                        {
                            if (checkActive("C3") == 1)
                            {
                                frm4.button13.Text = oku["a_plaka"].ToString();
                                frm4.button13.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "C4":
                        {
                            if (checkActive("C4") == 1)
                            {
                                frm4.button14.Text = oku["a_plaka"].ToString();
                                frm4.button14.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "C5":
                        {
                            if (checkActive("C5") == 1)
                            {
                                frm4.button15.Text = oku["a_plaka"].ToString();
                                frm4.button15.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "D1":
                        {
                            if (checkActive("D1") == 1)
                            {
                                frm4.button16.Text = oku["a_plaka"].ToString();
                                frm4.button16.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "D2":
                        {
                            if (checkActive("D2") == 1)
                            {
                                frm4.button17.Text = oku["a_plaka"].ToString();
                                frm4.button17.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "D3":
                        {
                            if (checkActive("D3") == 1)
                            {
                                frm4.button18.Text = oku["a_plaka"].ToString();
                                frm4.button18.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "D4":
                        {
                            if (checkActive("D4") == 1)
                            {
                                frm4.button19.Text = oku["a_plaka"].ToString();
                                frm4.button19.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case "D5":
                        {
                            if (checkActive("D5") == 1)
                            {
                                frm4.button20.Text = oku["a_plaka"].ToString();
                                frm4.button20.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                }

            }
            bag.Close();
            oku.Dispose();
        }
        public void plakasil()
        {
            switch (frm5.label9.Text)
            {
                case "A1":
                    {
                        frm4.button1.Text = "A1";
                        frm4.button1.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "A2":
                    {

                        frm4.button2.Text = "A2";
                        frm4.button2.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "A3":
                    {
                        frm4.button3.Text = "A3";
                        frm4.button3.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "A4":
                    {
                        frm4.button4.Text = "A4";
                        frm4.button4.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "A5":
                    {
                        frm4.button5.Text = "A5";
                        frm4.button5.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "B1":
                    {
                        frm4.button6.Text = "B1";
                        frm4.button6.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "B2":
                    {
                        frm4.button7.Text = "B2";
                        frm4.button7.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "B3":
                    {
                        frm4.button8.Text = "B3";
                        frm4.button8.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "B4":
                    {
                        frm4.button9.Text = "B4";
                        frm4.button9.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "B5":
                    {
                        frm4.button10.Text = "B5";
                        frm4.button10.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "C1":
                    {
                        frm4.button11.Text = "C1";
                        frm4.button11.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "C2":
                    {
                        frm4.button12.Text = "C2";
                        frm4.button12.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "C3":
                    {
                        frm4.button13.Text = "C3";
                        frm4.button13.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "C4":
                    {
                        frm4.button14.Text = "C4";
                        frm4.button14.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "C5":
                    {
                        frm4.button15.Text = "C5";
                        frm4.button15.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "D1":
                    {
                        frm4.button16.Text = "D1";
                        frm4.button16.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "D2":
                    {
                        frm4.button17.Text = "D2";
                        frm4.button17.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "D3":
                    {
                        frm4.button18.Text = "D3";
                        frm4.button18.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "D4":
                    {
                        frm4.button19.Text = "D4";
                        frm4.button19.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
                case "D5":
                    {
                        frm4.button20.Text = "D5";
                        frm4.button20.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                        break;
                    }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            combo();
            //timer1.Start();
            //timePicker = new DateTimePicker();
            //timePicker.Format = DateTimePickerFormat.Time;
            //timePicker.ShowUpDown = true;
            //timePicker.Location = new Point(10, 10);
            //timePicker.Width = 100;
            //Controls.Add(timePicker);
            dateTimePicker1.Value = DateTime.Now;


            //TimeSpan fark = dateTimePicker2.Value - dateTimePicker1.Value;
            //int gün = fark.Hours;
            //textBox10.Text = gün.ToString();
            this.musteriTableAdapter.Fill(this.rmendata1.Musteri);
            this.aracTableAdapter.Fill(this.rmendata1.Arac);
            this.tarihTableAdapter.Fill(this.rmendata1.Tarih);
            this.konumTableAdapter.Fill(this.rmendata1.Konum);
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            frm5.Show();  
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            plakayaz();
            frm4.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Çıkmak istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText= "SELECT MAX(ID) FROM logKayit";
                maxID= Convert.ToInt32(kmt.ExecuteScalar());
                kmt.CommandText= "UPDATE logKayit SET LogoutTime='" + DateTime.Now + "' WHERE ID="+maxID+"";
                kmt.ExecuteNonQuery();
                bag.Close();
                Application.Exit();
            }
            else
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox5.Text != "" && comboBox1.Text != "")
            {
                string tcList = (from x in rm.Musteris where x.TC == textBox1.Text select x.TC).FirstOrDefault();
                RMENdata.MusteriRow musteriRow = rmendata1.Musteri.NewMusteriRow();
                //MUSTERI
                if (tcList != null)
                {
                    Musteri m = (from x in rm.Musteris where x.TC == textBox1.Text select x).FirstOrDefault();
                    m.Aktif = 1;
                    rm.SaveChanges();
                }
                else
                {
                    musteriRow.TC = textBox1.Text;
                    musteriRow.Adı = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBox2.Text);
                    musteriRow.Soyadı = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBox3.Text);
                    musteriRow.Telefon = textBox4.Text;
                    musteriRow.Aktif = 1;
                    rmendata1.Musteri.AddMusteriRow(musteriRow);
                    musteriTableAdapter.Update(musteriRow);
                }


                ////ARAC
                string plakaList = (from x in rm.Aracs where x.Plaka == textBox5.Text select x.Plaka).FirstOrDefault();

                if (plakaList != null)
                {
                    RMENdata.AracRow aracRow = rmendata1.Arac.FindByPlaka(textBox5.Text);
                    aracRow.Plaka = textBox5.Text.ToUpper();
                    aracRow.Marka = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBox6.Text);
                    aracRow.Model = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBox7.Text);
                    aracRow.Renk = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBox8.Text);
                    aracRow.m_id = (from x in rm.Musteris where x.TC == textBox1.Text select x.Id).FirstOrDefault();
                    aracTableAdapter.Update(aracRow);
                }
                else
                {
                    RMENdata.AracRow aracRow = rmendata1.Arac.NewAracRow();
                    aracRow.Plaka = textBox5.Text.ToUpper();
                    aracRow.Marka = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBox6.Text);
                    aracRow.Model = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBox7.Text);
                    aracRow.Renk = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBox8.Text);
                    aracRow.m_id = musteriRow.Id;
                    rmendata1.Arac.AddAracRow(aracRow);
                    aracTableAdapter.Update(aracRow);
                }

                //TARIH
                string tarihPlaka = (from x in rm.Tarihs where x.a_plaka == textBox5.Text select x.a_plaka).FirstOrDefault();

                if (tarihPlaka != null)
                {
                    Tarih t = (from x in rm.Tarihs where x.a_plaka == textBox5.Text select x).FirstOrDefault();
                    t.GirisSaati = dateTimePicker1.Value.ToString();
                    t.a_plaka = (from x in rm.Aracs where x.Plaka == textBox5.Text select x.Plaka).FirstOrDefault();
                    rm.SaveChanges();
                }
                else
                {
                    RMENdata.TarihRow tarihRow = rmendata1.Tarih.NewTarihRow();
                    tarihRow.GirisSaati = dateTimePicker1.Value.ToString();
                    tarihRow.a_plaka = (from x in rm.Aracs where x.Plaka == textBox5.Text select x.Plaka).FirstOrDefault();
                    rmendata1.Tarih.AddTarihRow(tarihRow);
                    tarihTableAdapter.Update(tarihRow);
                }

                //KONUM
                string konumPlaka = (from x in rm.Konums where x.a_plaka == textBox5.Text select x.a_plaka).FirstOrDefault();

                if (konumPlaka != null)
                {
                    Konum k = (from x in rm.Konums where x.a_plaka == textBox5.Text select x).FirstOrDefault();
                    k.konum1 = comboBox1.Text;
                    k.a_plaka = (from x in rm.Aracs where x.Plaka == textBox5.Text select x.Plaka).FirstOrDefault();
                    rm.SaveChanges();
                }
                else
                {
                    RMENdata.KonumRow konumRow = rmendata1.Konum.NewKonumRow();
                    konumRow.konum = comboBox1.Text;
                    konumRow.a_plaka = (from x in rm.Aracs where x.Plaka == textBox5.Text select x.Plaka).FirstOrDefault();
                    rmendata1.Konum.AddKonumRow(konumRow);
                    konumTableAdapter.Update(konumRow);
                }
                
                plakayaz();

               
                
                //DOLU
                RMENdata.doluRow doluRow = rmendata1.dolu.NewdoluRow();
                doluRow.doluyerler = comboBox1.Text;
                rmendata1.dolu.AdddoluRow(doluRow);
                doluTableAdapter.Update(doluRow);


                //BOS
                bo b = (from x in rm.bos where x.bosyerler == comboBox1.Text select x).FirstOrDefault();
                rm.bos.Remove(b);
                rm.SaveChanges();

                comboBox1.Items.Clear();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
                textBox5.Clear(); textBox6.Clear(); textBox7.Clear(); textBox8.Clear();
                comboBox1.Text = "";
                combo();
                plakayaz();
                MessageBox.Show("Kayıt işlemi tamamlandı ! ");


            }
            else
            {
                MessageBox.Show("Boş alanları doldurunuz !!!");
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            Musteri query = (from x in rm.Musteris where x.TC == textBox1.Text select x).FirstOrDefault();

            if (query != null)
            {
                DialogResult cevap;
                cevap = MessageBox.Show("Daha önce kayıtlı bir müşteriyi otomatik eklemek istermisiniz? \n", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    textBox2.Text = query.Adı;
                    textBox3.Text = query.Soyadı;
                    textBox4.Text = query.Telefon;
                }
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            Arac query = (from x in rm.Aracs where x.Plaka == textBox5.Text select x).FirstOrDefault();
            if (query != null)
            {
                DialogResult cevap;
                cevap = MessageBox.Show("Daha önce kayıtlı bir aracı otomatik eklemek istermisiniz? \n", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    textBox6.Text = query.Marka;
                    textBox7.Text = query.Model;
                    textBox8.Text = query.Renk;
                }
            }
        }
    }
}
