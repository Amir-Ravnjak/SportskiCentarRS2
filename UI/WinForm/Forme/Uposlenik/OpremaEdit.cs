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
    public partial class OpremaEdit : Form
    {
        private int _id;

        public OpremaEdit(int id)
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

        private async void OpremaEdit_Load(object sender, EventArgs e)
        {
            if (_id == 0)
                return;
            var opremaVM = await ApiClient.GetAsync<OpremaVM>($"oprema/{_id}");
            tb_Naziv.Text = opremaVM.Naziv;
            nud_NaStanju.Value = opremaVM.NaStanju;

        }
        private async void btn_Snimi_Click(object sender, EventArgs e)
        {
            var oprema = new OpremaVM
            {
                Id = _id,
                NaStanju = (int)nud_NaStanju.Value,
                Naziv = tb_Naziv.Text
            };
            if (_id == 0)
            {
                (bool uspjesno, string responseString) createResult = await ApiClient.PostAsync("oprema", oprema);
                if (createResult.uspjesno)
                {
                    MessageBox.Show("Uspješno dodana oprema.");
                    this.Close();
                }                    
                //else
                //    MessageBox.Show("Došlo je do greške.\r\nDodavanje opreme nije uspjelo.");
                return;
            }

            (bool uspjesno, string responseString) updateResult = await ApiClient.PutAsync($"oprema/{_id}", oprema);
            if (updateResult.uspjesno)
            {
                MessageBox.Show("Uspješno ažurirana oprema.");
                this.Close();
            }
            //else
            //    MessageBox.Show("Došlo je do greške.\r\nAžuriranje nije uspjelo.");
            return;

        }

    }
}
