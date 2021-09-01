using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Notifikacije.Queries.GetNeprocitaneNotifikacije
{
    public class GetNeprocitaneNotifikacijeQuery : IRequest<List<NotifikacijaDto>>
    {
    }
    public class GetNeprocitaneNotifikacijeQueryHandler : IRequestHandler<GetNeprocitaneNotifikacijeQuery, List<NotifikacijaDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public GetNeprocitaneNotifikacijeQueryHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }
        public async Task<List<NotifikacijaDto>> Handle(GetNeprocitaneNotifikacijeQuery request, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Notifikacije
                .Where(x => x.PrimalacId == _currentUserService.UserId && !x.Procitana)
                .ProjectTo<NotifikacijaDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }
    }
}
