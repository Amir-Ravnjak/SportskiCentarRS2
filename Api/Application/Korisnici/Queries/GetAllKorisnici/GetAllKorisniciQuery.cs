using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Application.Common.Mappings;
using SportskiCentarRS2.Application.Korisnici.Queries.GetKorisniciWithPagination;
using SportskiCentarRS2.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Korisnici.Queries.GetAllKorisnici
{
    public class GetAllKorisniciQuery : KorisniciQueryModel, IRequest<List<KorisnikDto>>
    {
    }
    public class GetAllKorisniciQueryHandler : IRequestHandler<GetAllKorisniciQuery, List<KorisnikDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllKorisniciQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<KorisnikDto>> Handle(GetAllKorisniciQuery request, CancellationToken cancellationToken)
        {
            var korisniciQuery = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(request.Username))
                korisniciQuery = korisniciQuery.Where(x => x.UserName == request.Username);
            if (!string.IsNullOrEmpty(request.JMBG))
                korisniciQuery = korisniciQuery.Where(x => x.JMBG == JMBG.From(request.JMBG));
            if (!string.IsNullOrEmpty(request.Email))
                korisniciQuery = korisniciQuery.Where(x => x.Email == request.Email);

            var korisnici = await korisniciQuery.ProjectToListAsync<KorisnikDto>(_mapper.ConfigurationProvider, cancellationToken);

            var korisnickeUloge = await _context.Roles.ToListAsync();
            var korisnikeUlogeKorisnika = await _context.UserRoles.ToListAsync();
            foreach (var k in korisnici)
            {
                var korisnickaUlogaKorisnikaId = korisnikeUlogeKorisnika.Where(x => x.UserId == k.Id).FirstOrDefault()?.RoleId;
                if (korisnickaUlogaKorisnikaId.HasValue)
                    k.KorisnickaUloga = korisnickeUloge.Where(w => w.Id == korisnickaUlogaKorisnikaId).FirstOrDefault().Name;
            }
            if (!string.IsNullOrEmpty(request.KorisnickaUloga))
                korisnici = korisnici.Where(x => x.KorisnickaUloga == request.KorisnickaUloga).ToList();
            return korisnici;
        }
    }
}
