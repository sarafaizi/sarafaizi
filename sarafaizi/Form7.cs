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
    public partial class Form7 : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();

        public Form7()
        {
            InitializeComponent();
        }
        void listele()
        {
            SqlCommand komut = new SqlCommand("select * from rapor", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            try
            {

                SqlCommand komut = new SqlCommand("insert into RAPOR (raportarihi) values (@p2)", bgl.baglanti());
                //komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                /*komut.Parameters.AddWithValue("@p3", textBox3.Text);
                komut.Parameters.AddWithValue("@p4", textBox4.Text);*/
                /*
                komut.ExecuteNonQuery();
                MessageBox.Show("rapor oluşturuldu ve kaydedildi");

                listele();
                SqlCommand komut1 = new SqlCommand("SELECT SUM(toplamtutar) AS ToplamSatis from SATIS where  sipariszamani= @p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p2", textBox3.Text);

                SqlDataAdapter da = new SqlDataAdapter(komut1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                komut1.ExecuteNonQuery();

                SqlCommand komut2 = new SqlCommand("select COUNT(siparisid) AS IslemSayisi FROM SIPARISLER ");
                SqlDataAdapter da1 = new SqlDataAdapter(komut2);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                komut2.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show("rapor eklenemedi" + ex.ToString());
            }
            finally
            {
                bgl.baglanti().Close();
            }*/
            try
            {

                


                SqlCommand komut3 = new SqlCommand("SELECT SUM(odencek_tutar) from SATIS",bgl.baglanti());
                SqlDataReader dr = komut3.ExecuteReader();
                while(dr.Read())
                {
                    textBox3.Text = dr[0].ToString();

                }
                bgl.baglanti().Close();

                SqlCommand komut4 = new SqlCommand("SELECT COUNT(siparisid) FROM SIPARISLER", bgl.baglanti());
                SqlDataReader dr1=komut4.ExecuteReader();
                while(dr1.Read())
                {
                    textBox4.Text = dr1[0].ToString();

                }
                bgl.baglanti().Close();
                SqlCommand komut = new SqlCommand("insert into RAPOR (raportarihi,toplamsatıs,islemsayisi) values (@p1,@p2,@p3)", bgl.baglanti());
                //komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p1", textBox2.Text);
                komut.Parameters.AddWithValue("@p2", textBox3.Text);
                komut.Parameters.AddWithValue("@p3", textBox4.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("rapor oluşturuldu ve kaydedildi");

                listele();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Z Raporu oluşturulamadı: " + ex.ToString());
            }
            finally
            {
                bgl.baglanti().Close();
            }

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'nIGIN_RETURANTDataSet4.SIPARISLER' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.sIPARISLERTableAdapter1.Fill(this.nIGIN_RETURANTDataSet4.SIPARISLER);
            // TODO: Bu kod satırı 'nIGIN_RETURANTDataSet3.SIPARISLER' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.sIPARISLERTableAdapter.Fill(this.nIGIN_RETURANTDataSet3.SIPARISLER);
            listele();
            textBox2.Text= DateTime.Now.ToShortDateString();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            SqlCommand komut = new SqlCommand("delete from RAPOR where raporid=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            /*komut.Parameters.AddWithValue("@p2", textBox3.Text);
            komut.Parameters.AddWithValue("@p3", textBox4.Text);*/
            komut.ExecuteNonQuery();
            MessageBox.Show("rapor silindi");
            listele();
            bgl.baglanti().Close();
            
        }

        private void Anasayfa(object sender, EventArgs e)
        {
            Form3 from3 = new Form3();
            from3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
