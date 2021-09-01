using AutoMapper;
using SportskiCentarRS2.Application.Common.Mappings;
using SportskiCentarRS2.Domain.Entities;

namespace SportskiCentarRS2.Application.Notifikacije.Queries.GetNeprocitaneNotifikacije
{
    public class NotifikacijaDto : IMapFrom<Notifikacija>
    {
        public int Id { get; set; }
        public string Posiljalac { get; set; }
        public string Poruka { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Notifikacija, NotifikacijaDto>()
                .ForMember(x => x.Posiljalac, opt => opt.MapFrom(s => s.Posiljalac.Ime + " " + s.Posiljalac.Prezime));
        }
    }
}