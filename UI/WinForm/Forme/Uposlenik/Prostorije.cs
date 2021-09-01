using SportskiCentarRS2.WinForm.Helpers;
using SportskiCentarRS2.WinForm.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportskiCentarRS2.WinForm.Forme.Uposlenik
{
    public partial class Prostorije : Form
    {
        private Form otvorenaForma = null;
        public Prostorije()
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
        private async Task OsvjeziTabeluAsync()
        {
            List<ProstorijaVM> prostorije = await ApiClient.GetAsync<List<ProstorijaVM>>("prostorije");
            if (prostorije == null || prostorije.Count == 0)
                return;
            dgv_Prostorije.DataSource = prostorije;
            dgv_Prostorije.Columns["Id"].Visible = false;
            dgv_Prostorije.Columns["Slika"].Visible = false;

        }
        private async void OsvjeziTabelu(object sender, FormClosedEventArgs e)
        {
            await OsvjeziTabeluAsync();
        }
        private async void Prostorije_Load(object sender, EventArgs e)
        {
            await OsvjeziTabeluAsync();
        }

        private void btn_Kreiraj_Click(object sender, EventArgs e)
        {
            if (otvorenaForma != null)
                otvorenaForma.Close();

            ProstorijeEdit frm_ProstorijeEdit = new ProstorijeEdit(0);
            otvorenaForma = frm_ProstorijeEdit;
            otvorenaForma.FormClosed += OsvjeziTabelu;
            frm_ProstorijeEdit.ShowDialog();
        }
        private void IzmjenaOdabranogReda()
        {
            if (otvorenaForma != null)
                otvorenaForma.Close();

            ProstorijeEdit frmProstorijaEdit = new ProstorijeEdit(int.Parse(dgv_Prostorije.SelectedRows[0].Cells["Id"].Value.ToString()));
            otvorenaForma = frmProstorijaEdit;
            otvorenaForma.FormClosed += OsvjeziTabelu;
            frmProstorijaEdit.ShowDialog();
        }
        private void btn_Izmijeni_Click(object sender, EventArgs e)
        {
            IzmjenaOdabranogReda();
        }

        private void dgv_Prostorije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IzmjenaOdabranogReda();
        }

        private async void btn_Obrisi_Click(object sender, EventArgs e)
        {
            var odabranaProstorijaId = int.Parse(dgv_Prostorije.SelectedRows[0].Cells["Id"].Value.ToString());
            (bool uspjesno, string responseString) deleteResult = await ApiClient.DeleteAsync($"prostorije/{odabranaProstorijaId}");
            if (deleteResult.uspjesno)
            {
                MessageBox.Show("Uspješno obrisana prostorija.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await OsvjeziTabeluAsync();
                return;
            }
            MessageBox.Show("Neuspješno brisanje Prostorije.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
