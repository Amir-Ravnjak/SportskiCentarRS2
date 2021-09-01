using SportskiCentarRS2.WinForm.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportskiCentarRS2.WinForm.Forme.Admin
{
    public partial class AdminMain : Form
    {
        private Form trenutnaForma;
        public AdminMain()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleparam = base.CreateParams;
                handleparam.ExStyle |= 0x02000000;
                return handleparam;
            }
        }
        private void tsmi_Korisnici_Click(object sender, EventArgs e)
        {
            if (trenutnaForma != null)
                trenutnaForma.Close();
            var frmKorisnici = new Korisnici();
            frmKorisnici.MdiParent = this;
            frmKorisnici.Dock = DockStyle.Fill;
            trenutnaForma = frmKorisnici;
            trenutnaForma.Show();
        }

        private void tsmi_Izvjestaji_Click(object sender, EventArgs e)
        {
            if (trenutnaForma != null)
                trenutnaForma.Close();
            var frmIzvjestaji = new Izvjestaji();
            frmIzvjestaji.MdiParent = this;
            frmIzvjestaji.Dock = DockStyle.Fill;
            trenutnaForma = frmIzvjestaji;
            trenutnaForma.Show();
        }

        private async void AdminMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            await ApiClient.LogOutAsync();
        }
    }
}
