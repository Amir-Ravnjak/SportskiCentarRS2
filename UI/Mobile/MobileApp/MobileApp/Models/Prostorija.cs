using System.Collections.Generic;

namespace SportskiCentarRS2.MobileApp.Models
{
    public class Prostorija
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Velicina { get; set; }
        public byte[] Slika { get; set; }
        public double ProsjecnaOcjena { get; set; }
        public string ProsjecnaOcjenaString { get => ProsjecnaOcjena == 0 ? "Nema ocjena" : ProsjecnaOcjena.ToString(); }
        public List<Oprema> Oprema { get; set; }
    }
}
