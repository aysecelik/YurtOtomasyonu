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
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }

        Sqlbaglanti bgl = new Sqlbaglanti();

        private void FrmBolumler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonuDataSet.Bolumler' table. You can move, or remove it, as needed.
            this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDataSet.Bolumler);
            // bunu porgram kendisi üretti ve bunu bolumekle kısmında kullandık yenileme ve bilgileri getirmede kullandık

        }

        private void PcbBolumEkle_Click(object sender, EventArgs e)
        {
            try
            {
               
                SqlCommand komut = new SqlCommand("insert into Bolumler(BolumAd) values (@p1)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtBolumAd.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bölüm Eklendi");
                //Bu kod birliği sayesinde sayfayı yenilemeden datagrid üzerinde bölümü anında görebilidik
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDataSet.Bolumler);

            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!Yeniden Deneyiniz.");
            }
        }

        private void PcbBolumSil_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlCommand komut2 = new SqlCommand("delete from Bolumler where BolumID=@p1 ", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtBolumID.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Silme İşlemi Gerçekleşti");
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDataSet.Bolumler);
            }
            catch (Exception)
            {

                MessageBox.Show("HATA, İşlem Gerçekleşmedi.");
            }
        }
        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // bu kod bütünlüğü sayesinde tıkladığımız verinin textboxlara yazılmasını sağladık
            string id, bolumad;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            bolumad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

            TxtBolumID.Text = id;
            TxtBolumAd.Text = bolumad;

        }

        private void PcbBolumDuzenle_Click(object sender, EventArgs e)
        {
            try
            {

                
                SqlCommand komut3 = new SqlCommand("update Bolumler Set BolumAd=@p1 where BolumID=@p2", bgl.baglanti());
                komut3.Parameters.AddWithValue("@p2", TxtBolumID.Text);
                komut3.Parameters.AddWithValue("@p1", TxtBolumAd.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme Gerçeleşti.");

                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDataSet.Bolumler);

            }
            catch (Exception)
            {

                MessageBox.Show("Hata");
            }
        }
    }
}
