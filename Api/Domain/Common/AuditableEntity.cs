using SportskiCentarRS2.Domain.Entities;
using System;

namespace SportskiCentarRS2.Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime KreiranoDatumVrijeme { get; set; }
        public Korisnik KreoiraoKorisnik { get; set; }
        public int KreoiraoKorisnikId { get; set; }

        public DateTime? IzmijenjenoDatumVrijeme { get; set; }
        public Korisnik ZadnjiIzmijenioKorisnik { get; set; }

        public int? ZadnjiIzmijenioKorisnikId { get; set; }
    }
}
