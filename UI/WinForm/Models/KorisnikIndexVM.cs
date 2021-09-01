using System.ComponentModel;
using System.Windows.Forms;

namespace SportskiCentarRS2.WinForm.Models
{
    public class KorisnikIndexVM
    {
        public int Id { get; set; }
        [DisplayName("Korisničko ime")]
        public string KorisnickoIme { get; set; }
        [DisplayName("Ime i prezime")]
        public string ImePrezime { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        public string KorisnickaUloga { get; set; }
    }
}
