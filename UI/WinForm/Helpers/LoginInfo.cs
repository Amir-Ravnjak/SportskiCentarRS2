namespace SportskiCentarRS2.WinForm.Helperi
{
    public static class LoginInfo
    {
        public static int KorisnikId { get; set; }
        public static string KorisnickoIme { get; set; }
        public static string KorisnickaUloga { get; set; }
        public static string Lozinka { get; set; }

        public static void UpdateLoginInfo(int korisnikId, string korisnickoIme, string lozinka, string korisnickaUloga)
        {
            KorisnikId = korisnikId;
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            KorisnickaUloga = korisnickaUloga;
        }
    }
}
