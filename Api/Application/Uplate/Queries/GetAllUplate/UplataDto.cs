using AutoMapper;
using SportskiCentarRS2.Application.Common.Mappings;
using SportskiCentarRS2.Domain.Entities;

namespace SportskiCentarRS2.Application.Uplate.Queries.GetAllUplate
{
    public class UplataDto : IMapFrom<Uplata>
    {
        public string Klijent { get; set; }
        public string Prostorija { get; set; }
        public string Termin { get; set; }
        public string Zarada { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Uplata, UplataDto>()
                .ForMember(x => x.Klijent, opt => opt.MapFrom(s => s.Korisnik.Ime + " " + s.Korisnik.Prezime))
                .ForMember(x => x.Prostorija, opt => opt.MapFrom(s => s.Rezervacija.Termin.Prostorija.Naziv))
                .ForMember(x => x.Termin, opt => opt.MapFrom(s => s.Rezervacija.Termin.Pocetak.ToString("dd.MM.yyyy HH:mm") + "-" + s.Rezervacija.Termin.Kraj.ToString("HH:mm")))
                .ForMember(x => x.Zarada, opt => opt.MapFrom(s => s.Rezervacija.Termin.Cijena.Value));
        }
    }
}
