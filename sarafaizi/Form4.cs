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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sarafaizi
{
    public partial class Form4 : Form
    {

        sqlbaglantisi bgl = new sqlbaglantisi();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand komut = new SqlCommand("insert into MENU (isim,fiyat,kategori,aciklama) values (@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                komut.Parameters.AddWithValue("@p3",textBox3.Text);
                komut.Parameters.AddWithValue("@p4", comboBox1.Text);
                komut.Parameters.AddWithValue("@p5", textBox4.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("menüye ürün başarıyla eklendi");

                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ürün eklenemedi eklenemedi" + ex.ToString());
            }
            finally
            {
                bgl.baglanti().Close();
            }
        }
        void listele()
        {
            SqlCommand komut = new SqlCommand("select * from MENU", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("delete from MENU where urunid=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.ExecuteNonQuery();
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " +ex.ToString());
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); // urunid
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); // isim
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); // fiyat
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(); // kategori
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(); // aciklama
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
            listele();
            SqlCommand komut = new SqlCommand("select * from MENU WHERE urunid LIKE '%"+textBox5.Text+"%'", bgl.baglanti());
            SqlDataAdapter da= new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
            bgl.baglanti().Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            listele();
            SqlCommand komut = new SqlCommand("select * from MENU WHERE kategori LIKE '%" + comboBox2.Text + "%'", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            bgl.baglanti().Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update MENU set isim=@p1,fiyat=@p2,kategori=@p3, aciklama=@p4 where urunid=@p5", bgl.baglanti());
                komut.Parameters.AddWithValue("@p5", textBox1.Text);
                komut.Parameters.AddWithValue("@p1", textBox2.Text);
                komut.Parameters.AddWithValue("@p2", textBox3.Text);
                komut.Parameters.AddWithValue("@p3", comboBox1.Text);
                komut.Parameters.AddWithValue("@p4", textBox4.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show(textBox1.Text + ". urun başarıyla güncellendi");
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

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
