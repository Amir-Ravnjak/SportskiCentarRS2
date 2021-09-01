using AutoMapper;
using SportskiCentarRS2.Application.Common.Mappings;
using SportskiCentarRS2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Korisnici.Queries.GetUserById
{
    public class KorisnikVM : IMapFrom<Korisnik>
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string JMBG { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string KorisnickaUloga { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Korisnik, KorisnikVM>()
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.JMBG, opt => opt.MapFrom(s => s.JMBG.Value));
        }
    }
}
