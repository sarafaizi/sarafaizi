﻿using System;
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
    public partial class Form9 : Form
    {

        sqlbaglantisi bgl = new sqlbaglantisi();

        public Form9()
        {
            InitializeComponent();
        }
        void listele()
        {
            SqlCommand komut = new SqlCommand("select * from personel_giris", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into  personel_giris values (@p2,@p3)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p2",textBox1.Text);
            komut.Parameters.AddWithValue("@p3",textBox2.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("kayıdnız başarılı");

            listele();

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'nIGIN_RETURANTDataSet4.personel_giris' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.personel_girisTableAdapter.Fill(this.nIGIN_RETURANTDataSet4.personel_giris);
            listele ();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1 ();
            form1.Show();
            this.Hide();
        }
    }
}
