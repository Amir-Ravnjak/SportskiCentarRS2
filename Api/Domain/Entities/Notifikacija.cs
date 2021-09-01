
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SportskiCentarRS2.Domain.Entities
{
    public class Notifikacija
    {
        public int Id { get; set; }
        public Korisnik Posiljalac { get; set; }
        public int PosiljalacId { get; set; }
        public Korisnik Primalac { get; set; }
        public int PrimalacId { get; set; }
        public string Poruka { get; set; }
        public bool Procitana { get; set; }
    }
}
