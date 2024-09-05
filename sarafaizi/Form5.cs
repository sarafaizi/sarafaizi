using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sarafaizi
{
    public partial class Form5 : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public Form5()
        {
            InitializeComponent();
        }

        void listele()
        {
            SqlCommand komut = new SqlCommand("select * from SIPARISLER", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'nIGIN_RETURANTDataSet4.SIPARISLER' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.sIPARISLERTableAdapter1.Fill(this.nIGIN_RETURANTDataSet4.SIPARISLER);
            // TODO: Bu kod satırı 'nIGIN_RETURANTDataSet2.SIPARISLER' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            //this.sIPARISLERTableAdapter.Fill(this.nIGIN_RETURANTDataSet2.SIPARISLER);
            listele();
            // TODO: Bu kod satırı 'nIGIN_RETURANTDataSet2.MENU' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.mENUTableAdapter.Fill(this.nIGIN_RETURANTDataSet2.MENU);
            // TODO: Bu kod satırı 'nIGIN_RETURANTDataSet2.MASALAR' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.mASALARTableAdapter.Fill(this.nIGIN_RETURANTDataSet2.MASALAR);
            textBox2.Text = DateTime.Now.ToShortDateString();
        }
        void masaid()
        {
            SqlCommand komut = new SqlCommand("select * from MASALAR where masaid=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p2", comboBox1.Text);

        }
        void urunid()
        {
            SqlCommand komut = new SqlCommand("select * from MENU where urunid=@p4", bgl.baglanti());
            komut.Parameters.AddWithValue("@p4", comboBox2.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                masaid();
                urunid();
                SqlCommand komut = new SqlCommand("insert into SIPARISLER (masaid,sipariszamani,urunid,urunadet,toplamtutaR) values (@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
                //komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", comboBox1.Text);
                komut.Parameters.AddWithValue("@p3", textBox2.Text);
                komut.Parameters.AddWithValue("@p4", comboBox2.Text);
                komut.Parameters.AddWithValue("@p5", textBox3.Text);
                double a=Convert.ToDouble(textBox3.Text);
                double b=Convert.ToDouble(comboBox3.Text);
                textBox4.Text =Convert.ToString(a*b);
                komut.Parameters.AddWithValue("@p6", textBox4.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("masanız başarıyla eklendi");

                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("masa eklenemedi" + ex.ToString());
            }
            finally
            {
                bgl.baglanti().Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                masaid();
                urunid();
                SqlCommand komut = new SqlCommand("update SIPARISLER set masaid=@p1,sipariszamani=@p2,urunid=@p3,urunadet=@p4,toplamtutar=@p5 where siparisid=@p6", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", comboBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                komut.Parameters.AddWithValue("@p3", comboBox2.Text);
                komut.Parameters.AddWithValue("@p4", textBox3.Text);
                double a = Convert.ToDouble(textBox3.Text);
                double b = Convert.ToDouble(comboBox3.Text);
                textBox4.Text = Convert.ToString(a * b);
                komut.Parameters.AddWithValue("@p5", textBox4.Text);
                komut.Parameters.AddWithValue("@p6", textBox1.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show(textBox2.Text + ". siparişiniz başarıyla güncellendi");
                bgl.baglanti().Close();
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("güncellenmedi" + ex.ToString());
            }
            finally
            {
                bgl.baglanti().Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            //comboBox3.Text=dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();


        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("delete from SIPARISLER where siparisid=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.ExecuteNonQuery();
            listele();
        }
       
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            listele();
            try {
            SqlCommand komut = new SqlCommand("select * from SIPARISLER WHERE siparisid LIKE '%" + comboBox4.Text + "%'", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            bgl.baglanti().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            listele();
            SqlCommand komut = new SqlCommand("select * from MASALAR WHERE masaid LIKE '%" + comboBox5.Text + "%'", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            bgl.baglanti().Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text= dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            MessageBox.Show("MASA"+dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString());
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox2.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBox3.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            MessageBox.Show(dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString());
        }
    }
}
