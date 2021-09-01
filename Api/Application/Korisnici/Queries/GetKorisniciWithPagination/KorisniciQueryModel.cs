using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Korisnici.Queries.GetKorisniciWithPagination
{
    public class KorisniciQueryModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string JMBG { get; set; }
        public string KorisnickaUloga { get; set; }
    }
}
