using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtOtomasyonu
{
    public partial class FrmAdminGirisi : Form
    {
        public FrmAdminGirisi()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtKullanıcıAdı.Text == "yurtotosist" && txtSifre.Text == "123456")
            {
                FrmAnaForm fr = new FrmAnaForm();
                fr.Show();

            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız.");
            }

        }

        private void FrmAdminGirisi_Load(object sender, EventArgs e)
        {

        }
    }
}
