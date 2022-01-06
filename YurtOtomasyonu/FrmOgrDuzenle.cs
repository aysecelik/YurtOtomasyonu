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
    public partial class FrmOgrDuzenle : Form
    {
        public FrmOgrDuzenle()
        {
            InitializeComponent();
        }
        public string id,ad,soyad,TC,telefon,dogum,bolum,mail,oda,velibil,velitel,adres;

        private void MskTelefon_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void CmbBolum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MskVeliTel_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        Sqlbaglanti bgl = new Sqlbaglanti();
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Ogrenci set OgrAd=@p2, OgrSoyad=@p3, OgrTC=@p4, OgrTel=@p5, OgrDogum=@p6 ,OgrBolum=@p7 ,OgrMail=@p8, OgrOdaNo=@p9, OgrVeliAdSoyad=@p10 ,OgrVeliTel=@p11 ,OgrAdres=@p12 where Ogrid=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtOgrid.Text);
            komut.Parameters.AddWithValue("@p2", TxtOgrAd.Text);
            komut.Parameters.AddWithValue("@p3", TxtOgrSoyad.Text);
            komut.Parameters.AddWithValue("@p4", MskTC.Text);
            komut.Parameters.AddWithValue("@p5", MskTelefon.Text);
            komut.Parameters.AddWithValue("@p6", MskDogum.Text);
            komut.Parameters.AddWithValue("@p7", CmbBolum.Text);
            komut.Parameters.AddWithValue("@p8", TxtMail.Text);
            komut.Parameters.AddWithValue("@p9", CmbOdaNo.Text);
            komut.Parameters.AddWithValue("@p10", TxtVeliAdSoyad.Text);
            komut.Parameters.AddWithValue("@p11", MskVeliTel.Text);
            komut.Parameters.AddWithValue("@p12", RichAdres.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleme İşleminiz Gerçekleşmiştir.");
          
        }
        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sil = new SqlCommand("delete from Ogrenci where Ogrid=@p1", bgl.baglanti());
            sil.Parameters.AddWithValue("@p1", txtOgrid.Text);
            sil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğrenci Sistemden Silindi.");

            //Öğrenci Silindikten sonra oda kont ayarlaması
            SqlCommand oda = new SqlCommand("update Odalar set OdaAktif=OdaAktif+1 where OdaNo=@a1",bgl.baglanti());
            oda.Parameters.AddWithValue("@a1", CmbOdaNo.Text);
            oda.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void FrmOgrDuzenle_Load(object sender, EventArgs e)
        {
            
            txtOgrid.Text = id;
            TxtOgrAd.Text = ad;
            TxtOgrSoyad.Text = soyad;
            MskTC.Text = TC;
            MskTelefon.Text = telefon;
            MskDogum.Text = dogum;
            CmbBolum.Text = bolum;
            TxtMail.Text = mail;
            CmbOdaNo.Text = oda;
            TxtVeliAdSoyad.Text = velibil;
            MskVeliTel.Text = velitel;
            RichAdres.Text = adres;


        }
    }
}
