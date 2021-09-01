using SportskiCentarRS2.WinForm.Helpers;
using SportskiCentarRS2.WinForm.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SportskiCentarRS2.WinForm.Forme.Uposlenik
{
    public partial class ProstorijeEdit : Form
    {
        private int _id;

        public ProstorijeEdit(int id)
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

        private async void ProstorijeEdit_Load(object sender, EventArgs e)
        {
            var oprema = await ApiClient.GetAsync<List<OpremaVM>>("oprema");
            if(oprema!=null && oprema.Count > 0)
            {
                var position = new Point(10, 10);
                foreach (var o in oprema)
                {
                    var label = new Label();
                    label.AutoSize = true;
                    label.Text = o.Naziv;
                    label.Location = position;
                    var nud = new NumericUpDown();
                    nud.AutoSize = true;
                    nud.Location = new Point(position.X + 150, position.Y);
                    nud.Size = new Size(nud.Height, 20);
                    nud.Maximum = o.NaStanju;
                    nud.Name = o.Id.ToString();
                    position.Y += 20;
                    panel1.Controls.Add(label);
                    panel1.Controls.Add(nud);
                }
            }
            if (_id != 0)
            {
                var prostorija = await ApiClient.GetAsync<ProstorijaVM>($"prostorije/{_id}");
                tb_Naziv.Text = prostorija.Naziv;
                tb_Velicina.Text = prostorija.Velicina;
                if(prostorija.Slika!=null && prostorija.Slika.Length>0)
                    pb_Slika.Image = (Bitmap)((new ImageConverter()).ConvertFrom(prostorija.Slika));
                foreach (var control in panel1.Controls)
                {
                    if (control.GetType() == typeof(NumericUpDown))
                    {
                        var nud = (NumericUpDown)control;
                        var opremaFieldID = int.Parse(nud.Name);
                        var opremaNaProstoriji = prostorija.Oprema.Where(x => x.Id == opremaFieldID).FirstOrDefault();
                        if (opremaNaProstoriji != null)
                        {
                            nud.Value = opremaNaProstoriji.NaStanju;
                            nud.Maximum += opremaNaProstoriji.NaStanju;
                        }
                            
                    }
                }
            }
        }
        private async void btn_Snimi_Click(object sender, EventArgs e)
        {
            /*public string Naziv { get; set; }
        public string Velicina { get; set; }
        public byte[] Slika { get; set; }
        public List<Oprema> Oprema { get; set; }*/
            
            List<OpremaVM> oprema = new List<OpremaVM>();
            foreach (var control in panel1.Controls)
            {
                if (control.GetType() == typeof(NumericUpDown))
                {
                    var nud = (NumericUpDown)control;
                    if (nud.Value > 0)
                        oprema.Add(new OpremaVM { Id = int.Parse(nud.Name), NaStanju = (int)nud.Value });
                }
            }
            var prostorija = new
            {
                Id = _id,
                Naziv = tb_Naziv.Text,
                Velicina = tb_Velicina.Text,
                Slika = (byte[])(new ImageConverter()).ConvertTo(pb_Slika.Image, typeof(byte[])),
                Oprema = oprema
            };
            if (_id == 0)
            {
                (bool uspjesno, string responseString) createResult = await ApiClient.PostAsync("prostorije", prostorija);
                if (createResult.uspjesno)
                {
                    MessageBox.Show("Uspješno dodana prostorija.");
                    this.Close();
                }
                //else
                //    MessageBox.Show("Došlo je do greške.\r\nDodavanje prostorije nije uspjelo.");
                return;
            }
            (bool uspjesno, string responseString) updateResult = await ApiClient.PutAsync($"prostorije/{_id}", prostorija);
            if (updateResult.uspjesno)
            {
                MessageBox.Show("Uspješno ažurirana prostorija.");
                this.Close();
            }
            //else
            //    MessageBox.Show("Došlo je do greške.\r\nAžuriranje nije uspjelo.");
            return;
        }

        private void btn_DodajSliku_Click(object sender, EventArgs e)
        {
            if (ofd_Slika.ShowDialog() == DialogResult.OK)
            {
                pb_Slika.Image = Image.FromFile(ofd_Slika.FileName);
            }
        }

        private void btn_UkloniSliku_Click(object sender, EventArgs e)
        {
            pb_Slika.Image = null;
        }
    }
}
