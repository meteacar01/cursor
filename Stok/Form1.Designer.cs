namespace Stok
{
    partial class Form1
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.basTarih = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.malAdi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bitTarih = new System.Windows.Forms.DateTimePicker();
            this.getir = new System.Windows.Forms.Button();
            this.excel = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.yazdir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(-2, 224);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(877, 578);
            this.dataGridView.TabIndex = 0;
            // 
            // basTarih
            // 
            this.basTarih.CustomFormat = "MM/dd/yyyy";
            this.basTarih.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.basTarih.Location = new System.Drawing.Point(441, 29);
            this.basTarih.Name = "basTarih";
            this.basTarih.Size = new System.Drawing.Size(110, 20);
            this.basTarih.TabIndex = 1;
            this.basTarih.Value = new System.DateTime(2016, 9, 27, 17, 14, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mal Adı";
            // 
            // malAdi
            // 
            this.malAdi.FormattingEnabled = true;
            this.malAdi.Location = new System.Drawing.Point(60, 31);
            this.malAdi.Name = "malAdi";
            this.malAdi.Size = new System.Drawing.Size(268, 21);
            this.malAdi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Başlama Tarihi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(579, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bitiş Tarihi";
            // 
            // bitTarih
            // 
            this.bitTarih.CustomFormat = "MM/dd/yyyy";
            this.bitTarih.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bitTarih.Location = new System.Drawing.Point(658, 28);
            this.bitTarih.Name = "bitTarih";
            this.bitTarih.Size = new System.Drawing.Size(110, 20);
            this.bitTarih.TabIndex = 6;
            // 
            // getir
            // 
            this.getir.Location = new System.Drawing.Point(658, 85);
            this.getir.Name = "getir";
            this.getir.Size = new System.Drawing.Size(110, 37);
            this.getir.TabIndex = 7;
            this.getir.Text = "Kayıtları Getir";
            this.getir.UseVisualStyleBackColor = true;
            this.getir.Click += new System.EventHandler(this.getir_Click);
            // 
            // excel
            // 
            this.excel.Location = new System.Drawing.Point(45, 85);
            this.excel.Name = "excel";
            this.excel.Size = new System.Drawing.Size(119, 37);
            this.excel.TabIndex = 8;
            this.excel.Text = "Excel";
            this.excel.UseVisualStyleBackColor = true;
            this.excel.Click += new System.EventHandler(this.excel_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // yazdir
            // 
            this.yazdir.Location = new System.Drawing.Point(335, 85);
            this.yazdir.Name = "yazdir";
            this.yazdir.Size = new System.Drawing.Size(113, 37);
            this.yazdir.TabIndex = 9;
            this.yazdir.Text = "Yazdır";
            this.yazdir.UseVisualStyleBackColor = true;
            this.yazdir.Click += new System.EventHandler(this.yazdir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 814);
            this.Controls.Add(this.yazdir);
            this.Controls.Add(this.excel);
            this.Controls.Add(this.getir);
            this.Controls.Add(this.bitTarih);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.malAdi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.basTarih);
            this.Controls.Add(this.dataGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DateTimePicker basTarih;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox malAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker bitTarih;
        private System.Windows.Forms.Button getir;
        private System.Windows.Forms.Button excel;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button yazdir;
    }
}

