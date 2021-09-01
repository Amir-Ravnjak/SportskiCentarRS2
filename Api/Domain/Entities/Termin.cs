using SportskiCentarRS2.Domain.Common;
using SportskiCentarRS2.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportskiCentarRS2.Domain.Entities
{
    public class Termin : AuditableEntity
    {
        public int Id { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        public bool Slobodan { get; set; }
        public Cijena Cijena { get; set; }
        public int ProstorijaId { get; set; }
        public Prostorija Prostorija { get; set; }
    }
}
