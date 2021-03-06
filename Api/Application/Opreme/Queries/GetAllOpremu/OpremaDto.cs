using AutoMapper;
using SportskiCentarRS2.Application.Common.Mappings;
using SportskiCentarRS2.Domain.Entities;

namespace SportskiCentarRS2.Application.Opreme.Queries.GetAllOpremu
{
    public class OpremaDto : IMapFrom<Oprema>
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int Zauzeto { get; set; }
        public int NaStanju { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Oprema, OpremaDto>()
                .ForMember(d => d.NaStanju, opt => opt.MapFrom(s => s.NaStanju.Value));
        }
    }
}