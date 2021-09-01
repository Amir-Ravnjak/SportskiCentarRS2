using Newtonsoft.Json;
using SportskiCentarRS2.WinForm.Helpers;
using SportskiCentarRS2.WinForm.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportskiCentarRS2.WinForm.Forme.Uposlenik
{
    public partial class RezervacijeDetalji : Form
    {
        private int _id;
        private RezervacijaVM rezervacija;
        public RezervacijeDetalji(int id)
        {
            InitializeComponent();
            _id = id;
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

        private async void RezervacijeDetalji_Load(object sender, EventArgs e)
        {
            rezervacija = await ApiClient.GetAsync<RezervacijaVM>($"rezervacije/{_id}");
            lbl_Cijena.Text = rezervacija.Cijena.ToString();
            lbl_Klijent.Text = rezervacija.Klijent;
            lbl_Prostorija.Text = rezervacija.Prostorija;
            lbl_Termin.Text = rezervacija.Termin;
            cb_Uplaceno.Checked = rezervacija.Uplaceno;
            cb_Uplaceno.Enabled = false;
            btn_Odobri.Enabled = !rezervacija.Odobrena;
            btn_Odobri.Visible = !rezervacija.Odobrena;

            cb_Odobreno.Checked = rezervacija.Odobrena;
            cb_Odobreno.Enabled = rezervacija.Odobrena;
            cb_Odobreno.Visible = rezervacija.Odobrena;
        }

        private async void btn_Odobri_Click(object sender, EventArgs e)
        {
            rezervacija.Odobrena = true;
            (bool uspjesno, string responseString) updateResult = await ApiClient.PutAsync($"rezervacije/{_id}", rezervacija);
            if (updateResult.uspjesno)
            {
                MessageBox.Show("Uspješno odobrena rezervacija.");
                this.Close();
            }                
        }

        private void btn_Nazad_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
