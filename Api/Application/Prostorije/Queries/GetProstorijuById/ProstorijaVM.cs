using AutoMapper;
using SportskiCentarRS2.Application.Common.Mappings;
using SportskiCentarRS2.Application.Opreme.Queries.GetAllOpremu;
using SportskiCentarRS2.Domain.Entities;
using System.Collections.Generic;

namespace SportskiCentarRS2.Application.Prostorije.Queries.GetProstorijuById
{
    public class ProstorijaVM : IMapFrom<Prostorija>
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Velicina { get; set; }
        public byte[] Slika { get; set; }
        public double ProsjecnaOcjena { get; set; }
        public List<OpremaDto> Oprema { get; set; }
    }
}