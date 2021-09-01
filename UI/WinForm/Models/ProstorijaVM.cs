using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskiCentarRS2.WinForm.Models
{
    public class ProstorijaVM
    {

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Velicina { get; set; }
        public byte[] Slika { get; set; }
        public List<OpremaVM> Oprema { get; set; }
    }
}
