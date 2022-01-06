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
    public partial class FrmOgrKayit : Form
    {
        public FrmOgrKayit()
        {
            InitializeComponent();
        }

        Sqlbaglanti bgl = new Sqlbaglanti();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //Bölümlerin adlarını serverdan çektik Listeleme Komutu
            
            // selecttensonra neyi istediğimiz from ise nereden çektiğimizi yazyıyoruz
            SqlCommand komut = new SqlCommand("Select BolumAd from Bolumler", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            
            while (oku.Read())
            {
                CmbBolum.Items.Add(oku[0].ToString());
            }

            bgl.baglanti().Close();

            // Boş Odaları Listeleme Komutları
            
            // where != ifadesi sayesinde dolu olan odaları listelemede göstermedik
            SqlCommand komut2 = new SqlCommand("Select OdaNo from Odalar where OdaKapasite != OdaAktif", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                CmbOdaNo.Items.Add(oku2[0].ToString());
            }

            bgl.baglanti().Close();
            
                
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlCommand komutkaydet = new SqlCommand("insert into Ogrenci (OgrAd, OgrSoyad, OgrTC, OgrTel, OgrDogum, OgrBolum, OgrMail, OgrOdaNo, OgrVeliAdSoyad, OgrVeliTel, OgrAdres) values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11)", bgl.baglanti());
                komutkaydet.Parameters.AddWithValue("@p1", TxtOgrAd.Text);
                komutkaydet.Parameters.AddWithValue("@p2", TxtOgrSoyad.Text);
                komutkaydet.Parameters.AddWithValue("@p3", MskTC.Text);
                komutkaydet.Parameters.AddWithValue("@p4", MskTelefon.Text);
                komutkaydet.Parameters.AddWithValue("@p5", MskDogum.Text);
                komutkaydet.Parameters.AddWithValue("@p6", CmbBolum.Text);
                komutkaydet.Parameters.AddWithValue("@p7", TxtMail.Text);
                komutkaydet.Parameters.AddWithValue("@p8", CmbOdaNo.Text);
                komutkaydet.Parameters.AddWithValue("@p9", TxtVeliAdSoyad.Text);
                komutkaydet.Parameters.AddWithValue("@p10", MskVeliTel.Text);
                komutkaydet.Parameters.AddWithValue("@p11", RichAdres.Text);
                komutkaydet.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Kayıt Başarılı");
                

                SqlCommand komut = new SqlCommand("Select Ogrid from Ogrenci ", bgl.baglanti());
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    label16.Text = oku[0].ToString(); 
                }
                bgl.baglanti().Close();



                //Öğrenci Borç Alanı Oluşturma

                SqlCommand komutkaydet2 = new SqlCommand("insert into Borclar (Ogrid,OgrAd,OgrSoyad) values (@b1,@b2,@b3)", bgl.baglanti());
                komutkaydet2.Parameters.AddWithValue("@b1", label16.Text);
                komutkaydet2.Parameters.AddWithValue("@b2", TxtOgrAd.Text);
                komutkaydet2.Parameters.AddWithValue("@b3", TxtOgrSoyad.Text);
                komutkaydet2.ExecuteNonQuery();

                bgl.baglanti().Close();
               

            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!!Lütfen Yeniden Deneyin.");
            }
            //Öğrenci oda Kontenjanı arttırma
            SqlCommand oda = new SqlCommand("update Odalar set  OdaAktif=OdaAktif-1 where OdaNo=@s1 ",bgl.baglanti());

            oda.Parameters.AddWithValue("@s1", CmbOdaNo.Text);
            oda.ExecuteNonQuery();
            bgl.baglanti().Close();
        }
    }
}
//Data Source=LAPTOP-H17HO6C2\SQLEXPRESS;Initial Catalog=YurtOtomasyonu;Integrated Security=True