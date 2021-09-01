using SportskiCentarRS2.WinForm.Forme.Admin;
using SportskiCentarRS2.WinForm.Forme.Uposlenik;
using SportskiCentarRS2.WinForm.Helperi;
using SportskiCentarRS2.WinForm.Helpers;
using SportskiCentarRS2.WinForm.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Windows.Forms;

namespace SportskiCentarRS2.WinForm.Forme
{
    public partial class Prijava : Form
    {
        public Prijava()
        {            
            InitializeComponent();

            this.Text = "Prijava korisnika";
        }
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams handleparam = base.CreateParams;
        //        handleparam.ExStyle |= 0x02000000;
        //        return handleparam;
        //    }
        //}
        private async void btn_Prijava_Click(object sender, EventArgs e)
        {
            var korisnickoIme = tb_KorisnickoIme.Text;
            var lozinka = tb_Lozinka.Text;
            var uspjesnaPrijava = await ApiClient.GetAccessTokenForUserAndSetItToHttpClient(korisnickoIme, lozinka);
            if (!uspjesnaPrijava)
            {
                tb_KorisnickoIme.Text = "";
                tb_Lozinka.Text = "";
                tb_KorisnickoIme.Focus();
                return;
            }

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(ApiClient.httpClient.DefaultRequestHeaders.Authorization.Parameter);
            LoginInfo.KorisnickoIme = jwtSecurityToken.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault().Value;
            LoginInfo.KorisnikId = int.Parse(jwtSecurityToken.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
            LoginInfo.KorisnickaUloga = jwtSecurityToken.Claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault().Value;

            

            tb_KorisnickoIme.Text = "";
            tb_KorisnickoIme.Focus();
            tb_Lozinka.Text = "";
            

            switch (LoginInfo.KorisnickaUloga)
            {
                case "Admin":
                    this.Hide();
                    AdminMain formaAdmin = new AdminMain();
                    formaAdmin.Show();
                    formaAdmin.FormClosed += OtvoriFormu;
                    break;
                case "Uposlenik":
                    this.Hide();
                    UposlenikMain formaUposlenik = new UposlenikMain();
                    formaUposlenik.Show();
                    formaUposlenik.FormClosed += OtvoriFormu;
                    break;
                default:
                    MessageBox.Show($"Korisnik {LoginInfo.KorisnickoIme} sa korisničkom ulogom \"{LoginInfo.KorisnickaUloga}\" nema pravo na korištenje ove aplikacije.");
                    ApiClient.httpClient.DefaultRequestHeaders.Authorization = null;
                    break;
            }
        }
        private void OtvoriFormu(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
