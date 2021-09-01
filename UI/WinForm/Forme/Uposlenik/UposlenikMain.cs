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

namespace SportskiCentarRS2.WinForm.Forme.Uposlenik
{
    public partial class UposlenikMain : Form
    {
        private Form trenutnaForma;
        public UposlenikMain()
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
        private void prostorijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trenutnaForma != null)
                trenutnaForma.Close();
            var frmProstorije = new Prostorije();
            frmProstorije.MdiParent = this;
            frmProstorije.Dock = DockStyle.Fill;
            trenutnaForma = frmProstorije;
            trenutnaForma.Show();
        }

        private void opremaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trenutnaForma != null)
                trenutnaForma.Close();
            var frmOprema = new Oprema();
            frmOprema.MdiParent = this;
            frmOprema.Dock = DockStyle.Fill;
            trenutnaForma = frmOprema;
            trenutnaForma.Show();
        }

        private void terminiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trenutnaForma != null)
                trenutnaForma.Close();
            var frmTermini = new Termini();
            frmTermini.MdiParent = this;
            frmTermini.Dock = DockStyle.Fill;
            trenutnaForma = frmTermini;
            trenutnaForma.Show();
        }

        private void rezervacijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trenutnaForma != null)
                trenutnaForma.Close();
            var frmRezervacije = new Rezervacije();
            frmRezervacije.MdiParent = this;
            frmRezervacije.Dock = DockStyle.Fill;
            trenutnaForma = frmRezervacije;
            trenutnaForma.Show();
        }

        private async void UposlenikMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            await ApiClient.LogOutAsync();
        }
    }
}
