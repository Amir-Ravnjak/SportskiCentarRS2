using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Uplate.Queries.GetAllUplate
{
    public class GetAllUplateQuery : IRequest<List<UplataDto>>
    {
        public int KorisnikId { get; set; }
        public int ProstorijaId { get; set; }
        public DateTime DatumOd { get; set; } = DateTime.MinValue;
        public DateTime DatumDo { get; set; } = DateTime.MaxValue;
    }
    public class GetAllUplateQueryHandler : IRequestHandler<GetAllUplateQuery, List<UplataDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetAllUplateQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<List<UplataDto>> Handle(GetAllUplateQuery request, CancellationToken cancellationToken)
        {
            var query = _applicationDbContext.Uplate.AsQueryable();
            if (request.KorisnikId != 0)
                query = query.Where(x => x.KorisnikId == request.KorisnikId);
            if (request.ProstorijaId != 0)
                query = query.Where(x => x.Rezervacija.Termin.ProstorijaId == request.ProstorijaId);
            query = query.Where(x => x.DatumUplate >= request.DatumOd && x.DatumUplate <= request.DatumDo);

            return await query.ProjectTo<UplataDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);            
        }
    }
}
