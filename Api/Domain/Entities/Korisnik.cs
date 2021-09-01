using Microsoft.AspNetCore.Identity;
using SportskiCentarRS2.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace SportskiCentarRS2.Domain.Entities
{
    public class Korisnik : IdentityUser<int>
    {        
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public JMBG JMBG { get; set; }        
    }
}
