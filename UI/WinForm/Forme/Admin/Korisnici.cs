using SportskiCentarRS2.WinForm.Helpers;
using SportskiCentarRS2.WinForm.Models;
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
    public partial class Korisnici : Form
    {
        private Form otvorenaForma = null;
        public Korisnici()
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
        private async void OsvjeziTabele(object sender, FormClosedEventArgs e)
        {
            await OsvjeziTabeleAsync();
        }
        private async Task OsvjeziTabeleAsync()
        {
            List<KorisnikIndexVM> korisnici = await ApiClient.GetAsync<List<KorisnikIndexVM>>($"users/all");
            if (korisnici == null)
                return;
            dgv_Administratori.DataSource = korisnici.Where(x => x.KorisnickaUloga == "Admin").ToList();
            dgv_Administratori.Columns["Id"].Visible = false;
            dgv_Administratori.Columns["KorisnickaUloga"].Visible = false;

            dgv_Uposlenici.DataSource = korisnici.Where(x => x.KorisnickaUloga == "Uposlenik").ToList();
            dgv_Uposlenici.Columns["Id"].Visible = false;
            dgv_Uposlenici.Columns["KorisnickaUloga"].Visible = false;


            dgv_Klijenti.DataSource = korisnici.Where(x => x.KorisnickaUloga == "Klijent").ToList();
            dgv_Klijenti.Columns["Id"].Visible = false;
            dgv_Klijenti.Columns["KorisnickaUloga"].Visible = false;
        }
        private async void Korisnici_Load(object sender, EventArgs e)
        {
            await OsvjeziTabeleAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (otvorenaForma != null)
                otvorenaForma.Close();

            KorisnikEdit frm_korisnikEdit = new KorisnikEdit(0);
            otvorenaForma = frm_korisnikEdit;
            otvorenaForma.FormClosed += OsvjeziTabele;
            frm_korisnikEdit.ShowDialog();
        }

        private void dgv_Administratori_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditOdabranogKorisnika(int.Parse(dgv_Administratori.SelectedRows[0].Cells["Id"].Value.ToString()));
        }
        private void EditOdabranogKorisnika(int korisnikId)
        {
            if (otvorenaForma != null)
                otvorenaForma.Close();

            KorisnikEdit frm_korisnikEdit = new KorisnikEdit(korisnikId);
            otvorenaForma = frm_korisnikEdit;
            otvorenaForma.FormClosed += OsvjeziTabele;
            frm_korisnikEdit.ShowDialog();
        }

        private void btn_Izmijeni_Click(object sender, EventArgs e)
        {
            switch (tabmenu_Korisnici.SelectedTab.Name)
            {
                case "tab_Administratori":
                    EditOdabranogKorisnika(int.Parse(dgv_Administratori.SelectedRows[0].Cells["Id"].Value.ToString()));
                    break;
                case "tab_Uposlenici":
                    EditOdabranogKorisnika(int.Parse(dgv_Uposlenici.SelectedRows[0].Cells["Id"].Value.ToString()));
                    break;
                case "tab_Klijenti":
                    EditOdabranogKorisnika(int.Parse(dgv_Klijenti.SelectedRows[0].Cells["Id"].Value.ToString()));
                    break;
                default:
                    break;
            }
        }

        private void dgv_Uposlenici_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditOdabranogKorisnika(int.Parse(dgv_Uposlenici.SelectedRows[0].Cells["Id"].Value.ToString()));
        }

        private void dgv_Klijenti_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditOdabranogKorisnika(int.Parse(dgv_Klijenti.SelectedRows[0].Cells["Id"].Value.ToString()));
        }

        private void dgv_Administratori_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        private async Task ObrisiOdabranogKorisnika(int korisnikId)
        {
            (bool uspjesno, string responseString) deleteResult = await ApiClient.DeleteAsync($"users/{korisnikId}");
            if (deleteResult.uspjesno)
            {
                MessageBox.Show("Uspješno obrisan korisnik.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await OsvjeziTabeleAsync();
                return;
            }
            MessageBox.Show("Neuspješno brisanje korisnka.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private async void btn_Obrisi_Click(object sender, EventArgs e)
        {
            var potvrda = MessageBox.Show("Da li se sigurni da želite obrisati korisnika.\r\nBrisanjem korisnika brišete i historiju njegovih podataka.", "BRISANJE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (potvrda == DialogResult.No)
                return;
            switch (tabmenu_Korisnici.SelectedTab.Name)
            {
                case "tab_Administratori":
                    await ObrisiOdabranogKorisnika(int.Parse(dgv_Administratori.SelectedRows[0].Cells["Id"].Value.ToString()));
                    break;
                case "tab_Uposlenici":
                    await ObrisiOdabranogKorisnika(int.Parse(dgv_Uposlenici.SelectedRows[0].Cells["Id"].Value.ToString()));
                    break;
                case "tab_Klijenti":
                    await ObrisiOdabranogKorisnika (int.Parse(dgv_Klijenti.SelectedRows[0].Cells["Id"].Value.ToString()));
                    break;
                default:
                    break;
            }
        }
    }
}
