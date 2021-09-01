using Newtonsoft.Json;
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
    public partial class KorisnikEdit : Form
    {
        private int _id;
        private KorisnikEditVM korisnik;

        public KorisnikEdit(int id)
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
        private async void KorisnikEdit_Load(object sender, EventArgs e)
        {
            dtp_DatumRodjenja.Format = DateTimePickerFormat.Custom;
            dtp_DatumRodjenja.CustomFormat = " ";
            var korisnickeUloge = new List<string> { "Admin", "Uposlenik", "Klijent" };
            cb_KorisnikaUloga.DataSource = korisnickeUloge;
            if (_id != 0)
            {
                korisnik = await GetUserById(_id);
                if (korisnik.DateOfBirth.HasValue)
                {
                    dtp_DatumRodjenja.Value = (DateTime)korisnik.DateOfBirth;
                    dtp_DatumRodjenja.Format = DateTimePickerFormat.Short;
                }
                tb_Email.Text = korisnik.Email;
                _id = korisnik.Id;
                tb_Ime.Text = korisnik.Ime;
                tb_JMBG.Text = korisnik.JMBG;
                tb_Telefon.Text = korisnik.PhoneNumber;
                tb_Prezime.Text = korisnik.Prezime;
                tb_KorisnickoIme.Text = korisnik.Username;
                cb_KorisnikaUloga.SelectedIndex = korisnickeUloge.IndexOf(korisnik.KorisnickaUloga);
            }
        }
        private async Task<KorisnikEditVM> GetUserById(int id)
        {
            return await ApiClient.GetAsync<KorisnikEditVM>($"users/{id}");
        }

        private void dtp_DatumRodjenja_ValueChanged(object sender, EventArgs e)
        {
            dtp_DatumRodjenja.Format = DateTimePickerFormat.Short;
        }

        private void dtp_DatumRodjenja_Enter(object sender, EventArgs e)
        {
            dtp_DatumRodjenja.Format = DateTimePickerFormat.Short;
        }

        private async void btn_Snimi_Click(object sender, EventArgs e)
        {
            List<string> errors = new List<string>();
            if (string.IsNullOrEmpty(tb_KorisnickoIme.Text))
                errors.Add("Niste unijeli korisniško ime.");
            if (string.IsNullOrEmpty(tb_Lozinka.Text))
                errors.Add("Niste unijeli lozinku.");
            if (tb_Lozinka.Text != tb_LozinkaPotvrda.Text)
                errors.Add("Lozinka i potvrda lozinke nisu jednake.");
            if (errors.Any())
            {
                MessageBox.Show(string.Join("\r\n", errors), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                

            korisnik = new KorisnikEditVM
            {
                ConfirmPassword = tb_LozinkaPotvrda.Text,
                DateOfBirth = dtp_DatumRodjenja.Value == new DateTime(1900, 1, 1) ? (DateTime?)null : dtp_DatumRodjenja.Value,
                Email = tb_Email.Text,
                Id = _id,
                Ime = tb_Ime.Text,
                JMBG = tb_JMBG.Text,
                Password = tb_Lozinka.Text,
                PhoneNumber = tb_Telefon.Text,
                Prezime = tb_Prezime.Text,
                Username = tb_KorisnickoIme.Text,
                KorisnickaUloga = (string)cb_KorisnikaUloga.SelectedValue
            };
            if (korisnik.Id == 0)
            {
                (bool uspjesno,string responseString) createResult = await ApiClient.PostAsync("users", korisnik);
                if (createResult.uspjesno)
                {
                    MessageBox.Show("Uspješno kreiran korisnik.","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }
                //MessageBox.Show("Neuspješno snimanje korisnika.");
                return;
            }

            (bool uspjesno, string responseString) updateResult = await ApiClient.PutAsync($"users/{korisnik.Id}", korisnik);
            if (updateResult.uspjesno)
            {
                MessageBox.Show("Uspješno ažuriran korisnik.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }
            
            //MessageBox.Show("Neuspješno snimanje korisnika.");
        }
    }
}
