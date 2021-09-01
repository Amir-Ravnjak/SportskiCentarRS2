using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Application.Opreme.Queries.GetAllOpremu;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Prostorije.Queries.GetProstorijuById
{
    public class GetProstorijuByIdQuery : IRequest<ProstorijaVM>
    {
        public int Id { get; set; }
    }
    public class GetProstorijuByIdQueryHandler : IRequestHandler<GetProstorijuByIdQuery, ProstorijaVM>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetProstorijuByIdQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<ProstorijaVM> Handle(GetProstorijuByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _applicationDbContext.Prostorije.Where(x => x.Id == request.Id)
                .ProjectTo<ProstorijaVM>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
            
            result.Oprema = await _applicationDbContext.ProstoroijeOpreme
                .Where(x => x.ProstorijaId == result.Id)
                .Select(x => new OpremaDto
                {
                    Id = x.OpremaId,
                    NaStanju = x.Kolicina.Value,
                    Naziv = x.Oprema.Naziv
                })
                .ToListAsync(cancellationToken);
            var ocjene = await _applicationDbContext.Ocjene
                .Where(x => x.Rezervacija.Termin.ProstorijaId == request.Id)
                .Select(x => x.Vrijednost.Value)
                .ToListAsync(cancellationToken);
            if (ocjene != null && ocjene.Count > 0)
                result.ProsjecnaOcjena = ocjene.Average();
            return result;
        }
    }
}
