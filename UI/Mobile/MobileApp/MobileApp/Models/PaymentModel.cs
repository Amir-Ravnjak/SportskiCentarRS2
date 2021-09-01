namespace SportskiCentarRS2.MobileApp.Models
{
    public class PaymentModel
    {
        public string Token { get; set; }
        public long Amount { get; set; }
        public string Description { get; set; }
        public int KorisnikId { get; set; }
        public int RezervacijaId { get; set; }
    }
}
