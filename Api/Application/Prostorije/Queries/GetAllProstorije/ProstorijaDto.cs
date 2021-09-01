using SportskiCentarRS2.Application.Common.Mappings;
using SportskiCentarRS2.Domain.Entities;

namespace SportskiCentarRS2.Application.Prostorije.Queries.GetAllProstorije
{
    public class ProstorijaDto : IMapFrom<Prostorija>
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Velicina { get; set; }
        public byte[] Slika { get; set; }
    }
}
