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

namespace SportskiCentarRS2.WinForm.Forme.Uposlenik
{
    public partial class Rezervacije : Form
    {
        private Form otvorenaForma = null;
        public Rezervacije()
        {
            InitializeComponent();
        }

        private void dgv_Rezervacije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OtvoriDetaljeOdabraneRezervacije();
        }

        private void btn_Detalji_Click(object sender, EventArgs e)
        {
            OtvoriDetaljeOdabraneRezervacije();
        }
        private void OtvoriDetaljeOdabraneRezervacije()
        {
            if (otvorenaForma != null)
                otvorenaForma.Close();

            RezervacijeDetalji frm_RezervacijeEdit = new RezervacijeDetalji(int.Parse(dgv_Rezervacije.SelectedRows[0].Cells["Id"].Value.ToString()));
            otvorenaForma = frm_RezervacijeEdit;
            otvorenaForma.FormClosed += OsvjeziTabelu;
            frm_RezervacijeEdit.ShowDialog();
        }
        private async Task OsvjeziTabeluAsync()
        {
            PaginatedList<RezervacijaVM> rezervacijePaginated = await ApiClient.GetAsync<PaginatedList<RezervacijaVM>>($"rezervacije?PageNumber={(int)nud_TrenutnaStranica.Value}");
            if (rezervacijePaginated == null)
            {
                nud_TrenutnaStranica.Visible = false;
                btn_Sljedeca.Visible = false;
                btn_Prethodna.Visible = false;
                return;
            }
            if (rezervacijePaginated.TotalPages == 1)
                nud_TrenutnaStranica.Visible = false;
            nud_TrenutnaStranica.Value = rezervacijePaginated.PageIndex;
            nud_TrenutnaStranica.Minimum = 1;

            nud_TrenutnaStranica.Maximum = rezervacijePaginated.TotalPages;
            btn_Prethodna.Visible = rezervacijePaginated.HasPreviousPage;
            btn_Sljedeca.Visible = rezervacijePaginated.HasNextPage;

            dgv_Rezervacije.DataSource = rezervacijePaginated.Items;
            dgv_Rezervacije.Columns["Id"].Visible = false;
        }
        private async void OsvjeziTabelu(object sender, FormClosedEventArgs e)
        {
            await OsvjeziTabeluAsync();
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

        private async void Rezervacije_Load(object sender, EventArgs e)
        {
            await OsvjeziTabeluAsync();
        }
    }
}
