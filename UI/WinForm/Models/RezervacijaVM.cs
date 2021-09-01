using System;

namespace SportskiCentarRS2.WinForm.Models
{
    public class RezervacijaVM
    {
        public int Id { get; set; }
        public string Klijent { get; set; }
        public string Prostorija { get; set; }
        public string Termin { get; set; }
        public double Cijena { get; set; }
        public bool Odobrena { get; set; }
        public bool Uplaceno { get; set; }
    }
}
