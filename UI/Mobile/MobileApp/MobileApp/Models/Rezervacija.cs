namespace SportskiCentarRS2.MobileApp.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }
        public string Klijent { get; set; }
        public string Prostorija { get; set; }
        public string Termin { get; set; }
        public double Cijena { get; set; }
        public bool Odobrena { get; set; }
        public bool Uplaceno { get; set; }
        public bool Ocijenjena { get; set; }
        public string CijenaString { get => Cijena + " KM"; }
        public string OdobrenaString { get => Odobrena ? "Odobrena" : "Nije odobrena"; }
        public string UplacenoString { get => Uplaceno ? "Uplaćeno" : "Nije uplaćeno"; }
    }
}
