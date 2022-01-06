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
    public partial class FrmGider : Form
    {
        public FrmGider()
        {
            InitializeComponent();
        }
        Sqlbaglanti bgl = new Sqlbaglanti();
        private void FrmGider_Load(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand kaydet = new SqlCommand("insert into Giderler (Elektrik,Su,Dogalgaz,internet,Gıda,Personel,Diger) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7)", bgl.baglanti());
            kaydet.Parameters.AddWithValue("@a1", TxtElektrik.Text);
            kaydet.Parameters.AddWithValue("@a2", TxtSu.Text);
            kaydet.Parameters.AddWithValue("@a3", TxtDogalgaz.Text);
            kaydet.Parameters.AddWithValue("@a4", TxtInternet.Text);
            kaydet.Parameters.AddWithValue("@a5", TxtGida.Text);
            kaydet.Parameters.AddWithValue("@a6", Txtpersonel.Text);
            kaydet.Parameters.AddWithValue("@a7", Txtdiger.Text);
            kaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("İşleminiz başarıyla gerçekleşmiştir.");
            Txtdiger.Clear();
            TxtDogalgaz.Clear();
            TxtElektrik.Clear();
            TxtGida.Clear();
            TxtInternet.Clear();
            Txtpersonel.Clear();
            TxtSu.Clear();


        }
    }
}
