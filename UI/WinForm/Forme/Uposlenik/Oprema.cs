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
    public partial class Oprema : Form
    {
        private Form otvorenaForma = null;
        public Oprema()
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
            List<OpremaVM> oprema = await ApiClient.GetAsync<List<OpremaVM>>("oprema");
            if (oprema == null || oprema.Count == 0)
                return;
            dgv_Oprema.DataSource = oprema;
            dgv_Oprema.Columns["Id"].Visible = false;

        }
        private async void OsvjeziTabelu(object sender, FormClosedEventArgs e)
        {
            await OsvjeziTabeluAsync();
        }
        private async void Oprema_Load(object sender, EventArgs e)
        {
            await OsvjeziTabeluAsync();
        }
        private void btn_Kreiraj_Click(object sender, EventArgs e)
        {
            if (otvorenaForma != null)
                otvorenaForma.Close();

            OpremaEdit frmOpremaEdit = new OpremaEdit(0);
            otvorenaForma = frmOpremaEdit;
            otvorenaForma.FormClosed += OsvjeziTabelu;
            frmOpremaEdit.ShowDialog();
        }

        private void dgv_Oprema_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IzmjenaOdabranogReda();
        }

        private void IzmjenaOdabranogReda()
        {
            if (otvorenaForma != null)
                otvorenaForma.Close();

            OpremaEdit frmOpremaEdit = new OpremaEdit(int.Parse(dgv_Oprema.SelectedRows[0].Cells["Id"].Value.ToString()));
            otvorenaForma = frmOpremaEdit;
            otvorenaForma.FormClosed += OsvjeziTabelu;
            frmOpremaEdit.ShowDialog();
        }

        private void btn_Izmijeni_Click(object sender, EventArgs e)
        {
            IzmjenaOdabranogReda();
        }
        private async Task ObrisiOdabraniRed()
        {
            var odabranaOpremaID = int.Parse(dgv_Oprema.SelectedRows[0].Cells["Id"].Value.ToString());
            (bool uspjesno, string responseString) deleteResult = await ApiClient.DeleteAsync($"oprema/{odabranaOpremaID}");
            if (deleteResult.uspjesno)
            {
                MessageBox.Show("Uspješno obrisana oprema.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await OsvjeziTabeluAsync();
                return;
            }
            MessageBox.Show("Neuspješno brisanje opreme.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private async void btn_Obrisi_ClickAsync(object sender, EventArgs e)
        {
            var potvrda = MessageBox.Show("Da li se sigurni da želite obrisati odabranu opremu.\r\nBrisanjem opreme brišete i historiju njenih podataka.", "BRISANJE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (potvrda == DialogResult.No)
                return;
            await ObrisiOdabraniRed();            
        }
    }
}
