namespace sarafaizi
{
    partial class Form9
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nIGIN_RETURANTDataSet4 = new sarafaizi.NIGIN_RETURANTDataSet4();
            this.personelgirisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.personel_girisTableAdapter = new sarafaizi.NIGIN_RETURANTDataSet4TableAdapters.personel_girisTableAdapter();
            this.kullaniciidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kullaniciadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sifreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIGIN_RETURANTDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelgirisBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "KULLANICI ADINIZ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "SİFRE";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(143, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 22);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(140, 101);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(230, 22);
            this.textBox2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Pink;
            this.button1.Location = new System.Drawing.Point(262, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "KAYIT OL";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kullaniciidDataGridViewTextBoxColumn,
            this.kullaniciadDataGridViewTextBoxColumn,
            this.sifreDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.personelgirisBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(436, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(430, 296);
            this.dataGridView1.TabIndex = 5;
            // 
            // nIGIN_RETURANTDataSet4
            // 
            this.nIGIN_RETURANTDataSet4.DataSetName = "NIGIN_RETURANTDataSet4";
            this.nIGIN_RETURANTDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // personelgirisBindingSource
            // 
            this.personelgirisBindingSource.DataMember = "personel_giris";
            this.personelgirisBindingSource.DataSource = this.nIGIN_RETURANTDataSet4;
            // 
            // personel_girisTableAdapter
            // 
            this.personel_girisTableAdapter.ClearBeforeFill = true;
            // 
            // kullaniciidDataGridViewTextBoxColumn
            // 
            this.kullaniciidDataGridViewTextBoxColumn.DataPropertyName = "kullaniciid";
            this.kullaniciidDataGridViewTextBoxColumn.HeaderText = "kullaniciid";
            this.kullaniciidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.kullaniciidDataGridViewTextBoxColumn.Name = "kullaniciidDataGridViewTextBoxColumn";
            this.kullaniciidDataGridViewTextBoxColumn.ReadOnly = true;
            this.kullaniciidDataGridViewTextBoxColumn.Width = 125;
            // 
            // kullaniciadDataGridViewTextBoxColumn
            // 
            this.kullaniciadDataGridViewTextBoxColumn.DataPropertyName = "kullaniciad";
            this.kullaniciadDataGridViewTextBoxColumn.HeaderText = "kullaniciad";
            this.kullaniciadDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.kullaniciadDataGridViewTextBoxColumn.Name = "kullaniciadDataGridViewTextBoxColumn";
            this.kullaniciadDataGridViewTextBoxColumn.Width = 125;
            // 
            // sifreDataGridViewTextBoxColumn
            // 
            this.sifreDataGridViewTextBoxColumn.DataPropertyName = "sifre";
            this.sifreDataGridViewTextBoxColumn.HeaderText = "sifre";
            this.sifreDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sifreDataGridViewTextBoxColumn.Name = "sifreDataGridViewTextBoxColumn";
            this.sifreDataGridViewTextBoxColumn.Width = 125;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Pink;
            this.button2.Location = new System.Drawing.Point(243, 240);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 50);
            this.button2.TabIndex = 6;
            this.button2.Text = "GİRİŞ SAYFASINA DÖN";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(34, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 296);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PERSONEL KAYIT";
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(924, 340);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form9";
            this.Text = "Form9";
            this.Load += new System.EventHandler(this.Form9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIGIN_RETURANTDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelgirisBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private NIGIN_RETURANTDataSet4 nIGIN_RETURANTDataSet4;
        private System.Windows.Forms.BindingSource personelgirisBindingSource;
        private NIGIN_RETURANTDataSet4TableAdapters.personel_girisTableAdapter personel_girisTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn kullaniciidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kullaniciadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sifreDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}