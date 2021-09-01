using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Domain.Entities
{
    public class KorisnickaUloga : IdentityRole<int>
    {
        public KorisnickaUloga()
        {

        }
        public KorisnickaUloga(string roleName) : base(roleName)
        {

        }
    }
}
