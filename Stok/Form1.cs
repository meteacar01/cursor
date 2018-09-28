
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Stok
{
    public partial class Form1 : Form
    {
        Excel.Application xlApp = new Excel.Application();
        // connectionStrings kısmı (app.config içinde tanımlı olan connectiona bağlanıyorum)
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DbEntities"].ConnectionString);
        public Form1()
        {
            InitializeComponent();
            List(null,0,0); // from ilk çağrıldığında tüm kayıtları çekmek için yapılmıştır.
            FillCombobox(); // form ilk çağrıldığında kullanıcı mal adi ni seçebilmesi için comboboxa dolduruyorum
        }
        public void List(string malKodu, int basTarih, int bitTarih)
        {
            conn.Open();
            string query = "exec [dbo].[StokProcedure]'"+malKodu+"','"+ basTarih + "','"+ bitTarih + "'"; 
            SqlCommand comd = new SqlCommand(query, conn); 
            SqlDataAdapter da = new SqlDataAdapter(comd);
            
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt; // gelen kayıtların gridview e aktarılması
            conn.Close();
        
        }
        public void FillCombobox()
        {
            conn.Open();
            string query = "select MalKodu, MalAdi from dbo.STK "; // stk tablosundan malkodu ve maladi alanlarını cekiyorum
            SqlCommand comd = new SqlCommand(query, conn);

            SqlDataAdapter da = new SqlDataAdapter(comd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            malAdi.DisplayMember = "MalAdi"; //mal adi alanını comboboxa ekliyorum. kullanıcı mal adi kismini seçip filtreleme yapacak
            malAdi.ValueMember = "MalKodu"; // kullanıcın seçtiği maladi nin karşılığı olan malkodunu parametre olarak procedure gönderilecek 
            malAdi.DataSource = ds.Tables[0];

            conn.Close();

        }
        
        private void getir_Click(object sender, EventArgs e)
        { 
            // Filtereleme işlemi parametreleri gönderip yeniden proceduru çalıştırıyorum
            List(malAdi.SelectedValue.ToString(), Convert.ToInt32(basTarih.Value.Date.ToOADate()), Convert.ToInt32(bitTarih.Value.Date.ToOADate()));
        }
        private void excel_Click(object sender, EventArgs e)
        {
            //excele aktarmak için kullanılan kısım 

            Excel.Workbook xlWorkBook;

            Excel.Worksheet xlWorkSheet;

            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet = xlWorkBook.ActiveSheet;

            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                xlWorkSheet.Cells[1, i + 1] = dataGridView.Columns[i].HeaderText;
            }
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    if (dataGridView.Rows[i].Cells[j].Value != null)
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }
            
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveDialog.FilterIndex = 2;

            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                xlWorkBook.SaveAs(saveDialog.FileName);
                MessageBox.Show("Başarıyla Kaydedildi", "Kayıt Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //yazdirma işlemi
            Bitmap bm = new Bitmap(this.dataGridView.Width, this.dataGridView.Height);
            dataGridView.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView.Width, this.dataGridView.Height));
            e.Graphics.DrawImage(bm,0,0); 
        }

        private void yazdir_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }
    }
}
