using AutoMapper;
using SportskiCentarRS2.Application.Common.Mappings;
using SportskiCentarRS2.Domain.Entities;
using System;

namespace SportskiCentarRS2.Application.Korisnici.Queries.GetKorisniciWithPagination
{
    public class KorisnikDto : IMapFrom<Korisnik>
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string ImePrezime { get; set; }
        public string DatumRodjenja { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string KorisnickaUloga { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Korisnik, KorisnikDto>()
                .ForMember(d => d.KorisnickoIme, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d=>d.ImePrezime, opt => opt.MapFrom(s=>s.Ime+" "+s.Prezime))
                .ForMember(d => d.DatumRodjenja, opt => opt.MapFrom(s => s.DatumRodjenja != null ? ((DateTime)s.DatumRodjenja).ToString("dd.MM.yyyy") : null))
                .ForMember(d=>d.Telefon,opt=>opt.MapFrom(s=>s.PhoneNumber));
        }
    }
}
