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
    public partial class Izvjestaji : Form
    {
        public Izvjestaji()
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
        private async void Izvjestaji_Load(object sender, EventArgs e)
        {
            List<KorisnikIndexVM> klijenti = await ApiClient.GetAsync<List<KorisnikIndexVM>>("users/all?KorisnickaUloga=Klijent");
            List<ProstorijaVM> prostorije = await ApiClient.GetAsync<List<ProstorijaVM>>("prostorije");
            if (!klijenti.Any() || !prostorije.Any())
            {
                MessageBox.Show("Trenutno nema izvještaja.");
                return;
            }
            klijenti.Add(new KorisnikIndexVM { ImePrezime = "Svi", Id = 0 });
            cb_Klijent.DataSource = klijenti.OrderBy(x=>x.Id).ToList();
            cb_Klijent.DisplayMember = "ImePrezime";
            cb_Klijent.ValueMember = "Id";

            prostorije.Add(new ProstorijaVM { Naziv = "Sve", Id = 0 });
            cb_Prostorija.DataSource = prostorije.OrderBy(x=>x.Id).ToList();
            cb_Prostorija.DisplayMember = "Naziv";
            cb_Prostorija.ValueMember = "Id";

            cb_Klijent.Visible = true;
            cb_Prostorija.Visible = true;
            dtp_DatumOd.Visible = true;
            dtp_DatumDo.Visible = true;

            await OsvjeziTabeluAsync();
        }
        private async Task OsvjeziTabeluAsync()
        {
            var odabraniKlijentId = ((KorisnikIndexVM)cb_Klijent.SelectedItem).Id;
            var odabranaProstorijaId = ((ProstorijaVM)cb_Prostorija.SelectedItem).Id;
            var uplate = await ApiClient.GetAsync<List<UplataVM>>($"uplate?KorisnikId={odabraniKlijentId}&ProstorijaId={odabranaProstorijaId}&DatumOd={dtp_DatumOd.Value:s}&DatumDo={dtp_DatumDo.Value:s}");
            dgv_Izvjestaj.DataSource = uplate;
        }
        private async void btn_Osvjezi_Click(object sender, EventArgs e)
        {
            await OsvjeziTabeluAsync();
        }
    }
}
