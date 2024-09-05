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
    public partial class Form2 : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public Form2()
        {
            InitializeComponent();
        }
        //sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            SqlCommand komut = new SqlCommand("select * from MASALAR", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
       
        private void Form2_Load(object sender, EventArgs e)
        {
            listele();
        }

        //ekle buttonu
        private void button1_Click_1(object sender, EventArgs e)
        {
            
            try
            {
              
                SqlCommand komut = new SqlCommand("insert into MASALAR (kapasite,durum,rezervasyondurumu) values (@p1,@p2,@p3)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", comboBox1.Text);
                komut.Parameters.AddWithValue("@p3", comboBox2.Text);
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

        //sil buttonu
        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("delete from MASALAR where masaid=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.ExecuteNonQuery();
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update MASALAR set kapasite=@p1,durum=@p2,rezervasyondurumu=@p3 where masaid=@p4",bgl.baglanti());
                komut.Parameters.AddWithValue("@p4", textBox2.Text);
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", comboBox1.Text);
                komut.Parameters.AddWithValue("@p3", comboBox2.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show(textBox2.Text + ". masa başarıyla güncellendi");
                bgl.baglanti().Close();
                listele();
            }
            catch(Exception ex)
            {
                MessageBox.Show("güncellenmedi"+ex.ToString());
            }
            finally
            {
                bgl.baglanti().Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

        }

        private void Çıkış(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
