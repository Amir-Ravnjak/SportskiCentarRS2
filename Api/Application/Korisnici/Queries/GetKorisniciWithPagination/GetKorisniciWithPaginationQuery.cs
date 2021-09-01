using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Application.Common.Mappings;
using SportskiCentarRS2.Application.HelperModels;
using SportskiCentarRS2.Domain.Entities;
using SportskiCentarRS2.Domain.ValueObjects;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Korisnici.Queries.GetKorisniciWithPagination
{
    public class GetKorisniciWithPaginationQuery : KorisniciQueryModel, IRequest<PaginatedList<KorisnikDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string OrderBy { get; set; } = "Id";
        public bool Ascending { get; set; } = true;
    }
    public class GetKorisniciWithPaginationQueryHandler : IRequestHandler<GetKorisniciWithPaginationQuery, PaginatedList<KorisnikDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetKorisniciWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginatedList<KorisnikDto>> Handle(GetKorisniciWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var korisniciQuery = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(request.Username))
                korisniciQuery = korisniciQuery.Where(x => x.UserName == request.Username);
            if (!string.IsNullOrEmpty(request.JMBG))
                korisniciQuery = korisniciQuery.Where(x => x.JMBG == JMBG.From(request.JMBG));
            if (!string.IsNullOrEmpty(request.Email))
                korisniciQuery = korisniciQuery.Where(x => x.Email == request.Email);
            if (request.Ascending)
                korisniciQuery.OrderBy(x => EF.Property<object>(x, request.OrderBy));
            else
                korisniciQuery.OrderByDescending(x => EF.Property<object>(x, request.OrderBy));
            var korisnici = await korisniciQuery.ProjectTo<KorisnikDto>(_mapper.ConfigurationProvider, cancellationToken).PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);

            var korisnickeUloge = await _context.Roles.ToListAsync(cancellationToken);
            var korisnikeUlogeKorisnika = await _context.UserRoles.ToListAsync(cancellationToken);
            foreach (var k in korisnici.Items)
            {
                var korisnickaUlogaKorisnikaId = korisnikeUlogeKorisnika.Where(x => x.UserId == k.Id).FirstOrDefault()?.RoleId;
                if (korisnickaUlogaKorisnikaId.HasValue)
                    k.KorisnickaUloga = korisnickeUloge.Where(w => w.Id == korisnickaUlogaKorisnikaId).FirstOrDefault().Name;
            }

            if (!string.IsNullOrEmpty(request.KorisnickaUloga))
                korisnici.Items = korisnici.Items.Where(x=>x.KorisnickaUloga == request.KorisnickaUloga).ToList();
            return korisnici;
        }
    }
}
