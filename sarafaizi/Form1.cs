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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl=new sqlbaglantisi();
        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlCommand komut=new SqlCommand("select * from personel_giris where kullaniciad=@P1 and sifre=@P2",bgl.baglanti());

            komut.Parameters.AddWithValue("@P1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@P2",textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                Form3 form3= new Form3();
                form3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("kullanıcı adı veya şifre hatalı");
                Application.Exit();
            }
            bgl.baglanti();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from yonetici_giris where kullaniciad=@p1 and sifre=@p2", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form7 form7 = new Form7();
                form7.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("kullanıcı adı veya şifre hatalı");
                Application.Exit();
            }
            bgl.baglanti();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show(); this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 form10= new Form10();
            form10.Show(); this.Hide();
        }

        private void Form1_BackgroundImageChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
