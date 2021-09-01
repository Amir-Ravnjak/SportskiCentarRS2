using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Opreme.Queries.GetOpremuById
{
    public class GetOpremuByIdQuery : IRequest<OpremaVM>
    {
        public int Id { get; set; }
    }
    public class GetOpremuByIdQueryHandler : IRequestHandler<GetOpremuByIdQuery, OpremaVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOpremuByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OpremaVM> Handle(GetOpremuByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Oprema.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            var result = _mapper.Map<OpremaVM>(entity);
            result.Zauzeto = await _context.ProstoroijeOpreme.Where(x => x.OpremaId == entity.Id).SumAsync(x => x.Kolicina.Value, cancellationToken);
            return result;
        }
    }
}
