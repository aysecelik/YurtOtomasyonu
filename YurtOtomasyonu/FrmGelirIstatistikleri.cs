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
    public partial class FrmGelirIstatistikleri : Form
    {
        public FrmGelirIstatistikleri()
        {
            InitializeComponent();
        }
        Sqlbaglanti bgl = new Sqlbaglanti();
        private void FrmGelirIstatistikleri_Load(object sender, EventArgs e)
        {
            //Kasadaki toplam para
            SqlCommand komut =new SqlCommand ("Select Sum (OdemeMiktar) from Kasa", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read
                ())
            {
                lblPara.Text = oku[0].ToString()+" TL";
            }
            bgl.baglanti().Close();


            //Tekrarsız olarak Ayları Listeleme
            SqlCommand komut2 = new SqlCommand("Select distinct(OdemeAy)from Kasa", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while(oku2.Read())
            {
                comboBox1.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();

            ////Aylık kazanç manuel 
            //this.chart1.Series["Aylık"].Points.AddY(15);
            //this.chart1.Series["Aylık"].Points.AddY(22);
            ////addxy sayesinde sütuna adlandırma yaptırabildik.
            ///
            //this.chart1.Series["Aylık"].Points.AddXY("Mayıs",13);
            //Grafiklere veri tabanından veri çekme
            SqlCommand grafik = new SqlCommand("select OdemeAy,sum(OdemeMiktar) from Kasa group by OdemeAy", bgl.baglanti());
            SqlDataReader okug = grafik.ExecuteReader();
            while (okug.Read())
            {
                this.chart1.Series["Aylık"].Points.AddXY(okug[0],okug[1]);
            }
            bgl.baglanti().Close();
 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select sum(OdemeMiktar)from Kasa where OdemeAy=@a1", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", comboBox1.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblsecilenay.Text = oku[0].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
