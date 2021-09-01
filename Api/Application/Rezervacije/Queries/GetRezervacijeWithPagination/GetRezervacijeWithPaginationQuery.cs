using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Application.Common.Mappings;
using SportskiCentarRS2.Application.HelperModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Rezervacije.Queries.GetRezervacijeWithPagination
{
    public class GetRezervacijeWithPaginationQuery : RezervacijeQueryModel, IRequest<PaginatedList<RezervacijaDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string OrderBy { get; set; } = "Id";
        public bool Ascending { get; set; } = true;
    }
    public class GetRezervacijeWithPaginationQueryHandler : IRequestHandler<GetRezervacijeWithPaginationQuery, PaginatedList<RezervacijaDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRezervacijeWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginatedList<RezervacijaDto>> Handle(GetRezervacijeWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var rezervacijeQuery = _context.Rezervacije.AsQueryable();
            

            if (request.Ascending)
                rezervacijeQuery.OrderBy(x => EF.Property<object>(x, request.OrderBy));
            else
                rezervacijeQuery.OrderByDescending(x => EF.Property<object>(x, request.OrderBy));
            var korisnici = await rezervacijeQuery.ProjectTo<RezervacijaDto>(_mapper.ConfigurationProvider, cancellationToken).PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);

            return korisnici;
        }
    }
}
