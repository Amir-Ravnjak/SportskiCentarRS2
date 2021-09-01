using AutoMapper;
using SportskiCentarRS2.Application.Common.Mappings;
using SportskiCentarRS2.Domain.Entities;
using System;

namespace SportskiCentarRS2.Application.Termini.Queries.GetTermineWithPagination
{
    public class TerminDto : IMapFrom<Termin>
    {
        public int Id { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        public bool Slobodan { get; set; }
        public double Cijena { get; set; }
        public string Prostorija { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Termin, TerminDto>()
                .ForMember(x => x.Cijena, opt => opt.MapFrom(s => s.Cijena.Value))
                .ForMember(x => x.Prostorija, opt => opt.MapFrom(s => s.Prostorija.Naziv));
        }
    }
}