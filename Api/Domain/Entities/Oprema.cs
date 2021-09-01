using SportskiCentarRS2.Domain.Common;
using SportskiCentarRS2.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportskiCentarRS2.Domain.Entities
{
    public class Oprema : AuditableEntity
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public Kolicina NaStanju { get; set; }
    }
}
