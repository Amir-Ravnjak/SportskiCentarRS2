using MediatR;
using Microsoft.AspNetCore.Identity;
using SportskiCentarRS2.Application.Common.Exceptions;
using SportskiCentarRS2.Domain.Entities;
using SportskiCentarRS2.Domain.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Korisnici.Commands.CreateKorisnik
{
    public class CreateKorisnikCommand : IRequest<int>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string JMBG { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickaUloga { get; set; }
    }
    public class CreateKorisnikCommandHandler : IRequestHandler<CreateKorisnikCommand, int>
    {
        private readonly UserManager<Korisnik> _userManager;
        private readonly RoleManager<KorisnickaUloga> _roleManager;

        public CreateKorisnikCommandHandler(UserManager<Korisnik> userManager,RoleManager<KorisnickaUloga> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<int> Handle(CreateKorisnikCommand request, CancellationToken cancellationToken)
        {
            if (!(await _roleManager.RoleExistsAsync(request.KorisnickaUloga)))
                throw new NotFoundException(nameof(KorisnickaUloga), request.KorisnickaUloga);
            Korisnik k = new Korisnik
            {
                DatumRodjenja = request.DateOfBirth,
                Email = request.Email,
                Ime = request.Ime,
                Prezime = request.Prezime,
                JMBG = JMBG.From(request.JMBG),
                UserName = request.Username
            };
            var result = await _userManager.CreateAsync(k, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(k, request.KorisnickaUloga);
                return k.Id;
            }
                
            return 0;
        }
    }
}
