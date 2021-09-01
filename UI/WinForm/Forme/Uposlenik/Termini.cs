using SportskiCentarRS2.WinForm.Helpers;
using SportskiCentarRS2.WinForm.Models;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportskiCentarRS2.WinForm.Forme.Uposlenik
{
    public partial class Termini : Form
    {
        private Form otvorenaForma = null;
        public Termini()
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
            PaginatedList<TerminVM> terminiPaginated = await ApiClient.GetAsync<PaginatedList<TerminVM>>($"termini?PageNumber={(int)nud_TrenutnaStranica.Value}&Slobodan=true");
            if (terminiPaginated == null)
            {
                nud_TrenutnaStranica.Visible = false;
                btn_Sljedeca.Visible = false;
                btn_Prethodna.Visible = false;
                return;
            }
            if (terminiPaginated.TotalPages == 1)
                nud_TrenutnaStranica.Visible = false;
            nud_TrenutnaStranica.Value = terminiPaginated.PageIndex;
            nud_TrenutnaStranica.Minimum = 1;
            
            nud_TrenutnaStranica.Maximum = terminiPaginated.TotalPages;
            btn_Prethodna.Visible = terminiPaginated.HasPreviousPage;
            btn_Sljedeca.Visible = terminiPaginated.HasNextPage;

            dgv_Termini.DataSource = terminiPaginated.Items;
            dgv_Termini.Columns["Id"].Visible = false;
            dgv_Termini.Columns["ProstorijaId"].Visible = false;
            dgv_Termini.Columns["Slobodan"].Visible = false;
        }

        private async void btn_Sljedeca_Click(object sender, System.EventArgs e)
        {
            nud_TrenutnaStranica.Value += 1;
            await OsvjeziTabeluAsync();
        }

        private async void btn_Prethodna_Click(object sender, System.EventArgs e)
        {
            nud_TrenutnaStranica.Value -= 1;
            await OsvjeziTabeluAsync();
        }

        private async void nud_TrenutnaStranica_ValueChanged(object sender, System.EventArgs e)
        {
            await OsvjeziTabeluAsync();
        }

        private async void Termini_Load(object sender, System.EventArgs e)
        {
            await OsvjeziTabeluAsync();
        }
        private async void OsvjeziTabelu(object sender, FormClosedEventArgs e)
        {
            await OsvjeziTabeluAsync();
        }
        private void btn_Kreiraj_Click(object sender, System.EventArgs e)
        {
            if (otvorenaForma != null)
                otvorenaForma.Close();

            TerminiEdit frm_TerminiEdit = new TerminiEdit(0);
            otvorenaForma = frm_TerminiEdit;
            otvorenaForma.FormClosed += OsvjeziTabelu;
            frm_TerminiEdit.ShowDialog();
        }
        private void IzmjenaOdabranogReda()
        {
            if (otvorenaForma != null)
                otvorenaForma.Close();

            TerminiEdit frm_TerminiEdit = new TerminiEdit(int.Parse(dgv_Termini.SelectedRows[0].Cells["Id"].Value.ToString()));
            otvorenaForma = frm_TerminiEdit;
            otvorenaForma.FormClosed += OsvjeziTabelu;
            frm_TerminiEdit.ShowDialog();
        }
        private void btn_Izmijeni_Click(object sender, System.EventArgs e)
        {
            IzmjenaOdabranogReda();
        }

        private void dgv_Termini_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IzmjenaOdabranogReda();
        }
        private async Task ObrisiOdabraniRed()
        {
            var odabraniTerminId = int.Parse(dgv_Termini.SelectedRows[0].Cells["Id"].Value.ToString());
            (bool uspjesno, string responseString) deleteResult = await ApiClient.DeleteAsync($"termini/{odabraniTerminId}");
            if (deleteResult.uspjesno)
            {
                MessageBox.Show("Uspješno obrisan termin.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await OsvjeziTabeluAsync();
                return;
            }
            MessageBox.Show("Neuspješno brisanje termina.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private async void btn_Obrisi_Click(object sender, System.EventArgs e)
        {
            var potvrda = MessageBox.Show("Da li se sigurni da želite obrisati odabran termin.\r\nBrisanjem termina brišete i historiju njegovih podataka.", "BRISANJE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (potvrda == DialogResult.No)
                return;
            await ObrisiOdabraniRed();
        }
    }
}
