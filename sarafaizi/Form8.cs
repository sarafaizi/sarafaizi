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
    public partial class Form8 : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();

        public Form8()
        {
            InitializeComponent();
        }
        void listele()
        {
            SqlCommand komut = new SqlCommand("select * from STOK1", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();




        }
    
        void urunid()
        {
            SqlCommand komut = new SqlCommand("select * from MENU where urunid=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p2", comboBox1.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlCommand komut = new SqlCommand("insert into stok1(urunid,stokisim,stokmiktar,minstokmiktar,tedarikci_bilgileri)  values (@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p2", comboBox1.Text);
                komut.Parameters.AddWithValue("@p3", comboBox2.Text);
                komut.Parameters.AddWithValue("@p4", textBox2.Text);
                komut.Parameters.AddWithValue("@p5", textBox4.Text);
                komut.Parameters.AddWithValue("@p6", textBox5.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("stok  başarıyla eklendi");

                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("stok eklenemedi" + ex.ToString());
            }
            finally
            {
                bgl.baglanti().Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("delete from STOK1 where stokid=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.ExecuteNonQuery();
            listele();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'nIGIN_RETURANTDataSet4.SIPARISLER' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.sIPARISLERTableAdapter.Fill(this.nIGIN_RETURANTDataSet4.SIPARISLER);
            // TODO: Bu kod satırı 'nIGIN_RETURANTDataSet4.MENU' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.mENUTableAdapter.Fill(this.nIGIN_RETURANTDataSet4.MENU);
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            try
            {
                urunid();
                SqlCommand komut = new SqlCommand("insert into stok1 (urunid,stokisim,stokmiktar,urunadet,kalanstokmiktari,minstokmiktar,tedarikci_bilgileri) values (@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p2", comboBox1.Text);
                komut.Parameters.AddWithValue("@p3", comboBox2.Text);
                komut.Parameters.AddWithValue("@p4", textBox2.Text);
                komut.Parameters.AddWithValue("@p5", comboBox3.Text);
                double a = Convert.ToDouble(textBox2.Text);
                double b = Convert.ToDouble(comboBox3.Text);
                textBox3.Text = Convert.ToString(a - b);
                komut.Parameters.AddWithValue("@p6", textBox3.Text);
                komut.Parameters.AddWithValue("@p7", textBox4.Text);
                komut.Parameters.AddWithValue("@p8", textBox5.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show(comboBox2.Text + ".kontrol edildi ");
                bgl.baglanti().Close();
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("kontrol edilmedi" + ex.ToString());
            }
            finally
            {
                bgl.baglanti().Close();
            }






        }

        private void ANASAYFA(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
