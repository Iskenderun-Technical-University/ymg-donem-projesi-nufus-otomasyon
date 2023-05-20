using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _202503071_nüfus_müdürlüğü_otomosyonu
{
    public partial class Frmkayit : Form
    {
        public Frmkayit()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=localhost\\SQLEXPRESS;Initial Catalog=202503071;Integrated Security=True");
     

        void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            txtanneadi.Text = "";
            txtbabaadi.Text = "";
            txtannekizliksoyadi.Text = "";
            dateTimePicker1.Text  = "";
            msktxtbxserino.Text = "";
            cmbdogumyeri.Text = "";
            cmbkangrubu.Text = "";
            txtad.Focus();
            
               
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Server=localhost\\SQLEXPRESS;Initial Catalog=202503071;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("Select * from Table_vatandas", baglanti);

            DataSet ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "Table_vatandas");


            dataGridView2.DataSource = ds.Tables["Table_vatandas"];
            baglanti.Close();

        }

       
        
        private void btnekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Table_vatandas(Ad,Soyad,Cinsiyet,Seri_no,Dogum_tarihi,Dogum_yeri,Kan_grubu,Uyruk,Anne_adi,Baba_adi,Anne_kizlik_soyadi) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", baglanti);

            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", label13.Text);
            komut.Parameters.AddWithValue("@p4", Convert.ToString (msktxtbxserino.Text));
            komut.Parameters.AddWithValue("@p5", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@p6", cmbdogumyeri.Text);
            komut.Parameters.AddWithValue("@p7", cmbkangrubu.Text);
            komut.Parameters.AddWithValue("@p8", label14.Text);
            komut.Parameters.AddWithValue("@p9", txtanneadi.Text);
            komut.Parameters.AddWithValue("@p10", txtbabaadi.Text);
            komut.Parameters.AddWithValue("@p11", txtannekizliksoyadi.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kayıt Eklendi.");

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete From Table_vatandas where vatandas_id=@k1",baglanti);

            komut.Parameters.AddWithValue("@k1", txtid.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kayıt Silindi.");

        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

     

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;

            txtid.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            label13.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            msktxtbxserino.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView2.Rows[secilen].Cells[5].Value.ToString();
            cmbdogumyeri.Text = dataGridView2.Rows[secilen].Cells[6].Value.ToString();
            cmbkangrubu.Text = dataGridView2.Rows[secilen].Cells[7].Value.ToString();
            label14.Text = dataGridView2.Rows[secilen].Cells[8].Value.ToString();
            txtanneadi.Text = dataGridView2.Rows[secilen].Cells[9].Value.ToString();
            txtbabaadi.Text = dataGridView2.Rows[secilen].Cells[10].Value.ToString();
            txtannekizliksoyadi.Text = dataGridView2.Rows[secilen].Cells[11].Value.ToString();

        }

        private void Frmkayit_Load(object sender, EventArgs e)
        { 
            SqlConnection baglanti = new SqlConnection("Server=localhost\\SQLEXPRESS;Initial Catalog=202503071;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("Select * from Table_vatandas", baglanti);

            DataSet ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "Table_vatandas");


            dataGridView2.DataSource = ds.Tables["Table_vatandas"];
            baglanti.Close();
            
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("Update Table_vatandas set Ad=@n1,Soyad=@n2,Cinsiyet=@n3,Seri_no=@n4,Dogum_tarihi=@n5,Dogum_yeri=@n6,Kan_grubu=@n7,Uyruk=@n8,Anne_adi=@n9,Baba_adi=@n10,Anne_kizlik_soyadi=@n11 where vatandas_id=@n12", baglanti);
           
            komut.Parameters.AddWithValue("@n1", txtad.Text);
            komut.Parameters.AddWithValue("@n2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@n3", label13.Text);
            komut.Parameters.AddWithValue("@n4", Convert.ToString (msktxtbxserino.Text)); 
            komut.Parameters.AddWithValue("@n5", dateTimePicker1 .Value);
            komut.Parameters.AddWithValue("@n6", cmbdogumyeri.Text);
            komut.Parameters.AddWithValue("@n7", cmbkangrubu.Text);
            komut.Parameters.AddWithValue("@n8", label14.Text);
            komut.Parameters.AddWithValue("@n9", txtanneadi.Text);
            komut.Parameters.AddWithValue("@n10", txtbabaadi.Text);
            komut.Parameters.AddWithValue("@n11", txtannekizliksoyadi.Text);
            komut.Parameters.AddWithValue("@n12",txtid.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kayıt Güncellendi.");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                label13.Text = "Kız";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label13.Text = "Erkek";
            }
        }

        private void label13_TextChanged(object sender, EventArgs e)
        {
            if(label13.Text == "Kız")
            {
                radioButton1.Checked = true;
            }
            if(label13.Text == "Erkek")
            {
                radioButton2.Checked  = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                label14.Text = "True";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                label14.Text = "False";
            }
        }

        private void label14_TextChanged(object sender, EventArgs e)
        {
            if (label14.Text == "True")
            {
                radioButton3.Checked = true;
            }
            if (label14.Text == "False")
            {
                radioButton4.Checked = true;
            }
        }

        private void şifreDeğiştirmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SifreDegistir a = new SifreDegistir();
            a.ShowDialog();
        }

        private void evlilikKaydıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEvlilik a = new FrmEvlilik();
            a.ShowDialog();
        }

      

        public void grid_doldur(string sorgu)
        {

            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);

            DataSet ds = new DataSet();
            baglanti.Open();
            da.Fill(ds,"Table_vatandas");


            dataGridView2.DataSource = ds.Tables["Table_vatandas"];

            baglanti.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Server=localhost\\SQLEXPRESS;Initial Catalog=202503071;Integrated Security=True");
            try
            {
                if (textBox1.Text != "")
                {

                    if (radioButton5.Checked)
                    {

                        string sorgu = ("select * from Table_vatandas where Ad like '%" + textBox1.Text + "%'");
                        grid_doldur(sorgu);

                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
