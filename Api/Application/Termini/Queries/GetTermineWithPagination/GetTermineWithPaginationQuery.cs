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

namespace SportskiCentarRS2.Application.Termini.Queries.GetTermineWithPagination
{
    public class GetTermineWithPaginationQuery : TerminiQueryModel, IRequest<PaginatedList<TerminDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 30;
        public string OrderBy { get; set; } = "Id";
        public bool Ascending { get; set; } = true;
    }
    public class GetTermineWithPaginationQueryHandler : IRequestHandler<GetTermineWithPaginationQuery, PaginatedList<TerminDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTermineWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<TerminDto>> Handle(GetTermineWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var terminiQuery = _context.Termini.AsQueryable();
            if (request.DatumOd.HasValue)
                terminiQuery = terminiQuery.Where(x => x.Pocetak >= request.DatumOd);
            if (request.DatumDo.HasValue)
                terminiQuery = terminiQuery.Where(x => x.Pocetak <= request.DatumDo);
            if (request.Slobodan.HasValue)
                terminiQuery = terminiQuery.Where(x => x.Slobodan == request.Slobodan);
            if (request.ProstorijaId.HasValue)
                terminiQuery = terminiQuery.Where(x => x.ProstorijaId == request.ProstorijaId);

            if (request.Ascending)
                terminiQuery.OrderBy(x => EF.Property<object>(x, request.OrderBy));
            else
                terminiQuery.OrderByDescending(x => EF.Property<object>(x, request.OrderBy));

            var termini = await terminiQuery.ProjectTo<TerminDto>(_mapper.ConfigurationProvider).PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
            return termini;
        }
    }
}
