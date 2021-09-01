using AutoMapper;
using SportskiCentarRS2.Application.Common.Mappings;
using SportskiCentarRS2.Domain.Entities;
using System;

namespace SportskiCentarRS2.Application.Rezervacije.Queries.GetRezervacijuById
{
    public class RezervacijaVM : IMapFrom<Rezervacija>
    {
        public int Id { get; set; }
        public string Klijent { get; set; }
        public string Prostorija { get; set; }
        public string Termin { get; set; }
        public double Cijena { get; set; }
        public bool Odobrena { get; set; }
        public bool Uplaceno { get; set; }
        public bool Ocijenjena { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Rezervacija, RezervacijaVM>()
                .ForMember(x => x.Klijent, opt => opt.MapFrom(s => s.Korisnik.UserName))
                .ForMember(x => x.Prostorija, opt => opt.MapFrom(s => s.Termin.Prostorija.Naziv))
                .ForMember(x => x.Termin, opt => opt.MapFrom(s => s.Termin.Pocetak.ToString("dd.MM.yyyy HH:mm") + "-" + s.Termin.Kraj.ToString("HH:mm")))
                .ForMember(x => x.Cijena, opt => opt.MapFrom(s => s.Termin.Cijena.Value))
                .ForMember(x => x.Uplaceno, opt => opt.MapFrom(s => s.Uplata != null))
                .ForMember(x => x.Ocijenjena, opt => opt.MapFrom(s => s.Ocjena != null));

        }
    }
}