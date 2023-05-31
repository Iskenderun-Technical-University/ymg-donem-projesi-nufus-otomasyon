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
    public partial class FrmEvlilik : Form
    {
        public FrmEvlilik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=localhost\\SQLEXPRESS;Initial Catalog=202503071;Integrated Security=True");
        
        void temizle()
        {
            txtevlilikid.Text  = "";
            txterkekad.Text = "";
            txterkeksoyad.Text = "";
            txtkadınad .Text = "";
            txtkadınsoyad.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            dateTimePicker3.Text = "";
            txtmemurad .Text = "";
            txtmemursoyad .Text = "";
            txterkekad.Focus();
        
        }
  

        private void FrmEvlilik_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Server=localhost\\SQLEXPRESS;Initial Catalog=202503071;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("Select * from Table_evlilik", baglanti);

            DataSet ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "Table_evlilik");


            dataGridView1.DataSource = ds.Tables["Table_evlilik"];
            baglanti.Close();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

           txtevlilikid .Text  = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
           txterkekad .Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
           txterkeksoyad .Text  = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
           txtkadınad .Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
           txtkadınsoyad .Text  = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
           dateTimePicker1.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
           dateTimePicker2.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
           dateTimePicker3.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
           txtmemurad .Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
           txtmemursoyad .Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Table_evlilik(erkek_ad,erkek_soyad,kadın_ad,kadın_soyad,erkek_dogum_tarihi,kadın_dogum_tarihi,evlilik_tarihi,memur_ad,memur_soyad) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", baglanti);

            komut.Parameters.AddWithValue("@p1", txterkekad .Text);
            komut.Parameters.AddWithValue("@p2", txterkeksoyad .Text);
            komut.Parameters.AddWithValue("@p3", txtkadınad .Text);
            komut.Parameters.AddWithValue("@p4", txtkadınsoyad .Text);
            komut.Parameters.AddWithValue("@p5", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@p6", dateTimePicker2 .Value);
            komut.Parameters.AddWithValue("@p7", dateTimePicker3 .Value);
            komut.Parameters.AddWithValue("@p8", txtmemurad .Text);
            komut.Parameters.AddWithValue("@p9", txtmemursoyad .Text);
          
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kayıt Eklendi.");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete From Table_evlilik where evlilik_id=@k1", baglanti);

            komut.Parameters.AddWithValue("@k1", txtevlilikid .Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kayıt Silindi.");
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("Update Table_evlilik set erkek_ad=@n1,erkek_soyad=@n2,kadın_ad=@n3,kadın_soyad=@n4,erkek_dogum_tarihi=@n5,kadın_dogum_tarihi=@n6,evlilik_tarihi=@n7,memur_ad=@n8,memur_soyad=@n9 where evlilik_id=@n10", baglanti);

            komut.Parameters.AddWithValue("@n1", txterkekad .Text);
            komut.Parameters.AddWithValue("@n2", txterkeksoyad.Text );
            komut.Parameters.AddWithValue("@n3", txtkadınad .Text);
            komut.Parameters.AddWithValue("@n4", txtkadınsoyad .Text );
            komut.Parameters.AddWithValue("@n5", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@n6", dateTimePicker2.Value);
            komut.Parameters.AddWithValue("@n7", dateTimePicker3.Value);
            komut.Parameters.AddWithValue("@n8", txtmemurad .Text);
            komut.Parameters.AddWithValue("@n9", txtmemursoyad .Text);
            komut.Parameters.AddWithValue("@n10", txtevlilikid .Text);
          
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kayıt Güncellendi.");
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Server=localhost\\SQLEXPRESS;Initial Catalog=202503071;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("Select * from Table_evlilik", baglanti);

            DataSet ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "Table_evlilik");


            dataGridView1.DataSource = ds.Tables["Table_evlilik"];
            baglanti.Close();
        
        }

        public void grid_doldur(string sorgu)
        {

            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);

            DataSet ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "Table_evlilik");


            dataGridView1.DataSource = ds.Tables["Table_evlilik"];

            baglanti.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
            try
            {
                if (textBox1.Text != "")
                {

                    if (radioButton1.Checked)
                    {

                        string sorgu = ("select * from Table_evlilik where kadın_ad like '%" + textBox1.Text + "%'");
                        grid_doldur(sorgu);

                    }
                    if(radioButton2.Checked)
                    {
                        string sorgu = ("select * from Table_evlilik where erkek_ad like '%" + textBox1.Text + "%'");
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

