using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Korisnici.Queries.GetUserById
{
    public class GetKorisnikByIdQuery : IRequest<KorisnikVM>
    {
        public int Id { get; set; }
    }
    public class GetKorisnikByIdQueryHandler : IRequestHandler<GetKorisnikByIdQuery, KorisnikVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<Korisnik> _userManager;

        public GetKorisnikByIdQueryHandler(IApplicationDbContext context, IMapper mapper, UserManager<Korisnik> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<KorisnikVM> Handle(GetKorisnikByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            var result = _mapper.Map<KorisnikVM>(entity);
            result.KorisnickaUloga = (await _userManager.GetRolesAsync(entity))[0];
            return result;
        }
    }
}
