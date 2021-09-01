using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Opreme.Queries.GetAllOpremu
{
    public class GetAllOpremuQuery : IRequest<List<OpremaDto>>
    {
    }
    public class GetAllOpremuQueryHandler : IRequestHandler<GetAllOpremuQuery, List<OpremaDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllOpremuQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<OpremaDto>> Handle(GetAllOpremuQuery request, CancellationToken cancellationToken)
        {
            var oprema = await _context.Oprema.Select(x => _mapper.Map<OpremaDto>(x)).ToListAsync(cancellationToken);
            var opremaZauzetaKolocinaIId = _context.ProstoroijeOpreme.AsEnumerable().GroupBy(x => x.OpremaId, x=>x.Kolicina.Value);
            foreach (var zauzetaKolicina in opremaZauzetaKolocinaIId)
            {
                oprema.Where(x => x.Id == zauzetaKolicina.Key).FirstOrDefault().Zauzeto = zauzetaKolicina.Sum();
            }
            return oprema;
        }
    }
}
