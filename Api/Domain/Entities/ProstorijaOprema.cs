using SportskiCentarRS2.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportskiCentarRS2.Domain.Entities
{
    public class ProstorijaOprema
    {
        public int Id { get; set; }
        public Prostorija Prostorija { get; set; }
        public int ProstorijaId { get; set; }
        public Oprema Oprema { get; set; }
        public int OpremaId { get; set; }
        public Kolicina Kolicina { get; set; }
    }
}
