using SportskiCentarRS2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportskiCentarRS2.Domain.Entities
{
    public class Prostorija : AuditableEntity
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Velicina { get; set; }
        public byte[] Slika { get; set; }
    }
}
