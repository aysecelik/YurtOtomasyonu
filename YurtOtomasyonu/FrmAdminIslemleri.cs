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
    public partial class FrmAdminIslemleri : Form
    {
        public FrmAdminIslemleri()
        {
            InitializeComponent();
        }
        Sqlbaglanti bgl = new Sqlbaglanti();
        private void FrmAdminIslemleri_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonuDataSet5.Admin' table. You can move, or remove it, as needed.
            this.adminTableAdapter.Fill(this.yurtOtomasyonuDataSet5.Admin);

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Admin (YoneticiAd,YoneticiSifre) values (@a1,@a2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", txtKullanıcıAdı.Text);
            komut.Parameters.AddWithValue("@a2", txtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yönetici Eklendi.");
            this.adminTableAdapter.Fill(this.yurtOtomasyonuDataSet5.Admin);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string id, ad, sifre;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            sifre = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            Txtyöneticiid.Text = id;
            txtKullanıcıAdı.Text = ad;
            txtSifre.Text = sifre;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("delete from Admin where YoneticiID=@a1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@a1", Txtyöneticiid.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yönetici Silindi.");
            this.adminTableAdapter.Fill(this.yurtOtomasyonuDataSet5.Admin);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Admin set YoneticiAd=@a2, YoneticiSifre=@a3 where YoneticiID=@a1", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", Txtyöneticiid.Text);
            komut.Parameters.AddWithValue("@a2", txtKullanıcıAdı.Text);
            komut.Parameters.AddWithValue("@a3", txtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();

            this.adminTableAdapter.Fill(this.yurtOtomasyonuDataSet5.Admin);
        }
    }
}
