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
    public partial class TerminiEdit : Form
    {
        private int _id;

        public TerminiEdit(int id)
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

        private async void TerminiEdit_Load(object sender, EventArgs e)
        {
            var prostorije = await ApiClient.GetAsync<List<ProstorijaVM>>("prostorije");
            if (prostorije == null || prostorije.Count==0)
            {
                MessageBox.Show("Ne može se dodati termin ako ne postoji nijedna prostorija.");
                this.Close();
            }

            cb_Prostorija.DataSource = prostorije;
            cb_Prostorija.ValueMember = "Id";
            cb_Prostorija.DisplayMember = "Naziv";


            if (_id == 0)
            {
                dtp_Datum.MinDate = DateTime.Now.Date;
                dtp_Pocetak.MinDate = DateTime.Now.Date.AddHours(DateTime.Now.Hour + 1);
                dtp_Kraj.MinDate = dtp_Pocetak.MinDate.AddHours(1);
                return;
            }            
            var terminVM = await ApiClient.GetAsync<TerminVM>($"termini/{_id}");

            cb_Prostorija.SelectedValue = terminVM.ProstorijaId;
            dtp_Datum.Value = terminVM.Pocetak.Date;
            dtp_Pocetak.Value = terminVM.Pocetak;
            dtp_Kraj.Value = terminVM.Kraj;
            nud_Cijena.Value = (decimal)terminVM.Cijena;

        }
        private async void btn_Snimi_Click(object sender, EventArgs e)
        {
            var termin = new TerminVM
            {
                Id = _id,
                Cijena = (double)nud_Cijena.Value,
                Kraj = dtp_Datum.Value.Date.Add(dtp_Kraj.Value.TimeOfDay),
                Pocetak = dtp_Datum.Value.Date.Add(dtp_Pocetak.Value.TimeOfDay),
                ProstorijaId = ((ProstorijaVM)cb_Prostorija.SelectedItem).Id,
                Slobodan = true                
            };
            if (_id == 0)
            {
                (bool uspjesno, string responseString) createResult = await ApiClient.PostAsync("termini", termin);
                if (createResult.uspjesno)
                {
                    MessageBox.Show("Uspješno dodan termin.");
                    this.Close();
                }                    
                //else
                //    MessageBox.Show($"Došlo je do greške.\r\nDodavanje termina nije uspjelo.\r\n{createResult.responseString}");
                return;
            }

            (bool uspjesno, string responseString) updateResult = await ApiClient.PutAsync($"termini/{_id}", termin);
            if (updateResult.uspjesno)
            {
                MessageBox.Show("Uspješno ažuriran termin.");
                this.Close();
            }
            //else
            //    MessageBox.Show("Došlo je do greške.\r\nAžuriranje nije uspjelo.");
            return;

        }

        private void dtp_Pocetak_Leave(object sender, EventArgs e)
        {
            dtp_Kraj.MinDate = dtp_Pocetak.MinDate.AddHours(1);
            dtp_Kraj.Value = dtp_Pocetak.MinDate.AddHours(1);
        }

        private void dtp_Kraj_Leave(object sender, EventArgs e)
        {
            if (dtp_Pocetak.Value < dtp_Kraj.MinDate.AddHours(-1))
            {
                MessageBox.Show("Termin mora trajati barem 1h.");
                dtp_Kraj.Value = dtp_Pocetak.MinDate.AddHours(1);
            }                
        }
    }
}
