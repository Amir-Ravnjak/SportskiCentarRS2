using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Termini.Queries.GetTerminById
{
    public class GetTerminByIdQuery : IRequest<TerminVM>
    {
        public int Id { get; set; }
    }
    public class GetTerminByIdQueryHandler : IRequestHandler<GetTerminByIdQuery, TerminVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTerminByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TerminVM> Handle(GetTerminByIdQuery request, CancellationToken cancellationToken)
        {
            
            var entity = await _context.Termini.Where(x => x.Id == request.Id).Include(x=>x.Prostorija).FirstOrDefaultAsync(cancellationToken);
            return _mapper.Map<TerminVM>(entity);
        }
    }
}
