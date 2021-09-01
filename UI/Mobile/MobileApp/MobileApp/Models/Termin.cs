using System;

namespace SportskiCentarRS2.MobileApp.Models
{
    public class Termin
    {
        public int Id { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        public bool Slobodan { get; set; }
        public double Cijena { get; set; }
        public string Prostorija { get; set; }
        public string CijenaString { get => Cijena + " KM"; }
    }
}
