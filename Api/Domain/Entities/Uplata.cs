using System;
using System.Collections.Generic;
using System.Text;

namespace SportskiCentarRS2.Domain.Entities
{
    public class Uplata
    {
        public int Id { get; set; }
        public Korisnik Korisnik { get; set; }
        public int KorisnikId { get; set; }
        public Rezervacija Rezervacija { get; set; }
        public int RezervacijaId { get; set; }
        public DateTime DatumUplate { get; set; }
    }
}
