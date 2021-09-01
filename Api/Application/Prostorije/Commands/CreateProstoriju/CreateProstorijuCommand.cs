using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Application.Opreme.Queries.GetAllOpremu;
using SportskiCentarRS2.Domain.Entities;
using SportskiCentarRS2.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Prostorije.Commands.CreateProstoriju
{
    public class CreateProstorijuCommand : IRequest<int>
    {
        public string Naziv { get; set; }
        public string Velicina { get; set; }
        public byte[] Slika { get; set; }
        public List<OpremaDto> Oprema { get; set; }
    }
    public class CreateProstorijuCommandHandler : IRequestHandler<CreateProstorijuCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateProstorijuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateProstorijuCommand request, CancellationToken cancellationToken)
        {
            var prostorija = new Prostorija
            {
                Naziv = request.Naziv,
                Velicina = request.Velicina,
                Slika = request.Slika
            };
            await _context.Prostorije.AddAsync(prostorija);
            await _context.SaveChangesAsync(cancellationToken);

            if(request.Oprema!=null && request.Oprema.Count > 0)
            {
                var opremeIds = request.Oprema.Select(x => x.Id).ToList();
                var postojeceOpreme = await _context.Oprema.Where(x => opremeIds.Contains(x.Id)).ToListAsync(cancellationToken);
                foreach (var oprema in request.Oprema)
                {
                    var postojecaOprema = postojeceOpreme.Where(x => x.Id == oprema.Id).FirstOrDefault();
                    postojecaOprema.NaStanju = Kolicina.From(postojecaOprema.NaStanju.Value - oprema.NaStanju);
                    await _context.ProstoroijeOpreme
                        .AddAsync(new ProstorijaOprema
                        {
                            OpremaId = oprema.Id,
                            ProstorijaId = prostorija.Id,
                            Kolicina = Kolicina.From(oprema.NaStanju)
                        });
                }
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return prostorija.Id;
        }
    }
}
