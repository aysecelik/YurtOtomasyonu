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
    public partial class FrmGiderGuncelleme : Form
    {
        public FrmGiderGuncelleme()
        {
            InitializeComponent();
        }
        Sqlbaglanti bgl = new Sqlbaglanti();
        public string elektrik, su, dogalgaz, internet, gida, personel, diger,id;

        private void FrmGiderGuncelleme_Load(object sender, EventArgs e)
        {
            textBox1.Text = id;
            Txtdiger.Text = diger;
            TxtDogalgaz.Text = dogalgaz;
            TxtElektrik.Text = elektrik;
            TxtGida.Text = gida;
            TxtInternet.Text = internet;
            Txtpersonel.Text = personel;
            TxtSu.Text = su;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

            SqlCommand guncelle = new SqlCommand("update Giderler set Elektrik=@s1,Su=@s2,Dogalgaz=@s3,internet=@s4,Gıda=@s5,Personel=@s6,Diger=@s7 where OdemeID=@s8", bgl.baglanti());
            guncelle.Parameters.AddWithValue("@s8", textBox1.Text);
            guncelle.Parameters.AddWithValue("@s1", TxtElektrik.Text);
            guncelle.Parameters.AddWithValue("@s2", TxtSu.Text);
            guncelle.Parameters.AddWithValue("@s3", TxtDogalgaz.Text);
            guncelle.Parameters.AddWithValue("@s4", TxtInternet.Text);
            guncelle.Parameters.AddWithValue("@s5", TxtGida.Text);
            guncelle.Parameters.AddWithValue("@s6", Txtpersonel.Text);
            guncelle.Parameters.AddWithValue("@s7", Txtdiger.Text);
            guncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleme işleminiz gerçekleşmiştir.");



        }
    }
}
