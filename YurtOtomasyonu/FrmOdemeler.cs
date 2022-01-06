using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YurtOtomasyonu
{
    public partial class FrmOdemeler : Form
    {
        public FrmOdemeler()
        {
            InitializeComponent();
        }
        Sqlbaglanti bgl = new Sqlbaglanti();
        private void FrmOdemeler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonuDataSet2.Borclar' table. You can move, or remove it, as needed.
            this.borclarTableAdapter.Fill(this.yurtOtomasyonuDataSet2.Borclar);
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            string id, kalanborc, ograd, ogrsoyad;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ograd = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            ogrsoyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            kalanborc = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            txtKalanBorc.Text = kalanborc;

            TxtOgrid.Text = id;
            textBox1.Text = ograd;
            textBox2.Text = ogrsoyad;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            // bu kısımda ödeme aldığımız miktarı kalan borçtan düştük
            int odenen, kalan, yeniborc;
            odenen = Convert.ToInt16(TxtOdenen.Text);
            kalan = Convert.ToInt16(txtKalanBorc.Text);
            yeniborc = kalan - odenen;
            txtKalanBorc.Text = yeniborc.ToString();


            //Kalan borcu güncelleme işlemi


            SqlCommand degistir = new SqlCommand("update Borclar set OgrKalanBorc=@a1 where Ogrid=@a2 ",bgl.baglanti());
            degistir.Parameters.AddWithValue("@a2",TxtOgrid.Text);
            degistir.Parameters.AddWithValue("@a1",txtKalanBorc.Text);
            degistir.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Borcunuz güncellendi.");
            this.borclarTableAdapter.Fill(this.yurtOtomasyonuDataSet2.Borclar);
            

            //Kasa Tablosuna Ekleme
            SqlCommand komut2 = new SqlCommand("insert into Kasa (OdemeAy,OdemeMiktar) values (@a1,@a2)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@a1", TxtOdenenAy.Text);
            komut2.Parameters.AddWithValue("@a2", TxtOdenen.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            TxtOdenen.Clear();






        }
    }
}
