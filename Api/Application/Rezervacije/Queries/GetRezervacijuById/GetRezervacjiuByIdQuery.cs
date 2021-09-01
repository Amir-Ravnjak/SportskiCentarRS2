using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Rezervacije.Queries.GetRezervacijuById
{
    public class GetRezervacjiuByIdQuery : IRequest<RezervacijaVM>
    {
        public int Id { get; set; }
    }
    public class GetRezervacijuByIdQueryHandler : IRequestHandler<GetRezervacjiuByIdQuery, RezervacijaVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRezervacijuByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RezervacijaVM> Handle(GetRezervacjiuByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Rezervacije.Where(x => x.Id == request.Id)
                .ProjectTo<RezervacijaVM>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
