using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sarafaizi
{
    public partial class Form6 : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'nIGIN_RETURANTDataSet4.SIPARISLER' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.sIPARISLERTableAdapter1.Fill(this.nIGIN_RETURANTDataSet4.SIPARISLER);
            // TODO: Bu kod satırı 'nIGIN_RETURANTDataSet4.MENU' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.mENUTableAdapter.Fill(this.nIGIN_RETURANTDataSet4.MENU);
            // TODO: Bu kod satırı 'nIGIN_RETURANTDataSet4.MASALAR' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.mASALARTableAdapter1.Fill(this.nIGIN_RETURANTDataSet4.MASALAR);
            // TODO: Bu kod satırı 'nIGIN_RETURANTDataSet4.SATIS' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.sATISTableAdapter.Fill(this.nIGIN_RETURANTDataSet4.SATIS);
            // TODO: Bu kod satırı 'nIGIN_RETURANTDataSet3.SIPARISLER' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.sIPARISLERTableAdapter.Fill(this.nIGIN_RETURANTDataSet3.SIPARISLER);
            // TODO: Bu kod satırı 'nIGIN_RETURANTDataSet3.MASALAR' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.mASALARTableAdapter.Fill(this.nIGIN_RETURANTDataSet3.MASALAR);

            listele();
        }

        void listele()
        {
            SqlCommand komut = new SqlCommand("select * from SATIS", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            
        }

        void masaid()
        {
            SqlCommand komut = new SqlCommand("select * from MASALAR where masaid=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);

        }
        void siparisid()
        {
            SqlCommand komut = new SqlCommand("select * from SIPARISLER where siparisid=@p3", bgl.baglanti());
            komut.Parameters.AddWithValue("@p3", comboBox3.Text);

        }


        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                masaid();
                siparisid();
                SqlCommand komut = new SqlCommand("insert into SATIS (masaid,odemeturu,siparisid,odencek_tutar) values (@p1,@p2,@p3,@p4)", bgl.baglanti());

                komut.Parameters.AddWithValue("@p1", comboBox1.Text);
                komut.Parameters.AddWithValue("@p2", comboBox2.Text);
                komut.Parameters.AddWithValue("@p3", comboBox3.Text);
                komut.Parameters.AddWithValue("@p4", comboBox4.Text);
                // komut.ExecuteNonQuery();

                SqlCommand komutSiparisSil = new SqlCommand("DELETE FROM SIPARISLER WHERE siparisid=@p3", bgl.baglanti());
                komutSiparisSil.Parameters.AddWithValue("@p3", comboBox3.Text);
                komutSiparisSil.ExecuteNonQuery();
                MessageBox.Show("Ödeme başarıyla kaydedildi " + comboBox3.Text + ". sipariş id siparişlerden silindi.");

                listele();
                listele1();

                //label6.Visible = true;
                //label6.Text=
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ödeme kaydedilemedi:" + ex.ToString());
            }
            finally
            {
                bgl.baglanti().Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*SqlCommand komut = new SqlCommand("delete from SIPARISLAR where siparisid=@p1", bgl.baglanti());
            SqlCommand komut2 = new SqlCommand("")
            if (@p1==)
            {

            }
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.ExecuteNonQuery();
            listele();*/
            Form3 form3 = new Form3();
            form3.Show();
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox3.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();

        }
        void listele1()
        {
            SqlCommand komut = new SqlCommand("select * from SIPARISLER", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from SATIS where odemeid=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p5", textBox1.Text);
            komut.ExecuteNonQuery();
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

        }
    }
}
