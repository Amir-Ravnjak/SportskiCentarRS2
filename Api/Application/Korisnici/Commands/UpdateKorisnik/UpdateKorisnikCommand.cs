using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SportskiCentarRS2.Application.Common.Exceptions;
using SportskiCentarRS2.Application.Korisnici.Queries.GetKorisniciWithPagination;
using SportskiCentarRS2.Domain.Entities;
using SportskiCentarRS2.Domain.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Korisnici.Commands.UpdateKorisnik
{
    public class UpdateKorisnikCommand : IRequest
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string JMBG { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
    }
    public class UpdateKorisnikCommandHandler : IRequestHandler<UpdateKorisnikCommand>
    {
        private readonly UserManager<Korisnik> _userManager;
        private readonly IMapper _mapper;

        public UpdateKorisnikCommandHandler(UserManager<Korisnik> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(UpdateKorisnikCommand request, CancellationToken cancellationToken)
        {
            Korisnik k = await _userManager.FindByIdAsync(request.Id.ToString());
            if (k == null)
                throw new NotFoundException("Korisnik ne postoji.");
            
            k.DatumRodjenja = request.DateOfBirth;
            k.Email = request.Email;
            k.Ime = request.Ime;
            k.Prezime = request.Prezime;
            k.JMBG = JMBG.From(request.JMBG);
            k.UserName = request.Username;
            

            var result = await _userManager.UpdateAsync(k);
            var passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(k);
            result = await _userManager.ResetPasswordAsync(k, passwordResetToken, request.Password);
            if (result.Succeeded)
                return Unit.Value;
            
            throw new Exception("Neuspješno ažuriranje korisnika.");
        }
    }
}
