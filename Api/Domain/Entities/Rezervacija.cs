using SportskiCentarRS2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportskiCentarRS2.Domain.Entities
{
    public class Rezervacija : AuditableEntity
    {
        public int Id { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public Korisnik Korisnik { get; set; }
        public int KorisnikId { get; set; }
        public Termin Termin { get; set; }
        public int TerminId { get; set; }
        public bool Odobrena { get; set; }
        public Ocjena Ocjena { get; set; }
        public Uplata Uplata { get; set; }
    }
}
