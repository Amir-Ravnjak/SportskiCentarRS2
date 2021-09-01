using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Prostorije.Queries.GetAllProstorije
{
    public class GetAllProstorijeQuery : IRequest<List<ProstorijaDto>>
    {
    }
    public class GetAllProstorijeQueryHandler : IRequestHandler<GetAllProstorijeQuery, List<ProstorijaDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProstorijeQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProstorijaDto>> Handle(GetAllProstorijeQuery request, CancellationToken cancellationToken)
        {
            return await _context.Prostorije.Select(x=>_mapper.Map<ProstorijaDto>(x)).ToListAsync(cancellationToken);
        }
    }
}
