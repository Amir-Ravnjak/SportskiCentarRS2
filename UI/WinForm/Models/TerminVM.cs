using System;

namespace SportskiCentarRS2.WinForm.Models
{
    public class TerminVM
    {
        public int Id { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        public bool Slobodan { get; set; }
        public double Cijena { get; set; }
        public int ProstorijaId { get; set; }
        public string Prostorija { get; set; }

    }
}
